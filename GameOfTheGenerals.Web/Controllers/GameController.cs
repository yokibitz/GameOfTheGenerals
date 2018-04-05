using GameOfTheGenerals.ApplicationLogic;
using GameOfTheGenerals.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTheGenerals.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGame _game;

        public GameController(IGame game)
        {
            _game = game;
        }

        public IActionResult Board()
        {
            return View(new GameViewModel(_game));
        }
    }
}
