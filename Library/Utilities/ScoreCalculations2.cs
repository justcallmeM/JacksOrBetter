using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities
{
    public class ScoreCalculations2 : IScoreCalculations
    {
        public int AssignScore(Scorer.Combination combination)
        {
            switch (combination)
            {
                case Scorer.Combination.RoyalFlush:
                    return 1600;
                case Scorer.Combination.StraightFlush:
                    return 100;
                case Scorer.Combination.FourOfaKind:
                    return 50;
                case Scorer.Combination.FullHouse:
                    return 18;
                case Scorer.Combination.Flush:
                    return 12;
                case Scorer.Combination.Straight:
                    return 8;
                case Scorer.Combination.ThreeOfaKind:
                    return 6;
                case Scorer.Combination.TwoPair:
                    return 4;
                case Scorer.Combination.JacksOrBetter:
                    return 2;
                case Scorer.Combination.Other:
                    return 0;
                default:
                    return 404;
            }
        }
    }
}
