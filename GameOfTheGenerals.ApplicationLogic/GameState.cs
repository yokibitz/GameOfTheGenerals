using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTheGenerals.ApplicationLogic
{
    public class GameState: IGameState
    {
        public GameState(IBoard board, IPlayer player1, IPlayer player2, IPlayer activePlayer)
        {
            Board = board;
            Player1 = player1;
            Player2 = player2;
            ActivePlayer = activePlayer;
        }
        public GameState(IGameState gameState) : 
            this(gameState.Board, gameState.Player1, gameState.Player1, gameState.ActivePlayer)
        {
        }
        public IPlayer ActivePlayer { get; private set; }

        public IBoard Board { get; private set; }

        public IPlayer Player1 { get; private set; }

        public IPlayer Player2 { get; private set; }

        public void ToggleActivePlayer()
        {
            ActivePlayer = ActivePlayer == Player1 ? Player2 : Player1;
        }
    }
}
