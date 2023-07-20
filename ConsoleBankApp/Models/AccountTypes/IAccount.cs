using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Models.AccountTypes
{
    internal interface IAccount
    {
        public decimal CheckBalance();

        public void MakeDeposit(decimal amount);

        public void MakeWithdraw(decimal amount);

        public void MakeTransfer(int accountNumber, decimal amount);
    }
}
