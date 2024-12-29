using System.ComponentModel.DataAnnotations;

namespace TeacherManagementUI.Dto.LessonDto
{
    public class CreateLessonDto
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string LessonName { get; set; }
        [Required(ErrorMessage = "Sayısal Karakter Giriniz")]
        public int LessonCode { get; set; }
        [Required(ErrorMessage = "Eğitmen Seçiniz")]
        public int TeacherId { get; set; }
    }
}
