using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankerApp.Infrastructure.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public decimal balance { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int count { get; set; }
        public DateTime DateCrated { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
    }
}