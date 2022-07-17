using System;
using System.Collections.Generic;

namespace Cards
{
    public class Card
    {
        public Card(string face, string suit)
        {
            this.face = face;
            Suit = suit;
        }

        public string face { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            string cardSuit = "";
            if (Suit == "S")
            {
                cardSuit = "\u2660";
            }
            else if (Suit == "C")
            {
                cardSuit = "\u2663";
            }
            else if (Suit == "D")
            {
                cardSuit = "\u2666";
            }
            else if (Suit == "H")
            {
                cardSuit = "\u2665";
            }

            return $"[{face}{cardSuit}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] cards = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<Card> coloda = new List<Card>();

            for (int i = 0; i < cards.Length; i += 2)
            {
                string face = cards[i];
                string color = cards[i + 1];

                try
                {
                    Card card = CreateCard(face, color);
                    coloda.Add(card);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(" ", coloda));
        }

        public static Card CreateCard(string face, string color)
        {
            FaceCheck(face);
            ColorCheck(color);

            Card card = new Card(face, color);
            return card;
        }

        public static void ColorCheck(string color)
        {
            if (color != "S" && color != "D" && color != "H" && color != "C")
            {
                throw new ArgumentException();
            }
        }

        public static void FaceCheck(string face)
        {
            if (face != "2" && face != "3" && face != "4" && face != "5" && face != "6" && face != "7" && face != "8" && face != "9" && face != "10" && face != "J" && face != "Q" && face != "K" && face != "A")
            {
                throw new ArgumentException();
            }
        }
    }
}
