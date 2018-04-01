using System.Collections.Generic;

namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IMoveResult
    {
        BattleResult BattleResult { get; }
        IEnumerable<ISquare> UpdatedSquares { get; }
        IEnumerable<IPiece> GetLostPieces();
    }
}