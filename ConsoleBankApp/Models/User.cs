using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    internal class User
    {
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public User(string firstName, string lastName, int phoneNumber, string emailAddress)
        {
            FullName = $"{firstName} {lastName}";
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public User(string firstName, string lastName)
        {
            FullName = $"{firstName} {lastName}";
            PhoneNumber = 0;
            EmailAddress = null;
        }
    }

}
