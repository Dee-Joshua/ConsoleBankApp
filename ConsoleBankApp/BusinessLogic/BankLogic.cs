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
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Other Name(s): ");
            string otherName = Console.ReadLine();
            Console.Write("Email Address: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string mobile = Console.ReadLine();
            Console.Write("Resident Address: ");
            string address = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();

            //If logic the call a method which validates the user input and returns a bool value
            SignInPage();
        }

        public static void AccountPage()
        {
            Console.WriteLine("\nPlease select your bank account or create a new one to start transactions");
            Console.WriteLine("1. {} \n2. {} \n3. Create new bank account");
            Console.Write("Enter choice:    ");
            string choice = Console.ReadLine();
            string sourceAccountNumber;

            if (choice.StartsWith("1") //&& !account.Number.IsNullorEmpty)
        {
                sourceAccountNumber = null;
                MainMenu();
            }
            else if (choice.StartsWith("2")  //&& !account.Number.IsNullorEmpty )
        {
                sourceAccountNumber = "";
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
            if (choice.StartsWith("1"))
            {
                //accounttype = "Current"
                //Create account method
                MainMenu();
            }
            else if (choice.StartsWith("2"))
            {
                //acounttype = "Savings"
                //Create and save account method
                MainMenu();
            }
            else
            {
                Console.WriteLine("!!! Invalid Selection !!!");
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
            decimal crdAmount;
            if (decimal.TryParse(Console.ReadLine(), out crdAmount))
            {
                //deposit method call

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
            decimal debAmount;
            if (decimal.TryParse(Console.ReadLine(), out debAmount))
            {
                //withdrawal method call

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


            if (destinationAccount == //acount numbers in banks)
    {
                Console.Write("Please enter deposit amount: ₦");
                if (decimal.TryParse(Console.ReadLine(), out debAmount))
                {
                    //withdrawal method call

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
            Console.WriteLine("Your current account balance is: ₦{}");
        }

        public static void StatementPage()
        {
            Console.WriteLine("\n****Account Statement****");
            Console.WriteLine();

        }
    }
}

