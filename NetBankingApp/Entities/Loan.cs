using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Loan : IAccount
    {
        public string type { get; set; }
        public int accountNumber { get; set; }
        public int CustomerId { get; set; }
        public double InterestRate { get; set; }
        public double Balance { get; set; }


  


        public List<Transaction> transactionList = new List<Transaction>();

        public void addTransaction(Transaction transactionNew)
        {
            this.transactionList.Add(transactionNew);
        }

        public string withdraw(double amount)
        {

            return "You can not withdraw from a loan account";
        }

        public string deposit(double amount)
        {
            
            if ((this.Balance + amount) > 0)
            {
                return $"You can not deposit more than the balance that remains on your loan. Your loan balance is currently {this.Balance}";
            }
            this.Balance = this.Balance + amount;
            Transaction transactionNew = new Transaction()
            {
                message = $"${amount} has been deposited at {DateTime.Now} balance is now ${this.Balance}."
            };
            this.addTransaction(transactionNew);


            return $"You have deposited ${amount} into account number {this.accountNumber}. Your balance is now ${this.Balance}.";

        }



        public List<Transaction> getLog()
        {
            return this.transactionList;
        }
    }
}
