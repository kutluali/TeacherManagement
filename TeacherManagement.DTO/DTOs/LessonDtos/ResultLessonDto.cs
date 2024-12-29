using TeacherManagement.DTO.DTOs.TeacherDtos;

namespace TeacherManagement.DTO.DTOs.LessonDtos
{
    public class ResultLessonDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int LessonCode { get; set; }
        public int TeacherId { get; set; }
        public ResultTeacherDto Teacher { get; set; }
    }
}
