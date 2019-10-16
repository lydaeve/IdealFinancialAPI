using IdealFinancialAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public double AvailableFunds { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

       // [DataType(DataType.DateTime, ErrorMessage = "Created date is not valid")]
        public DateTime? CreatedAt { get; set; }

        public ICollection<Transactions> Transactions { get; set; }
        public ICollection<CreditLine> CreditLine { get; set; }

        public Account()
        {
            Transactions = new List<Transactions>();
            CreditLine = new List<CreditLine>();
        }
    }
}
