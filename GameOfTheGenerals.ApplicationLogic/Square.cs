using System;

namespace GameOfTheGenerals.ApplicationLogic
{
    internal class Square : ISquare
    {

        public Square(int position)
        {
            this.Position = position;
        }
        public Square(IPiece piece, int position) : this(position)
        {
            this.ContainedPiece = piece;
        }

        public int Position { get; private set; }

        public IPiece ContainedPiece { get; set; }
    }
}