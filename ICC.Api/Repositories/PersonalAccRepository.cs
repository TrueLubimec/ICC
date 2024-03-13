using ICC.Api.Data;
using ICC.Api.Entities;
using ICC.Api.Repositories.Contracts;
using ICC.Models.DtOs;
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

        public async Task<PersonalAccount> AddPersonalAccount(PersonalAccToAddDto personalAccToAddDto)
        {
            //сюда впихнуть потом функцию проверки
            var account = await (from acc in this.iCCDbContext.PersonalAccounts
                                 select new PersonalAccount
                                 {
                                     EffectiveDate = acc.EffectiveDate,
                                     Address = acc.Address,
                                     Square = acc.Square,
                                     Residents = acc.Residents
                                 }).SingleOrDefaultAsync();
            if (personalAccToAddDto != null)
            {
                var res = await this.iCCDbContext.PersonalAccounts.AddAsync(account);
                await this.iCCDbContext.SaveChangesAsync();
                return res.Entity;
            }
            return null;
        }

        public async Task<PersonalAccount> DeletePersonalAccount(int id)
        {
            var personalAccount = await this.iCCDbContext.PersonalAccounts.FindAsync(id);
            if (personalAccount != null) {
                this.iCCDbContext.PersonalAccounts.Remove(personalAccount);
                await this.iCCDbContext.SaveChangesAsync();
            }
            return personalAccount;
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

        public async Task<PersonalAccount> UpdatePersonalAccount(int id, PersonalAccToAddDto personalAccountDto)
        {
            var account = await this.iCCDbContext.PersonalAccounts.FindAsync(id);

            if (account != null)
            {
                account.ExpirationDate = personalAccountDto.EffectiveDate;
                account.Address = personalAccountDto.Address;
                account.Square = personalAccountDto.Square;
                account.Residents = personalAccountDto.Residents;
                await this.iCCDbContext.SaveChangesAsync();
                return account;
            }

            return null;
        }
    }
}
