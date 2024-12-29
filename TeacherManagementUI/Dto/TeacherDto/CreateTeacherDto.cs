using System.ComponentModel.DataAnnotations;
using TeacherManagementUI.Dto.LessonDto;

namespace TeacherManagementUI.Dto.TeacherDto
{
    public class CreateTeacherDto
    {
        [Required(ErrorMessage = "Eğitmen Adı Soyadı Gereklidir.")]
        public string TeacherNameSurname { get; set; }
        [Required(ErrorMessage = "Branş Bilgisi Giriniz")]
        public string TeacherBranch { get; set; }
        [Required(ErrorMessage = "Telefon Numarası Giriniz")]
        public string TeacherPhone { get; set; }
        [Required(ErrorMessage = "Email Adresi Giriniz")]
        public string TeacherEmail { get; set; }
    }
}
