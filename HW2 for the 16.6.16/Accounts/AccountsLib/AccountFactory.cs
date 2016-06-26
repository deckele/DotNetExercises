using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int _id = 0;
        public static List<Account> accountData = new List<Account>();

        public static Account CreatAccount(decimal money)
        {
            accountData.Add(new Account(_id));
            accountData[_id].Deposit(money);
            _id++;
            return accountData[_id - 1];
        }
    }
}
