using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities
{
    public class Player
    {
        public List<ICard> Hand { get; set; }

        public Player()
        {
            Hand = new List<ICard>();
        }
    }
}
