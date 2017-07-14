using System.Collections.Generic;

namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IGameState
    {
        IPlayer ActivePlayer { get; }
        IBoard Board { get; }
        IPlayer Player1 { get; }
        IPlayer Player2 { get; }
        void ToggleActivePlayer();
    }
}