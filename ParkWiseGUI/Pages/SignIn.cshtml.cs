using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ParkWiseGUI.Pages
{
    public class SignIn : PageModel
    {
        private readonly ILogger<SignIn> _logger;

        public SignIn(ILogger<SignIn> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}