using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(
               new User { Id = 1, UserName = "maria12345", Password = "12345mo", Name = "Maria" }
           );

            builder.Entity<Account>().HasData(
                new Account { Id = 1, AccountNumber = "12345", Balance = 0.0, AvailableFunds = 100000, UserId = 1, CreatedAt = DateTime.Now },
                new Account { Id = 2, AccountNumber = "332456", Balance = 0.0, AvailableFunds = 200000, UserId = 1, CreatedAt = DateTime.Now }
            );         

            builder.Entity<CreditLine>().HasData(
                new CreditLine { Id = 1, Amount = 100000, AccountId = 1, CreatedAt = DateTime.Now },
                new CreditLine { Id = 2, Amount = 200000, AccountId = 2, CreatedAt = DateTime.Now }
            );
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<CreditLine> CreditLines { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
