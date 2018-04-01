using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameOfTheGenerals.ApplicationLogic
{
    [Serializable]
    public class InvalidMoveResult : IMoveResult
    {
        public InvalidMoveResult()
        {
        }

        public IEnumerable<IPiece> GetLostPieces()
        {
            return Enumerable.Empty<IPiece>();
        }
        public BattleResult BattleResult { get { return null; } }
        public IEnumerable<ISquare> UpdatedSquares { get { return null; } }
    }
}
