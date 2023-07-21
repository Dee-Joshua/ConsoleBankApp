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
        public string SourceAccountNumber { get; set; }
        public int ReciverAccountNumber { get; set; }
        public DateTime DateAndTime { get; set; }

        public Transaction(string transactionType, decimal amount, string description)
        {
            Type = transactionType;
            Amount = amount;    
            Description = description;
            DateAndTime = DateTime.Now;
        }


    }
}
