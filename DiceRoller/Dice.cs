using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller
{
    public class Dice
    {
        public int NumberOfSides { get; set; }
        private static Random RandomNumberGenerator { get; set; }

         static Dice()
        {
            RandomNumberGenerator = new Random();
        }
        
        public Dice(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }


        /// <summary>
        /// Rolls the dice to determine which side lands face-up
        /// </summary>
        /// <returns>The side which landed face-up</returns>
        public int Roll()
        {
            return RandomNumberGenerator.Next(NumberOfSides) + 1;
        }
    }
}
