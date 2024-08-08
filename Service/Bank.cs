using BankingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service
{
    public class Bank : IBank
    {
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

        public void AddAccount(BankAccount account)
        {
            if (!accounts.ContainsKey(account.AccountNumber))
            {
                accounts[account.AccountNumber] = account;
                Console.WriteLine($"Account {account.AccountNumber} created successfully.");
            }
            else
            {
                Console.WriteLine($"Account {account.AccountNumber} already exists.");
            }
        }

        public void Deposit(BankAccount account, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            account.Balance += amount;
            Console.WriteLine($"Deposited . New balance is {account.Balance}");
        }

        public void Withdraw(BankAccount account, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }
            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                Console.WriteLine($" Withdrewed   .New Balance is  {account.Balance}");

            }
            else
            {
                Console.WriteLine("Insufficient funds. Withdrawal canceled.");
            }
        }

        public void CheckBalance(BankAccount account)
        {
            Console.WriteLine($"The balance of account is {account.Balance}");
        }

        public BankAccount GetAccount(string accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber];
            }
            else
            {
                Console.WriteLine($"Account {accountNumber} not found.");
                return null;
            }
        }
    }
}
