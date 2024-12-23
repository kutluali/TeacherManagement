using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacherManagement.Business.Abstract;
using TeacherManagement.Entity.Entites;
using TeacherManagementApi.DTO.LessonDto;

namespace TeacherManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        [HttpGet]   
        public IActionResult LessonList()
        {
            var values = _lessonService.TGetListAll();
            return Ok(_mapper.Map<List<ResultLessonDto>>(values));

        }
        [HttpPost]
        public IActionResult CreateLesson(CreateLessonDto createLessonDto)
        {
            try
            {
                var values = _mapper.Map<Lesson>(createLessonDto);
                _lessonService.TAdd(values);
                return Ok("Başarılı Bir Şekilde Eklendi");
            }
            catch (Exception ex)
            {
                // Tüm hata türlerini yakalar ve mesajını döner
                return BadRequest(new { Message = "Bir hata oluştu.", Detail = ex.Message });
            }
        }
        [HttpPut]
        public IActionResult UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            try
            {
                var values = _mapper.Map<Lesson>(updateLessonDto);
                _lessonService.TUpdate(values);
                return Ok("Başarılı Bir Şekilde Güncellendi");
            }
            catch (Exception ex)
            {
                // Tüm hata türlerini yakalar ve mesajını döner
                return BadRequest(new { Message = "Bir hata oluştu.", Detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            try
            {
                var values = _lessonService.TGetById(id);
                _lessonService.TDelete(values);
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
