using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using viewModel_fun.Models;

namespace viewModel_fun.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Message one = new Message()
            {
                Messages = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "
            };
            return View("index", one);
        }

        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers()
        {
            int[] num = new int[]
            {
                1,2,3,4,55,66,3
            };

            return View("numbers", num);
        }
        [HttpGet]
        [Route("user")]

        public IActionResult Userss()
        {
            User user1 = new User()
            {
                Firstname = "Moose",
                Lastname = "Phillips"
            };

            return View("user", user1);
        }

        [HttpGet]
        [Route("users")]
        public IActionResult Users()
        {
            List<User> userlist = new List<User>()
            {
                new User() {Firstname = "Moose",Lastname = "Phillips"},
                new User() {Firstname = "Sarah"},
                new User() {Firstname = "Jerry"},
                new User() {Firstname = "Rene", Lastname = "Ricky"},
                new User() {Firstname = "Barbarah"}
            };

            return View("users", userlist);
        }
    }
}