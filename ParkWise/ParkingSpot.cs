using System;
using System.Collections.Generic;
public class ParkingSpot
{
    public int SpotNumber { get; set; }
    public bool IsOccupied { get; set; }
    public bool isPrepaid { get; set; }
    public DateTime? timeOccuipied { get; set; }
    public DateTime? timeEmpited { get; set; }
    public string ParentID { get; set; }
    public int? floorNumber { get; set; }
}
