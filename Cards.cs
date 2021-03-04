/*@project          Ch13CardLib
 *@file             Cards.cs 
 *@version          2.0 
 *@since            2021-02-07 
 *@author           Scott Alton
 *@modified         This program is based on the code presented in chapter 10 of our course textbook. 
 *@see              Beginning Visual C# 2012 Programming by Karli Watson et al.
 *@see              OOP4200-Tutorial-7-EventsAndExceptions.pdf
 *@description      This class represents a deck of cards.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OOPFinalProject
{
    /// <summary>
    /// Cards class - collection of playing cards in hand
    /// </summary>
    public class Cards : List<Card>, ICloneable
    {
        /// <summary>
        /// Clone - clones collection of cards
        /// </summary>
        /// <returns>clone of card collection</returns>
        public object Clone()
        {
            Cards newCards = new Cards();

            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }

            return newCards;
        }

        /// <summary>
        /// CopyTo - copies card(s) to new collection
        /// </summary>
        /// <param name="targetCards">the card(s) to be copied</param>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

    }
}
