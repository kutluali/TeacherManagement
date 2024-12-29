using TeacherManagementUI.Dto.LessonDto;

namespace TeacherManagementUI.Dto.TeacherDto
{
    public class ResultTeacherDto
    {
        public int TeacherId { get; set; }
        public string TeacherNameSurname { get; set; }
        public string TeacherBranch { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public List<ResultLessonDto> Lessons { get; set; }
    }
}
