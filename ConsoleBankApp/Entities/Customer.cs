using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models
{
    public class Customer
    {
        public string Surname { get; set; }
        public string OtherName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public Account[] UserAccounts { get; set; } = new Account[2];
    }

}
