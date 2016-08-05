using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        private int _id;
        private decimal _balance;
        
        public int ID {             //property
            get
            {
                return _id;
            }
        }             
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        internal Account(int factoryid)   //constructor
        {
            _id = factoryid;
        }

        public void Deposit(decimal money)
        {
            _balance += money;
            Console.WriteLine("Deposited: ${0}. New balance: ${1}", money, Balance);
        }
        public void Withdraw(decimal money)
        {
            if (money <= Balance)
            {
                _balance -= money;
                Console.WriteLine("Withdrew: ${0}. New balance: ${1}", money, Balance);
            }
            else
            {
                Console.WriteLine("Not enough money in account. Action canceled. Balance: ${0}", Balance);
            }
        }
        public void Transfer(Account acc, decimal money)
        {
            if (money <= Balance)
            {
                _balance -= money;
                acc._balance += money;
                Console.WriteLine("Transferred: ${0} from account {1} to {2}. New balance: ${3}", money, ID, acc.ID, Balance);
            }
            else
            {
                Console.WriteLine("Not enough money in account. Action canceled. Balance: ${0}", Balance);
            }
        }
        
    }

    public class AccountFactory
    {
        private static int factoryid =  new Random().Next(100,1000);
        public static Account CreateAccount(decimal money)
        {
            Account acc = new Account(factoryid);
            Console.WriteLine("Created new account number: {0}. Depositing initial amount: ${1}...", acc.ID, money);
            acc.Deposit(money);
            factoryid++;
            return acc;
        }
    }
}
