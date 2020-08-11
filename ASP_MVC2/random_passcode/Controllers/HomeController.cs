using System;
// using System.Web.Security;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace random_passcode.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            ViewBag.Pc = HttpContext.Session.GetString("Pc");
            // ViewBag.Password = Membership.GeneratePassword(14, 1);
            return View();
        }

        public void ButtonCount()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if(count == null)
            {
                count = 0;
            }
            count += 1;
            HttpContext.Session.SetInt32("count", (int)count);
        }

        public void CreatePasscode()
        {
            string PasscodeLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] Passcode = new char[14];
            Random rand = new Random();
            for(int i = 0; i < Passcode.Length; i++)
            {
                Passcode[i] = PasscodeLetter[rand.Next(PasscodeLetter.Length)];
            }
            string pc = new string(Passcode);
            HttpContext.Session.SetString("Pc", pc);
        }

        [HttpPost("getcode")]
        public IActionResult Code()
        {
            ButtonCount();
            CreatePasscode();
            return RedirectToAction("Index");
        }

    }
}