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

        public void MakeDeposit(decimal amount, string transactionDescription);

        public void MakeWithdrawal(decimal amount, string transactionDescription);

        public void MakeTransfer(uint recieverAccountNumber, decimal amount, string transactionDescription);
    }
}
