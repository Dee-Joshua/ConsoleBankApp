using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models.AccountTypes
{
    internal class CurrentAccount : IAccount    
    {
        public User Owner;
        public uint Number { get; }
        private decimal Balance;
        private static uint accountNumberSeed = 0987654321;
        private List<Transaction> transactionHistory = new List<Transaction>();

        public CurrentAccount(User accountOwner, decimal initialDepositAmount)
        { 
            if (initialDepositAmount < 5000)
            {
                throw new ArgumentOutOfRangeException(nameof(initialDepositAmount), "Current Account requires a minimun opening balance of \u20A65,000");
            }
            Owner = accountOwner;
            Number = accountNumberSeed;
            accountNumberSeed += 10;
            MakeDeposit(initialDepositAmount, "Opening Balance");
        }

        public decimal CheckBalance()
        {
            decimal accountBalance = Balance;
            return accountBalance;
        }

        public void MakeDeposit(decimal amount, string transactionDescription)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
            }
            Balance += amount;
            //Store completed transaction in list of transactions
            Transaction deposit = new Transaction("Credit", amount, transactionDescription, this.Number, Balance);
            transactionHistory.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, string transactionDescription)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be more than positive(more than zero)");
            }
            else if (amount > Balance) 
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal");
            }
            else
            {
                Balance -= amount;
                //Store completed transaction in list of transactions
                Transaction withdrawal = new Transaction("Dedit W/D", amount, transactionDescription, this.Number, Balance);
                transactionHistory.Add(withdrawal); 
            }
        }

        public void MakeTransfer(uint recieverAccountNumber, decimal amount, string transactionDescription)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Transfer amount must be more than positive(more than zero)");
            }
            else if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds for this transfer");
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
            string header = "ACCOUNT NAME".PadRight(20) + "NUMBER".PadRight(15) + "TRANSACTION".PadRight(20) + "AMOUNT(\u20A6)".PadRight(15) + "NARRATION".PadRight(25) + "DATE AND TIME".PadRight(25) + "BALANCE";
            statement.AppendLine(header);

            foreach (Transaction alert in transactionHistory)
            {
                // Table Rows
                string row = Owner.FullName.PadRight(20) + accNum.PadRight(15) + alert.Type.PadRight(20) + alert.Amount.ToString("N2").PadRight(15) + alert.Description.PadRight(25) + alert.DateAndTime.PadRight(25) + alert.RemainingBalance.ToString("N2");
                statement.AppendLine(row);
            }
            return statement.ToString();
        }
    }
}
