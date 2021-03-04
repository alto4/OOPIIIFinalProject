/*@project          OOPFinalProject
 *@file             Player.cs 
 *@version          3.0 
 *@since            2021-03-04 
 *@author           Scott Alton
 *@modified         This program is based on the code presented in chapter 13 of our course textbook. 
 *@see              Beginning Visual C# 2012 Programming by Karli Watson et al.
 *@see              OOP4200-Tutorial-7-EventsAndExceptions.pdf
 *@description      This class repesents a player, and contains the players name and a collection containing their current hand.
 */

using OOPFinalProject;
using System;
using System.Collections.Generic;
using System.Text;


namespace OOPFinalProject
{
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        private Player()
        {
        }

        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }

        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].Suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].Suit == match;
            }
            return won;
        }
    }
}
