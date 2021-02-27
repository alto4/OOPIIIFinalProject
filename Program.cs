using System;

namespace OOPFinalProject
{
    /// <summary>
    /// Entry point for the game
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n******************************************");
            Console.WriteLine("*  Durak Project: Console App Iteration  *");
            Console.WriteLine("******************************************\n");

            // Gameplay Pseudo-Code

            // GAME COMMENCES
            // 1. Deck of 36 cards is shuffled
            Deck testDeck1 = new Deck();

            Console.WriteLine("Testing new shuffle algorithm...");
            Console.WriteLine(testDeck1.ToString());
            testDeck1.Shuffle();

            Console.WriteLine("Results of the shuffle algorithm:");
            Console.WriteLine(testDeck1.ToString());

            // 2. Each player is dealt 6 cards
            CardCollection hand1 = new CardCollection();
            CardCollection hand2 = new CardCollection();

            for(int i = 0; i < 6; i++)
            {
                hand1.Add(testDeck1.DrawCard());
                hand2.Add(testDeck1.DrawCard());
            }
                    
            Console.WriteLine("Results of drawing cards and placing in player hand:");
            Console.WriteLine("Hand Length:" + hand1.Count);
            Console.WriteLine("\nUpdated Deck :" + testDeck1.ToString());

            // 3. Bottom card is turned to face up state
            Card startingTrumpCard = testDeck1.GetCard(0);
            startingTrumpCard.isFaceUp = true;

            Console.WriteLine("\nFirst card drawn! It's a {0} of {1}.", startingTrumpCard.Rank, startingTrumpCard.Suit);
            Console.WriteLine("Testing faceup status of first drawn card: " + startingTrumpCard.isFaceUp);

            // 4. Suit of first card to be drawn becomes trump suit
            Suit startingTrumpSuit = startingTrumpCard.Suit;
            Console.WriteLine("\nThe starting trump suit is {0}.", startingTrumpCard.Suit);

            // ATTACK ROUND
            // 5. First attack - current player attacks by playing a face-up card from their hand that trumps 
            Console.WriteLine("\nFirst players turn to attack");




            // 6. Defender attempts to beat attack card with a higher-ranking defence card

            // 7. Defender loses - pick up all defending and attaching cards played during the attach round

            // 8. Defender is successful (no other player attacks or they successfully defend 6th attack card) and attack/defence cards discarded

            // 9. Defender becomes attacker

            // 10. Each player draws cards from deck until they have 6 (or deck runs out) - order for draw is attacker, then clockwise, then defender

            // 11. REPEAT ATTACK ROUND STEPS 5-10

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Looks for a sequence that makes a flush in a random deck, user for testing
        /// </summary>
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
