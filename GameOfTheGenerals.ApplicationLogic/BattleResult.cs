using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTheGenerals.ApplicationLogic
{
    public sealed class BattleResult
    {
        private BattleResult()
        {
            IsDraw = true;
        }
        private BattleResult(IPiece winner, IPiece loser)
        {
            this.IsDraw = false;
            this.Winner = winner;
            LostPieces.Add(loser);
        }

        public static BattleResult WinResult(IPiece winner, IPiece loser)
        {
            return new BattleResult(winner, loser);
        }

        public static BattleResult DrawResult(IPiece attacker, IPiece attacked)
        {
            var drawResult = new BattleResult();
            drawResult.LostPieces.Add(attacker);
            drawResult.LostPieces.Add(attacked);
            return drawResult;
        }
        public IPiece Winner { get; private set; }
        public IList<IPiece> LostPieces { get; private set; }
        public bool IsDraw { get; private set; }
    }
}
