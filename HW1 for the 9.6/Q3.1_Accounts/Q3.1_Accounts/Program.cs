using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace Q3._1_Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            bool prog = true;
            bool access = false;
            List<Account> acc_list = new List<Account>();

        Console.WriteLine("Welcome to E-bank!");
            while (prog)
            {
                Console.WriteLine("What would you like to do?\n1. Access existing account.\n2. Creat new account.\n3. Exit.");
                int choice = Console.Read();
                if (choice == 1)
                {
                    Console.WriteLine("What is you account ID?");
                    string choice_ID = Console.ReadLine();
                    if (acc_list.Exists(element => element == choice_ID))
                    {
                        Console.WriteLine("Hellow account number: {0}!\n\nWhat do you want to do?\n1. Deposite.\n2. Withdraw.\n3. Transfer.\n4. Exit account.", choice2);
                        int choice3 = Console.Read();
                        switch (choice3)
                        {
                            case 1:
                                Console.WriteLine("How much?");
                                
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                }
                else if (choice == 2)
                {

                    acc_list.Add(AccountFactory.CreateAccount(100));
                }
                else if (choice == 3)
                {
                    prog = false;
                }
                else
                {
                    Console.WriteLine("Error: Invalid opperation. Please try again.");
                }               
            }
            Console.WriteLine("Thanks for using E-Bank!"); 
        }
    }
}
