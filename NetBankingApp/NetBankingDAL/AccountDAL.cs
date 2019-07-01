using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace NetBankingDAL
{
    public class AccountDAL
    {
        public string CreateAccount(IAccount accountNew)
        {
            string accntInfo = $"Congradulations you have created a new {accountNew.type} account.";
            accntInfo += $"Your new account number is {accountNew.accountNumber}. ";
            accntInfo += $"Your new account has a balance of {accountNew.Balance} and your inerest rate is {accountNew.InterestRate}.";
            Bank.AccountList.Add(accountNew);

            return accntInfo;
        }
    }
}
