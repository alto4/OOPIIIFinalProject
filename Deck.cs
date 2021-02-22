/*  Deck.cs - Implements a class that acts as a collection of 52 Card objects.
 * 
 *  Author:     Eduardo San Martin Celi
 *  Since:      2020/02/06
 */

using System;

namespace OOPFinalProject
{
    /// <summary>
    /// Deck class holds an array of Card objects
    /// </summary>
    public class Deck : ICloneable
    {
        // define the standard size of a deck
        public static readonly int SIZE_OF_DECK = 52;

        // instantiate a CardCollection object
        private CardCollection cards = new CardCollection();

        /// <summary>
        /// Default constructor for a deck of cards.
        /// </summary>
        public Deck()
        {
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit))) // for each suit in the Suit enum
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank))) // for each rank in the Rank enum
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        /// <summary>
        /// return the card at the param index
        /// </summary>
        /// <param name="cardIndex">The cards index</param>
        /// <returns>The Card at this index</returns>
        public Card GetCard(int cardIndex)
        {
            if (cardIndex >= 0 && cardIndex <= 51)
            {
                return cards[cardIndex]; // card number 0 to SIZE_OF_DECK
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format(" * Card index must be between {0} and {1}", 0, SIZE_OF_DECK - 1));
            }
        }

        public Deck(bool isAceHigh) : this() // high aces
        {
            Card.isAceHigh = isAceHigh;
        }

        public Deck(bool useTrump, Suit trumpSuit) : this() // setting the trump
        {
            Card.useTrumps = useTrump;
            Card.trumpSuit = trumpSuit;
        }

        public Deck(bool isAceHigh, bool useTrumps, Suit trumpSuit) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trumpSuit = trumpSuit;
        }

        /// <summary>
        /// swaps each card at an index with a random card, 5 times.
        /// </summary>
        public void Shuffle()
        {
            CardCollection randomDeck = new CardCollection();
            Random randSource = new Random();
            int randIndex = 0;
            Card tempCardHolder;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < SIZE_OF_DECK; i++)
                {
                    // Random index for each position
                    randIndex = i + randSource.Next(SIZE_OF_DECK - i);

                    // swap the cards
                    tempCardHolder = cards[randIndex];
                    cards[randIndex] = cards[i];
                    cards[i] = tempCardHolder;
                }
            }
            // copy the random deck to this deck
            randomDeck.CopyTo(cards);
        }

        /// <summary>
        /// Creates a deck for deep cloning
        /// </summary>
        /// <param name="newCards">The new cards</param>
        private Deck(CardCollection newCards)
        {
            cards = newCards;
        }

        /// <summary>
        /// creates a new deck by passing the private constructor a set of cards
        /// </summary>
        /// <returns>a new deck</returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as CardCollection);
            return newDeck;
        }

        public override string ToString()
        {
            string allTheCards = "";

            foreach (Card card in cards)
            {
                allTheCards += card.ToString() + "\n";
            }

            return allTheCards;
        }
    }
}
