﻿using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
    }
}