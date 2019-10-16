using IdealFinancialAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //needs to saved in the database as hash value with a key for security

        public ICollection<Account> Accounts { get; set; }

        public User()
        {
            Accounts = new List<Account>();
        }
    }
}
