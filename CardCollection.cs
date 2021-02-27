/*  CardCollection.cs - Implements a class that acts as a collection of any amount of Card objects.
 * 
 *  Author:     Eduardo San Martin Celi
 *  Since:      2020/02/06
 */

using System;
using System.Collections.Generic;
using System.Collections;

namespace OOPFinalProject
{
    /// <summary>
    /// Collection of cards
    /// </summary>
    public class CardCollection : List<Card>, ICloneable
    {

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
        /// Deep copies a Cards object
        /// </summary>
        /// <returns>Cards object</returns>
        public object Clone()
        {
            CardCollection newCards = new CardCollection();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

        /// <summary>
        /// Displays a player's current hand
        /// </summary>
        /// <returns></returns>
       public string ShowHand()
        {
            return "Hand:";
        }
    }
}
