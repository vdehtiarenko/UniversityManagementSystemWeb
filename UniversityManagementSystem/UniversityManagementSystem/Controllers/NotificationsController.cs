using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
