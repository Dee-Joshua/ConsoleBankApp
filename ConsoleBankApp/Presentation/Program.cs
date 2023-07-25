using System.Diagnostics.Metrics;
using System.Diagnostics;
using ConsoleBankApp.Models;

Console.WriteLine("************** AlphaTech Bank *****************");

//Login or create account
LandingPage();





//Methods Hidden here
static void LandingPage()
{
    Console.WriteLine("\n1. SignIn \n2. SignUp \nPress any key to EXIT");
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
        return;
    }
}

static void SignInPage()
{
    Console.WriteLine("\n::SignIn Page::");
    Console.Write("EmailAddress(Press ENTER to exit): ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();
    //Call method in business logic to check for stored email and password from list of customers
    AccountPage();
}

static void SignUpPage()
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

static void AccountPage()
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

static void CreateAccountPage()
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

static void MainMenu()
{
    Console.WriteLine("\n:::Main Menu:::");
    Console.WriteLine("1. Deposit funds \n2. Withdraw funds \n3. Transfer funds \n4. Check balance \n5. Account Statement \n0. Exit");
    Console.Write("Enter choice:    ");
    string choice = Console.ReadLine();
}

static void DepositPage()
{
    Console.WriteLine("\n****Funds Deposit Page****");
    Console.Write("Please enter deposit amount: ₦");
    Console.ReadLine();
}

static void WithdrawPage()
{
    Console.WriteLine("\n****Funds Withdrawal Page****");
    Console.Write("Please enter withdrawal amount: ₦");
    Console.ReadLine();
}

static void TransferPage()
{
    Console.WriteLine("\n****Funds Transfer Page****");
    Console.Write("Please enter reciever's account number: ");
    Console.ReadLine();
    Console.Write("Please enter deposit amount: ₦");
    Console.ReadLine();
}

static void BalancePage()
{
    Console.WriteLine("\n****Account Balance****");
    Console.WriteLine("Your current account balance is: ₦{}");
}

static void StatementPage()
{
    Console.WriteLine("\n****Account Statement****");
    Console.WriteLine("");
}