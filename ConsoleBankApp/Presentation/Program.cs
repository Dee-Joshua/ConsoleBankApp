using ConsoleBankApp.BusinessLogic;
using System.Text;

Console.WriteLine("Application Loading . . .");
Console.OutputEncoding = Encoding.UTF8;

//Demo Account
var admin1 = CustomerLogic.CreateCustomer("System", "Admin", "+2349025621900", "system.admin@example.com", "Nigeria", "admin1");
BankLogic.Customers.Add(admin1);
var adminAcc1 = AccountLogic.CreateAccount(admin1, "Current");
BankLogic.Accounts.Add(adminAcc1);
admin1.UserAccountNumbers[0] = adminAcc1.Number;
var adminAcc2 = AccountLogic.CreateAccount(admin1, "Savings");
BankLogic.Accounts.Add(adminAcc2);
admin1.UserAccountNumbers[1] = adminAcc2.Number;
AccountLogic.MakeDeposit(adminAcc1.Number, 2500000, "Cr./Test Funds");
AccountLogic.MakeDeposit(adminAcc2.Number, 200000, "Cr./Test Funds");

//Login or Create Account
BankLogic.LandingPage();