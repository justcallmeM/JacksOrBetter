using System.Collections.Generic;

namespace Library.Utilities
{
    public interface IScorer
    {
        bool CheckFlush(List<ICard> hand);
        bool CheckFullHouse(List<int> hand);
        List<int> CheckHand(Deck deck);
        int HandValue(List<int> hand, Deck deck);
        bool CheckJackOrBetter(List<int> hand);
        bool CheckPair(List<int> hand);
        bool CheckQuads(List<int> hand);
        bool CheckStraight(List<int> hand);
        bool CheckStraightFlush(List<int> hand, List<ICard> cards);
        bool CheckTrips(List<int> hand);
        bool CheckTwoPair(List<int> hand);
    }
}