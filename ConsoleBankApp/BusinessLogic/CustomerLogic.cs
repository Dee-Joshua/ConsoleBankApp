﻿using ConsoleBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.BusinessLogic
{
    public static class CustomerLogic
    {
        public static Customer CreateCustomer(string firstName, string lastName, string phoneNumber, string emailAddress, string residentAddress, string password)
        {
            Customer user = new Customer();
            user.FullName = $"{firstName} {lastName}";
            user.Surname = lastName;
            user.Surname = firstName;
            user.Mobile = phoneNumber;
            user.Email = emailAddress;
            user.Address = residentAddress;
            user.Password = password;

            Console.WriteLine("\nThank you for signing up with AlphaTech Bank! \n\nPress any key to continue...");
            return user;
        }
    }
}
