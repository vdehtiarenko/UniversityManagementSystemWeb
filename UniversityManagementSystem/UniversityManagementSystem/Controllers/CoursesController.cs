﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CoursesController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
