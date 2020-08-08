using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
namespace survey
{
    public class SurveyController: Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("result");
        }


    }
}