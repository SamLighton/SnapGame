namespace SnapGame.Game
{
    public interface IGame
    {
        GameType GameType { get; }
        GameState GameState { get; }
    }
}
