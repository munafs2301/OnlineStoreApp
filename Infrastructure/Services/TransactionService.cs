using BankerApp.Infrastructure.Entities;
using BankerApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static BankerApp.Infrastructure.Entities.Transactions;

namespace BankerApp.Infrastructure.Services
{
    public class TransactionService
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Account GetCustomerAccountDetails(string userid, string accountnumber = "")
        {
           
            Account customeraccount = new Account();
            if (!string.IsNullOrEmpty(userid))
            {                
                customeraccount = db.accounts.Where(a => a.customer.UserId == userid).FirstOrDefault();                
                //OR
                //customeraccount = db.accounts.Include("Customer").Where(a => a.customer.UserId == userid).FirstOrDefault();
            }
            else
            {
                customeraccount = db.accounts.Where(a => a.Id == accountnumber).FirstOrDefault();
            }

            return customeraccount;
        }

        public void UpdateAccountAmount(Account AccounttoUpdate, decimal amount, TransactionTypes type)
        {
            if (type == TransactionTypes.Deposit)
            {
                AccounttoUpdate.balance = AccounttoUpdate.balance + amount;
            }
            else
            {
                AccounttoUpdate.balance = AccounttoUpdate.balance - amount;
            }

            db.Entry(AccounttoUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool SaveTransactionRecord(decimal amount, decimal previousbalance, int customerid, string AccountId, TransactionTypes type)
        {
            decimal newbalance = 0;
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                try
                {
                    if (type == TransactionTypes.Deposit)
                    {
                        newbalance = previousbalance + amount;
                    }
                    else
                    {
                        newbalance = previousbalance - amount;
                    }

                    Transactions newrecord = new Transactions()
                    {
                        AccountId = AccountId,
                        previousBalance = previousbalance,
                        newBalance = newbalance,
                        customerId = customerid,
                        TimeofTransaction = DateTime.Now,
                        TransactionTypes = type,
                        UserId = HttpContext.Current.User.Identity.GetUserId()
                    };

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
    }
}