using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DiceRoller
{
    public class DiceCollection : INotifyPropertyChanged
    {
        private List<DiceGroup> _diceGroups;
        public List<DiceGroup> DiceGroups 
        {
            get { return _diceGroups; }
            set
            {
                _diceGroups = value;
                this.OnPropertyChanged("DiceGroups");
            }
        }

        private Dice TwentySidedDice = new Dice(20);


        #region Constructors

        public DiceCollection()
        {

        }

        public DiceCollection(List<DiceGroup> DiceGroups)
        {
            this.DiceGroups = new List<DiceGroup>();
            
            foreach (DiceGroup diceGroup in DiceGroups)
            {
                this.DiceGroups.Add(diceGroup);
            }
        }

        #endregion

        public List<DiceGroupRollResult> Roll()
        {
            List<DiceGroupRollResult> resultsOfRoll = new List<DiceGroupRollResult>();

            foreach (DiceGroup diceGroup in DiceGroups)
            {
                resultsOfRoll.Add(diceGroup.Roll());
            }

            return resultsOfRoll;
        }

        public int RollTwentySidedDice()
        {
            return TwentySidedDice.Roll();
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
