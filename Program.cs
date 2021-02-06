using System;

namespace OOPFinalProject
{
    /*
     * As of 2020/02/06 this just shows that things work.
     * btw its pretty rare to get a flush even in the 100 decks
     */
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++) // try to get a flush in 100 shuffled decks
            {
                Console.Write(i + ":");
                TryFlush();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void TryFlush()
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();

            int numberOfDraws = (int)Math.Round((double)(Deck.SIZE_OF_DECK / 5), 0); // Can draw 5 cards 10 times in a deck of 52
            bool isFlush = false;

            for (int i = 0; i < numberOfDraws; i++)
            {
                try
                {
                    int sameSuitCount = 0;
                    Card tempCard = myDeck.GetCard(i * 5);
                    Suit tempSuit = tempCard.Suit;
                    for (int j = 1; j <= 4; j++)
                    {
                        if (myDeck.GetCard(i * 5 + j).Suit == tempSuit) // same suit as temp card
                        {
                            sameSuitCount++;
                        }
                        if (sameSuitCount == 4) // the other 4 cards are the same suit as the first of the 5 draws
                        {
                            isFlush = true;
                            Console.WriteLine("*******************\n");
                            Console.WriteLine("Flush!!!");
                            for (int z = 0; z < 5; z++) // printing out the last 5 cards
                            {
                                Console.WriteLine(myDeck.GetCard(i * 5 + j - z).ToString());
                            }
                            return; // exit out of the method
                        }
                    }
                }
                catch (IndexOutOfRangeException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            if (isFlush == false) // if no flush in this shuffle, show this msg
            {
                Console.WriteLine("No Flush");
            }
        }
    }
}
