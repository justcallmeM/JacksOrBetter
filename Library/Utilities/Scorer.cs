using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Utilities
{
    public class Scorer : IScorer
    {
        public enum Combination { RoyalFlush, StraightFlush, FourOfaKind, FullHouse, Flush, Straight, ThreeOfaKind, TwoPair, JacksOrBetter, Other }

        public int CheckHand(Deck deck)
        {
            List<int> hand = new List<int>();
            int scoreID = 0;

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

            bool jack = CheckJackOrBetter(hand);
            //bool pair = CheckPair(hand);
            bool twoPair = CheckTwoPair(hand);
            bool triple = CheckTrips(hand);
            bool straight = CheckStraight(hand);
            bool flush = CheckFlush(deck.Player.hand);
            bool fullHouse = CheckFullHouse(hand);
            bool quads = CheckQuads(hand);
            bool straightFlush = CheckStraightFlush(hand, deck.Player.hand);

            if (straightFlush) {scoreID = 1;}
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

        //paduosi enum'a kazkoki kai metodas apdoros rankoje turimas kortas.
        public int AssignScore(Combination combination)
        {
            switch (combination)
            {
                case Combination.RoyalFlush:
                    return 800;
                case Combination.StraightFlush:
                    return 50;
                case Combination.FourOfaKind:
                    return 25;
                case Combination.FullHouse:
                    return 9;
                case Combination.Flush:
                    return 6;
                case Combination.Straight:
                    return 4;
                case Combination.ThreeOfaKind:
                    return 3;
                case Combination.TwoPair:
                    return 2;
                case Combination.JacksOrBetter:
                    return 1;
                case Combination.Other:
                    return 0;
                default:
                    return 404;
            }
        }
    }
}
