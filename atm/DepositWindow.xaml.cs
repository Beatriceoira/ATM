using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class DepositWindow : Window
    {
        private readonly Account account;

        public DepositWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void FixedAmountButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && decimal.TryParse(button.Tag.ToString(), out decimal amount))
            {
                ProcessDeposit(amount);
            }
        }

        private void DepositCustomAmountButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(CustomDepositAmountTextBox.Text, out decimal amount))
            {
                ProcessDeposit(amount);
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }
        private void ProcessDeposit(decimal amount)
        {
            account.SetBalance(account.GetBalance() + amount);
            SaveTransactionLog("Deposit", amount);
            MessageBox.Show($"Deposited: {amount}\nNew Balance: {account.GetBalance()}");
            Close();
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
