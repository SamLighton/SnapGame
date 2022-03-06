namespace SnapGame.Game
{
    public class Game : IGame
    {
        public GameType GameType { get; }
        public GameState GameState { get; set; }
        public Game(GameType gameType)
        {
            GameType = gameType;
            GameState = GameState.EnterPlayerAmount;
        }
    }
}
