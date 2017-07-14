using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameOfTheGenerals.ApplicationLogic
{
    [Serializable]
    public class MoveResult : IMoveResult
    {
        public MoveResult(ISquare origin, ISquare destination)
        {
            UpdatedSquares = new ISquare[] { origin, destination };
        }

        public IEnumerable<IPiece> GetLostPieces()
        {
            if(BattleResult != null)
            {
                return BattleResult.LostPieces;
            }

            return Enumerable.Empty<IPiece>();
        }
        public BattleResult BattleResult { get; set; }
        public IEnumerable<ISquare> UpdatedSquares { get; set; }
    }
}
