﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
