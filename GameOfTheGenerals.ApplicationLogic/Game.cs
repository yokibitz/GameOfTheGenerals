using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfTheGenerals.ApplicationLogic
{
    public class Game : IGame
    {
        public Game()
        {
            InitializeGameState();
        }
        public Game(IGameState gameState)
        {
            this.GameState = gameState;
        }

        public void InitializeGameState()
        {
            IBoard board = new Board();

            List<IPiece> player1ActivePieces = CreateDefaultActivePieces(1).ToList();
            List<IPiece> player2ActivePieces = CreateDefaultActivePieces(2).ToList();
            board.InitializePieceSetup(player1ActivePieces, player2ActivePieces);
            
            var player1 = new Player(1, board.GameBoard.Where(s => s.ContainedPiece?.PlayerId == 1).ToList(), new List<IPiece>());
            var player2 = new Player(2, board.GameBoard.Where(s => s.ContainedPiece?.PlayerId == 2).ToList(), new List<IPiece>());

            this.GameState = new GameState(board, player1, player2, player1);
        }

        public IMoveResult Move(int fromPosition, int toPosition)
        {
            var moveResult = GameState.Board.Move(fromPosition, toPosition);

            if (moveResult is MoveResult)
            {
                GameState.Player1.UpdatePieces(moveResult);
                GameState.Player2.UpdatePieces(moveResult);

                GameState.ToggleActivePlayer();
            }

            return moveResult;
        }        

        private static void CheckAttackLogic()
        {
            Random rng = new Random();

            IPiece attacker = new Piece((Rank)rng.Next(0, 14), 1);
            IPiece attacked = new Piece((Rank)rng.Next(0, 14), 2);

            Console.WriteLine($"{attacker.Rank} is attacking {attacked.Rank}");

            IArbiter arbiter = new Arbiter();
            var result = arbiter.DecideWinner(attacker, attacked);

            if (result.IsDraw)
            {
                Console.WriteLine("Result is Draw");
            }
            else
            {
                Console.WriteLine($"The winner is {result.Winner}");
            }
        }

        private static void CheckPieceOnPosition(IBoard board)
        {
            string input = Console.ReadLine();

            while (input != "exit")
            {
                if (int.TryParse(input, out int position))
                {
                    var pieceAtPosition = board.GetSquare(position).ContainedPiece;

                    Console.WriteLine($"Piece at Position {input} is {pieceAtPosition?.ToString()}");
                }

                input = Console.ReadLine();
            }
        }

        private IEnumerable<IPiece> CreateDefaultActivePieces(int playerId)
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                if (rank == Rank.Private)
                {
                    for (int index = 0; index < 6; index++)
                    {
                        yield return new Piece(rank, playerId);
                    }
                }
                else if (rank == Rank.Spy)
                {
                    for (int index = 0; index < 2; index++)
                    {
                        yield return new Piece(rank, playerId);
                    }
                }
                else
                {
                    yield return new Piece(rank, playerId);
                }
            }
        }



        public int GameID { get; private set; }

        public string GameCode { get; private set; }

        public IGameState GameState {get; private set;}
    }
}