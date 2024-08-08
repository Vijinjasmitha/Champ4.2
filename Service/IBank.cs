using BankingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service
{
    public interface IBank
    {
        void AddAccount(BankAccount account);
        void Deposit(BankAccount account, decimal amount);
        void Withdraw(BankAccount account, decimal amount);
        void CheckBalance(BankAccount account);
        BankAccount GetAccount(string accountNumber);
    }
}