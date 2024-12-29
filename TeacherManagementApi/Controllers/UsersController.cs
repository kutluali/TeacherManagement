using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TeacherManagement.Entity.Entites;
using System.Linq;
using System.Threading.Tasks;
using TeacherManagement.DTO.DTOs.AppRoleDtos;
using Microsoft.EntityFrameworkCore;
using TeacherManagement.DTO.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Authorization;

namespace TeacherManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("list-users")]
        public async Task<IActionResult> ListUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                if (users == null || !users.Any())
                {
                    return NotFound(new { message = "No users found." });
                }

                var userList = new List<object>();
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userList.Add(new
                    {
                        userId = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        roles = roles
                    });
                }

                return Ok(userList);
            }
            catch (Exception ex)
            {
                // Log hatası
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("list-roles/{userId}")]
        public async Task<IActionResult> ListRoles(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound(new { message = "Kullanıcı Bulunamadı" });

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        


        // Kullanıcıya rol atama
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return NotFound(new { message = "Kullanıcı bulunamadı." });

            var roleExists = await _roleManager.RoleExistsAsync(request.RoleName);
            if (!roleExists)
                return BadRequest(new { message = "Rol mevcut değil." });

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            if (result.Succeeded)
                return Ok(new { message = $"'{request.RoleName}' rolü '{user.UserName}' kullanıcısına başarıyla atandı." });

            return BadRequest(new { errors = result.Errors });
        }


        // Kullanıcıdan rol kaldırma
        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveRole([FromBody] AssignRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return NotFound(new { message = "Kullanıcı bulunamadı." });

            var roleExists = await _roleManager.RoleExistsAsync(request.RoleName);
            if (!roleExists)
                return BadRequest(new { message = "Rol mevcut değil." });

            var result = await _userManager.RemoveFromRoleAsync(user, request.RoleName);
            if (result.Succeeded)
                return Ok(new { message = $"'{request.RoleName}' Role   '{user.UserName}' Kullanıcıdan Başarıyla Silindi." });

            return BadRequest(new { errors = result.Errors });
        }



        // Kullanıcının rolünü değiştirme
        [HttpPost("change-role")]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return NotFound(new { message = "Kullanıcı Bulunamadı." });

            // Eski rolü kaldır
            var removeResult = await _userManager.RemoveFromRoleAsync(user, request.CurrentRole);
            if (!removeResult.Succeeded)
                return BadRequest(new { message = "Mevcut rol kaldırılamadı." });

            // Yeni rolü ekle
            var addResult = await _userManager.AddToRoleAsync(user, request.NewRole);
            if (!addResult.Succeeded)
                return BadRequest(new { message = "Yeni rol atanamadı." });

            return Ok(new { message = $"Kullanıcı '{user.UserName}' için rol '{request.CurrentRole}'dan '{request.NewRole}'a değiştirildi." });
        }

    }
}
