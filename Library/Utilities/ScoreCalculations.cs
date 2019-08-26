using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities
{
    public class ScoreCalculations : IScoreCalculations
    {
        public int AssignScore(Scorer.Combination combination)
        {
            switch (combination)
            {
                case Scorer.Combination.RoyalFlush:
                    return 800;
                case Scorer.Combination.StraightFlush:
                    return 50;
                case Scorer.Combination.FourOfaKind:
                    return 25;
                case Scorer.Combination.FullHouse:
                    return 9;
                case Scorer.Combination.Flush:
                    return 6;
                case Scorer.Combination.Straight:
                    return 4;
                case Scorer.Combination.ThreeOfaKind:
                    return 3;
                case Scorer.Combination.TwoPair:
                    return 2;
                case Scorer.Combination.JacksOrBetter:
                    return 1;
                case Scorer.Combination.Other:
                    return 0;
                default:
                    return 404;
            }
        }
    }
}
