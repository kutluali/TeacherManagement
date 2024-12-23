using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacherManagement.Business.Abstract;
using TeacherManagement.Entity.Entites;
using TeacherManagementApi.DTO.TeacherDto;

namespace TeacherManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TeacherList()
        {
            var values = _teacherService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTeacherDto>>(values));

        }
        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDto createTeacherDto)
        {
            try
            {
                var values = _mapper.Map<Teacher>(createTeacherDto);
                _teacherService.TAdd(values);
                return Ok("Başarılı Bir Şekilde Eklendi");
            }
            catch (Exception ex)
            {
                // Tüm hata türlerini yakalar ve mesajını döner
                return BadRequest(new { Message = "Bir hata oluştu.", Detail = ex.Message });
            }
        }
        [HttpPut]
        public IActionResult UpdateTeacher(UpdateTeacherDto updateTeacherDto)
        {
            try
            {
                var values = _mapper.Map<Teacher>(updateTeacherDto);
                _teacherService.TUpdate(values);
                return Ok("Başarılı Bir Şekilde Güncellendi");
            }
            catch (Exception ex)
            {
                // Tüm hata türlerini yakalar ve mesajını döner
                return BadRequest(new { Message = "Bir hata oluştu.", Detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            try
            {
                var values = _teacherService.TGetById(id);
                _teacherService.TDelete(values);
                return Ok("Başarılı Bir Şekilde Silindi");
            }
            catch (Exception ex)
            {
                // Tüm hata türlerini yakalar ve mesajını döner
                return BadRequest(new { Message = "Bir hata oluştu.", Detail = ex.Message });
            }
        }
    }
}
