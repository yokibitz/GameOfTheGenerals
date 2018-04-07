using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfTheGenerals.ApplicationLogic
{
    public class Player : IPlayer
    {
        public Player(int playerId)
        {
            Id = playerId;
        }
        public Player(int playerId, ICollection<ISquare> activeSquares, ICollection<IPiece> lostPieces)
            : this(playerId)
        {
            this.ActiveSquares = activeSquares;
            this.LostPieces = lostPieces;
        }
        public void UpdatePieces(IMoveResult moveResult)
        {
            foreach (var lostPiece in moveResult.GetLostPieces().Where(p => p.PlayerId == Id))
            {
                ActiveSquares.Remove(moveResult.UpdatedSquares.Single(s => s.ContainedPiece == lostPiece));
                LostPieces.Add(lostPiece);
            }
        }

        public ICollection<ISquare> ActiveSquares { get; private set; }

        public ICollection<IPiece> LostPieces { get; private set; }

        public int Id { get; private set; }
    }
}