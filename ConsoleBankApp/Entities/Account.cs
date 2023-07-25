using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    public class Account
    {
        public Customer Owner { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
    }
}
