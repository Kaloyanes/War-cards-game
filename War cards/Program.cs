using System;
using System.Collections;

namespace War_cards
{
    internal class Program
    {
        private static int cards = 52;
        private static int player1 = 0;
        private static int player2 = 0;

        private static Queue player1cards = new Queue();
        private static Queue player2cards = new Queue();


        private static int player1wins = 0;
        private static int player2wins = 0;

        static void Main(string[] args)
        {
            var card = new Card();
            for (int i = 0; i < cards; i++)
            {
                var cards = card.GetCard();

                if (i % 2 == 0)
                {
                    player1cards.Enqueue(cards);
                    continue;
                }

                player2cards.Enqueue(cards);
            }
            Console.WriteLine("Cards are distributed");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine(player1cards.Peek());

            /*while (player1 != 0 || player2 != 0)
            {
                if (player1cards == player2cards)
                {
                    
                }

                ShowCards(player1cards, player2cards);
            }*/
        }

        public static void ShowCards(Queue player1, Queue player2)
        {
            string card = "";
            // switch (player1)
            // {
            //     case 11:
            //         card = "J";
            //         break;
            //
            //     case 12:
            //         card = "Q";
            //         break;
            //
            //     case 13:
            //         card = "K";
            //         break;
            //
            //     case 14:
            //         card = "A";
            //         break;
            // }
        }
    }
}
