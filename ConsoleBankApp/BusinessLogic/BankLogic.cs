using ConsoleBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.BusinessLogic
{
    public static class BankLogic
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<Account> Accounts { get; set; } = new List<Account>();
        public static Customer currentUser { get; set; }
        public static string NumberInUse { get; set; }



        public static void LandingPage()
        {
            Console.Clear();
            Console.WriteLine("************** AlphaTech Bank *****************");
            Console.WriteLine("\n\n1. SignIn \n2. SignUp \nPress any key to EXIT");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            if (choice.StartsWith("1"))
            {
                SignInPage();
            }
            else if (choice.StartsWith("2"))
            {
                SignUpPage();
            }
            else
            {
                Console.WriteLine("\nThankyou, have a nice day :)\n");
            }
        }

        public static void SignInPage()
        {
            Console.WriteLine("\n::SignIn Page::");
            Console.Write("EmailAddress: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            //Call method in business logic to check for stored email and password from list of customers
            var findCustomer = Customers.Where(c => c.Email == username).FirstOrDefault();
            if (findCustomer != null && findCustomer.Password == password)
            {
                currentUser = findCustomer;
                AccountPage();
            }
            else
            {
                Console.WriteLine("Invalid username or password");
                LandingPage();
            }
        }

        public static void SignUpPage()
        {
            Console.WriteLine("\n::SignUp Page::");
            Console.WriteLine("Welcome to AlphaTech Bank, please enter your details below\n");
            Console.WriteLine("********NEW CUSTOMER*********");

            string lastName = GetNonEmptyInput("Last Name: ");
            string otherName = GetNonEmptyInput("Other Name(s): ");
            string email = GetValidInput("Email Address (e.g., user@example.com): ", IsValidEmail);
            string mobile = GetValidInput("Phone Number (e.g., 08012345678): ", IsValidPhoneNumber);
            string address = GetNonEmptyInput("Resident Address: ");
            string password = GetMinLengthInput("Password (at least 6 characters): ", 6);

            // Your code to process the validated input (e.g., create the customer, etc.)
            var newUser = CustomerLogic.CreateCustomer(otherName, lastName, mobile, email, address, password);
            Customers.Add(newUser);

            // Wait for user key press before exiting
            Console.ReadKey();
            SignInPage();
        }

        public static void AccountPage()
        {
            Console.WriteLine("\n:::Account Page:::\n");
            Console.WriteLine("\nPlease select your bank account or create a new one to start transactions");
            Console.WriteLine($"1. {currentUser.UserAccountNumbers[0]} \n2. {currentUser.UserAccountNumbers[1]} \n3. Create new bank account");
            Console.Write("Enter choice:    ");
            string choice = Console.ReadLine();
            

            if (choice.StartsWith("1") && currentUser.UserAccountNumbers[0] != "")
            {
                NumberInUse = currentUser.UserAccountNumbers[0];
                MainMenu();
            }
            else if (choice.StartsWith("2")  && currentUser.UserAccountNumbers[1] != "")
            {
                NumberInUse = currentUser.UserAccountNumbers[1];
                MainMenu();
            }
            else
            {
                CreateAccountPage();
            }
        }

        public static void CreateAccountPage()
        {
            Console.WriteLine("\n********NEW ACCOUNT*********");
            Console.WriteLine("1. Current \n2. Savings");
            Console.Write("Enter choice:    ");
            string choice = Console.ReadLine();
            var findAccount1 = Accounts.Where(a => a.Owner == currentUser).FirstOrDefault();
            var findAccount2 = Accounts.Where(a => a.Owner == currentUser).LastOrDefault();
            if (choice.StartsWith("1") && findAccount1.Type != "Current" && findAccount2.Type != "Current")
            {
                var newAccount = AccountLogic.CreateAccount(currentUser, "Current");
                currentUser.UserAccountNumbers[0] = newAccount.Number;
                Accounts.Add(newAccount);
                NumberInUse = newAccount.Number;
                Console.ReadKey();
                MainMenu();
            }
            else if (choice.StartsWith("2") && findAccount1.Type != "Savings" && findAccount2.Type != "Savings")
            {
                var newAccount = AccountLogic.CreateAccount(currentUser, "Savings");
                currentUser.UserAccountNumbers[1] = newAccount.Number;
                Accounts.Add(newAccount);
                NumberInUse = newAccount.Number;
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid Selection or you are trying to create an account type that already exist! \n Note: You cannot have multiple accounts of the same type (e.g both savings or both current");
                AccountPage();
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n:::Main Menu:::");
            Console.WriteLine("1. Deposit funds \n2. Withdraw funds \n3. Transfer funds \n4. Check balance \n5. Account Statement \n0. Exit");
            Console.Write("Enter choice:    ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": DepositPage(); break;
                case "2": WithdrawPage(); break;
                case "3": TransferPage(); break;
                case "4": BalancePage(); break;
                case "5": StatementPage(); break;
                case "0":
                    Console.WriteLine("Logging out...");
                    LandingPage();
                    break;
                default:
                    Console.WriteLine("\nInvalid Selection. \nPlease try again\n");
                    MainMenu();
                    break;
            }

        }

        public static void DepositPage()
        {
            Console.WriteLine("\n****Funds Deposit Page****");
            Console.Write("Please enter deposit amount: ₦");
            decimal crAmount;
            if (decimal.TryParse(Console.ReadLine(), out crAmount))
            {
                //deposit method call
                AccountLogic.MakeDeposit(NumberInUse, crAmount, "Cr./Deposit");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            MainMenu();
        }

        public static void WithdrawPage()
        {
            Console.WriteLine("\n****Funds Withdrawal Page****");
            Console.Write("Please enter withdrawal amount: ₦");
            decimal drAmount;
            if (decimal.TryParse(Console.ReadLine(), out drAmount))
            {
                //withdrawal method call
                AccountLogic.MakeWithdrawal(NumberInUse, drAmount, "Dr./Withdrawal");
            }
            else
            {
                Console.WriteLine("Invalid input. Amount must be numbers only");
            }
            MainMenu();
        }

        public static void TransferPage()
        {
            decimal debAmount;
            Console.WriteLine("\n****Funds Transfer Page****");
            Console.Write("Please enter reciever's account number: ");
            string destinationAccount = Console.ReadLine();
            var findAccount = Accounts.Where(a => a.Number == destinationAccount).FirstOrDefault();

            if (findAccount is not null)
    {
                Console.Write("Please enter deposit amount: ₦");
                if (decimal.TryParse(Console.ReadLine(), out debAmount))
                {
                    //withdrawal method call
                    AccountLogic.MakeTransfer(NumberInUse, destinationAccount, debAmount, "Dr./Transfer");
                }
                else
                {
                    Console.WriteLine("Invalid input. Amount must be numbers only");
                }
            }
            else
            {
                Console.WriteLine("This account does not exist in our Bank");
            }
            MainMenu();
        }

        public static void BalancePage()
        {
            Console.WriteLine("\n****Account Balance****");
            Console.WriteLine($"Your current account balance is: ₦{AccountLogic.CheckBalance}");
        }

        public static void StatementPage()
        {
            Console.WriteLine("\n****Account Statement****");
            Console.WriteLine(AccountLogic.GetAccountStatement(NumberInUse));
        }

        //User Input Validation Methods
        static string GetNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        static string GetValidInput(string prompt, Func<string, bool> validator)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!validator(input));
            return input;
        }

        static string GetMinLengthInput(string prompt, int minLength)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (input.Length < minLength);
            return input;
        }

        // Email validation method (using a simple regex pattern)
        static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        // Nigerian phone number validation method (must start with 0 and have 11 digits)
        static bool IsValidPhoneNumber(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone) &&
                   System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0\d{10}$");
        }
    }
}

