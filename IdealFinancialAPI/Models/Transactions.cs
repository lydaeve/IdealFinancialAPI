using IdealFinancialAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static IdealFinancialAPI.Helpers.CustomEnums;

namespace IdealFinancialAPI.Models
{
    public class Transactions 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }

        public TransactionType TypeTxn { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Created date is not valid")]
        public DateTime? CreatedAt { get; set; }
    }
}
