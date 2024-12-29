using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeacherManagement.Business.Abstract;
using TeacherManagement.DTO.DTOs.LessonDtos;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController(ILessonService _lessonService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values=_lessonService.TGetLessonWithTeacher();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _lessonService.TGetById(id);
            return Ok(_mapper.Map<ResultLessonDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _lessonService.TGetById(id);
            _lessonService.TDelete(value);
            return Ok("Başarlı Bir Şekilde Silindi");
        }
        [HttpPost]
        public IActionResult CreateLesson(CreateLessonDto createLessonDto)
        {
            var value = _mapper.Map<Lesson>(createLessonDto);
            _lessonService.TAdd(value);
            return Ok("Başarılı Bir Şekilde Eklendi");  
        }
        [HttpPut]
        public IActionResult UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            var value = _mapper.Map<Lesson>(updateLessonDto);
            _lessonService.TUpdate(value);
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

    }
}
