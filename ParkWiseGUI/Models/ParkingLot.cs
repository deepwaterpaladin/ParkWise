using System;
using System.Collections.Generic;
using System.Linq;


namespace ParkWiseGUI.Models
{
    // <summary>
    /// Represents a parking lot with the number of floors, available spots, and the ID of the lot.
    /// </summary>
    public class ParkingLot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int TotalSpots { get; set; }
        public string LotAddress { get; set; }
        public double HourlyRate { get; set; }
        public int MonthlyRate { get; set; }
        public int ReservedSpots { get; set; }
        public int AvailableSpots { get; set; }
        public ICollection<ParkingSpot> ListOfSpots{ get; set; }
    }

    
}