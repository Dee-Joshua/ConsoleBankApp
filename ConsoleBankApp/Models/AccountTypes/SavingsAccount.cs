using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models.AccountTypes
{
    internal class SavingsAccount : IAccount
    {
        public User Owner;
        public uint Number { get; }
        public decimal Balance { get; }
        private static uint accountNumberSeed = 2345678901;

        public SavingsAccount(User accountOwner, decimal initalBalance)
        {
            Owner = accountOwner;
            Balance = initalBalance;
            Number = accountNumberSeed;
            accountNumberSeed += 10;
        }

        public decimal CheckBalance()
        {
            throw new NotImplementedException();
        }

        public void MakeDeposit(decimal amount, string transactionDescription)
        {
            throw new NotImplementedException();
        }

        public void MakeWithdrawal(decimal amount, string transactionDescription)
        {
            throw new NotImplementedException();
        }

        public void MakeTransfer(uint recieverAccountNumber, decimal amount, string transactionDescription)
        {
            throw new NotImplementedException();
        }
    }
}
