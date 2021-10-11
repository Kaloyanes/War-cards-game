using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace War_cards
{
    public class Card
    {
        private List<int> values = new List<int>()
        {
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
        };

        public int GetCard()
        {
            var rnd = new Random();
            var random = rnd.Next(2, 14);
            return values[random];
        }
    }
}