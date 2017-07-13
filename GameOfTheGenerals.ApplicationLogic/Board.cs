using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfTheGenerals.ApplicationLogic
{
    internal class Board : IBoard
    {
        public Board()
        {
            this.GameBoard = new ISquare[Y, X];

            for (int position = 0; position < (Y * X); position++)
            {
                int x = position % X;
                int y = position / X;
                GameBoard[y, x] = new Square(position);
            }
        }

        public void InitializePieceSetup(List<IPiece> player1ActivePieces,List<IPiece> player2ActivePieces)
        {
            var player1StartingSetup = player1ActivePieces
                            .Zip(RandomlyPickStartingPosition(0, 27)
                                , (piece, position) => new { Piece = piece, Position = position });
            
            foreach (var item in player1StartingSetup)
            {
                this.PlacePieceInPosition(item.Piece, item.Position);
            };

            var player2StartingSetup = player2ActivePieces
                            .Zip(RandomlyPickStartingPosition(45, 27)
                                , (piece, position) => new { Piece = piece, Position = position });

            foreach (var item in player2StartingSetup)
            {
                this.PlacePieceInPosition(item.Piece, item.Position);
            };
        }
        private void PlacePieceInPosition(IPiece piece, int position)
        {
            PlacePieceOnSquare(piece, GetSquare(position));
        }
        private void PlacePieceOnSquare(IPiece piece, ISquare square)
        {
            square.ContainedPiece = piece;
        }
        public ISquare GetSquare(int position)
        {
            int x = position % X;
            int y = position / X;

            ISquare square = GameBoard[y, x];

            if (square == null)
            {
                square = new Square(position);
                GameBoard[y, x] = square;
            }

            return square;
        }

        private IEnumerable<int> RandomlyPickStartingPosition(int startingPosition, int numberOfPositions)
        {
            var listOfSpots = Enumerable.Range(startingPosition, numberOfPositions).ToList();

            do
            {
                var rng = new Random();
                int pickedIndex = rng.Next(0, listOfSpots.Count - 1);
                yield return listOfSpots[pickedIndex];
                listOfSpots.RemoveAt(pickedIndex);
            }
            while (listOfSpots.Count > 0);
        }

        public MoveResult Move(int fromPosition, int toPosition)
        {
            var origin = GetSquare(fromPosition);
            var destination = GetSquare(toPosition);
            var attacker = origin.ContainedPiece;
            var attacked = destination.ContainedPiece;
            var moveResult = new MoveResult();
            if(attacked == null)
            {
                PlacePieceInPosition(attacker, toPosition);
            }
            else
            {
                var arbiter = new Arbiter();
                moveResult.BattleResult = arbiter.DecideWinner(attacker, attacked);
                ApplyBattleResult(origin, destination, moveResult.BattleResult);
            }
            return moveResult;
        }

        private void ApplyBattleResult(ISquare origin, ISquare destination, BattleResult battleResult)
        {
            if (battleResult.IsDraw)
            {
                origin.ContainedPiece = null;
                destination.ContainedPiece = null;
            }
            else
            {
                PlacePieceOnSquare(battleResult.Winner, destination);
            }
        }

        public ISquare[,] GameBoard { get; private set; }
        private const int X = 9;
        private const int Y = 8;
    }
}