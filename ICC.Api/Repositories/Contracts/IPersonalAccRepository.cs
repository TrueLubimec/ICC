using ICC.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICC.Api.Repositories.Contracts
{
    public interface IPersonalAccRepository
    {
        Task<IEnumerable<PersonalAccount>> GetPersonalAccounts();
        Task<PersonalAccount> GetPersonalAccountById(int id);
        Task<PersonalAccount> AddPersonalAccount();
        Task<PersonalAccount> UpdatePersonalAccount(int id);
        Task<PersonalAccount> DeletePersonalAccount(int id);
    }
}
