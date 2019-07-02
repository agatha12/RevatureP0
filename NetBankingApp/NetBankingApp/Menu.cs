using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBankingBL;
using NetBankingDAL;
using Entities;


namespace NetBankingApp
{
    public static class Menu
    {
        public static void menu()
        {
            Console.WriteLine("Welcome to the bank.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Register as a new customer");
            Console.WriteLine("2. Create a new account");
            Console.WriteLine("3. Make a transaction on an exisitng account");
            Console.WriteLine("4. View list of accounts for a customer");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":

                    Console.WriteLine("Please enter your first name...");
                    string fname = Console.ReadLine();
           
             

                    Console.WriteLine("Please enter your last name...");
                    string lname = Console.ReadLine();
       
                    Console.WriteLine("Please enter your area code");
                    int areaCode = getAreaCode();

                    Console.WriteLine("Please enter you phone number...");
                    int phoneNumber = getPhoneNumber();



                    Customer customerNew = new Customer()
                    {
                        Id = Bank.custNumber,
                        firstName = fname,
                        lastName = lname,
                        areaCode = areaCode,
                        phoneNumber= phoneNumber

                    };
                    Bank.custNumber++;
                    CustomerBL customerBL = new CustomerBL();
                    Console.WriteLine(customerBL.Create(customerNew));

                    menu();

                    break;
                case "2":
                    Console.WriteLine("Please enter your Customer ID");
                    int custId = getCustomerId();



                    Console.WriteLine("What type of account would you like to open?");
                    Console.WriteLine("Press 1 for Checking");
                    Console.WriteLine("Press 2 for Business");
                    Console.WriteLine("Press 3 for Term");
                    Console.WriteLine("Press 4 for Loan");
                    string type = Console.ReadLine();
                    double rate = 0.00;
                    double balance = 0;
                    if (type == "1")
                    {
                        type = "Checking";
                        rate = 0.11;
                        IAccount accountNew = new Checking()
                        {
                            type = type,
                            accountNumber = Bank.accntNumber,
                            CustomerId = custId,
                            InterestRate = rate,
                            Balance = balance
                        };

                        Bank.accntNumber++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.CreateAccount(accountNew));



                    }
                    else if (type == "2")
                    {
                        type = "Business";
                        rate = 1.14;
                        IAccount accountNew = new Business()
                        {
                            type = type,
                            accountNumber = Bank.accntNumber,
                            CustomerId = custId,
                            InterestRate = rate,
                            Balance = balance
                        };
                        Bank.accntNumber++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.CreateAccount(accountNew));
                    }
                    else if (type == "3")
                    {
                        type = "Term";
                        rate = 3.0;
                        Console.WriteLine("How much would you like to deposit in your term account?");
                        balance = Convert.ToInt32(Console.ReadLine());
                        IAccount accountNew = new Term()
                        {
                            type = type,
                            accountNumber = Bank.accntNumber,
                            CustomerId = custId,
                            InterestRate = rate,
                            Balance = balance
                        };
                        Bank.accntNumber++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.CreateAccount(accountNew));
                    }
                    else if (type == "4")
                    {
                        type = "Loan";
                        rate = 4.5;
                        Console.WriteLine("How much would you like to take out as a loan?");
                        balance = 0 - Convert.ToInt32(Console.ReadLine());

                        IAccount accountNew = new Loan()
                        {
                            type = type,
                            accountNumber = Bank.accntNumber,
                            CustomerId = custId,
                            InterestRate = rate,
                            Balance = balance
                        };
                        Bank.accntNumber++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.CreateAccount(accountNew));
                    }
                    else
                    {
                        invalidKey();
                    }
                    Menu.menu();
                    break;
                case "3":
                    Console.WriteLine("What is your account number?");
                    int accountId = getAccountNumber();
                    
                    int accountIndex = Bank.AccountList.FindIndex(a => a.accountNumber.Equals(accountId));

                    Console.WriteLine("What is your Customer Id?");
                    int yourId = getCustomerId();
                    if (yourId != Bank.AccountList[accountIndex].CustomerId)
                    {
                        Console.WriteLine($"That is not the correct customer Id for account number {accountId}");
                        returnToMain();
                    }

                    Console.WriteLine("What type of transaction would you like to make?");
                    Console.WriteLine("Press 1 for Withdrawl");
                    Console.WriteLine("Press 2 for Deposit");
                    Console.WriteLine("Press 3 to Transfer Funds between accounts");
                    Console.WriteLine("Press 4 to Check balance");
                    Console.WriteLine("Press 5 to View transaction log");
                    Console.WriteLine("Press 6 to Delete account");
                    string transType = Console.ReadLine();

                    if (transType == "1")
                    {
                        Console.WriteLine("How much would you like to withdraw?");
                        double amount = getAmount();



                        var accountType = Bank.AccountList[accountIndex].type;
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));
                            returnToMain();

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));
                            returnToMain();


                        }
                        else if (accountType == "Term")
                        {
                            Term accountNew = new Term();
                            accountNew = (Term)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));
                            returnToMain();

                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));
                            returnToMain();
                        }





                    }
                    else if (transType == "2")
                    {
                        Console.WriteLine("How much would you like to deposit?");
                        var accountType = Bank.AccountList[accountIndex].type;
                        double amount = getAmount();
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            returnToMain();

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            returnToMain();


                        }
                        else if (accountType == "Term")
                        {
                            Term accountNew = new Term();
                            accountNew = (Term)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            returnToMain();

                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            returnToMain();
                        }
                    }
                    else if (transType == "3")
                    {

                        Console.WriteLine("Enter the account number of the account you would like to transfer money to.");
                        int toAccount = getAccountNumber();
                        if (!Menu.accountIdValidation(toAccount))
                        {
                            Console.WriteLine("There is no account under that number.");
                            Console.WriteLine("Please press enter to return to the main menu");
                            Console.ReadLine();
                            Menu.menu();
                        }
                        int toAccountIndex = Bank.AccountList.FindIndex(a => a.accountNumber.Equals(toAccount));

                        if (yourId != Bank.AccountList[toAccountIndex].CustomerId)
                        {
                            Console.WriteLine($"That account is registered under a different customer.");
                            Console.WriteLine("You can only transfer between your own accounts.");
                            returnToMain();
                        }




                        var toAccountType = Bank.AccountList[toAccount].type;

                        var accountType = Bank.AccountList[accountIndex].type;

                        Console.WriteLine("How much would you like to transfer?");
                        double amount = getAmount();
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));

                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)Bank.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                Menu.menu();
                            }
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)Bank.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                Menu.menu();
                            }
                            else
                            {
                                Console.WriteLine("You can only trasfer between Checking and Buisness accounts. ");
                                Menu.menu();
                            }

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)Bank.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));

                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)Bank.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                Menu.menu();
                            }
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)Bank.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                Menu.menu();
                            }
                            else
                            {
                                Console.WriteLine("You can only trasfer between Checking and Buisness accounts. ");
                                Menu.menu();
                            }

                        }
                        else
                        {
                            Console.WriteLine("You can only trasfer between Checking and Buisness accounts. ");
                            Menu.menu();
                        }


                    }
                    else if (transType == "4")
                    {

                        var yourBalance = Bank.AccountList[accountIndex].Balance;
                        Console.WriteLine($"Your account balance is ${yourBalance}");
                        Menu.menu();

                    }
                    else if (transType == "5")
                    {
                        var accountType = Bank.AccountList[accountIndex].type;
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)Bank.AccountList[accountIndex];
                            foreach (Transaction item in accountNew.getLog())
                            {
                                Console.WriteLine(item.message);
                            }
                            returnToMain();

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)Bank.AccountList[accountIndex];
                            foreach (Transaction item in accountNew.getLog())
                            {
                                Console.WriteLine(item.message);
                            }
                            returnToMain();


                        }
                        else if (accountType == "Term")
                        {
                            Term accountNew = new Term();
                            accountNew = (Term)Bank.AccountList[accountIndex];
                            foreach (Transaction item in accountNew.getLog())
                            {
                                Console.WriteLine(item.message);
                            }
                            returnToMain();

                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)Bank.AccountList[accountIndex];
                            foreach (Transaction item in accountNew.getLog())
                            {
                                Console.WriteLine(item.message);
                            }
                            returnToMain();
                        }

                    }
                    else if (transType == "6")
                    {


                        Bank.AccountList.RemoveAt(accountIndex);
                        Console.WriteLine($"You're account has been deleted");
                        Menu.menu();


                    }
                    else
                    {
                        invalidKey();
                    }

                    break;
                case "4":

                    Console.WriteLine("Please enter your customer ID");
                    int CustId = getCustomerId();
                    if (!Menu.customerIdValidation(CustId))
                    {
                        Console.WriteLine("There is no customer under that number.");
                        returnToMain();
                    }
                    else
                    {
                        Console.WriteLine("The customer Id you provided is associated with the following accounts...");
                        foreach (IAccount item in Bank.AccountList)
                        {
                            if (item.CustomerId == CustId) {
                                Console.WriteLine($"{item.type} account with a balance of ${item.Balance} and an account number of {item.accountNumber}");
                            }
                        }
                        returnToMain();
                    }


                    break;
                default:
                    invalidKey();
                    break;
            }
        }

        public static bool customerIdValidation(int Id)
        {
            bool x = false;

            foreach (Customer item in Bank.CustomerList)
            {
                if (item.Id == Id)
                {
                    x = true;
                }
            }

            return x;
        }

        public static bool accountIdValidation(int accountId)
        {
            bool x = false;

            foreach (IAccount item in Bank.AccountList)
            {
                if (item.accountNumber == accountId)
                {
                    x = true;
                }
            }

            return x;
        }

        public static void invalidKey()
        {
            Console.WriteLine("You have pressed and invalid key.");
            Console.WriteLine("Please press enter to return to the main menu");
            Menu.menu();
        }

        public static void returnToMain()
        {
            Console.WriteLine("Please press enter to return to the main menu");
            Console.ReadLine();
            Menu.menu();
        }

        public static int getAreaCode()
        {
            try
            {
                int areaCode = Convert.ToInt32(Console.ReadLine());
                if (areaCode < 100 || areaCode > 999)
                {
                    Console.WriteLine("That was not a valid area code");
                    Menu.menu();
                }
                return areaCode;
            }
            catch
            {
                Console.WriteLine("That was not a valid area code");
                Menu.menu();
                return 0;
            }
        }

        public static int getPhoneNumber()
        {
            try
            {
                int phoneNumber = Convert.ToInt32(Console.ReadLine());

                if (phoneNumber < 1000000 || phoneNumber > 9999999)
                {
                    Console.WriteLine("That was not a valid phone number");
                    Menu.menu();
                }
                return phoneNumber;
            }
            catch
            {
                Console.WriteLine("That was not a valid phone number");
                Menu.menu();
                return 0;
            }
        }

        public static int getCustomerId()
        {
            try
            {
                int custId = Convert.ToInt32(Console.ReadLine());
                if (!Menu.customerIdValidation(custId))
                {
                    Console.WriteLine("There is no customer under that number.");
                    returnToMain();
                }
                return custId;
            }
            catch
            {
                Console.WriteLine("That was not a valid customer Id");
                Menu.menu();
                return 0;
            }
        }



        public static int getAccountNumber()
        {
            try
            {
                int accountId = Convert.ToInt32(Console.ReadLine());
                if (!Menu.accountIdValidation(accountId))
                {
                    Console.WriteLine("There is no account under that number.");
                    Console.WriteLine("Please press enter to return to the main menu");
                    Console.ReadLine();
                    Menu.menu();
                }
                return accountId;
            }
            catch
            {
                invalidKey();
                return 0;
            }
        }

        public static double getAmount()
        {
            
                     try
            {
                double amount = Convert.ToInt32(Console.ReadLine());
  
                return amount;
            }
            catch
            {
                invalidKey();
                return 0;
            }
        }
        

    }
}
