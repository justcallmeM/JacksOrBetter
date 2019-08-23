using System;
using System.Collections.Generic;

namespace Library.Utilities
{
    public class Scorer : IScorer
    {
        public enum Combination { RoyalFlush, StraightFlush, FourOfaKind, FullHouse, Flush, Straight, ThreeOfaKind, TwoPair, JacksOrBetter, Other }

        public int CalculateScore(Deck deck)
        {
            List<int> hand = new List<int>();
            int score = 0;

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

            return score;
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
