using ConsoleBankApp.Models;
using ConsoleBankApp.Models.AccountTypes;
using System.Text;

char nairaSymbol = '\u20A6';
Console.OutputEncoding = Encoding.UTF8;
CurrentAccount myNewAccount = new CurrentAccount(new User("Joshua", "Daria"), 10000);
Console.WriteLine($"Account {myNewAccount.Number} was created for {myNewAccount.Owner.FullName} with {nairaSymbol}{myNewAccount.CheckBalance}.");

myNewAccount.MakeWithdrawal(2000, "shopping allowance");
decimal accountBalance = myNewAccount.CheckBalance();
Console.WriteLine(accountBalance);

