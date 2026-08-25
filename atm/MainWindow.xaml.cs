using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, Account> accounts;
        private string accountsFilePath;

        public MainWindow()
        {
            InitializeComponent();
            accountsFilePath = @"C:\Users\biank\OneDrive\Documents\Visual Studio 2022\Accounts.txt";
            LoadAccounts();
        }
        private void LoadAccounts()
        {
            accounts = new Dictionary<string, Account>();

            if (File.Exists(accountsFilePath))
            {
                string[] lines = File.ReadAllLines(accountsFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string accountNumber = parts[0].Trim();
                        if (decimal.TryParse(parts[1], out decimal balance))
                        {
                            string pin = parts[2].Trim();
                            accounts[accountNumber] = new Account(accountNumber, balance, pin);
                        }
                    }
                }
            }
        }
        private void SaveAccounts()
        {
            IEnumerable<string> lines = accounts.Select(a => $"{a.Value.GetAccountNumber()},{a.Value.GetBalance()},{a.Value.GetPIN()}");
            File.WriteAllLines(accountsFilePath, lines);
        }
        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = AccountNumberTextBox.Text.Trim();
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                PinWindow pinWindow = new PinWindow(account, () =>
                {
                    WithdrawWindow withdrawWindow = new WithdrawWindow(account);
                    withdrawWindow.ShowDialog();
                    SaveAccounts();
                    Close();
                });
                pinWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account number not found.");
            }
        }
        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = AccountNumberTextBox.Text.Trim();
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                PinWindow pinWindow = new PinWindow(account, () =>
                {
                    DepositWindow depositWindow = new DepositWindow(account);
                    depositWindow.ShowDialog();
                    SaveAccounts();
                    Close();
                });
                pinWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account number not found.");
            }
        }
        private void BalanceCheck_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = AccountNumberTextBox.Text.Trim();
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                PinWindow pinWindow = new PinWindow(account, () =>
                {
                    BalanceWindow balanceWindow = new BalanceWindow(account);
                    balanceWindow.ShowDialog();
                    Close();
                });
                pinWindow.ShowDialog();
              
            }
            else
            {
                MessageBox.Show("Account number not found.");
            }
        }
        public void ShowMainWindow()
        {
            this.Show(); 
            Activate();
        }
    }
}

