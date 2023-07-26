using ConsoleBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleBankApp.BusinessLogic
{
    public static class AccountLogic
    {
        public static Account CreateAccount(Customer customerInfo, string accountType)
        {
            Account account = new Account();
            account.Owner = customerInfo;
            account.Balance = 0;
            if (accountType == "Current") 
            {
                account.Number = AccountNumberGenerator.GenerateAccountNumber("100");
            }
            else
            {
                account.Number = AccountNumberGenerator.GenerateAccountNumber("200");
            }
            account.Type = accountType;
            Console.WriteLine($"Account Successfully Created! \nYour account number is: {account.Number} \nPlease write down your account number then, press any key to continue");
            return account;
        }

        public static string CheckBalance(string accountNumber)
        {
            Account account = BankLogic.Accounts.Where(a => a.Number == accountNumber).FirstOrDefault();
            return $"{account.Balance}";
        }

        public static void MakeDeposit(string accountNumber, decimal amount, string transactionDescription)
        {
            Account account = BankLogic.Accounts.Where(a => a.Number == accountNumber).FirstOrDefault();
            if (amount < 0)
            {
                Console.WriteLine("Failed! Deposit amount must be positive");
                return;
            }

            //Credit Customer
            account.Balance += amount;

            //Store details of completed transaction in list of transactions
            Transaction depositRecord = TransactionLogic.CreateRecord("Credit DP", amount, transactionDescription, account.Number, account.Balance);
            account.TransactionHistory.Add(depositRecord);

            Console.WriteLine("Credit Transaction Successful!");
        }

        public static void MakeWithdrawal(string accountNumber, decimal amount, string transactionDescription)
        {

            Account account = BankLogic.Accounts.Where(a => a.Number == accountNumber).FirstOrDefault();

            if (amount <= 0)
            {
                Console.WriteLine("Failed! Withdrawal amount must be more than positive(more than zero)");
            }
            else if (amount > account.Balance)
            {
                Console.WriteLine("Failed! Insufficient funds for this withdrawal");
            }
            else
            {
                if (account.Type  == "Savings")
                {
                    if ((account.Balance - amount) < 1000)
                    {
                        Console.WriteLine("Sorry, you can not withdraw past the minimum balance(₦1,000) for a savings account");
                        return;

                    }
                }
                
                //Debit Customer
                account.Balance -= amount;

                //Store completed transaction in list of transactions
                Transaction withdrawalRecord = TransactionLogic.CreateRecord("Dedit W/D", amount, transactionDescription, account.Number, account.Balance);
                account.TransactionHistory.Add(withdrawalRecord);

                Console.WriteLine("Debit Transaction Successful!");
            }
        }

        public static void MakeTransfer(string accountNumber, string recieverAccountNumber, decimal amount, string transactionDescription)
        {
            Account account = BankLogic.Accounts.Where(a => a.Number == accountNumber).FirstOrDefault();

            //Debit User
            MakeWithdrawal(accountNumber, amount, transactionDescription);

            //Credit Reciever
            MakeDeposit(recieverAccountNumber, amount, $"TRF from {account.Owner.FullName}");
        }

        public static string GetAccountStatement(string accountNumber)
        {
            Account account = BankLogic.Accounts.Where(a => a.Number == accountNumber).FirstOrDefault();

            var statement = new StringBuilder();
            string accNum = accountNumber;

            //Table Header
            string header = "ACCOUNT NAME".PadRight(20) + "NUMBER".PadRight(15) + "TRANSACTION".PadRight(20) + "AMOUNT(₦)".PadRight(15) + "NARRATION".PadRight(25) + "DATE AND TIME".PadRight(25) + "BALANCE(₦)";
            statement.AppendLine(header);

            foreach (Transaction alert in account.TransactionHistory)
            {
                // Table Rows
                string row = account.Owner.FullName.PadRight(20) + accNum.PadRight(15) + alert.Type.PadRight(20) + alert.Amount.ToString("N2").PadRight(15) + alert.Description.PadRight(25) + alert.DateAndTime.PadRight(25) + alert.Balance.ToString("N2");
                statement.AppendLine(row);
            }
            return statement.ToString();
        }
    }
}
