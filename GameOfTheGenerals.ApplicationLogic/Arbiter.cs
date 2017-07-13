using System.Linq;
using System;
namespace GameOfTheGenerals.ApplicationLogic
{
    public class Arbiter : IArbiter
    {
        public BattleResult DecideWinner(IPiece attacker, IPiece attacked)
        {
            BattleResult result;

            if (attacker.Rank == attacked.Rank)
            {
                if (attacker.Rank == Rank.Flag)
                {
                    result = BattleResult.WinResult(attacker, attacked);
                }
                else
                {
                    result = BattleResult.DrawResult(attacker, attacked);
                }
            }
            else
            {
                var pieces = new[] { attacker, attacked }.OrderByDescending(r => r.Rank);

                if (pieces.Any(p => p.Is(Rank.Private)) && pieces.Any(p => p.Is(Rank.Spy)))
                {
                    result = BattleResult.WinResult(pieces.Single(p => p.Is(Rank.Private)), pieces.Single(p => p.Is(Rank.Private)));
                }
                else
                {
                    result = BattleResult.WinResult(pieces.First(), pieces.Last());
                }
            }

            return result;
        }

    }
}
