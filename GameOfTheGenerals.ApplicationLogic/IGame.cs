namespace GameOfTheGenerals.ApplicationLogic
{
    public interface IGame
    {
        int GameID { get; }
        string GameCode { get; }
        IGameState GameState { get; }
    }
}