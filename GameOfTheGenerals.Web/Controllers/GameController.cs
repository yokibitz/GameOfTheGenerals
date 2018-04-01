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
        public IActionResult Board()
        {
            return View();
        }
    }
}
