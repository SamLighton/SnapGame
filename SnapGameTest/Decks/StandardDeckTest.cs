using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGame.Decks;

namespace SnapGameTest
{
    [TestClass]
    public class StandardDeckTest
    {
        [TestMethod]
        public void FillDeck()
        {
            // arrange
            var deck = new StandardDeck();

            // act
            deck.FillDeck();

            // assert
            Assert.AreEqual(deck.Cards.Count, 52);
        }

        [TestMethod]
        [Ignore]
        public void ShuffleDeck()
        {
            // arrange
            var deck = new StandardDeck();

            // act
            deck.FillDeck();
            deck.Shuffle();

            // assert
            // not sure how to test this appropriately
        }
    }
}
