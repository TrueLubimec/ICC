using ICC.Models.DtOs;
using ICC.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ICC.Web.Services
{
    public class PersonalAccountService : IPersonalAccountService
    {
        private readonly IHttpClientFactory httpClientFactory;

        private HttpClient httpClient { get; set; }
        public PersonalAccountService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            //this.httpClient = httpClientFactory.CreateClient("test");
        }
        public async Task<PersonalAccountDto> GetAccount(int id)
        {
            httpClient = httpClientFactory.CreateClient("test");
            try
            {
                var response = await httpClient.GetAsync($"api/PersonalAccount/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(PersonalAccountDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PersonalAccountDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch (Exception ex)
            {
                //log
                throw;  
            }
        }

        public async Task<IEnumerable<PersonalAccountDto>> GetAccounts()
        {
            var httpClient = httpClientFactory.CreateClient("test");
            try
            {
                var response = await httpClient.GetAsync("api/PersonalAccount");
                
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<PersonalAccountDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<PersonalAccountDto>>();
                }
                else {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<PersonalAccountDto> UpdateAccount(PersonalAccToUpdateDto updateAccDto)
        {
            var httpClient = httpClientFactory.CreateClient("test");

            try
            {
                var response = await httpClient.PutAsJsonAsync($"api/update/{updateAccDto.Id}", updateAccDto);
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(PersonalAccountDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PersonalAccountDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
