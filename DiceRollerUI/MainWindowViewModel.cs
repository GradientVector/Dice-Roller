using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DiceRoller;

namespace DiceRollerUI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        DiceCollection Dice { get; set; }

        List<DiceGroupRollResult> LastRollResults { get; set; }

        private int _numberOfTwoSidedDice;
        public int NumberOfTwoSidedDice 
        {
            get { return _numberOfTwoSidedDice; }
            set
            {
                _numberOfTwoSidedDice = value;
                OnPropertyChanged("NumberOfTwoSidedDice");
            }
        }

        private int _numberOfFourSidedDice;
        public int NumberOfFourSidedDice
        {
            get { return _numberOfFourSidedDice; }
            set
            {
                _numberOfFourSidedDice = value;
                OnPropertyChanged("NumberOfFourSidedDice");
            }
        }

        private int _numberOfSixSidedDice;
        public int NumberOfSixSidedDice
        {
            get { return _numberOfSixSidedDice; }
            set
            {
                _numberOfSixSidedDice = value;
                OnPropertyChanged("NumberOfSixSidedDice");
            }
        }

        private int _numberOfEightSidedDice;
        public int NumberOfEightSidedDice
        {
            get { return _numberOfEightSidedDice; }
            set
            {
                _numberOfEightSidedDice = value;
                OnPropertyChanged("NumberOfEightSidedDice");
            }
        }

        private int _numberOfTwelveSidedDice;
        public int NumberOfTwelveSidedDice
        {
            get { return _numberOfTwelveSidedDice; }
            set
            {
                _numberOfTwelveSidedDice = value;
                OnPropertyChanged("NumberOfTwelveSidedDice");
            }
        }

        private int _numberOfTwentySidedDice;
        public int NumberOfTwentySidedDice
        {
            get { return _numberOfTwentySidedDice; }
            set
            {
                _numberOfTwentySidedDice = value;
                OnPropertyChanged("NumberOfTwentySidedDice");
            }
        }

        private string _resultText;
        public string ResultText 
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        #region Constructors

        public MainWindowViewModel()
        {
            Dice = new DiceCollection();
        }

        #endregion

        public void Roll()
        {
            CreateDice();
            LastRollResults = Dice.Roll();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("***** Results *****");
            builder.AppendLine(PrintRollResults(LastRollResults));
            ResultText = builder.ToString();
        }

        public void RollTwentySidedDice()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("***** Results *****");
            builder.AppendLine("Twenty Sided Dice Roll:");
            builder.AppendLine(Dice.RollTwentySidedDice().ToString());
            ResultText = builder.ToString();
        }

        private void CreateDice()
        {
            Dice = new DiceCollection(
                new List<DiceGroup>()
                {
                    new DiceGroup(2, NumberOfTwoSidedDice), 
                    new DiceGroup(4, NumberOfFourSidedDice), 
                    new DiceGroup(6, NumberOfSixSidedDice), 
                    new DiceGroup(8, NumberOfEightSidedDice), 
                    new DiceGroup(12, NumberOfTwelveSidedDice), 
                    new DiceGroup(20, NumberOfTwentySidedDice)
                });
        }

        private static string PrintRollResults(List<DiceGroupRollResult> results)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DiceGroupRollResult diceGroupResult in results)
            {
                builder.AppendLine((String.Format("** {0}-sided dice rolls **", diceGroupResult.NumberOfSides)));
                foreach (int diceResult in diceGroupResult.Values)
                {
                    builder.Append(diceResult.ToString() + "  ");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
