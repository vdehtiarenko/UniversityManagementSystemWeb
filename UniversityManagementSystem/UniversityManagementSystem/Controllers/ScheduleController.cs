using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
