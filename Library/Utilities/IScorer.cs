using System.Collections.Generic;

namespace Library.Utilities
{
    public interface IScorer
    {
        int AssignScore(Scorer.Combination combination);
        bool CheckFlush(List<ICard> hand);
        bool CheckFullHouse(List<int> hand);
        int CheckHand(Deck deck);
        bool CheckJackOrBetter(List<int> hand);
        bool CheckPair(List<int> hand);
        bool CheckQuads(List<int> hand);
        bool CheckStraight(List<int> hand);
        bool CheckStraightFlush(List<int> hand, List<ICard> cards);
        bool CheckTrips(List<int> hand);
        bool CheckTwoPair(List<int> hand);
    }
}