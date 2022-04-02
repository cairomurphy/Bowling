using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Bowlers
                .Include(x => x.Team)
                .ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult AddBowler(string state)
        {
            ViewBag.Teams = _repo.Teams.ToList();
            ViewBag.States = _repo.Bowlers.Where(x => x.BowlerState == state).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateBowler(b);
                _repo.SaveBowler(b);
                return View("Confirmation", b);
            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                return View();
            }
        }

    }
}
