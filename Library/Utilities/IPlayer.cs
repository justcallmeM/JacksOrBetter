using System.Collections.Generic;

namespace Library.Utilities
{
    public interface IPlayer
    {
        List<ICard> hand { get; set; }
        //void changeCards();
    }
}