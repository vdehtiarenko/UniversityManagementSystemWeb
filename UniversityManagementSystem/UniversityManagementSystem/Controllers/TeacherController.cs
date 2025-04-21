using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
