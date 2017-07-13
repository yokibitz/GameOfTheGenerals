using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameOfTheGenerals.ApplicationLogic
{
    public class MoveResult
    {
        public MoveResult()
        {

        }
        public MoveResult(BattleResult battleResult)
        {
            BattleResult = battleResult;
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
    }
}
