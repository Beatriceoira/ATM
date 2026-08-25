using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class WithdrawWindow : Window
    {
        private readonly Account account;

        public WithdrawWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void FixedAmount_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && decimal.TryParse(button.Content.ToString(), out decimal amount))
            {
                ProcessWithdrawal(amount);
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(WithdrawAmountTextBox.Text, out decimal amount))
            {
                ProcessWithdrawal(amount);
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }

        private void ProcessWithdrawal(decimal amount)
        {
            if (amount <= account.GetBalance())
            {
                account.SetBalance(account.GetBalance() - amount);
                SaveTransactionLog("Withdraw", amount);
                MessageBox.Show($"Withdrawn: {amount}\nNew Balance: {account.GetBalance()}");
                Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance.");
            }
        }

        private void SaveTransactionLog(string transactionType, decimal amount)
        {
            try
            {
                string logFile = $"{account.GetAccountNumber()}_log.txt";
                string logEntry = $"{DateTime.Now},{transactionType},{amount},{account.GetBalance()}";

                using (StreamWriter writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine(logEntry);
                }
                MessageBox.Show($"Log file entry added: {logEntry}");

                string receiptFile = $"{account.GetAccountNumber()}_receipt.txt";
                string receiptEntry = $"{transactionType}: {amount}\nNew Balance: {account.GetBalance()}";
                File.WriteAllText(receiptFile, receiptEntry);

                MessageBox.Show($"Receipt file created: {receiptEntry}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving transaction log: {ex.Message}");
            }
        }


        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowMainWindow();
            Close();
        }
    }
}
