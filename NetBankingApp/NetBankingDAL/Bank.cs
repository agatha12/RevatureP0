using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace NetBankingDAL
{
    public static class Bank
    {

        public static int custNumber = 0;

        public static int accntNumber = 0;

        public static List<Customer> CustomerList = new List<Customer>();

        public static List<IAccount> AccountList = new List<IAccount>();

        public enum accountType
        {
            checking,
            buisness,
            term,
            loan
        };


    }
}
