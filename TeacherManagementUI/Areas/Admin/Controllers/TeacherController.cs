using Microsoft.AspNetCore.Mvc;
using TeacherManagementUI.Dto.TeacherDto;
using TeacherManagementUI.Helpers;

namespace TeacherManagementUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeacherController : Controller
	{
		private readonly HttpClient _client = HttpClientIstance.CreateClient();

		public async Task<IActionResult> Index()
		{
			var value = await _client.GetFromJsonAsync<List<ResultTeacherDto>>("Teachers");
			if (value == null || !value.Any())
			{
				ViewBag.ErrorMessage = "Ders listesi alınamadı.";
				return View(new List<ResultTeacherDto>()); // Boş liste döndür
			}
			return View(value);
		}

        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateTeacherDto createTeacherDto)
		{
			if (ModelState.IsValid)
			{
                await _client.PostAsJsonAsync("Teachers", createTeacherDto);
                return RedirectToAction("Index");
			}

            return View(createTeacherDto);
        }

		public async Task<IActionResult> Update(int id)
		{
			var value = await _client.GetFromJsonAsync<UpdateTeacherDto>("Teachers/" + id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateTeacherDto updataTeacherDto)
		{
			if (!ModelState.IsValid)
			{
				return View(updataTeacherDto);
			}
			await _client.PutAsJsonAsync("Teachers", updataTeacherDto);
			return RedirectToAction("Index");
		}

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("Teachers/" + id);
            return RedirectToAction("Index");
        }
    }
}
