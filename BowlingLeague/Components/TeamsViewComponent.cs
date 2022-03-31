using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingLeague.Models;

namespace BowlingLeague.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlingLeagueRepository repo { get; set; }

        public TeamsViewComponent(IBowlingLeagueRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];

            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
