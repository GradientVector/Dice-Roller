using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller
{
    public class DiceGroup
    {
        public int NumberOfSides { get; private set; }       
        private List<Dice> Dice { get; set; }
        public int NumberOfDice
        {
            get { return Dice.Count; }
        }
        public DiceGroupRollResult LastRollResults { get; private set; }

        public DiceGroup()
        {
            NumberOfSides = 0;
            Dice = new List<Dice>();
        }

        public DiceGroup(int numberOfSides = 20, int numberOfDice = 1)
        {
            NumberOfSides = numberOfSides;
            Dice = new List<Dice>();

            for (int i = 0; i < numberOfDice; i++)
            {
                Dice.Add(new Dice(NumberOfSides));
            }
        }

        public DiceGroupRollResult Roll()
        {
            List<int> rollValues = new List<int>();

            foreach (Dice dice in Dice)
            {
                rollValues.Add(dice.Roll());
            }

            LastRollResults = new DiceGroupRollResult(NumberOfSides, rollValues);

            return LastRollResults;
        }
    }
}
