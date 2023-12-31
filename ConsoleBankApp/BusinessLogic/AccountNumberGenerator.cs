﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.BusinessLogic
{
    public class AccountNumberGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateAccountNumber(string prefix)
        {
            int randomNumber = random.Next(1000000, 10000000); // 7-digit random number
            return $"{prefix}{randomNumber:D7}";
        }
    }
}
