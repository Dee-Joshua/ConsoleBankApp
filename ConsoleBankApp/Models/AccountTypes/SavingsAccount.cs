using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models.AccountTypes
{
    internal class SavingsAccount : IAccount
    {
        private User Owner;
        public int Number { get; }
        public decimal Balance { get; }

        public SavingsAccount(User accountOwner, decimal initalBalance)
        {
            Owner = accountOwner;
            Balance = initalBalance;
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
