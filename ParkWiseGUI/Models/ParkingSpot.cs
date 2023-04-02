using System;
using System.ComponentModel.DataAnnotations;

namespace ParkWiseGUI.Models
{
    public class ParkingSpot
    {
        public string ParkingLotID { get; set; }
        public string ParkingSpotID { get; set; }
        public int SpotNumber { get; set; }
        public bool IsOccupied { get; set; }
        public bool isPrepaid { get; set; }
        public bool? IsMonthly { get; set; }
        [DisplayFormat(NullDisplayText = "Not occupied")]
        public DateTime? TimeOccuipied { get; set; }
        [DisplayFormat(NullDisplayText = "Not occupied")]
        public DateTime? TimeEmpited { get; set; }
        public int? FloorNumber { get; set; }

    }
}