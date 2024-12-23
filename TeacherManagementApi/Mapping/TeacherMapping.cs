using AutoMapper;
using TeacherManagement.Entity.Entites;
using TeacherManagementApi.DTO.TeacherDto;

namespace TeacherManagementApi.Mapping
{
    public class TeacherMapping:Profile
    {
        public TeacherMapping()
        {
            CreateMap<Teacher, ResultTeacherDto>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher, GetTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
        }
    }
}
