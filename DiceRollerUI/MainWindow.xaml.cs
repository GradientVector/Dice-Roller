using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiceRollerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            TheMainGrid.DataContext = ViewModel;
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.Roll();
        }

        private void RollTwentySidedDice_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.RollTwentySidedDice();
        }
    }
}
