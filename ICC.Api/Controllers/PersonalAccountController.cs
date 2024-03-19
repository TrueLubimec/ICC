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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Failed to retrieve data from datatbase");
            }
        }

        [HttpPost("/update/{id:int}")]
        public async Task<ActionResult<PersonalAccountDto>> UpdateAccount([FromBody]PersonalAccToUpdateDto accountToUpdate)
        {
            try
            {
                var updatedAcc = await personalAccRepository.UpdatePersonalAccount(accountToUpdate);

                if (updatedAcc == null)
                {
                    return NoContent();
                }

                var account = await personalAccRepository.GetPersonalAccountById(updatedAcc.Id);
                if (account == null)
                {
                    throw new Exception($"Couldn't retrieve account with id{account.Id} from database!");
                }

                var updataedAccountToDto = updatedAcc.ConvertToDto();
                return CreatedAtAction(nameof(GetAccount), new { id = updataedAccountToDto.Id }, updataedAccountToDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonalAccountDto>> CreateAccount([FromBody]PersonalAccToAddDto accountToAdd)
        {
            var createdAccount = await personalAccRepository.AddPersonalAccount(accountToAdd);

            if (createdAccount == null)
            {
                return NoContent();
            }

            var account = await personalAccRepository.GetPersonalAccountById(createdAccount.Id);
            if (account == null)
            {
                throw new Exception($"Couldn't retrieve account with id{account.Id} from database!");
            }

            var createdAccountToDto = createdAccount.ConvertToDto();
            return CreatedAtAction(nameof(GetAccount), new {id = createdAccountToDto.Id}, createdAccountToDto);
        }

    }
}
