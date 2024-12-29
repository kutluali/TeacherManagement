using AutoMapper;
using TeacherManagement.DTO.DTOs.TeacherDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Mapping
{
    public class TeacherMapping:Profile
    {
        public TeacherMapping()
        {
            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher, ResultTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
            
        }
    }
}
