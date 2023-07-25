using ConsoleBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.BusinessLogic
{
    public class CustomerLogic
    {
        public Customer CreateCustomer(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Customer user = new Customer();
            user.FullName = $"{firstName} {lastName}";
            user.Surname = lastName;
            user.Surname = firstName;
            user.Mobile = phoneNumber;
            user.Email = emailAddress;

            return user;
        }
    }
}
