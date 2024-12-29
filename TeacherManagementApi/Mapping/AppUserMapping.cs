using AutoMapper;
using TeacherManagement.DTO.DTOs.AppUserDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Mapping
{
    public class AppUserMapping : Profile
    {
        protected AppUserMapping()
        {

            CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.NameSurname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
