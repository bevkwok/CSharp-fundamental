using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using cru.Models;
namespace cru.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            // List<Dishes> AllDishes = _context.Dishes.ToList();
            ViewBag.AllDishes = _context.Dishes.ToList();
            return View("index");
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("new");
        }

        [HttpPost("newdish")]
        public IActionResult NewDish(Dishes dish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return New();
            }
        }

        [HttpGet("{Dishid}")]
        public IActionResult DishInfo(int Dishid)
        {
            Dishes showing = _context.Dishes.FirstOrDefault(i => i.DishId == Dishid);

            if(showing == null)
            {
                return RedirectToAction("Index");
            }
            return View("dishInfo", showing);
        }

        [HttpPost("delDish/{Dishid}")]
        public IActionResult DelDish(int Dishid)
        {
            Dishes theDish = _context.Dishes.SingleOrDefault(d => d.DishId == Dishid);
            _context.Dishes.Remove(theDish);
            _context.SaveChanges();
            return Index();
        }

        [HttpGet("Edit/{Dishid}")]
        public IActionResult EditPage(int Dishid)
        {
            Dishes dish = _context.Dishes.FirstOrDefault(ed => ed.DishId == Dishid);

            return View("EditPage", dish);
        }

        [HttpPost("editDish/{Dishid}")]
        public IActionResult EditDish(int Dishid, Dishes NewDish)
        {
            // Dishes theDish = _context.Dishes.SingleOrDefault(d => d.DishId == Dishid);
            // theDish.Name = NewDish.Name;
            // theDish.Chef = NewDish.Chef;
            // theDish.Calories = NewDish.Calories;
            // theDish.Tastiness = NewDish.Tastiness;
            // _context.SaveChanges();

            NewDish.DishId = Dishid;
            _context.Update(NewDish);
            _context.Entry(NewDish).Property("CreateAt").IsModified = false;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}