using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using NetBankingDAL;

namespace NetBankingBL
{
    public class AccountBL
    {
        public string CreateAccount(IAccount accountNew)
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.CreateAccount(accountNew);

        }
    }
}
