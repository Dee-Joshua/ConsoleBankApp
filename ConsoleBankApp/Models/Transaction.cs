using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    internal class Transaction 
    {
        public decimal Amount { get; private set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public uint SourceAccountNumber { get; set; }
        public uint DestinationAccountNumber { get; set; }
        public DateTime DateAndTime { get; set; }

        public Transaction(string transactionType, decimal amount, string description, uint sourceAccountNumber)
        {
            Type = transactionType;
            Amount = amount;    
            Description = description;
            DateAndTime = DateTime.Now;
            this.SourceAccountNumber = sourceAccountNumber;
        }

        public Transaction(string transactionType, decimal amount, string description, uint senderAccountNumber, uint recieverAccountNumber)
        {
            Type = transactionType;
            Amount = amount;
            Description = description;
            DateAndTime = DateTime.Now;
            SourceAccountNumber = senderAccountNumber;
            DestinationAccountNumber = recieverAccountNumber;
        }

    }
}
