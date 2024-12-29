using System.ComponentModel.DataAnnotations;

namespace TeacherManagementUI.Dto.UserDto
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
