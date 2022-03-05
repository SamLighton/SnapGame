namespace SnapGame.Game
{
    public class Game : IGame
    {
        public GameType GameType { get; }
        public GameState GameState { get; }
        public Game(GameType gameType)
        {
            this.GameType = gameType;
            this.GameState = GameState.Start;
        }
    }
}
