using BankerApp.Infrastructure.Entities;
using BankerApp.Infrastructure.ViewModels;
using BankerApp.Models;
using System;
using System.Linq;

namespace BankerApp.Infrastructure.Services
{
    public class CustomerService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int CreateCustomer(RegisterCustomerViewModel model, string userid)
        {

            Customer newcustomer = new Customer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                UserId = userid
            };

            db.customers.Add(newcustomer);
            db.SaveChanges();

            return newcustomer.ID;
        }

        public void CreateCustomerAccount(int customeruserid,string format, decimal bonus = 500)                                         
        {
            Account newaccount = new Account()
            {
                Id = GenerateAccountNumber(format),
                customerId = customeruserid,
                balance = bonus
            };

            db.accounts.Add(newaccount);
            db.SaveChanges();
        }

        public string GenerateAccountNumber(string initial)
        {
            string accountnumber = "";
            var lastaccountnumber = db.accounts.ToList().LastOrDefault();
            if (lastaccountnumber != null)
            {
                int newcount = lastaccountnumber.count + 1;
                accountnumber = initial + DateTime.Now.Year + newcount;
            }
            else
            {
                accountnumber = initial + DateTime.Now.Year + "001";
            }
            return accountnumber;
        }
    }
}