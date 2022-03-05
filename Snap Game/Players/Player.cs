using SnapGame.Cards;
using System.Collections.Generic;

namespace SnapGame.Players
{
    public class Player : IPlayer
    {
        public int PlayerNumber { get; }
        public string Name { get; }

        public List<Card> FaceDownCards;
        public List<Card> FaceUpCards;
        


        public Player(int playerNumber, string name)
        {
            this.PlayerNumber = playerNumber;
            this.Name = name;
        }
    }
}