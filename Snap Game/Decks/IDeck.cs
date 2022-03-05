namespace SnapGame.Decks
{
    using SnapGame.Cards;
    using System.Collections.Generic;
    public interface IDeck
    {
        // IEnumerable<ICard> Cards { get; }

        void FillDeck();

        void Shuffle();

        // void Split();

        // shuffle

        // take card off the top of the deck
    }
}
