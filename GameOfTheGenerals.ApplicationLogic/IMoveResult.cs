using System.Collections.Generic;

namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IMoveResult
    {
        BattleResult BattleResult { get; set; }
        IEnumerable<ISquare> UpdatedSquares { get; set; }
        IEnumerable<IPiece> GetLostPieces();
    }
}