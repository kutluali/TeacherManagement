using AutoMapper;
using TeacherManagement.DTO.DTOs.LessonDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Mapping
{
    public class LessonMapping : Profile
    {
        public LessonMapping()
        {
            CreateMap<CreateLessonDto, Lesson>().ReverseMap();
            CreateMap<UpdateLessonDto, Lesson>().ReverseMap();
            CreateMap<ResultLessonDto, Lesson>().ReverseMap();
        }
    }
}
