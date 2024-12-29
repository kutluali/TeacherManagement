using Microsoft.AspNetCore.Mvc;
using TeacherManagementUI.Dto.LessonDto;
using TeacherManagementUI.Dto.TeacherDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeacherManagementUI.Helpers;

namespace LessonManagementUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonController() : Controller
    {
        private readonly HttpClient _client= HttpClientIstance.CreateClient();

		public async Task<IActionResult> Index()
		{
			var value = await _client.GetFromJsonAsync<List<ResultLessonDto>>("Lessons");
			if (value == null || !value.Any())
			{
				ViewBag.ErrorMessage = "Ders listesi alınamadı.";
				return View(new List<ResultLessonDto>()); // Boş liste döndür
			}
			return View(value);
		}
        public async Task<IActionResult> Delete(int id)
		{
            await _client.DeleteAsync("Lessons/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            await TeacherDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLessonDto createLessonDto)
        {
            if (!ModelState.IsValid)
            {

                await TeacherDropDown();
                return View(createLessonDto);
            }
            await _client.PostAsJsonAsync("Teachers", createLessonDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
		{
            if (id <= 0)
            {
                return NotFound("Geçersiz id.");
            }

            await TeacherDropDown();
            var value = await _client.GetFromJsonAsync<UpdateLessonDto>("Lessons/" + id);
            if (value == null)
            {
                return NotFound("Ders bulunamadı.");
            }

            return View(value);
        }

		[HttpPost]
		public async Task<IActionResult> Update(UpdateLessonDto updataLessonDto)
		{
			if (!ModelState.IsValid)
			{
				return View(updataLessonDto);
			}
			await _client.PutAsJsonAsync("Lessons", updataLessonDto);
			return RedirectToAction("Index");
		}

		public async Task TeacherDropDown()
		{
			var teacherList = await _client.GetFromJsonAsync<List<ResultTeacherDto>>("Teachers");
			List<SelectListItem> teacher = (from x in teacherList
											select new SelectListItem
											{
												Text = x.TeacherNameSurname,
												Value=x.TeacherId.ToString()
											}).ToList();
			ViewBag.teacher = teacher;
		}
	}
}
