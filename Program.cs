using BankingSystem.Model;
using BankingSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IBank bank = new Bank();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Banking System ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateAccount(bank);
                        break;
                    case "2":
                        PerformTransaction(bank, bank.Deposit);
                        break;
                    case "3":
                        PerformTransaction(bank, bank.Withdraw);
                        break;
                    case "4":
                        CheckAccountBalance(bank);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateAccount(IBank bank)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
            {
                BankAccount account = new BankAccount(accountNumber, initialBalance);
                bank.AddAccount(account);
            }
            else
            {
                Console.WriteLine("Invalid initial balance.");
            }
        }

        static void PerformTransaction(IBank bank, TransactionDelegate transaction)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = bank.GetAccount(accountNumber);
            if (account != null)
            {
                Console.Write("Enter amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    transaction(account, amount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
            }
        }

        static void CheckAccountBalance(IBank bank)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = bank.GetAccount(accountNumber);
            if (account != null)
            {
                bank.CheckBalance(account);
            }
        }
    }
}