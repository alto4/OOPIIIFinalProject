/*  CardCollection.cs - Implements a concrete class that is 
 * 
 *  Author:     Eduardo San Martin Celi
 *  Since:      2020/02/06
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
        public Card(Suit suit, Rank rank)
        {
            mySuit = suit;
            myRank = rank;
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
    }
}
