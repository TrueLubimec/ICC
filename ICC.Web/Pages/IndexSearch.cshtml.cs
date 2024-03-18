using ICC.Models.DtOs;
using ICC.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICC.Web.Pages
{
    public class IndexSearchModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonalAccountService personalAccountService;
        public IEnumerable<PersonalAccountDto> accountDto {  get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AccountNumber { get; set; }

        public IndexSearchModel(ILogger<IndexModel> logger, IPersonalAccountService personalAccountService)
        {
            _logger = logger;
            this.personalAccountService = personalAccountService;
        }

        public async Task OnGet()
        {
            accountDto = await personalAccountService.GetAccounts();
        }
    }
}
