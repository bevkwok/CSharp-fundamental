using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using login_n_registration.Models;

namespace login_n_registration
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")] 
        public IActionResult Index()
        {
            ViewBag.AllUsers = _context.login_n_registration.ToList();

            return View("index");
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.login_n_registration.Any(au => au.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return Index();
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
            
        }

        [HttpGet("loginPage")]
        public IActionResult LoginPage()
        {
            return View("login");
        }

        [HttpPost("login")]
        public IActionResult Login(User loginUser)
        {
            var userInDb = _context.login_n_registration.FirstOrDefault(lu => lu.Email == loginUser.Email);

            if(userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email");
                return LoginPage();
            }

            var hasher = new PasswordHasher<User>();

            var result =  hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);

            if(result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Password");
                return LoginPage();
            }
            return RedirectToAction("success");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            return View("success");
        }
    }
}