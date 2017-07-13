namespace GameOfTheGenerals.ApplicationLogic
{
    public interface ISquare
    {
        int Position{get;}
        IPiece ContainedPiece{get;set;}
    }
}