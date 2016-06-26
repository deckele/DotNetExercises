using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        private decimal _balance;
        public string message;

        internal Account(int id)
        {
            this.ID = id;
        }

        public int ID { get; }
        public decimal Balance {
            get
            {
                return _balance;
            }           
        }

        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("Money can't be negative!");
            }
            this._balance += money;
        }
        public void Withdraw(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("Money can't be negative!");
            }
            if (this.Balance >= money)
            {
                this._balance -= money;
            }
            else
            {
                throw new InsufficientFundsException("Not enough money in account. Action cancelled");
            }
        }
        public void Transfer(decimal money, Account account2)
        {
            try
            {
                if (this == account2)
                {
                    throw new ArgumentException("Can't Transfer to the same account!");
                }
                this.Withdraw(money);

                if (this.Balance >= money)
                {
                    account2.Deposit(money);
                }
            }
            finally
            {
                message = string.Format("Transfer action terminated.\nCurrent balance is: ${0}.", this.Balance);
                Console.WriteLine(message);
            }
        }
    }
}
