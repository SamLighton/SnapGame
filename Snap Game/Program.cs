namespace SnapGame
{
    using SnapGame.Cards;
    using SnapGame.Decks;
    using SnapGame.Game;
    using SnapGame.Players;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var card = new Card(CardValue.Two, CardSuit.Spades);

            var deck = new StandardDeck();

            var game = new Game.Game(GameType.StandardSnap);

            var players = new List<Player>();

            string winningPlayerName;

            Console.WriteLine($"{card.Value} of {card.Suit}");

            Console.WriteLine(deck.Cards.Count);

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
                Console.WriteLine($"Number of players registered as + { players.Count}");
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

            while (game.GameState == GameState.InProgress)
            {
                foreach(var player in players)
                {
                    player.DrawCard();

                    var drawnCard = player.FaceUpCards[player.FaceUpCards.Count - 1];

                    Console.WriteLine($"Player {player.PlayerNumber} drew card {drawnCard.Value} of {drawnCard.Suit}");


                    // wait for Console.ReadLine
                    // if press 1, snap check for player 1
                    // if press 2, snap check for player 2
                    // if press spacebar, go to next turn

                    do
                    {
                        Console.WriteLine("Enter 1 or 2 to call Snap or press Spacebar to pass to the next turn");
                    }
                    while (Console.ReadKey().Key != ConsoleKey.D1 && Console.ReadKey().Key != ConsoleKey.D2 && Console.ReadKey().Key != ConsoleKey.Spacebar);

                    // Change to case statement for players 1-8 - Haven't figured out a of a way to handle this regardless of player number yet

                    if (Console.ReadKey().Key == ConsoleKey.D1)
                    {
                        Console.WriteLine("Checking for snap player 1");
                        // checkForSnap();

                        if (CheckForSnap(players))
                        {
                            HandleSnap(players[0]);
                        }
                        else
                        {
                            Console.WriteLine("No Snap");
                        }
                    }
                    if (Console.ReadKey().Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("Checking for snap player 2");
                        // checkForSnap();

                        if (CheckForSnap(players))
                        {
                            HandleSnap(players[1]);
                        }
                        else
                        {
                            Console.WriteLine("No Snap");
                        }
                    }
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine("Moving to next turn");
                        // go to next turn
                    }
                    
                    if (CheckForWinner(players))
                    {
                        game.GameState = GameState.Finish;
                    }
                    
                }

                // set player turn
                // flip that player's top card from the face down pile and move it into the face up pile
                // wait 5 seconds for anyone to press their 12345678 key for Snap

                // If snap, give the person who snapped all the cards from the player's face up pile who the card snapped against, plus their own, and place these at the bottom of the facedown pile
                // If not snap, ?

                // Check for winner post successful snap
            }

            if (game.GameState == GameState.Finish)
            {
                foreach (var player in players)
                {
                    if (player.FaceDownCards.Count == deck.Cards.Count)
                    {
                        Console.WriteLine($"Player {player.PlayerNumber} wins!");
                    }
                }
                // reset game state to the beginning
            }
        }

        public static bool CheckForSnap(List<Player> players)
        {
            var topCardCollection = new List<Card>();

            foreach (var player in players)
            {
                if (player.FaceUpCards.Count > 0)
                {
                    topCardCollection.Add(player.FaceUpCards[player.FaceUpCards.Count - 1]);
                }
            }

            // Go through the topCardCollection list and check for any of the same card values across any two in the list

            var duplicateCardList = topCardCollection.GroupBy(x => x.Value)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key)
                    .ToList();

            Console.WriteLine($"duplicateCardList.Count = {duplicateCardList.Count}");

            if (duplicateCardList.Count > 0)
            {
                Console.WriteLine("Snap!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HandleSnap(Player callingPlayer)
        {
            // callingPlayer.FaceUp
            return true;
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
