using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdealFinancialAPI.Models;
using IdealFinancialAPI.Repositories.Interfaces;
using IdealFinancialAPI.Helpers;
using Newtonsoft.Json;

namespace IdealFinancialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(AppDbContext context, IAccountRepository accountRepository, ITransactionRepository transactionRepository )
        {
            _context = context;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        // POST: api/Transactions
        [HttpPost]
        public IActionResult PostTransactions(Transactions transactions)
        {
            try
            {
                var account =  _accountRepository.FindBy(transactions.AccountId);
                if (account == null)
                {
                    throw new AppExceptions("Account not found");
                }
                if (transactions.Amount < 0)
                {                    
                    throw new AppExceptions("Amount must be greater than zero.");
                }
                else
                {
                    if(transactions.TypeTxn == CustomEnums.TransactionType.Withdraw)
                    {
                        if (transactions.Amount <= account.AvailableFunds)
                        {
                            Transactions txn = _transactionRepository.AddDrawTransaction(transactions);
                            var result = _transactionRepository.Add(txn);
                            var acc = _transactionRepository.EditTransaction(txn, account);
                            var accUpdated = _accountRepository.Edit(acc);
                            var js = JsonConvert.SerializeObject("Transaction created successfully");
                            return Ok(js);
                        }
                        else
                        {
                            throw new AppExceptions("Amount exceeds available funds.");
                        }                        
                    }                   
                    else
                    {
                        throw new AppExceptions("Must be a widthdraw.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}
