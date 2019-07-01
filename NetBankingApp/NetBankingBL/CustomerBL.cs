using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using NetBankingDAL;

namespace NetBankingBL
{
    public class CustomerBL
    {
        public string Create(Customer newCustomer)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            return customerDAL.Create(newCustomer);
        }
    }
}


//public void Create(Customer newCustomer)
//{
//    // Call the DAL to create a new record.
//    CustomerDAL customerDAL = new CustomerDAL();
//    customerDAL.Create(newCustomer);
//}

//public Customer Get(int id)
//{
//    CustomerDAL dal = new CustomerDAL();
//    try
//    {
//        var customer = dal.Get(id);
//        if (customer != null)
//        {
//            // Data found. Process it and return to UI.
//            return customer;
//        }
//        else
//        {
//            return null;
//        }
//    }
//    catch (Exception ex)
//    {
//        // Log it.
//        throw;
//    }
//}

//public List<Customer> GetAll()
//{
//    CustomerDAL dal = new CustomerDAL();
//    var customers = dal.GetAll();

//    return customers;
//}