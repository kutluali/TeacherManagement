using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.DTO.DTOs.LessonDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DTO.DTOs.TeacherDtos
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
