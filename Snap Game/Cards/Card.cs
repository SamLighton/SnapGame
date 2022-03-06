namespace SnapGame.Cards
{
    public class Card : ICard
    {
        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}