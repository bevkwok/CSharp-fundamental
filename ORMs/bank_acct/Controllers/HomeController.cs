using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using bank_acct.Models;

namespace bank_acct.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IndexWrapper WMod = new IndexWrapper();

        [HttpGet("")]

        public IActionResult Index()
        {
            WMod.UserTableModel = _context.Users.ToList();

            return View("Index", WMod);
        }

        [HttpPost("register")]
        public IActionResult Register(IndexWrapper newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(au => au.Email == newUser.UserFormModel.Email))
                {
                    ModelState.AddModelError("UserFormModel.Email", "Email already in use!");
                    return Index();
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.UserFormModel.Password = Hasher.HashPassword(newUser.UserFormModel, newUser.UserFormModel.Password);
                _context.Add(newUser.UserFormModel);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("AcitveUser", newUser.UserFormModel.UserId);
                return RedirectToAction("Acct", new{id = newUser.UserFormModel.UserId});
            }
            else
            {
                return Index();
            }
        }

        [HttpGet("login")]
        public IActionResult LoginPage()
        {

            return View("login");
        }

        [HttpPost("loginuser")]
        public IActionResult Login(User loginUser)
        {
            var userInDb = _context.Users.FirstOrDefault(lu => lu.Email == loginUser.Email);
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
            HttpContext.Session.SetInt32("AcitveUser", userInDb.UserId);
            return RedirectToAction("Acct", new{id = userInDb.UserId});
        }

        [HttpGet("account/{id}")]
        public IActionResult Acct(int? id)
        {
            // User ToDisplay = _context.Users
            // .FirstOrDefault(u => u.UserId == id);
            // WMod.UserTableModel = _context.Users
            // .FirstOrDefault(u => u.UserId == id);
            int? check = HttpContext.Session.GetInt32("AcitveUser");
            if(check != id)
            {
                return RedirectToAction("LoginPage");
            }

            WMod.UserFormModel = _context.Users
            .Include(ut => ut.UserTransaction)
            .SingleOrDefault(u => u.UserId == id);

            if(WMod == null)
            {
                ModelState.AddModelError("Email", "Please login first to get into the account");
                return LoginPage();
            }

            return View("account", WMod);
        }

        [HttpPost("deposit")]
        public IActionResult Deposit(IndexWrapper deposit)
        {
            var TheUser = _context.Users
            .Include(um => um.UserTransaction)
            .SingleOrDefault(um => um.UserId == deposit.TransactionFormModel.UserId);
            System.Console.WriteLine(TheUser.FirstName);
            int UserBalance = TheUser.UserTransaction.Sum(s => s.Amount);

            if(ModelState.IsValid)
            {
                if(-deposit.TransactionFormModel.Amount > UserBalance)
                {
                    ModelState.AddModelError("TransactionFormModel.Amount", "You cannot takeout more then your balance!");
                    return View("Acct", new{id = deposit.TransactionFormModel.UserId});
                }
                _context.Add(deposit.TransactionFormModel);
                _context.SaveChanges();
                return RedirectToAction("Acct", new{id = deposit.TransactionFormModel.UserId});
            }
            return RedirectToAction("Acct", new{id = deposit.TransactionFormModel.UserId});
        }
    }
}