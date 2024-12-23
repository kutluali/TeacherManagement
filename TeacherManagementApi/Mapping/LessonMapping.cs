using AutoMapper;
using TeacherManagement.Entity.Entites;
using TeacherManagementApi.DTO.LessonDto;

namespace TeacherManagementApi.Mapping
{
    public class LessonMapping:Profile
    {
        public LessonMapping()
        {
            CreateMap<Lesson, ResultLessonDto>().ReverseMap();
            CreateMap<Lesson, CreateLessonDto>().ReverseMap();
            CreateMap<Lesson, GetLessonDto>().ReverseMap();
            CreateMap<Lesson, UpdateLessonDto>().ReverseMap();
        }

    }
}
