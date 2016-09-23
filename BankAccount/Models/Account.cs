using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }

        [DataType(DataType.Currency)]
        public double Balance { get; set; }

 //       [DataType(DataType.Date)]
        public DateTime? DateofRegistration { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public Account()
        {
            Transactions = new List<Transaction>();
        }   

    }
}