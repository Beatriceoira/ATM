using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp
{
    public partial class BalanceWindow : Window
    {
        private readonly Account account;

        public BalanceWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            DisplayBalance();
        }

        private void DisplayBalance()
        {
            BalanceTextBlock.Text = $"${account.GetBalance():F2}";
        }
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowMainWindow(); 
            Close();
        }
    }
}



