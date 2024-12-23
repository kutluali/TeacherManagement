﻿using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.DTO.LessonDto
{
    public class CreateLessonDto
    {
        public string LessonName { get; set; }
        public int LessonCode { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
