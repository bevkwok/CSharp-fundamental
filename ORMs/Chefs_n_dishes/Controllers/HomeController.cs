using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Chefs_n_dishes.Models;
namespace Chefs_n_dishes.Controllers
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
            Wrapper WMod = new Wrapper();
            WMod.ChefTableModel = _context.Chefs.ToList();

            Dish newdish = new Dish();
            ViewBag.AllChefs = _context.Chefs
            .Include(c => c.CreatedDish)
            .ToList();

            return View("index", WMod);
        }

        [HttpGet("new")]
        public IActionResult AddChefPage()
        {
            return View("new");
        }

        [HttpPost("newChef")]
        public IActionResult addChef(Chef newchef)
        {
            if(ModelState.IsValid)
            {
                DateTime birthd = DateTime.Parse(newchef.Birthday.ToString());
                DateTime today = DateTime.Today;
                int age = today.Year - birthd.Year;
                if(age < 18)
                {
                    ModelState.AddModelError("Birthday", "Sorry, you have to be at least 18 years old to be a Chef!");
                    return AddChefPage();
                }
                if(birthd > today)
                {
                    ModelState.AddModelError("Birthday", "Sorry, you can't be born in the future");
                    return AddChefPage();
                }
                _context.Add(newchef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return AddChefPage();
            }
        }

        [HttpGet("dishes")]
        public IActionResult Dish()
        {
            Wrapper WMod = new Wrapper();
            WMod.DishTableModel = _context.Dishes
            .Include(d => d.CookedBy)
            .ToList();

            return View("dishes", WMod);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDishPage()
        {
            Wrapper WMod = new Wrapper();
            WMod.ChefTableModel = _context.Chefs.ToList();
            WMod.DishTableModel = _context.Dishes
            .Include(d => d.CookedBy)
            .ToList();
            return View("newdish",WMod);
        }

        [HttpPost("adddish")]
        public IActionResult AddDish(Wrapper newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newDish.DishFromModel);
                _context.SaveChanges();
                return Dish();
            }
            else
            {
                return NewDishPage();
            }
        }

        // [HttpPost("newDish")]
    }
}