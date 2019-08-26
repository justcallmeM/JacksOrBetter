using Library.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class TestLogic
    {
        Deck deck = new Deck();
        Scorer scorer = new Scorer();

        [Fact]
        public void DeckConstructionTest()
        {
            //Arrange
            Card S2 = new Card() { suit = "S", sign = "2" };
            Card S3 = new Card() { suit = "S", sign = "3" };
            Card S4 = new Card() { suit = "S", sign = "4" };
            Card S5 = new Card() { suit = "S", sign = "5" };
            Card S6 = new Card() { suit = "S", sign = "6" };
            Card S7 = new Card() { suit = "S", sign = "7" };
            Card S8 = new Card() { suit = "S", sign = "8" };
            Card S9 = new Card() { suit = "S", sign = "9" };
            Card S10 = new Card() { suit = "S", sign = "10" };
            Card SJ = new Card() { suit = "S", sign = "J" };
            Card SQ = new Card() { suit = "S", sign = "Q" };
            Card SK = new Card() { suit = "S", sign = "K" };
            Card SA = new Card() { suit = "S", sign = "A" };

            Card H2 = new Card() { suit = "H", sign = "2" };
            Card H3 = new Card() { suit = "H", sign = "3" };
            Card H4 = new Card() { suit = "H", sign = "4" };
            Card H5 = new Card() { suit = "H", sign = "5" };
            Card H6 = new Card() { suit = "H", sign = "6" };
            Card H7 = new Card() { suit = "H", sign = "7" };
            Card H8 = new Card() { suit = "H", sign = "8" };
            Card H9 = new Card() { suit = "H", sign = "9" };
            Card H10 = new Card() { suit = "H", sign = "10" };
            Card HJ = new Card() { suit = "H", sign = "J" };
            Card HQ = new Card() { suit = "H", sign = "Q" };
            Card HK = new Card() { suit = "H", sign = "K" };
            Card HA = new Card() { suit = "H", sign = "A" };

            Card C2 = new Card() { suit = "C", sign = "2" };
            Card C3 = new Card() { suit = "C", sign = "3" };
            Card C4 = new Card() { suit = "C", sign = "4" };
            Card C5 = new Card() { suit = "C", sign = "5" };
            Card C6 = new Card() { suit = "C", sign = "6" };
            Card C7 = new Card() { suit = "C", sign = "7" };
            Card C8 = new Card() { suit = "C", sign = "8" };
            Card C9 = new Card() { suit = "C", sign = "9" };
            Card C10 = new Card() { suit = "C", sign = "10" };
            Card CJ = new Card() { suit = "C", sign = "J" };
            Card CQ = new Card() { suit = "C", sign = "Q" };
            Card CK = new Card() { suit = "C", sign = "K" };
            Card CA = new Card() { suit = "C", sign = "A" };

            Card D2 = new Card() { suit = "D", sign = "2" };
            Card D3 = new Card() { suit = "D", sign = "3" };
            Card D4 = new Card() { suit = "D", sign = "4" };
            Card D5 = new Card() { suit = "D", sign = "5" };
            Card D6 = new Card() { suit = "D", sign = "6" };
            Card D7 = new Card() { suit = "D", sign = "7" };
            Card D8 = new Card() { suit = "D", sign = "8" };
            Card D9 = new Card() { suit = "D", sign = "9" };
            Card D10 = new Card() { suit = "D", sign = "10" };
            Card DJ = new Card() { suit = "D", sign = "J" };
            Card DQ = new Card() { suit = "D", sign = "Q" };
            Card DK = new Card() { suit = "D", sign = "K" };
            Card DA = new Card() { suit = "D", sign = "A" };

            List<Card> cards = new List<Card>() { S2, S3, S4, S5, S6, S7, S8, S9, S10, SJ, SQ, SK, SA,
                                                  H2, H3, H4, H5, H6, H7, H8, H9, H10, HJ, HQ, HK, HA,
                                                  D2, D3, D4, D5, D6, D7, D8, D9, D10, DJ, DQ, DK, DA,
                                                  C2, C3, C4, C5, C6, C7, C8, C9, C10, CJ, CQ, CK, CA };
            //Act
            deck.ConstructDeck();
            //Assert
            CollectionAssert.AreEquivalent(cards, deck.deckOfCards);
        }

        //Arrange-Part1/2
        [Xunit.Theory]
        [InlineData((object)(new object[] { 11, 2, 3, 4, 5 }),  8)] //JackOrMore
        [InlineData((object)(new object[] { 11, 11, 4, 4, 5 }), 7)] //TwoPair
        [InlineData((object)(new object[] { 11, 11, 11, 4, 5 }), 6)] //Triple
        [InlineData((object)(new object[] { 2, 3, 4, 5, 6 }), 5)] //Straight
        [InlineData((object)(new object[] { 9, 2, 3, 4, 5 }), 4)] //Flush
        [InlineData((object)(new object[] { 2, 2, 3, 3, 3 }), 3)] //FullHouse
        [InlineData((object)(new object[] { 11, 11, 11, 11, 5 }), 2)] //Quads
        [InlineData((object)(new object[] { 2, 3, 4, 5, 6 }), 1)] //StraightFlush
        public void AssignScoreTest_WhenProvidingAHandCheckIfTheReturnValueIsCorrect(object[] a, int expected)
        {
            //TODO: check for flush.
            //Arrange-Part2/2
            List<int> hand = new List<int>();
            foreach(int number in a)
            {
                hand.Add(number);
            }
            //Act
            int result = scorer.HandValue(hand, deck);
            //Assert
            Xunit.Assert.Equal(expected, result);
        }
    }
}
