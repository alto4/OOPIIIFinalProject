/*  CardCollection.cs - Implements a class that acts as a collection of any amount of Card objects.
 * 
 *  Author:     Eduardo San Martin Celi
 *  Since:      2020/02/06
 */

using System;
using System.Collections;

namespace OOPFinalProject
{
    /// <summary>
    /// Collection of cards
    /// </summary>
    public class CardCollection : CollectionBase, ICloneable
    {
        /// <summary>
        /// Add a card to the collection
        /// </summary>
        /// <param name="newCard">The new card to add</param>
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }

        /// <summary>
        /// Renive a card from the collection
        /// </summary>
        /// <param name="oldCard">The card to remove</param>
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }

        /// <summary>
        /// Cards indexer implementation
        /// </summary>
        /// <param name="cardIndex">The Card index in CardCollection</param>
        /// <returns>The Card that is at this index</returns>
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }

        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(CardCollection targetCards)
        {
            for (int i = 0; i < this.Count; i++)
            {
                targetCards[i] = this[i];
            }
        }

        /// <summary>
        /// Check to see if the Cards collection contains a particular card.
        /// This calls the Contains() method of the ArrayList for the collection,
        /// which you access through the InnerList property.
        /// </summary>
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }

        /// <summary>
        /// Deep copies a Cards object
        /// </summary>
        /// <returns>Cards object</returns>
        public object Clone()
        {
            CardCollection newCards = new CardCollection();
            foreach (Card sourceCard in List)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }
    }
}
