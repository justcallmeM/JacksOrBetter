using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Utilities
{
    public class Scorer : IScorer
    {
        public enum Combination { RoyalFlush, StraightFlush, FourOfaKind, FullHouse, Flush, Straight, ThreeOfaKind, TwoPair, JacksOrBetter, Other }

        public List<int> CheckHand(Deck deck)
        {
            List<int> hand = new List<int>();

            foreach (ICard card in deck.Player.hand)
            {
                switch (card.sign)
                {
                    case "J":
                        hand.Add(10);
                        break;
                    case "Q":
                        hand.Add(11);
                        break;
                    case "K":
                        hand.Add(12);
                        break;
                    case "A":
                        hand.Add(13);
                        hand.Add(1);
                        break;
                    default:
                        Int32.TryParse(card.sign, out int number);
                        hand.Add(number);
                        break;
                }
            }

            hand.Sort();

            return hand;
        }

        public int HandValue(List<int> hand, Deck deck)
        {
            int scoreID = 0;

            bool jack = CheckJackOrBetter(hand);
            bool twoPair = CheckTwoPair(hand);
            bool triple = CheckTrips(hand);
            bool straight = CheckStraight(hand);
            bool flush = CheckFlush(deck.Player.hand);
            bool fullHouse = CheckFullHouse(hand);
            bool quads = CheckQuads(hand);
            bool straightFlush = CheckStraightFlush(hand, deck.Player.hand);
            //bool pair = CheckPair(hand);

            if (straightFlush) { scoreID = 1; }
            else if (quads) { scoreID = 2; }
            else if (fullHouse) { scoreID = 3; }
            else if (flush) { scoreID = 4; }
            else if (straight) { scoreID = 5; }
            else if (triple) { scoreID = 6; }
            else if (twoPair) { scoreID = 7; }
            else if (jack) { scoreID = 8; }
            else { scoreID = 9; }
            //else if (pair) { scoreID = ; }

            return scoreID;
        }

        public bool CheckJackOrBetter(List<int> hand)
        {
            return hand.Contains(1) || hand.Contains(10) || hand.Contains(11) || hand.Contains(12) || hand.Contains(13);
        }

        public bool CheckPair(List<int> hand)
        {
            return hand.GroupBy(card => card).Count(group => group.Count() == 2) == 1;
        }

        public bool CheckTwoPair(List<int> hand)
        {
            return hand.GroupBy(card => card).Count(group => group.Count() >= 2) == 2;
        }

        public bool CheckTrips(List<int> hand)
        {
            return hand.GroupBy(card => card).Any(group => group.Count() == 3);
        }

        public bool CheckStraight(List<int> hand)
        {
            return hand.Zip(hand.Skip(1), (a, b) => (a + 1) == b).All(x => x);
        }

        public bool CheckQuads(List<int> hand)
        {
            return hand.GroupBy(card => card).Any(group => group.Count() == 4);
        }

        public bool CheckFullHouse(List<int> hand)
        {
            return CheckPair(hand) && CheckTrips(hand);
        }

        public bool CheckFlush(List<ICard> hand)
        {
            return hand.GroupBy(card => card.suit).Count(group => group.Count() >= 5) == 1;
        }

        public bool CheckStraightFlush(List<int> hand, List<ICard> cards)
        {
            return CheckFlush(cards) && CheckStraight(hand);
        }
    }
}
