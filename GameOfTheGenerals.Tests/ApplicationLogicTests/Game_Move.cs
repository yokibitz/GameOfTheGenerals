using System;
using FsCheck;
using FsCheck.NUnit;
using Property = FsCheck.NUnit.PropertyAttribute;
using NUnit.Framework;
using GameOfTheGenerals.ApplicationLogic;

namespace GameOfTheGenerals.Tests.ApplicationLogicTests
{
    [TestFixture]
    public class Game_Move
    {
        [Property(QuietOnSuccess = false)]
        public FsCheck.Property Player1Moves_InvalidMoveResult_NullBattleResult(int origin, int destination)
        {
            //Prop.ForAll<int>(origin =>
            //{
            var game = new Game();

            var result = game.Move(origin, destination);

            return (result.BattleResult == null)
            .When(result is InvalidMoveResult);
            //}).VerboseCheckThrowOnFailure();
        }

        [Property(EndSize = 18, QuietOnSuccess =false)]
        public FsCheck.Property Player1Moves_MoveToEmptySquare_NullBattleResult()
        {
            //Prop.ForAll<int>(origin =>
            //{
            IGame game = new Game();
            int origValue = Gen.Sample(1, 1, Gen.Choose(0, 71)).Head;
            int destination = origValue + 9;
            var movingPiece = game.GameState.Board.GetSquare(origValue)?.ContainedPiece;
            var destinationSquare = game.GameState.Board.GetSquare(destination);
            var result = game.Move(origValue, destination);

            return (result.BattleResult == null)
            .When(result is MoveResult && movingPiece != null && destinationSquare?.ContainedPiece != null);
            //}).VerboseCheckThrowOnFailure();
        }
    }
}
