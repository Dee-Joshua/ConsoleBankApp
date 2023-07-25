using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    public class Transaction 
    {
        public decimal Amount { get; private set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public uint SourceAccountNumber { get; set; }
        public uint DestinationAccountNumber { get; set; }
        public string Date { get; set; }
        public string TIme { get; set; }
        public string DateAndTime { get; set; }

        public Transaction(string transactionType, decimal amount, string description, uint sourceAccountNumber, decimal balance)
        {
            Type = transactionType;
            Amount = amount;    
            Description = description;
            this.SourceAccountNumber = sourceAccountNumber;
            RemainingBalance = balance;
            Date = DateTime.Now.ToString("dd-MM-yy");
            TIme = DateTime.Now.ToShortTimeString();
            DateAndTime = Date + " " + TIme;
        }

        public Transaction(string transactionType, decimal amount, string description, uint senderAccountNumber, uint recieverAccountNumber, decimal balance)
        {
            Type = transactionType;
            Amount = amount;
            Description = description;
            SourceAccountNumber = senderAccountNumber;
            DestinationAccountNumber = recieverAccountNumber;
            RemainingBalance = balance;
            Date = DateTime.Now.ToString("dd-MM-yy");
            TIme = DateTime.Now.ToShortTimeString();
            DateAndTime = Date + " " + TIme;
        }

    }
}
