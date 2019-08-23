using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities
{
    public class Player
    {
        public List<ICard> hand { get; set; }

        public Player()
        {
            hand = new List<ICard>();
        }
    }
}
