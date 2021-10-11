using System;
using System.Collections.Generic;
using System.Linq;

namespace War_cards
{
    internal class Program
    {
        private static int cards = 52;
        private static Queue<int> player1cards = new Queue<int>();
        private static Queue<int> player2cards = new Queue<int>();


        private static int player1wins = 0;
        private static int player2wins = 0;

        private static Random rnd = new Random();
        static public void Shuffle(int[] deck)
        {
            for (int n = deck.Length - 1; n > 0; --n)
            {
                int k = rnd.Next(n + 1);
                int temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }

        static void Main(string[] args)
        {
            var card = new Card();
            card.AddCards();
            var deck = card.cards.ToArray();
            Console.WriteLine(deck.Length);
            Shuffle(deck);
            for (int i = 0; i < cards; i++)
            {
                if (i % 2 == 0)
                {
                    player1cards.Enqueue(deck[i]);
                    continue;
                }

                player2cards.Enqueue(deck[i]);
            }

            Console.WriteLine("Cards are distributed");
            Pause();
            Console.Clear();
            int rounds = 0;

            while (player1cards.Count != 0 || player2cards.Count != 0)
            {
                if (player1cards.Count == 0 || player2cards.Count == 0) break;
                rounds++;
                PlayGame(rounds);
            }
            
        }

        public static void PlayGame(int rounds)
        {
            if (player1cards.Count == 0 || player2cards.Count == 0) return;
            string card;
            switch (player1cards.Peek())
            {
                case 11:
                    card = "J";
                    break;
            
                case 12:
                    card = "Q";
                    break;
            
                case 13:
                    card = "K";
                    break;
            
                case 14:
                    card = "A";
                    break;

                default:
                    card = player1cards.Peek().ToString();
                    break;
            }

            if (player1cards.Count == 0 || player2cards.Count == 0) return;
            string card2;
            switch (player2cards.Peek())
            {
                case 11:
                    card2 = "J";
                    break;

                case 12:
                    card2 = "Q";
                    break;

                case 13:
                    card2 = "K";
                    break;

                case 14:
                    card2 = "A";
                    break;

                default:
                    card2 = player2cards.Peek().ToString();
                    break;


            }

            Console.WriteLine($"Player 1 card:{card}  |  Player 2 card: {card2}");

            string winner = "";
            if (player1cards.Peek() > player2cards.Peek())
            {
                winner = "Player 1";
                player1wins++;
                player1cards.Enqueue(player2cards.Peek());
                player1cards.Dequeue();
                player2cards.Dequeue();
            }
            else if (player1cards.Peek() < player2cards.Peek())
            {
                winner = "Player 2";
                player2wins++;
                player2cards.Enqueue(player1cards.Peek());
                player2cards.Dequeue();
                player1cards.Dequeue();
            }
            else if (player1cards.Peek() == player2cards.Peek())
            {
                player2cards.Dequeue();
                player1cards.Dequeue();
                War(rounds);
                return;
            }

            Console.WriteLine($"{winner} Wins round #{rounds}!");
            Console.WriteLine();
        }

        public static void War(int rounds)
        {
            string winner = "";
            if (player1cards.Count == 0 || player2cards.Count == 0) return;

            var player1card = "";
            var player2card = "";

            var player1num = player1cards.Peek();
            var player2num = player2cards.Peek();
            switch (player1num)
            {
                case 11:
                    player1card = "J";
                    break;

                case 12:
                    player1card = "Q";
                    break;

                case 13:
                    player1card = "K";
                    break;

                case 14:
                    player1card = "A";
                    break;

                default:
                    player1card = player1cards.Peek().ToString();
                    break;
            }

            switch (player2num)
            {
                case 11:
                    player2card = "J";
                    break;

                case 12:
                    player2card = "Q";
                    break;

                case 13:
                    player2card = "K";
                    break;

                case 14:
                    player2card = "A";
                    break;

                default:
                    player2card = player2cards.Peek().ToString();
                    break;
            }
            if (player1num > player2num)
            {
                winner = "Player 1";
                player1wins++;
                player1cards.Enqueue(player2num);
                player1cards.Enqueue(player1num);
                player2cards.Dequeue();
            }
            else if (player1num < player2num)
            {
                winner = "Player 2";
                player2wins++;
                player2cards.Enqueue(player1num);
                player2cards.Enqueue(player2num);
                player1cards.Dequeue();
            }
            else
            {
                player2cards.Dequeue();
                player1cards.Dequeue();
                War(rounds);
            }

            Console.WriteLine($"Player 1 card:{player1card}  |  Player 2 card: {player2card}");
            Console.WriteLine($"{winner} Wins round #{rounds}!");
            Console.WriteLine();
        }

        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
