﻿using ICC.Models.DtOs;
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
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IPersonalAccountService personalAccountService;
        public PersonalAccountDto personalAccount { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IPersonalAccountService personalAccountService)
        {
            _logger = logger;
            this.personalAccountService = personalAccountService;
        }

        public async Task OnGet()
        {
            
        }
    }
}
