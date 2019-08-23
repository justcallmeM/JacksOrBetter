using Library.Utilities;
using System;

namespace Library
{
    public class BusinessLogic : IBusinessLogic
    {
        IDeck _deck;
        IPlayer _player;

        public BusinessLogic(IDeck deck, IPlayer player)
        {
            _deck = deck;
            _player = player;
        }
        public void OutputResults()
        {
            _deck.ConstructDeck();

            _deck.DealCards();

            _player = _deck.Player;

            foreach(ICard card in _player.hand)
            {
                Console.WriteLine(card.suit + card.sign + Environment.NewLine);
            }

        }
    }
}
