﻿using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
    }
}
