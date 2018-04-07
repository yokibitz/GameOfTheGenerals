using System.Collections.Generic;

namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IBoard
    {
        ISquare[] GameBoard { get; }
        ISquare GetSquare(int position);
        void InitializePieceSetup(List<IPiece> player1ActivePieces, List<IPiece> player2ActivePieces);
        IMoveResult Move(int fromPosition, int toPosition);
    }
}