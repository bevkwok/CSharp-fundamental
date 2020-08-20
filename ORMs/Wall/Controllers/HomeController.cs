using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wall.Models;

namespace Wall
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
            Console.WriteLine(TempData["message"]);
            return View("Index");
        }

        [HttpGet("Logoff")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["OneUser.FirstName"] = "Please login or register before joining any wedding";
            return RedirectToAction("Index");
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return Index();
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                int? theUserId = HttpContext.Session.GetInt32("UserId");
                return RedirectToAction("Wall",new{UserId = theUserId});
            }
            else
            {
                return Index();
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser loginUser)
        {
            User userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);

            if(userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return Index();
            }

            var hasher = new PasswordHasher<User>();

            var result =  hasher.VerifyHashedPassword(userInDb, userInDb.Password, loginUser.LogPassword);

            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return Index();
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            return RedirectToAction("Wall",new{UserId = theUserId});
        }

        [HttpGet("Wall/{UserId}")]
        public IActionResult Wall(int UserId)
        {   
            WallWrapper WMod = new WallWrapper();

            WMod.WallUser = _context.Users
            .Include(u => u.PostedMessage)
            .Include(u => u.RepliedComment)
            .ThenInclude(w => w.User)
            .FirstOrDefault(u => u.UserId == UserId);

            WMod.MessagesList = _context.Messages
            .Include(w => w.MessageCreator)
            .Include(w => w.Comments)
            .ToList();

            return View("Wall", WMod);
        }

        // [HttpPost("Wall/postMessage")]

        // public IActionResult PostMessage()
        // {

        // }
    }
}