using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICourseService _courseService;

        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();

            return View(courses);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
