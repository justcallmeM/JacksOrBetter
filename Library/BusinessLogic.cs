using Library.Utilities;
using System;

namespace Library
{
    public class BusinessLogic : IBusinessLogic
    {
        IScorer _scorer;
        IScoreCalculations _scoreCalculations;

        public BusinessLogic(IScorer scorer, IScoreCalculations scoreCalculations)
        {
            _scorer = scorer;
            _scoreCalculations = scoreCalculations;
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

            int result = _scoreCalculations.AssignScore((Scorer.Combination)_scorer.HandValue(_scorer.CheckHand(_deck),_deck));

            Console.WriteLine("your score:" + result);
        }
    }
}
