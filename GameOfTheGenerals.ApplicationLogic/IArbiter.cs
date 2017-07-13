namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IArbiter
    {
        BattleResult DecideWinner(IPiece pieceOne, IPiece pieceTwo);
    }
}