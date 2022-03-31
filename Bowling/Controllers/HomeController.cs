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

        public IActionResult AddBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            ViewBag.States = _repo.Bowlers.ToList();
            return View();
        }

    }
}
