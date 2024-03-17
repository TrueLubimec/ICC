using ICC.Web.Services;
using ICC.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ICC.Web.Pages
{
    public class AccountDetailsModel : PageModel
    {
        private readonly ILogger<AccountDetailsModel> logger;
        private readonly IPersonalAccountService personalAccountService;



        public AccountDetailsModel(ILogger<AccountDetailsModel> logger,IPersonalAccountService personalAccountService)
        {
            this.logger = logger;
            this.personalAccountService = personalAccountService;
        }
        public async Task OnGet()
        {
            personalAccount = await personalAccountService.GetAccount(1);
        }
    }
}
