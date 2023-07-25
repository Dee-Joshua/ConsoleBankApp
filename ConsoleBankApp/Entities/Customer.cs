using ConsoleBankApp.Models.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    public class Customer
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public Customer(string firstName, string lastName, int phoneNumber, string emailAddress)
        {
            FullName = $"{firstName} {lastName}";
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public Customer(string firstName, string lastName)
        {
            FullName = $"{firstName} {lastName}";
            PhoneNumber = 0;
            EmailAddress = null;

        }
    }

}
