using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.DTO.DTOs.TeacherDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DTO.DTOs.LessonDtos
{
    public class CreateLessonDto
    {
        public string LessonName { get; set; }
        public int LessonCode { get; set; }
        public int TeacherId { get; set; }
    }
}
