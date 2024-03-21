using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICC.Models.DtOs;

namespace ICC.Web.Services.Contracts
{
    public interface IPersonalAccountService
    {
        Task<IEnumerable<PersonalAccountDto>> GetAccounts();
        Task<PersonalAccountDto> GetAccount(int id);
        Task<PersonalAccountDto> UpdateAccount(PersonalAccToUpdateDto updateAccDto);
    }
}
