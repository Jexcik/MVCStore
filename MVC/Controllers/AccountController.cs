﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository usersRepository;
        public AccountController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login user)
        {
            var userAccount = usersRepository.TryGetByName(user.UserName);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем не найден. Проверьте имя или зарегестрируйтесь.");
                return View(user);
            }
            if (userAccount.Password != user.Password)
            {
                ModelState.AddModelError("", "Не верный пароль");
                return View(user);
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return Redirect("~/Home/Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            var userAccount = usersRepository.TryGetByName(register.UserName);
            if (userAccount != null)
            {
                ModelState.AddModelError("","Пользователь с таким именем уже есть.");
                return View(register);
            }
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
                return View(register);
            }
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            usersRepository.Add(new User(register.UserName, register.Password, register.FirstName, register.LastName, register.Phone));
            return Redirect("~/Home/Index");
        }
    }
}
