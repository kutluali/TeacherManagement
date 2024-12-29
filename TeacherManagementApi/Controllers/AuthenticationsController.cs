using Microsoft.AspNetCore.Mvc;
using TeacherManagement.Business.Abstract;
using TeacherManagementApi.Security;
using Microsoft.AspNetCore.Identity;
using TeacherManagement.Entity.Entites;
using TeacherManagement.DTO.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Authorization;
using TeacherManagement.DTO.DTOs.RefreshTokenDto.TeacherManagement.Dto;

namespace TeacherManagementApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationsController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IConfiguration _configuration;
		private readonly IRefreshTokenService _refreshTokenService;
		private readonly RoleManager<AppRole> _roleManager;

		public AuthenticationsController(UserManager<AppUser> userManager, IConfiguration configuration, IRefreshTokenService refreshTokenService, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_configuration = configuration;
			_refreshTokenService = refreshTokenService;
			_roleManager = roleManager;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
			{
				return Unauthorized(new { Message = "Invalid credentials" });
			}

			var roles = await _userManager.GetRolesAsync(user);

			// TokenHandler üzerinden token oluşturuluyor
			var token = TokenHandler.CreateToken(_configuration, user, roles.ToList());

			// Refresh Token oluşturuluyor
			var refreshToken = await _refreshTokenService.TGenerateRefreshTokenAsync(user);

			return Ok(new { Token = token, RefreshToken = refreshToken });
		}

		[HttpPost("RefreshToken")]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
		{
			var refreshToken = await _refreshTokenService.TGetByTokenAsync(refreshTokenDto.Token);
			if (refreshToken == null || refreshToken.IsRevoked || refreshToken.Expiration < DateTime.Now)
			{
				return Unauthorized(new { Message = "Invalid or expired refresh token" });
			}

			// Refresh token geçerliyse yeni token oluşturuluyor
			var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());
			var roles = await _userManager.GetRolesAsync(user);

			var newToken = TokenHandler.CreateToken(_configuration, user, roles.ToList());
			var newRefreshToken = await _refreshTokenService.TGenerateRefreshTokenAsync(user);

			return Ok(new { Token = newToken, RefreshToken = newRefreshToken });
		}

		[HttpPost("Logout")]
		public async Task<IActionResult> Logout([FromBody] RefreshTokenDto refreshTokenDto)
		{
			// Refresh token geçersiz kılma işlemi
			await _refreshTokenService.TRevokeTokenAsync(refreshTokenDto.Token);

			return Ok(new { Message = "Çıkış Başarılı" });
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			// Kullanıcı email'ini kontrol et
			var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
			if (existingUser != null)
			{
				return BadRequest("Bu e-posta adresi zaten kayıtlı.");
			}

			// Yeni kullanıcı oluştur
			var user = new AppUser
			{
				UserName=registerDto.Email,
                NameSurname = registerDto.NameSurname,
				Email = registerDto.Email,
			};

			// Kullanıcıyı kaydet
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded)
			{
				return BadRequest(result.Errors);
			}

			// "User" rolünü veritabanında kontrol et ve oluşturulmadıysa oluştur
			var roleExist = await _roleManager.RoleExistsAsync("User");
			if (!roleExist)
			{
				var roleResult = await _roleManager.CreateAsync(new AppRole { Name = "User" });
				if (!roleResult.Succeeded)
				{
					return StatusCode(500, new { message = "Rol oluşturulamadı." });
				}
			}

			// Kullanıcıya varsayılan olarak "User" rolünü ata
			await _userManager.AddToRoleAsync(user, "User");

			return Ok("Kullanıcı başarıyla oluşturuldu.");
		}


	}
}
