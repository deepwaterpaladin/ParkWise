using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ParkWiseGUI.Pages
{
    public class Index2 : PageModel
    {
        public string Message { get; private set; } = "";

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}