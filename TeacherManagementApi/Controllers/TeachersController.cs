using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacherManagement.Business.Abstract;
using TeacherManagement.DTO.DTOs.TeacherDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController(IGenericService<Teacher>_teacherService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _teacherService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTeacherDto>>(values));

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _teacherService.TGetById(id);
            return Ok(_mapper.Map<ResultTeacherDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _teacherService.TGetById(id);
            _teacherService.TDelete(value);
            return Ok("Başarlı Bir Şekilde Silindi");
        }
        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDto createTeacherDto)
        {
            var value = _mapper.Map<Teacher>(createTeacherDto);
            _teacherService.TAdd(value);
            return Ok("Başarılı Bir Şekilde Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateTeacher(UpdateTeacherDto updateTeacherDto)
        {
            var value = _mapper.Map<Teacher>(updateTeacherDto);
            _teacherService.TUpdate(value);
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
    }
}
