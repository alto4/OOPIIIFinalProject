/*@project          OOPFinal Projct
 *@file             Card.cs 
 *@version          1.0 
 *@since            2021-03-04 
 *@author           Eduardo San Martin Celi, Scott Alton, Nick Sturch-Flint
 *@modified         This program is based on the code presented in chapter 11 of our course textbook. 
 *@see              Beginning Visual C# 2012 Programming by Karli Watson et al.
 *@description      This program demonstrates various extended functionalities of the Ch11CardLib class library.
 */

using System;

namespace OOPFinalProject
{
    /// <summary>
    /// Card object is simply a suit and a rank.
    /// </summary>
    public class Card : ICloneable
    {
        private readonly Suit mySuit;
        private readonly Rank myRank;
        public bool isFaceUp { get; set; }

        /// <summary>
        /// Enabling allows for a selected card to be valued higher than others
        /// </summary>
        public static bool useTrumps = false;
        public static Suit trumpSuit = Suit.Clubs;

        public static bool isAceHigh = true;

        public Suit Suit
        {
            get { return mySuit; }
        }
        public Rank Rank
        {
            get { return myRank; }
        }
        
        /// <summary>
        /// private default constructor of a Card object
        /// </summary>
        private Card() { }

        /// <summary>
        /// Parameterized constructor of a Card object
        /// </summary>
        /// <param name="suit">The Card Suit</param>
        /// <param name="rank">The Card Rank</param>
        public Card(Suit suit, Rank rank, bool faceUp = false)
        {
            mySuit = suit;
            myRank = rank;
            isFaceUp = faceUp;
        }

        /// <summary>
        /// override to string
        /// </summary>
        /// <returns>The Card object described as a string</returns>
        public override string ToString()
        {
            return string.Format("Suit: {0} Rank: {1}", mySuit, myRank);
        }

        /// <summary>
        /// This is good enough since there are no object members, only value data fields
        /// </summary>
        /// <returns>Shallow Clone</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        #region "Operators"
        /// <summary>
        /// Equality operator - checks if 2 cards are made up of the same suit and rank
        /// </summary>
        /// <param name="card1">first card in comparison</param>
        /// <param name="card2">second card in comparison</param>
        /// <returns>boolean representing equality status</returns>
        public static bool operator ==(Card card1, Card card2) => ((card1.Suit == card2.Suit) && (card1.Rank == card2.Rank));

        /// <summary>
        /// Inequality operator - checks if 2 cards are not made up of the same suit and rank
        /// </summary>
        /// <param name="card1">first card in comparison</param>
        /// <param name="card2">second card in comparison</param>
        /// <returns>boolean representing inequality status</returns>
        public static bool operator !=(Card card1, Card card2) => !(card1 == card2);

        /// <summary>
        /// Equals - checks if 2 cards are made up of the same suit and rank
        /// </summary>
        /// <param name="card">card to compare to</param>
        /// <returns>boolean representing equality status</returns>
        public override bool Equals(object card) => this == (Card)card;

        /// <summary>
        /// GetHashCode - returns cards hash code that identifies card using a unique integer
        /// </summary>
        /// <returns>integer hash code generated based on the card's suit and rank</returns>
        public override int GetHashCode() => 13 * (int)Suit + (int)Rank;

        /// <summary>
        /// Greater than operator - returns boolean representing the status of left card as greater than right card
        /// </summary>
        /// <param name="card1">the first card for comparison</param>
        /// <param name="card2">the second card for comparison</param>
        /// <returns>boolean representing status of first card as greater than second card</returns>
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.Suit == card2.Suit)
            {
                if (isAceHigh)
                {
                    if (card1.Rank == Rank.Ace)
                    {
                        return (card2.Rank == Rank.Ace) ? false : true;
                    }
                    else
                    {
                        return (card2.Rank == Rank.Ace) ? false : (card1.Rank > card2.Rank);
                    }
                }
                else
                {
                    return (card1.Rank > card2.Rank);
                }
            }
            else
            {
                return (useTrumps && (card2.Suit == Card.trumpSuit)) ? false : true;
            }
        }

        // <summary>
        /// Greater than or equal to operator - returns boolean representing the status of left card as greater than or equal to right card
        /// </summary>
        /// <param name="card1">the first card for comparison</param>
        /// <param name="card2">the second card for comparison</param>
        /// <returns>boolean representing status of first card as greater than or equal to second card</returns>
        public static bool operator >=(Card card1, Card card2) => (!(card1 < card2) || card1 == card2);


        // <summary>
        /// Less than operator - returns boolean representing the status of left card as less than or equal to right card
        /// </summary>
        /// <param name="card1">the first card for comparison</param>
        /// <param name="card2">the second card for comparison</param>
        /// <returns>boolean representing status of first card as less than the second card</returns>
        public static bool operator <(Card card1, Card card2) => !(card1 >= card2);


        // <summary>
        /// Less than or equal to operator - returns boolean representing the status of left card as less than or equal to right card
        /// </summary>
        /// <param name="card1">the first card for comparison</param>
        /// <param name="card2">the second card for comparison</param>
        /// <returns>boolean representing status of first card as less than or equal to second card</returns>
        public static bool operator <=(Card card1, Card card2) => !(card1 > card2);
        #endregion

    }
}
