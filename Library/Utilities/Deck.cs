using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities
{
    public class Deck : IDeck
    {
        public Player Player { get; set; }
        public List<ICard> DeckOfCards { get; set; }
        public List<string> CardSignVariations { get { return new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; } }
        public List<string> CardSuitVariations { get { return new List<string>() { "D", "C", "S", "H" }; } }

        Random random = new Random();

        public Deck()
        {
            Player = new Player();
            DeckOfCards = new List<ICard>();
        }

        //Programos paleidime - sis metodas - 1
        public void ConstructDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                ICard _newcard = new Card();

                do
                {
                    _newcard.Sign = CardSignVariations[random.Next(0, 13)];
                    _newcard.Suit = CardSuitVariations[random.Next(0, 4)];
                }
                while (DeckOfCards.Exists(x => x.Sign == _newcard.Sign && x.Suit == _newcard.Suit));

                DeckOfCards.Add(_newcard);
            }
        }
        //Programos paleidime - sis metodas - 2
        public void DealCards()
        {
            int total = 51;

            for(int i = 0; i < 5; i++)
            {
                int number = random.Next(0, total);
                Player.Hand.Add(DeckOfCards[number]);
                DeckOfCards.Remove(DeckOfCards[number]);
                total--;
            }
        }
        public void ChangeCards()
        {
            //missing exception
            int total = 46;
            Console.WriteLine("kokias kortas norėtumėte pakeisti?");
            string cards = Console.ReadLine();
            int length = cards.Length;
            List<ICard> cardsToRemove = new List<ICard>();

            //parse the string and add the cards to the which cards would the player like to remove list.
            for(int i=0; i<length; i++)
            {
                Int32.TryParse(cards.Substring(i, 1), out int result);
                cardsToRemove.Add(Player.Hand[result]);
            }

            foreach(ICard card in cardsToRemove)
            {
                Player.Hand.Remove(card);
            }
            //add different cards, but the same amount that was discarded to the hand of the player.
            for (int i = 0; i < length; i++)
            {
                int number = random.Next(0, total);
                Player.Hand.Add(DeckOfCards[number]);
                DeckOfCards.Remove(DeckOfCards[number]);
                total--;
            }
        }
    }
}
