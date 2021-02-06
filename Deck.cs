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

        // TODO: make a better shuffle algorythm
        /// <summary>
        /// shuffle the deck, this is a trash algorythm but its purpose is to show how trash it is.
        /// </summary>
        public void Shuffle()
        {
            CardCollection newDeck = new CardCollection();
            bool[] assigned = new bool[SIZE_OF_DECK];
            Random sourceGen = new Random();

            for (int i = 0; i < SIZE_OF_DECK; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(SIZE_OF_DECK);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
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
    }
}
