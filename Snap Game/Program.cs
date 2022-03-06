namespace SnapGame
{
    using SnapGame.Cards;
    using SnapGame.Decks;
    using SnapGame.Game;
    using SnapGame.Players;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var card = new Card(CardValue.Two, CardSuit.Spades);

            var player1 = new Player(1, "Sam");

            var deck = new StandardDeck();

            var game = new Game.Game(GameType.StandardSnap);

            var players = new List<Player>();

            string winningPlayerName;


            Console.WriteLine($"{card.Value} of {card.Suit}");

            Console.WriteLine($"Player {player1.PlayerNumber} is called {player1.Name}");

            Console.WriteLine(deck.Cards.Count);

            // Console.WriteLine($"First card - {deck.Cards[0].Value} of {deck.Cards[0].Suit}");

            // Console.WriteLine($"Top card - {deck.Cards[51].Value} of {deck.Cards[51].Suit}");



            if (game.GameState == GameState.EnterPlayerAmount)
            {
                // Enter player amount
                // on succesful entry, move to Start state

                int numberOfPlayers;

                do
                {
                    Console.WriteLine("Please enter a number from 2 to 8.");
                    Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
                } while (numberOfPlayers < 2 || numberOfPlayers > 8);

                for (int i = 0; i < numberOfPlayers; i++)
                {
                    players.Add(new Player(i));
                }
                Console.WriteLine("Number of players registered as " + players.Count);
                game.GameState = GameState.Start;
            }

            if (game.GameState == GameState.Start)
            {
                deck.FillDeck();

                Console.WriteLine($"Number of cards in deck after filling: {deck.Cards.Count}");

                deck.Shuffle();
                deck.DealCards(players);

                foreach (var player in players)
                {
                    Console.WriteLine($"player {player.PlayerNumber} face down card count - {player.FaceDownCards.Count}");
                }

                game.GameState = GameState.InProgress;
            }

            if (game.GameState == GameState.InProgress)
            {
                // set player turn
                // flip that player's top card from the face down pile and move it into the face up pile
                // wait 5 seconds for anyone to press their 123456 key for Snap

                // If snap, give the person who snapped all the cards from the player's face up pile who the card snapped against, plus their own, and place these at the bottom of the facedown pile
                // If not snap, ?

                // Check for winner post successful snap
                if (CheckForWinner(players))
                {
                    game.GameState = GameState.Finish;
                }
            }

            if (game.GameState == GameState.Finish)
            {
                // declare winner
                // reset game state to the beginning
            }

        }
        
        public static bool CheckForWinner(List<Player> players)
        {
            foreach(var player in players)
            {
                if (player.FaceDownCards.Count == 52)
                {
                    Console.WriteLine($"Congratulations - Player {player.PlayerNumber} is the winner!");
                    return true;
                }
            }

            return false;
        }

    }
}
