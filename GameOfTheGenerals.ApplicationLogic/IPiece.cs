using System;
using System.ComponentModel;
using EnumsNET;

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

        public string RankCode => Rank.GetAttributes().Get<DescriptionAttribute>().Description;

        public override string ToString()
        {
            return Rank.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is IPiece otherPiece)
            {
                return this.Rank.CompareTo(otherPiece.Rank);
            }
            else
            {
                throw new ArgumentException("Object is not a Piece");
            }
        }

        private readonly Rank _rank;
    }
    public interface IPiece
    {
        Rank Rank { get; }
        string RankCode { get; }
        bool Is(Rank rank);
        int PlayerId { get; }
    }
}