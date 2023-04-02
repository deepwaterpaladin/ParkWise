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

    public class AddLotsModel : PageModel
    {
        // private readonly YourDataContext _context;

        [BindProperty]
        public string? Address { get; set; }
        [BindProperty]
        public int? NumberOfFloors { get; set; }
        [BindProperty]
        public int? NumberOfSpots { get; set; }
        [BindProperty]
        public bool? HasFloors { get; set; }
        [BindProperty]
        public int? SpotsPerFloor { get; set; }
        [BindProperty]
        public double? MonthlyRate { get; set; }

        [BindProperty]
        public double? HourlyRate { get; set; }
        

        // Initialize the list of parking lots
        public List<ParkingLot> ParkingLots { get; set; }


        // GET request for the AddLots page
        public void OnGet()
        {
            this.ParkingLots = new List<ParkingLot>(); 
            ParkingLot lot = new ParkingLot(40, "id");
            this.ParkingLots.Add(lot);
            Console.WriteLine($"{this.ParkingLots[0].numSpots}");
        }
    }
}