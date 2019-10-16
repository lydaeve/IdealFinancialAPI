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
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
                

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _userRepository.FindBy(id);

                if (user == null)
                {
                    throw new AppExceptions("User not found");
                }
                return Ok(user);
            }
            
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
