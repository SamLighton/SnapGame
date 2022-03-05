namespace SnapGame.Cards
{
    public class Card : ICard
    {
        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public Card(CardValue value, CardSuit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
    }
}