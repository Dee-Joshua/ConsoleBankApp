using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    public class Transaction 
    {
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string SourceAccountNumber { get; set; }
        public string DestinationAccountNumber { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("dd-MM-yy");
        public string Time { get; set; } = DateTime.Now.ToShortTimeString();
        public string DateAndTime { get; set; }
        
        }

    }
}
