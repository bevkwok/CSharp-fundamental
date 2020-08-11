using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomenLeagues = _context.Leagues.Where(lwoman => lwoman.Name.Contains("Womens")).ToList();

            ViewBag.hockeySport = _context.Leagues.Where(lhockey => lhockey.Sport.Contains("Hockey")).ToList();

            ViewBag.NotFootball = _context.Leagues.Where(nFootball => !nFootball.Sport.Contains("Football")).ToList();

            ViewBag.Conferences = _context.Leagues.Where(c => c.Name.Contains("Conference")).ToList();

            ViewBag.Atlantic = _context.Leagues.Where(ra => ra.Name.Contains("Atlantic")).ToList();

            ViewBag.Dallas = _context.Teams.Where(ld => ld.Location.Contains("Dallas")).ToList();

            ViewBag.Raptors = _context.Teams.Where(tnr => tnr.TeamName.Contains("Raptors")).ToList();

            ViewBag.City = _context.Teams.Where(lc => lc.Location.Contains("City")).ToList();

            ViewBag.Tname = _context.Teams.Where(tnt => tnt.TeamName.Contains("T")).ToList();

            ViewBag.LocationOrder = _context.Teams.OrderBy(lo => lo.Location).ToList();

            ViewBag.LocationOrderDes = _context.Teams.OrderByDescending(lod => lod.Location).ToList();

            ViewBag.Cooper = _context.Players.Where(ln => ln.LastName.Contains("Cooper")).ToList();

            ViewBag.Joshua = _context.Players.Where(fn => fn.FirstName.Contains("Joshua")).ToList();

            ViewBag.CoopNotJosh = _context.Players
            .Where(cnj => cnj.LastName.Contains("Cooper") && !cnj.FirstName.Contains("Joshua"))
            .ToList();

            ViewBag.AlexorWy = _context.Players
            .Where(aw => aw.FirstName.Contains("Alexander") || aw.FirstName.Contains("Wyatt"))
            .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}