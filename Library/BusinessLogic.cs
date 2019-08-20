using Library.Utilities;
using System;

namespace Library
{
    public class BusinessLogic : IBusinessLogic
    {
        IDeck _deck;

        public BusinessLogic(IDeck deck)
        {
            _deck = deck;
        }
        public void OutputResults()
        {
            _deck.ConstructDeck();

            foreach(Card card in _deck.deckOfCards)
            {
                Console.WriteLine(card.suit+ card.sign);
            }
        }
    }
}
