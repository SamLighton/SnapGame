using SnapGame.Cards;
using System.Collections.Generic;

namespace SnapGame.Players
{
    public class Player : IPlayer
    {
        public int PlayerNumber { get; }
        public string Name { get; }

        public List<Card> FaceDownCards { get; }
        public List<Card> FaceUpCards { get; }
        
        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
            FaceDownCards = new List<Card>();
            FaceUpCards = new List<Card>();
        }

        public Player(int playerNumber, string name)
        {
            PlayerNumber = playerNumber;
            Name = name;
        }

        public void DrawCard()
        {
            int topCardIndex = FaceDownCards.Count - 1;

            FaceUpCards.Add(FaceDownCards[topCardIndex]);

            FaceDownCards.RemoveAt(topCardIndex);
        }
    }
}