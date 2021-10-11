using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace War_cards
{
    public class Card
    {
        public Queue<int> cards = new Queue<int>();

        public void AddCards()
        {
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cards.Enqueue(i);   
                }
            }
        }
    }
}