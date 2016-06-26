using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace Main_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitFlag = false;

            Account acc1 = AccountFactory.CreateAccount(100);
            Account acc2 = AccountFactory.CreateAccount(100);

            while (!exitFlag) { 
                Console.WriteLine("Choose action:  1. Deposit.  2. Withdraw.  3. Transfer.  4. Check Balance.  5. Exit.");
                string action1 = Console.ReadLine();
                switch (action1)
                {
                    case "1":
                        {
                            Console.WriteLine("Specify amount to deposit:");
                            decimal money = decimal.Parse(Console.ReadLine());
                            acc1.Deposit(money);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Specify amount to Withdraw:");
                            decimal money = decimal.Parse(Console.ReadLine());
                            acc1.Withdraw(money);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Specify amount to transfer:");
                            decimal money = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Input target account for transfer:");
                            Console.ReadLine();
                            Account acc = acc2;
                            acc1.Transfer(acc, money);
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("You currently have ${0} in your account.", acc1.Balance);
                            break;
                        }                   
                    case "5":
                        {
                            exitFlag = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error: Invalid opperation. Please try again.");
                            break;
                        }
                }

            }
        }
    }
}
