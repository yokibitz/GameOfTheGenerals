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
        public Player(int playerId, ICollection<IPiece> activePieces, ICollection<IPiece> lostPieces)
            : this(playerId)
        {
            this.ActivePieces = activePieces;
            this.LostPieces = lostPieces;
        }
        public void UpdatePieces(IMoveResult moveResult)
        {
            foreach (var lostPiece in moveResult.GetLostPieces().Where(p => p.PlayerId == Id))
            {
                ActivePieces.Remove(lostPiece);
                LostPieces.Add(lostPiece);
            }
        }

        public ICollection<IPiece> ActivePieces { get; private set; }

        public ICollection<IPiece> LostPieces { get; private set; }

        public int Id { get; private set; }
    }
}