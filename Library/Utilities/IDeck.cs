﻿using System.Collections.Generic;

namespace Library.Utilities
{
    public interface IDeck
    {
        List<string> cardSignVariations { get; }
        List<string> cardSuitVariations { get; }
        List<ICard> deckOfCards { get; set; }

        IPlayer Player { get; set; }

        void ConstructDeck();
        void DealCards();
    }
}