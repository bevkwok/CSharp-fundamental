using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner
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

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(au => au.Email == newUser.Email))
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
                return RedirectToAction("Dashboard",new{UserId = theUserId});
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
            return RedirectToAction("Dashboard",new{UserId = theUserId});
        }
        
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["OneUser.FirstName"] = "Please login or register before joining any wedding";
            return RedirectToAction("Index");
        }


        [HttpGet("Dashboard/{UserId}")]
        public IActionResult Dashboard(int UserId)
        {   
            DashWrapper WMod = new DashWrapper();

            WMod.WedUser = _context.Users
            .Include(u => u.PlannedWedding)
            .Include(u => u.AttendingWedding)
            .ThenInclude(w => w.User)
            .FirstOrDefault(u => u.UserId == UserId);

            WMod.WeddingList = _context.Weddings
            .Include(w => w.Planner)
            .Include(w => w.Guests)
            .ToList();

            return View("Dashboard", WMod);
        }

        [HttpGet("PlanWedding")]
        public IActionResult PlanWedding()
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            PlanWrapper WMod = new PlanWrapper();
            WMod.WedUser = _context.Users
            .Include(u => u.PlannedWedding)
            .Include(u => u.AttendingWedding)
            .ThenInclude(w => w.User)
            .FirstOrDefault(u => u.UserId == theUserId);

            if(theUserId == null)
            {
                return Logout();
            }
            return View("PlanWedding", WMod);
        }

        [HttpPost("AddWedding")]
        public IActionResult AddWedding(PlanWrapper newWedding)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            if(ModelState.IsValid)
                {
                    DateTime WeddingDate = DateTime.Parse(newWedding.OneWedding.Date.ToString());
                    DateTime today = DateTime.Today;
                    if(WeddingDate < today)
                    {
                        ModelState.AddModelError("Date", "Sorry, you can't plan wedding before today");
                        return PlanWedding();
                    }
                    newWedding.OneWedding.UserId = (int)theUserId;
                    _context.Add(newWedding.OneWedding);
                    _context.SaveChanges();
                    // Wedding newWed = _context.Weddings.OrderByDescending(nw => nw.WeddingId)
                    // .FirstOrDefault();
                    HttpContext.Session.SetInt32("WId", newWedding.OneWedding.WeddingId);
                    int? theWedId = HttpContext.Session.GetInt32("WId");
                    return RedirectToAction("theWedding", new{WedId = theWedId});
                }
                return RedirectToAction("PlanWedding");
        }

        [HttpGet("theWeddingPage/{WedId}")]
        public IActionResult theWedding(int? WedId)
        {
            
            Wedding theWedding = _context.Weddings 
            .Include(w => w.Guests)
            .Include(w => w.Planner)
            .FirstOrDefault(wedding => wedding.WeddingId == WedId);

            return View("showWedding", theWedding);
        }
        [HttpGet("/wedding/delete/{id}")]
        public IActionResult DeleteWedding(int id)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            if(theUserId == null)
            {
                return Logout();
            }
            Wedding ToDelete = _context.Weddings
            .FirstOrDefault(w => w.WeddingId == id);

            if(ToDelete == null || ToDelete.UserId != (int)theUserId)
            {
                return RedirectToAction("Dashboard",new{UserId = theUserId});
            }
            _context.Remove(ToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard",new{UserId = theUserId});
        }

        [HttpGet("/wedding/join/{id}")]
        public IActionResult JoinWedding(int id, Guest guest)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            guest.UserId = (int)theUserId;
            guest.WeddingId = id;
            if(theUserId == null)
            {
                return Logout();
            }

            // Wedding ToJoin = _context.Weddings
            // .Include(w => w.Guests)
            // .ThenInclude(wt => wt.UserId)
            // .FirstOrDefault(w => w.WeddingId == id);

            // if(ToJoin == null || ToJoin.UserId != (int)theUserId)
            // {
            //     return RedirectToAction("Dashboard",new{UserId = theUserId});
            // }

            _context.Add(guest);
            _context.SaveChanges();

            return RedirectToAction("Dashboard",new{UserId = theUserId});
        }

        [HttpGet("/wedding/quit/{id}")]
        public IActionResult QuitWedding(int id, Guest guest)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            if(theUserId == null)
            {
                return Logout();
            }

            Guest DeleteGuest = _context.Guests
            .Where(g => g.UserId == theUserId)
            .FirstOrDefault(g1 => g1.WeddingId == id);

            _context.Remove(DeleteGuest);
            _context.SaveChanges();

            return RedirectToAction("Dashboard",new{UserId = theUserId});
        }
    }
}