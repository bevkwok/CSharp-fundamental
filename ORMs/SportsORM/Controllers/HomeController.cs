using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            ViewBag.Tname = _context.Teams.Where(tnt => tnt.TeamName.StartsWith("T")).ToList();

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
            ViewBag.ascTeam = _context.Teams
            .Include(t => t.CurrLeague)
            .Where(t => t.CurrLeague.Name.Contains("Atlantic Soccer Conference"))
            .ToList();

            ViewBag.bpplayer = _context.Players
            .Include(p => p.CurrentTeam)
            .Where(p => p.CurrentTeam.Location.Contains("Boston") && p.CurrentTeam.TeamName.Contains("Penguins"))
            .ToList();

            ViewBag.bcplayer = _context.Players
            .Include(p1 => p1.CurrentTeam.CurrLeague)
            .Where(p1 => p1.CurrentTeam.CurrLeague.Name.Contains("International Collegiate Baseball Conference"))
            .ToList();

            ViewBag.alplayer = _context.Players
            .Include(p2 => p2.CurrentTeam.CurrLeague)
            .Where(p2 => p2.CurrentTeam.CurrLeague.Name.Contains("American Conference of Amateur Football") && p2.LastName.Contains("Lopez"))
            .ToList();

            ViewBag.fplayer = _context.Players
            .Include(p3 => p3.CurrentTeam.CurrLeague)
            .Where(p3 => p3.CurrentTeam.CurrLeague.Sport.Contains("Football"))
            .ToList();



            ViewBag.tsophia = _context.Players
            .Where(tt => tt.FirstName.Contains("Sophia"))
            .Include(ts => ts.CurrentTeam)
            .ToList();
            
            ViewBag.lsophia =_context.Players
            .Where(ls => ls.FirstName.Contains("Sophia"))
            .Include(ss => ss.CurrentTeam.CurrLeague)
            .ToList();



            ViewBag.fwplayer = _context.Players
            .Include(p7 => p7.CurrentTeam.CurrLeague)
            .Where(p7 => !p7.CurrentTeam.CurrLeague.Name.Contains("Washington Roughriders") && p7.LastName.Contains("Flores"))
            .ToList();
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}