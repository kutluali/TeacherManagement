using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.DTO.LessonDto
{
    public class UpdateLessonDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int LessonCode { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
