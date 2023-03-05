using System;
using System.Collections.Generic;
using System.Linq;


public class ParkingLot
{
    public int? numberOfFloors {get; set;} // some lots will have several floors.

    private List<ParkingSpot> _spots;
    public Dictionary<Int32, ParkingSession> sessionSpots;
    public int numSpots {get;set;}

    public int emptySpots {get;set;}
    public string lotID { get; set; }

    public ParkingLot(int numberOfSpots, string ID)
    {
        this.lotID = ID;
        _spots = new List<ParkingSpot>();
        sessionSpots = new Dictionary<int, ParkingSession>();
        for (int i = 1; i <= numberOfSpots; i++)
        {
            _spots.Add(new ParkingSpot { SpotNumber = i, IsOccupied = false, ParentID = lotID});
        }
        this.numSpots = numberOfSpots;
        this.emptySpots = numSpots;
    }

    // Method to retrieve a specific parking spot by spot number
    private ParkingSpot GetSpot(int spotNumber)
    {
        return _spots.FirstOrDefault(s => s.SpotNumber == spotNumber);
    }

    // Method to occupy a parking spot
    public void OccupySpot(int spotNumber)
    {
        ParkingSpot spot = GetSpot(spotNumber);
        if (spot != null)
        {
            spot.IsOccupied = true;
            spot.timeOccuipied = DateTime.Now;
            ParkingSession sesh = new ParkingSession(lotID, spot.timeOccuipied);
            sessionSpots.Add(spotNumber,sesh);
            emptySpots -= 1;
        }
        else{
            //TODO: better error handling
            Console.WriteLine($"Spot #{spotNumber} is empty. Try another spot.");
        }
    }

    // Method to release a parking spot
    public void EmptySpot(int spotNumber)
    {
        ParkingSpot spot = GetSpot(spotNumber);
        if (spot != null)
        {
            spot.IsOccupied = false;
            emptySpots +=1;
            spot.timeEmpited = DateTime.Now;
            sessionSpots[spotNumber].timeOut = spot.timeEmpited;
            sessionSpots[spotNumber].GetPayment();
            spot.timeOccuipied = null;
        }
    }

    public int GetNumSpots()
    {
        return _spots.Count;
    }

}