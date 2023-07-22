using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models.AccountTypes
{
    internal class CurrentAccount : IAccount    
    {
        public User Owner;
        public int Number { get; }
        public decimal Balance { get; }
        private static int accountNumberSeed = 1234567890;

        public CurrentAccount(User accountOwner, decimal initalBalance)
        {
            Owner = accountOwner;
            Balance = initalBalance;
            Number = accountNumberSeed;
            accountNumberSeed++;
        }

        public decimal CheckBalance()
        {
            throw new NotImplementedException();
        }

        public void MakeDeposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void MakeWithdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void MakeTransfer(int accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
