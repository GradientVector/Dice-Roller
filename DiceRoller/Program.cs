using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceCollection Dice = new DiceCollection(
                new List<DiceGroup>()
                {
                    new DiceGroup(2), 
                    new DiceGroup(4), 
                    new DiceGroup(6), 
                    new DiceGroup(8), 
                    new DiceGroup(12), 
                    new DiceGroup(20)
                });
            List<DiceGroupRollResult> results = Dice.Roll();

            PrintRollResults(results);

            Console.ReadKey();
        }

        private static void PrintRollResults(List<DiceGroupRollResult> results)
        {
            foreach (DiceGroupRollResult diceGroupResult in results)
            {
                Console.WriteLine(String.Format("***** {0}-sided dice rolls *****", diceGroupResult.NumberOfSides));
                foreach (int diceResult in diceGroupResult.Values)
                {
                    Console.WriteLine(diceResult);
                }
            }
        }
    }
}
