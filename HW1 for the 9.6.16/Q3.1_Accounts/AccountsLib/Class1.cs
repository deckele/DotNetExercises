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

        public int ID
        {
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

        public Account(int acc_id)
        {
            _id = acc_id;
        }

        public void Deposit(decimal money)
        {
            _balance += money;
            Console.WriteLine("{0:C2} deposited.", Balance);
        }
        public void Withdraw(decimal money)
        {
            if (_balance >= money)
            {
                _balance -= money;
                Console.WriteLine("{0:C2} withdrawn.", Balance);
            }
            else
            {
                Console.WriteLine("Can't Withdraw specified amount. Current balance = {0:C2}.", Balance);
            }
        }
        public void Transfer(decimal money, Account acc)
        {
            if (_balance >= money)
            {
                Withdraw(money);
                acc.Deposit(money);
                Console.WriteLine("Transfer successful! Transferred {0:C2} to Account number: {1}.", Balance, acc.ID);
            }
            else
            {
                Console.WriteLine("Transfer failed. Not enough money in account. Current balance = {0:C2}.", Balance);
            }
        }
    }
    public static class AccountFactory
    {        
        public static Account CreateAccount(decimal money)
        {
            int acc_id = new Random().Next(1000, 10000);
            Account acc = new Account(acc_id);
            acc_id++;
            acc.Deposit(money);
            return acc;
        }
    }
}
