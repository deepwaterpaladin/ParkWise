using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ParkWiseGUI
{
    public class MyLotsPage : PageModel
    {
        private readonly ILogger<MyLotsPage> _logger;

        public MyLotsPage(ILogger<MyLotsPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}