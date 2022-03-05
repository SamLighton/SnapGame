namespace SnapGame.Cards
{
    public interface ICard
    {
        CardValue Value { get; }
        CardSuit Suit { get; }
    }
}