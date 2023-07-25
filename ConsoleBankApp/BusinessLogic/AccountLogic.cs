using ConsoleBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleBankApp.BusinessLogic
{
    public class AccountLogic
    {
        private List<Account> accounts;
        public AccountLogic()
        {
            accounts = new List<Account>();
        }


        public Account CreateAccount(Customer customerInfo, string accountType)
        {
            Account account = new Account();
            account.Owner = customerInfo;
            if (accountType == "Curent") 
            {
                account.Number = AccountNumberGenerator.GenerateAccountNumber("100");
            }
            else
            {
                account.Number = AccountNumberGenerator.GenerateAccountNumber("200");
            }
            account.Type = accountType;
            return account;
        }

        public string CheckBalance(string accountNumber)
        {
            Account account = accounts.Where(a => a.Number == accountNumber).FirstOrDefault();
            return $"{account.Balance}";
        }

        public void MakeDeposit(string accountNumber, decimal amount, string transactionDescription)
        {
            Account account = accounts.Where(a => a.Number == accountNumber).FirstOrDefault();
            if (amount < 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                //go to statement to let user re-enter the amount
            }

            //Credit Customer
            account.Balance += amount;

            //Store details of completed transaction in list of transactions
            Transaction depositRecord = TransactionLogic.CreateRecord("Credit DP", amount, transactionDescription, account.Number, account.Balance);
            account.TransactionHistory.Add(depositRecord);

            Console.WriteLine("Transaction Successful!");
        }

        public void MakeWithdrawal(string accountNumber, decimal amount, string transactionDescription)
        {
            
            Account account = accounts.Where(a => a.Number == accountNumber).FirstOrDefault();
            
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be more than positive(more than zero)");
                //goto statement to let user re-enter the amount

            }
            else if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal");
                //goto statement to throw the user out

            }
            else
            {
                if (account.Type  == "Savings")
                {
                    if ((account.Balance - amount) < 1000)
                    {
                        Console.WriteLine("Sorry, you can not withdraw past the minimum balance(₦1,000) for a savings account");
                        //goto statement to let the user re-enter the amount

                    }
                }
                
                //Debit Customer
                account.Balance -= amount;

                //Store completed transaction in list of transactions
                Transaction withdrawalRecord = TransactionLogic.CreateRecord("Dedit W/D", amount, transactionDescription, account.Number, account.Balance);
                account.TransactionHistory.Add(withdrawalRecord);

                Console.WriteLine("Transaction Successful! \nPlease take your cash");
            }
        }

        public void MakeTransfer(string accountNumber, string recieverAccountNumber, decimal amount, string transactionDescription)
        {
            Account account = accounts.Where(a => a.Number == accountNumber).FirstOrDefault();

            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive(more than zero)");
                //goto statement to let user re-enter the amount

            }
            else if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds for this transfer");
                //goto statement to throw the user out
            }
            else
            {
                Balance -= amount;
                //Store completed transaction in list of transactions
                Transaction transfer = new Transaction("Debit TRF", amount, $"{transactionDescription}", this.Number, recieverAccountNumber, Balance);
                transactionHistory.Add(transfer);
            }
        }

        public string GetAccountStatement()
        {
            var statement = new StringBuilder();
            string accNum = Convert.ToString(Number);

            //Table Header
            string header = "ACCOUNT NAME".PadRight(20) + "NUMBER".PadRight(15) + "TRANSACTION".PadRight(20) + "AMOUNT(₦)".PadRight(15) + "NARRATION".PadRight(25) + "DATE AND TIME".PadRight(25) + "BALANCE(₦)";
            statement.AppendLine(header);

            foreach (Transaction alert in transactionHistory)
            {
                // Table Rows
                string row = Owner.FullName.PadRight(20) + accNum.PadRight(15) + alert.Type.PadRight(20) + alert.Amount.ToString("N2").PadRight(15) + alert.Description.PadRight(25) + alert.DateAndTime.PadRight(25) + alert.Balance.ToString("N2");
                statement.AppendLine(row);
            }
            return statement.ToString();
        }
    }
}
