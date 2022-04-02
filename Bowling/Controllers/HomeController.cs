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

        public IActionResult Index(string teamname)
        {
            var x = _repo.Bowlers
            .Where(x => x.Team.TeamName == teamname || teamname == null);


            return View(_repo.Bowlers.ToList());
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            _repo.SaveBowler(b);
            return View("Index", _repo.Bowlers.ToList());
        }
        //[HttpPost]
        //public IActionResult AddBowler(Bowler b)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repo.CreateBowler(b);
        //        _repo.SaveBowler(b);
        //        return View("Confirmation", b);
        //    }
        //    else
        //    {
        //        ViewBag.Teams = _repo.Teams.ToList();
        //        return View();
        //    }
        //}

        [HttpGet]
        public IActionResult EditBowler(int BowlerID)
        {
            var b = _repo.Bowlers.Single(i => i.BowlerID == BowlerID);

            return View("AddBowler", b);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler b)
        {
            _repo.UpdateBowler(b);

            return RedirectToAction("AddBowler");
        }

        [HttpGet]
        public IActionResult DeleteBowler(int bowlerid)
        {
            var b = _repo.Bowlers.Single(i => i.BowlerID == bowlerid);

            return View(b);
        }

        [HttpPost]
        public IActionResult DeleteBowler(Bowler b)
        {
            _repo.DeleteBowler(b);
            return RedirectToAction("Index", _repo.Bowlers.ToList());
        }

    }
}
