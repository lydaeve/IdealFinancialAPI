using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdealFinancialAPI.Models;
using IdealFinancialAPI.Helpers;
using IdealFinancialAPI.Repositories.Interfaces;

namespace IdealFinancialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditLinesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly ICreditLineRepository _creditLineRepository;

        public CreditLinesController(AppDbContext context, IAccountRepository accountRepository, ICreditLineRepository creditLineRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _creditLineRepository = creditLineRepository;
        }


        // POST: api/CreditLines
        [HttpPost]
        public async Task<ActionResult<CreditLine>> PostCreditLine(CreditLine creditLine)
        {
            try
            {
                var account = _accountRepository.FindBy(creditLine.AccountId);
                if (account == null)
                {
                    throw new AppExceptions("Account not found");
                }
                _creditLineRepository.AddCreditLine(creditLine);

                var diference = _creditLineRepository.GetCreditDifference(creditLine.AccountId);
                var acc = _creditLineRepository.EditAccountFunds(diference, account);
                var accUpdated = _accountRepository.Edit(acc);

                return Ok("Credit Line created successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
