using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public interface IAccount
    {
        string type { get; set; }
        int accountNumber { get; set; }
        int CustomerId { get; set; }
        double InterestRate { get; set; }
        double Balance { get; set; }
        //List<Transaction> transactionList { get; set; }

        void addTransaction(Transaction transactionNew);

        string withdraw(double amount);

        string deposit(double amount);


    }
}
