using Library.Utilities;
using System;

namespace Library
{
    public class BusinessLogic : IBusinessLogic
    {
        IScorer _scorer;

        public BusinessLogic(IScorer scorer)
        {
            _scorer = scorer;
        }
        public void OutputResults()
        {
            Deck _deck = new Deck();

            _deck.ConstructDeck();
            _deck.DealCards();

            foreach (ICard card in _deck.Player.hand)
            {
                Console.WriteLine(card.suit + card.sign);
            }

            _deck.ChangeCards();

            foreach (ICard card in _deck.Player.hand)
            {
                Console.WriteLine(card.suit + card.sign);
            }

            int result = _scorer.AssignScore((Scorer.Combination)_scorer.CheckHand(_deck));

            Console.WriteLine("your score:" + result);
        }
    }
}
