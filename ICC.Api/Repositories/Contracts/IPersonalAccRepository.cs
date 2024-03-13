using ICC.Api.Entities;
using ICC.Models.DtOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICC.Api.Repositories.Contracts
{
    public interface IPersonalAccRepository
    {
        Task<IEnumerable<PersonalAccount>> GetPersonalAccounts();
        Task<PersonalAccount> GetPersonalAccountById(int id);
        Task<PersonalAccount> AddPersonalAccount(PersonalAccToAddDto personalAccountToAddDto);
        Task<PersonalAccount> UpdatePersonalAccount(int id, PersonalAccountDto personalAccountDto);
        Task<PersonalAccount> DeletePersonalAccount(int id);
    }
}
