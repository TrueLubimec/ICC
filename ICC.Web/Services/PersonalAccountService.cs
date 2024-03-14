using ICC.Models.DtOs;
using ICC.Web.Services.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ICC.Web.Services
{
    public class PersonalAccountService : IPersonalAccountService
    {
        private readonly HttpClient httpClient;

        public PersonalAccountService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<PersonalAccountDto> GetAccount(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PersonalAccountDto>> GetAccounts()
        {
            throw new System.NotImplementedException();
        }
    }
}
