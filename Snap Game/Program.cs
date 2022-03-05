namespace SnapGame
{
    using SnapGame.Cards;
    using SnapGame.Decks;
    using SnapGame.Game;
    using SnapGame.Players;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var card = new Card(CardValue.Two, CardSuit.Spades);

            var player1 = new Player(1, "Sam");

            var deck = new StandardDeck();

            var game = new Game.Game(GameType.StandardSnap);


            Console.WriteLine($"{card.Value} of {card.Suit}");

            Console.WriteLine($"Player {player1.PlayerNumber} is called {player1.Name}");

            Console.WriteLine(deck.Cards.Count);

            Console.WriteLine($"First card - {deck.Cards[0].Value} of {deck.Cards[0].Suit}");

            Console.WriteLine($"Top card - {deck.Cards[51].Value} of {deck.Cards[51].Suit}");

            if (game.GameState == GameState.Start)
            {
                // check player amount
                // deal cards
                // move to InProgress
            }

            if (game.GameState == GameState.InProgress)
            {
                // set player turn

            }

            if (game.GameState == GameState.Finish)
            {

            }



        }
    }
}
