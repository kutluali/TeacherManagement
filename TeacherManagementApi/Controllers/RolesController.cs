using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherManagement.Business.Abstract;
using TeacherManagement.DTO.DTOs.AppUserDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericService<AppRole> _roleService;

        public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IGenericService<AppRole> roleService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleService = roleService;
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = _roleService.TGetListAll();
            return Ok(roles);
        }

        //2.Yol Create
        [HttpPost("CreateRole")]
        public IActionResult CreateRole([FromBody] AppRole role)
        {
            if (role == null || string.IsNullOrEmpty(role.Name))
            {
                return BadRequest("Rol bilgileri geçersiz.");
            }

            _roleService.TAdd(role);
            return Ok("Rol başarıyla oluşturuldu.");
        }

        [HttpPost("CreateRole1")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Rol Adı Boş Olamaz.");
            }

            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (roleExist)
            {
                return BadRequest("Rol Boş.");
            }

            var result = await _roleManager.CreateAsync(new AppRole { Name = roleName });
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Rol Başarıyla Oluşturuldu");
        }

        //İsme Göre  Delete
        [HttpDelete("DeleteRoleName/{roleName}")]
        public async Task<IActionResult> DeleteNameRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound("Rol Bulunamadı");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        //ID ye Göre Delete
        [HttpDelete("DeleteRole/{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleService.TGetById(id);
            if (role == null)
            {
                return NotFound("Rol Bulunamadı");
            }

            var result = _roleManager.DeleteAsync(role);
            if (!result.IsCompleted)
            {
                return BadRequest("Rol Silinemedi");
            }

            return Ok("Rol Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateRole(int id)
        {
            var value =  _roleService.TGetById(id);
            if (value == null)
            {
                return NotFound("Rol Bulunamadı");
            }
            _roleService.TDelete(value);
            return Ok("Rol Başarılı Bir Şekilde Silindi.");
        }


        //2.Yol
        [HttpPut("UpdateRole1/{oldRoleName}")]
        public async Task<IActionResult> UpdateRole(string oldRoleName, string newRoleName)
        {
            var role = await _roleManager.FindByNameAsync(oldRoleName);
            if (role == null)
            {
                return NotFound("Rol Bulunamadı");
            }

            role.Name = newRoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Rol Başarılı Bir Şekilde Güncellendi.");
        }

        

    }

}
