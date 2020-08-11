using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojodachi.Models;
namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // Dojodachi dachi1 = new Dojodachi()
            // {
            //     Fullness = 70,
            //     Happiness = 45,
            //     Meals = 3,
            //     Energy = 85,
            // };
            if(HttpContext.Session.GetInt32("Fullness") == null)
            {
                HttpContext.Session.SetInt32("Fullness", 70);
                HttpContext.Session.SetInt32("Happiness", 45);
                HttpContext.Session.SetInt32("Meals", 3);
                HttpContext.Session.SetInt32("Energy", 85);
                HttpContext.Session.SetString("Message", "Welcome to Dojodochi!");
            }
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Meals = Meals;
            ViewBag.Energy = Energy;
            ViewBag.Message = HttpContext.Session.GetString("Message");
            
            return View("index");
        }

        [HttpPost("feed")]
        public IActionResult Feed()
        {
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Meal = HttpContext.Session.GetInt32("Meals");
            Random rand = new Random();
            int i = rand.Next(5,10);
            if (Fullness >= 100)
            {
                HttpContext.Session.SetString("Message", "Your Dojodachi is very full");
            }

            if (Meal <= 0)
            {
                HttpContext.Session.SetString("Message", "You have no meal to feed dachi.");
            } else {
                HttpContext.Session.SetInt32("Fullness", (int)Fullness+i);
                HttpContext.Session.SetInt32("Meals", (int)Meal-1);
                HttpContext.Session.SetString("Message", "You feed your Dojodachi Fullness +" + i + ", meal decrease 1.");
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost("play")]
        
        public IActionResult Play()
        {
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            Random rand = new Random();
            int i = rand.Next(5,11);

            if (Energy <= 0)
            {
                HttpContext.Session.SetString("Message", "Your Dojodachi has no energy to play");
            }
            else
            {
                int j = rand.Next(1,5);
                if (j != 4)
                {
                    HttpContext.Session.SetInt32("Happiness", (int)Happiness+i);
                    HttpContext.Session.SetInt32("Energy", (int)Energy-5);
                    HttpContext.Session.SetString("Message", "Your Dojodachi Happiness +" + i + ", Energy decrease 5.");
                }
                else
                {
                    HttpContext.Session.SetInt32("Energy", (int)Energy-5);
                    HttpContext.Session.SetString("Message", "Your Dojodachi doesn't want to play.");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost("work")]
        public IActionResult Work()
        {
            int? Meal = HttpContext.Session.GetInt32("Meals");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            Random rand = new Random();
            int i = rand.Next(1,4);
            if(Energy <= 0)
            {
                HttpContext.Session.SetString("Message", "Your Dojodachi has no energy to work");
            }
            else
            {
                HttpContext.Session.SetInt32("Energy", (int)Energy-5);
                HttpContext.Session.SetInt32("Meals", (int)Meal+i);
                HttpContext.Session.SetString("Message", "Your Dojodachi went to work , Energy decrease 5 and Meal increase" + i + ".");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("sleep")]

        public IActionResult Sleep()
        {
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if (Happiness <= 0 || Fullness <= 0)
            {
                return RedirectToAction("Death");
            } else 
            {
                HttpContext.Session.SetInt32("Energy", (int)Energy+15);
                HttpContext.Session.SetInt32("Fullness", (int)Fullness-5);
                HttpContext.Session.SetInt32("Happiness", (int)Happiness-5);
                HttpContext.Session.SetString("Message", "Your Dojodachi went to sleep , Energy increase 15, Happiness and Fullness decrease 5");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("death")]
        public IActionResult Death()
        {
            HttpContext.Session.SetString("Message", "Your Dojodachi has passed away");

            return RedirectToAction("Index");
        }

        [HttpGet("win")]
        public IActionResult Win()
        {
            HttpContext.Session.SetString("Message", "Your WIN!!");
            return RedirectToAction("Index");
        }

        [HttpPost("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}