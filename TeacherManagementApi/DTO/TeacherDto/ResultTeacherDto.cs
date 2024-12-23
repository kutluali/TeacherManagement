using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.DTO.TeacherDto
{
    public class ResultTeacherDto
    {
        public int TeacherId { get; set; }
        public string TeacherNameSurname { get; set; }
        public string TeacherBranch { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
