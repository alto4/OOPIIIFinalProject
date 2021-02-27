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
       public void ShowHand()
        {
             foreach (Card drawnCard in this)
            {
                Console.WriteLine("*************");
                Console.WriteLine("* Rank: {0} \n* Suit: {1}", drawnCard.Rank, drawnCard.Suit);
                Console.WriteLine("*************");
            }
        }

        // TODO: BROKEN SORTING ALGORITHM, NEED TO REVISIT
        /// <summary>
        /// Reorders cards in a hand using bubble sort to range from highest to lowest
        /// REFERENCE: https://dotnetcoretutorials.com/2020/05/10/basic-sorting-algorithms-in-c/
        /// Description: I used this article as a refresher for basic sorting algorithms, and in particular modified the bubble sort example to sort a collection
        /// </summary>
        public CardCollection Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine(this[i].ToString());

                if ((i < this.Count - 1) && (this[i].Rank > this[i + 1].Rank))
                {
                    Card tempCard = this[i];
                    this[i] = this[i + 1];
                    this[i + 1] = tempCard;

                }
            }

            return this;
        }
    }
}
