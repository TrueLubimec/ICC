using ICC.Api.Data;
using ICC.Api.Entities;
using ICC.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICC.Api.Repositories
{
    public class PersonalAccRepository : IPersonalAccRepository
    {
        private readonly ICCDbContext iCCDbContext;

        public PersonalAccRepository(ICCDbContext iCCDbContext)
        {
            this.iCCDbContext = iCCDbContext;
        }

        public async Task<bool> PersonalAccExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PersonalAccount> AddPersonalAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<PersonalAccount> DeletePersonalAccount(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PersonalAccount> GetPersonalAccountById(int id)
        {
            var personalAccount = await this.iCCDbContext.PersonalAccounts.FindAsync(id);
            return personalAccount;
        }

        public async Task<IEnumerable<PersonalAccount>> GetPersonalAccounts()
        {
            var personalAccounts = await this.iCCDbContext.PersonalAccounts.ToListAsync();
            return personalAccounts;
        }

        public Task<PersonalAccount> UpdatePersonalAccount(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
