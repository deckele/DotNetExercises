using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace MainAccounts
{
    class UserInterface
    {        
        private bool exit = false;
        private bool back = false;

        public string errorMessage;
        public string message;

        //First menu user encounters, where he can creat a new account or choose an existing one.
        public void AccountCreationMenu()
        {
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose action:");
                Console.WriteLine("1) Login to existing account.  2) Create new acount.  3) Exit aplication.\n");
                Console.WriteLine();
                Console.WriteLine(errorMessage);

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                Console.WriteLine("Please select account ID.");
                                try
                                {
                                    int index = UserIDInput();
                                    Account currentAccount = AccountFactory.accountData[index];
                                    MainAccountMenu(currentAccount);
                                }
                                catch (ArgumentException)
                                {
                                    AccountCreationMenu();
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("How much would you like to initially deposite?");
                                AccountFactory.CreatAccount(UserMoneyInput());
                                Account currentAccount = AccountFactory.accountData[AccountFactory.accountData.Count - 1];
                                MainAccountMenu(currentAccount);
                                break;
                            }
                        case "3":
                            {
                                exit = true;
                                back = true;
                                Console.WriteLine("Thank you for using E-Bank! Goodbye!");
                                break;
                            }
                        default:
                            {
                                errorMessage = "Error: invalid opperation. Pleae choose a number between (1-3).";
                                break;
                            }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex);
                }
                catch (InsufficientFundsException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex);
                }
                catch (ArgumentException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex.Message);
                }
            }
        }
        //Second menu user encounters, where he can do all account actions (deposit, withdraw, transfer...)
        public void MainAccountMenu(Account account)
        {
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Account no. {0}.", account.ID);
                Console.WriteLine("Choose action:");
                Console.WriteLine("1) Check balance.  2) Deposit.  3) Withdraw.  4) Transfer.  5) Log out.\n");
                Console.WriteLine();
                Console.WriteLine(message);
                Console.WriteLine(errorMessage);
                try {
                        switch (Console.ReadLine())
                        {
                        case "1":
                            {
                                message = string.Format("Account balance is ${0}.", account.Balance);
                                errorMessage = null;
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("How many $ would you like to deposit?");
                                message = null;
                                account.Deposit(UserMoneyInput());
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("How many $ would you like to withdraw?");
                                message = null;
                                account.Withdraw(UserMoneyInput());
                                break;
                            }
                        case "4":
                            {

                                Console.WriteLine("Choose account ID for transfer.");
                                message = null;
                                int account2 = UserIDInput();
                                Console.WriteLine("How many $ would you like to transfer?");
                                decimal money = UserMoneyInput();
                                account.Transfer(money, AccountFactory.accountData[account2]);
                                message = account.message;
                                break;

                            }
                        case "5":
                            {
                                message = null;
                                AccountCreationMenu();
                                break;
                            }
                        default:
                            {
                                errorMessage = "Error: invalid opperation. Pleae choose a number between (1-5).";
                                break;
                            }
                        }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex.Message);
                }
                catch (InsufficientFundsException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex.Message);
                }
                catch (ArgumentException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex.Message);
                }
            }
        }

        //Checks if money input by user is a valid decimal number.
        private decimal UserMoneyInput()
        {
            decimal money = 0;
            bool checkMoney = false;
            while (!checkMoney)
            {
                checkMoney = decimal.TryParse(Console.ReadLine(), out money);
                if (checkMoney)
                {
                    errorMessage = null;
                    return money;
                }
                else
                {
                    errorMessage ="Error: input was not a valid number. Please try again.";
                }
            }
            return money;
        }
        //Checks if Account ID input by user is a valid integer and in range of the accounts array "AccountFactory.accountData".
        private int UserIDInput()
        {
            int id = 0;
            bool checkID = false;
            while (!checkID)
            {
                try
                {
                    checkID = int.TryParse(Console.ReadLine(), out id);

                    if (checkID)
                    {
                        if (id < AccountFactory.accountData.Count)
                        {
                            errorMessage = null;
                            return id;
                        }
                        else
                        {
                            throw new ArgumentException("account ID not in database.");
                        }
                    }

                    else
                    {
                        errorMessage = "Error: Invalid input. Please try again.";
                        Console.WriteLine(errorMessage);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex.Message);
                }
                catch (InsufficientFundsException ex)
                {
                    errorMessage = string.Format("Error: {0}", ex.Message);
                }
                catch (ArgumentException ex)
                {
                    errorMessage = ex.Message;
                    throw;
                }
            }
            return id;
        }
    }
}
