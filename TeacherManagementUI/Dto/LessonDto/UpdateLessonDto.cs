using System.ComponentModel.DataAnnotations;
using TeacherManagementUI.Dto.TeacherDto;

namespace TeacherManagementUI.Dto.LessonDto
{
    public class UpdateLessonDto
    {
        public int LessonId { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string LessonName { get; set; }
        [Required(ErrorMessage = "Sayısal Karakter Giriniz")]
        public int LessonCode { get; set; }
        [Required(ErrorMessage = "Eğitmen Seçiniz")]
        public int TeacherId { get; set; }
    }
}
