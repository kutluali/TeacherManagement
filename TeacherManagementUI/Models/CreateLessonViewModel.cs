using Microsoft.AspNetCore.Mvc.Rendering;
using TeacherManagementUI.Dto.LessonDto;

namespace TeacherManagementUI.Models
{
    public class CreateLessonViewModel
    {
        public CreateLessonDto Lesson { get; set; }
        public List<SelectListItem> Teachers { get; set; }
    }

}
