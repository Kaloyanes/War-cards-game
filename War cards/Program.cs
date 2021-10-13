using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

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
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();


            int rounds = 0;

            while (true)
            {
                if (player1cards.Count == 0 || player2cards.Count == 0) break;
                rounds++;
                PlayGame(rounds);
            }

            Console.WriteLine($"Player 1 round wins: {player1wins} | Player 2 round wins: {player2wins}");
        }
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

        public static void PlayGame(int rounds)
        {
            if (player1cards.Count == 0 || player2cards.Count == 0) return;
            string card = Convert(player1cards);
            string card2 = Convert(player2cards);

            Console.WriteLine($"Player 1 card:{card}  |  Player 2 card: {card2}");

            var winner = Check(rounds);
            Console.WriteLine($"{winner} Wins round #{rounds}!");
            Console.WriteLine();
        }

        public static string Check(int rounds)
        {
            string winner = "";

            int player1num = player1cards.Peek();
            int player2num = player2cards.Peek();
            if (player1num > player2num)
            {
                winner = "Player 1";
                player1wins++;
                // The won cards are going back to the queue to be used again later
                player1cards.Enqueue(player2num);
                player1cards.Enqueue(player1num);

                // Removing the top cards so the cards don't repeat
                player1cards.Dequeue();
                player2cards.Dequeue();
            }
            else if (player1num < player2num)
            {
                winner = "Player 2";
                player2wins++;

                // The won cards are going back to the queue to be used again later
                player2cards.Enqueue(player1num);
                player2cards.Enqueue(player2num);

                // Removing the top cards so the cards don't repeat
                player1cards.Dequeue();
                player2cards.Dequeue();
            }
            else
            {
                player1cards.Dequeue();
                player2cards.Dequeue();

                // Going into a recursive function until a winner is decided
                return War(rounds);
            }

            return winner;
        }

        public static string War(int rounds)
        {
            if (player1cards.Count == 0 && player1cards.Count == 0) return "";

            string winner = "";

            int player1num = player1cards.Peek();
            int player2num = player2cards.Peek();

            if (player1num > player2num)
            {
                winner = "Player 1";
                player1wins++;

                // The won cards are going back to the queue to be used again later
                player1cards.Enqueue(player2num);
                player1cards.Enqueue(player1num);
                
                // Removing the top cards so the cards don't repeat
                player1cards.Dequeue();
                player2cards.Dequeue();
            }
            else if (player1num < player2num)
            {
                winner = "Player 2";
                player2wins++;

                // The won cards are going back to the queue to be used again later
                player2cards.Enqueue(player1num);
                player2cards.Enqueue(player2num);

                // Removing the top cards so the cards don't repeat
                player1cards.Dequeue();
                player2cards.Dequeue();
            }
            else
            {
                player2cards.Dequeue();
                player1cards.Dequeue();

                // Going into a recursive function until a winner is decided
                return War(rounds);
            }

            return winner;
        }

        // Converts card to symbols
        public static string Convert(Queue<int> player)
        {
            string playercard = "";
            switch (player.Peek())
            {
                case 11:
                    playercard = "J";
                    break;

                case 12:
                    playercard = "Q";
                    break;

                case 13:
                    playercard = "K";
                    break;

                case 14:
                    playercard = "A";
                    break;

                default:
                    playercard = player.Peek().ToString();
                    break;
            }

            return playercard;
        }
    }
}
