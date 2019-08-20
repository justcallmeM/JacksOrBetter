using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities
{
    public class Deck : IDeck
    {
        public List<ICard> deckOfCards { get; set; }
        public List<string> cardSignVariations { get { return new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; } }
        public List<string> cardSuitVariations { get { return new List<string>() { "D", "C", "S", "H" }; } }

        public void ConstructDeck()
        {
            deckOfCards = new List<ICard>();
            Random random = new Random();

            for (int i = 0; i < 52; i++)
            {
                ICard _newcard = new Card();

                do
                {
                    _newcard.sign = cardSignVariations[random.Next(0, 13)];
                    _newcard.suit = cardSuitVariations[random.Next(0, 4)];
                }
                while (deckOfCards.Exists(x => x.sign == _newcard.sign && x.suit == _newcard.suit));

                deckOfCards.Add(_newcard);
            }
        }
    }
}
