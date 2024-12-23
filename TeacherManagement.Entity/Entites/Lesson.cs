using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherManagement.Entity.Entites
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int LessonCode { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
