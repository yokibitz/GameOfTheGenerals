using System.Collections.Generic;

namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IPlayer
    {
        int Id { get; }
        ICollection<IPiece> ActivePieces { get; }
        ICollection<IPiece> LostPieces { get; }
        void UpdatePieces(IMoveResult moveResult);
    }
}