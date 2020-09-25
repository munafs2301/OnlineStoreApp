using BankerApp.Models;
using System;

namespace BankerApp.Infrastructure.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public TransactionTypes TransactionTypes { get; set; }
        public decimal amount { get; set; }
        public string UserId { get; set; }
        public decimal newBalance { get; internal set; }
        public decimal previousBalance { get; internal set; }
        public DateTime TimeofTransaction { get; internal set; }
        public string AccountId { get; internal set; }
        public bool status { get; set; }
        public int customerId { get; internal set; }
        public Customer customer { get; set; }
        public Account account { get; set; }
        public ApplicationUser User { get; set; }
    }

    public enum TransactionTypes
    {
        Deposit = 1,
        Withdrawal = 2,
        Transfer = 3
    }
}