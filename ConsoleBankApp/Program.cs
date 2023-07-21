using ConsoleBankApp.Models;
using ConsoleBankApp.Models.AccountTypes;

var userAccount = new CurrentAccount(new User("Joshua", "Daria"), 10000);
Console.WriteLine($"Account {userAccount.Number} was created for {userAccount.Owner.FullName} with \u20A6 {userAccount.Balance}.");