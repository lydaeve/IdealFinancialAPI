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
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly ICreditLineRepository _creditLineRepository;

        public AccountsController(AppDbContext context, IAccountRepository accountRepository, ICreditLineRepository creditLineRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _creditLineRepository = creditLineRepository;
        }


        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            try
            {
                var account =  _accountRepository.FindBy(id);
                var credit =  _creditLineRepository.FindByAccountId(account.Id);

                if (account == null)
                {
                    throw new AppExceptions("Account not found");
                }

                AccountDto accDto = new AccountDto();
                Utils.Map(account, credit, accDto);
                return Ok(accDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}

