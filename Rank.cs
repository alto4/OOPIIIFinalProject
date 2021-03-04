/*@project          OOPFinal Projct
 *@file             Rank.cs 
 *@version          1.0 
 *@since            2021-03-04 
 *@author           Eduardo San Martin Celi, Scott Alton, Nick Sturch-Flint
 *@modified         This program is based on the code presented in chapter 11 of our course textbook. 
 *@see              Beginning Visual C# 2012 Programming by Karli Watson et al.
 *@description      Defines an enumeration for ranks of a standard card deck.
 */

namespace OOPFinalProject
{
    /// <summary>
    /// Enum for rank of a card.
    /// </summary>
    public enum Rank
    {
        Ace=1,
        King=13,
        Queen=12,
        Jack=11,
        Ten=10,
        Nine=9,
        Eight=8,
        Seven=7,
        Six=6,
        Five=5,
        Four=4,
        Three=3,
        Two=2
    }
}
