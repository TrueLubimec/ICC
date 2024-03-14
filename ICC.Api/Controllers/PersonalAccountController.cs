using ICC.Api.Repositories.Contracts;
using ICC.Models.DtOs;
using ICC.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ICC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalAccountController : ControllerBase
    {
        private readonly IPersonalAccRepository personalAccRepository;

        public PersonalAccountController(IPersonalAccRepository personalAccRepository)
        {
            this.personalAccRepository = personalAccRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalAccountDto>>> GetAccounts()
        {
            try
            {
                var accounts = await this.personalAccRepository.GetPersonalAccounts();

                if (accounts == null)
                {
                    return NotFound();
                }
                else
                {
                    var accountDtos = accounts.ConvertToDto();

                    return Ok(accountDtos);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Failed to retrieve data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonalAccountDto>> GetAccount(int id)
        {
            try
            {
                var account = await this.personalAccRepository.GetPersonalAccountById(id);
                if (account == null)
                {
                    return BadRequest();
                }
                else
                {
                    var accountsDto = account.ConvertToDto();

                    return Ok(accountsDto);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Failed to retrieve data from datatbase");
            }
        }


    }
}
