using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller
{
    public class DiceGroupRollResult
    {
        public int NumberOfSides { get; private set; }   
        public List<int> Values { get; private set; }

        public DiceGroupRollResult(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
            Values = new List<int>();
        }

        public DiceGroupRollResult(int numberOfSides, List<int> values)
        {
            NumberOfSides = numberOfSides;
            Values = values;
        }

        public DiceGroupRollResult(List<int> values)
        {
            Values = values;
        }
    }
}
