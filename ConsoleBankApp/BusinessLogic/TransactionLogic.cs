using ConsoleBankApp.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleBankApp.BusinessLogic
{
    public static class TransactionLogic
    {
        public static Transaction CreateRecord(string transactionType, decimal amount, string description, string sourceAccountNumber, decimal balance)
        {
            Transaction record = new Transaction();
            
            record.Type = transactionType;
            record.Amount = amount;
            record.Description = description;
            record.SourceAccountNumber = sourceAccountNumber;
            record.Balance = balance;
            record.DateAndTime = record.Date + " " + record.Time;

            return record;
        }

        public static Transaction CreateRecord(string transactionType, decimal amount, string description, string senderAccountNumber, string recieverAccountNumber, decimal balance)
        {
            Transaction record = new Transaction();

            record.Type = transactionType;
            record.Amount = amount;
            record.Description = description;
            record.SourceAccountNumber = senderAccountNumber;
            record.DestinationAccountNumber = recieverAccountNumber;
            record.Balance = balance;
            record.DateAndTime = record.Date + " " + record.Time;

            return record;
        }
    }
}
