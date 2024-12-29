using System.ComponentModel.DataAnnotations;

namespace TeacherManagement.DTO.DTOs.AppUserDtos
{
    public class RegisterDto
    {
        [Required]
        public string NameSurname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }


}
