using System;

namespace GameOfTheGenerals.ApplicationLogic
{
    public class Piece : IPiece, IComparable
    {
        public Piece(Rank rank, int playerId)
        {
            this._rank = rank;
            this.PlayerId = playerId;
        }

        public bool Is(Rank rank)
        {
            return Rank == rank;
        }
        public Rank Rank
        {
            get
            {
                return _rank;
            }
        }
        public int PlayerId { get; private set; }
        public override string ToString()
        {
            return Rank.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            IPiece otherPiece = obj as IPiece;
            if (otherPiece != null)
                return this.Rank.CompareTo(otherPiece.Rank);
            else
                throw new ArgumentException("Object is not a Piece");
        }

        private readonly Rank _rank;
    }
    public interface IPiece
    {
        Rank Rank { get; }

        bool Is(Rank rank);
        int PlayerId { get; }
    }
}