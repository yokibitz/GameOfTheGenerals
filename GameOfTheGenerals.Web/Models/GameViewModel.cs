using GameOfTheGenerals.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTheGenerals.Web.Models
{
    public class GameViewModel
    {
        private readonly IGame _game;

        public IGame Game => _game;

        public GameViewModel(IGame game)
        {
            _game = game;
        }
    }
}
