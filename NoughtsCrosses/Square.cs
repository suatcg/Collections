using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsCrosses
{
    public enum Player { Noone= 0, Noughts, Crosses }
    
    //Squeare define struct that means Square automatically starts as empty by default 
    public struct Square
    {
        public Player Owner { get; }

        public Square(Player owner)
        {
            this.Owner = owner;
        }

        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Noone:
                    return ".";
                case Player.Noughts:
                    return "O";
                case Player.Crosses:
                    return "X";
                default:
                    throw new Exception("Invalid state");
            }
        }
    }
}
