using System;
using System.IO;


namespace WpfApp
{
    public class Account
    {
        private string accountNumber;
        private decimal balance;
        private string pin;

        public Account(string accountNumber, decimal balance, string pin)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.pin = pin;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void SetBalance(decimal newBalance)
        {
            balance = newBalance;
        }

        public string GetPIN()
        {
            return pin;
        }

    }
}

