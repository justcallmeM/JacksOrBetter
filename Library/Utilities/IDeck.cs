using System.Collections.Generic;

namespace Library.Utilities
{
    public interface IDeck
    {
        Player Player { get; set; }
        List<string> CardSignVariations { get; }
        List<string> CardSuitVariations { get; }
        List<ICard> DeckOfCards { get; set; }

        void ConstructDeck();
        void DealCards();
        void ChangeCards();
    }
}