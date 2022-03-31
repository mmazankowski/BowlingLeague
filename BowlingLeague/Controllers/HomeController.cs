using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        //private BowlingLeagueDbContext _context { get; set; }

        private BowlingLeagueDbContext _repo { get; set; }

        //Constructor 
        //public HomeController(BowlingLeagueDbContext temp)
        //{
        //    _context = temp; 
        //}

        public HomeController(BowlingLeagueDbContext temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string team)
        {
            var teams = _repo.Teams.ToList();

            var bowlers = _repo.Bowlers // if using repo method do _repo.Bowlers here, use _context if not 
                .Include(x => x.Team)
                //.FromSqlRaw("SELECT * FROM Bowlers") // can build the output with a sql statement
                .Where(x => x.Team.TeamName == team || team == null)
                .OrderBy(x => x.TeamID)
                .ToList(); 

            return View(bowlers);
        }

        //public IActionResult Index()
        //{
        //    List<Team> teams = _repo.Teams.ToList();

        //    List<Bowler> bowlers = _repo.Bowlers
        //        .OrderBy(x => x.TeamId)
        //        .ToList();
        //    return View(bowlers);
        //}

        [HttpGet]
        public IActionResult BowlerForm()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(b);
                _repo.SaveChanges();

                return View("Index");
            }
            else // If Invalid 
            {
                ViewBag.Bowlers = _repo.Bowlers.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowlers = _repo.Bowlers.ToList();

            var bowler = _repo.Bowlers.Single(b => b.BowlerID == bowlerid);

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.Update(b);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

        //var someData = context.Bowlers.Include(x => "Team").ToList();
        //return View(someData); (referring to whatever isi in the context file)

    }
}
