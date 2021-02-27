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
        public static bool operator ==(Card card1, Card card2) => ((card1.Suit == card2.Suit) && (card1.Rank == card2.Rank));

        public static bool operator !=(Card card1, Card card2) => !(card1 == card2);

        public override bool Equals(object card) => this == (Card)card;

        public override int GetHashCode() => 13 * (int)Suit + (int)Rank;

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

        public static bool operator >=(Card card1, Card card2) => (!(card1 < card2) || card1 == card2);

        public static bool operator <(Card card1, Card card2) => !(card1 >= card2);

        public static bool operator <=(Card card1, Card card2) => !(card1 > card2);
        #endregion

    }
}
