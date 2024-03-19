using ICC.Models.DtOs;
using ICC.Web.Services;
using ICC.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ICC.Web.Pages
{
    public class EditAccountModel : PageModel
    {
        private readonly ILogger<AccountDetailsModel> logger;
        private readonly IPersonalAccountService personalAccountService;

        public PersonalAccountDto accountDto { get; set; }

        [BindProperty(SupportsGet = true)]
        public int accountId { get; set; }

        public EditAccountModel(ILogger<AccountDetailsModel> logger,IPersonalAccountService personalAccountService)
        {
            this.logger = logger;
            this.personalAccountService = personalAccountService;
        }
        public async Task OnGet()
        {
            accountDto = await personalAccountService.GetAccount(accountId);
        }
    }
}
