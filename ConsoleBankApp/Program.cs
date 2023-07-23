using ConsoleBankApp.Models;
using ConsoleBankApp.Models.AccountTypes;
using System.Text;

char nairaSymbol = '\u20A6';
Console.OutputEncoding = Encoding.UTF8;
var userAccount = new CurrentAccount(new User("Joshua", "Daria"), 10000);
Console.WriteLine($"Account {userAccount.Number} was created for {userAccount.Owner.FullName} with {nairaSymbol}{userAccount.Balance}.");