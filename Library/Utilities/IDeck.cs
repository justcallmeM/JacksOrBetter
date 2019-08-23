using System.Collections.Generic;

namespace Library.Utilities
{
    public interface IDeck
    {
        Player Player { get; set; }
        List<string> cardSignVariations { get; }
        List<string> cardSuitVariations { get; }
        List<ICard> deckOfCards { get; set; }

        void ConstructDeck();
        void DealCards();
        void ChangeCards();
    }
}