using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Checking : IAccount
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
            if (this.Balance > amount)
            {
                this.Balance = this.Balance - amount;
                Transaction transactionNew = new Transaction()
                {
                    message = $"${amount} has been withdrawn at {DateTime.Now} balance is now ${this.Balance}."
                };
                this.addTransaction(transactionNew);

                return $"You withdrew ${amount} from account number {this.accountNumber}. Your balance is now ${this.Balance}.";
            }
            else
            {
                return $"You can not withdrawl ${amount} because you only have ${this.Balance} in you account.";
            }
 
        }

        public string deposit(double amount)
        {

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
