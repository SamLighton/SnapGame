namespace SnapGame.Decks
{
    using SnapGame.Cards;
    using SnapGame.Players;
    using System;
    using System.Collections.Generic;
    public class StandardDeck : IDeck
    {
        // public IEnumerable<ICard> Cards { get; }

        // public Card[] Cards = new Card[52];

        public List<Card> Cards { get; }

        public StandardDeck()
        {
            Cards = new List<Card>();
        }

        public void FillDeck()
        {
            // Add one of each card into the deck

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Cards.Add(new Card(value, suit));
                }
            }
        }

        public void Shuffle()
        {
            if (Cards.Count > 1)
            { 
                Random r = new Random();

                for (int i = Cards.Count - 1; i > 0; --i)
                {
                    int k = r.Next(i + 1);
                    Card temp = Cards[i];
                    Cards[i] = Cards[k];
                    Cards[k] = temp;
                }
            }
        }

        public void DealCards(List<Player> players)
        {
            while (Cards.Count > 0)
            { 
                foreach(var player in players)
                {
                    if (Cards.Count > 0)
                    {    
                        player.FaceDownCards.Add(TakeTopCard());
                    }
                }
            }
        }

        public Card TakeTopCard()
        {
            // Find the top card, remove it and return it
            var topCard = Cards[this.Cards.Count - 1];
            Cards.Remove(topCard);
            return topCard;
        }
    }
}
