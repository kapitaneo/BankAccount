using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public DateTime? DateofPay { get; set; }
        public string AdminName { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; } 
    }
}