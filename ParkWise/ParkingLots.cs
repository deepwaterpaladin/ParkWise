using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a parking lot with the number of floors, available spots, and the ID of the lot.
/// </summary>
public class ParkingLot
{
    /// <summary>
    /// The number of floors in the parking lot.
    /// </summary>
    public int? numberOfFloors { get; set;} // some lots will have several floors.

    public int? spotsPerFloor { get; set; } // naively assuming equal number spots per floor at first; TODO: refactor this

    /// <summary>
    /// A list of parking spots in the parking lot.
    /// </summary>
    public List<ParkingSpot> lotSpots;
    /// <summary>
    /// A dictionary of parking sessions with their corresponding spot numbers.
    /// </summary>
    public Dictionary<int, ParkingSession> sessionSpots;

    /// <summary>
    /// The number of total spots in the parking lot.
    /// </summary>
    public int numSpots {get;set;}

    /// <summary>
    /// The number of empty spots in the parking lot.
    /// </summary>
    public int emptySpots {get;set;}

    /// <summary>
    /// The ID of the parking lot.
    /// </summary>
    public string lotID { get; set; }

    public double? monthlyRate { get; set; }

    /// <summary>
    /// Initializes a new instance of the ParkingLot class with the specified number of spots and ID.
    /// </summary>
    /// <param name="numberOfSpots">The number of spots in the parking lot.</param>
    /// <param name="ID">The ID of the parking lot.</param>
    public ParkingLot(int numberOfSpots, string ID)
    {
        this.lotID = ID;
        lotSpots = new List<ParkingSpot>();
        sessionSpots = new Dictionary<int, ParkingSession>();
        for (int i = 1; i <= numberOfSpots; i++)
        {
            lotSpots.Add(new ParkingSpot { SpotNumber = i, IsOccupied = false, ParentID = lotID});
        }
        this.numSpots = numberOfSpots;
        this.emptySpots = numSpots;
    }

    // TODO: determine what 
    public ParkingLot(int numberOfSpots, string ID, int numberOfFloors)
    {
        this.lotID = ID;
        this.numberOfFloors = numberOfFloors;
        this.spotsPerFloor = (int?)(double)(numberOfSpots / numberOfFloors);
        lotSpots = new List<ParkingSpot>();
        sessionSpots = new Dictionary<int, ParkingSession>();
        for (int i = 1; i <= numberOfSpots; i++)
        {
            lotSpots.Add(new ParkingSpot { SpotNumber = i, IsOccupied = false, ParentID = lotID});
        }
        int k = 0;
        int nowFloor = 1;
        Console.WriteLine($"{spotsPerFloor}");
        while (k <= lotSpots.Count)
        {
            for (int i = k; i < Math.Min(k + spotsPerFloor.Value, lotSpots.Count); i++)
            {
                lotSpots[i].floorNumber = nowFloor;
            }
            k += spotsPerFloor.Value;
            nowFloor++;
        }
        this.numSpots = numberOfSpots;
        this.emptySpots = numSpots;
    }

    /// <summary>
    /// Retrieves a specific parking spot by spot number.
    /// </summary>
    /// <param name="spotNumber">The spot number to retrieve.</param>
    /// <returns>The parking spot with the specified spot number, or null if the spot is not found.</returns>
    private ParkingSpot GetSpot(int spotNumber)
    {
        return lotSpots.FirstOrDefault(s => s.SpotNumber == spotNumber);
    }

    /// <summary>
    /// Occupies a parking spot.
    /// </summary>
    /// <param name="spotNumber">The spot number to occupy.</param>
    public void OccupySpot(int spotNumber)
    {
        ParkingSpot spot = GetSpot(spotNumber);
        spot.IsOccupied = true;
        spot.timeOccuipied = DateTime.Now;
        ParkingSession sesh = new ParkingSession(lotID, (DateTime)spot.timeOccuipied);
        sessionSpots.Add(spotNumber,sesh);
        emptySpots -= 1;
    }

    public void OccupySpot()
    {
        int spotNumber = GetFirstAvaliableSpot();
        ParkingSpot spot = GetSpot(spotNumber);
        spot.IsOccupied = true;
        spot.timeOccuipied = DateTime.Now;
        ParkingSession sesh = new ParkingSession(lotID, (DateTime)spot.timeOccuipied);
        sessionSpots.Add(spotNumber,sesh);
        emptySpots -= 1;
    }

    public void OccupyPrepaidSpot(DateTime start_time, DateTime end_time)
    {
        int spotNumber = GetFirstAvaliableSpot();
        ParkingSpot spot = GetSpot(spotNumber);
        spot.IsOccupied = true;
        spot.timeOccuipied = start_time;
        spot.isPrepaid = true;
        PrepaidSession session = new PrepaidSession(lotID, start_time, end_time);
        sessionSpots.Add(spotNumber, session.session);
        emptySpots -= 1;
    }

    public void OccupyMonthly()
    {
        int spotNumber = GetFirstAvaliableSpot();
        ParkingSpot spot = GetSpot(spotNumber);
        spot.IsOccupied = true;
        spot.timeOccuipied = DateTime.Now;
        spot.isMonthly = true;
        emptySpots -= 1;
    }

    /// <summary>
    /// Releases a parking spot.
    /// </summary>
    /// <param name="spotNumber">The spot number to release.</param>
    public void EmptySpot(int spotNumber)
    {
        ParkingSpot spot = GetSpot(spotNumber);
        if (spot != null)
        {
            spot.IsOccupied = false;
            emptySpots +=1;
            spot.timeEmpited = DateTime.Now;
            spot.timeOccuipied = null;
            if(spot.isMonthly != true)
            {    
                sessionSpots[spotNumber].timeOut = spot.timeEmpited;
                sessionSpots[spotNumber].SetPayment();
            }
        }
    }

    public int GetNumSpots()
    {
        return lotSpots.Count;
    }

    /// <summary>
    /// Gets the first available parking spot.
    /// </summary>
    /// <param name="print_occupied_spots">A flag indicating whether to print the list of occupied spots. Defaults to false.</param>
    /// <returns>The number of the first available parking spot.</returns>
    public int GetFirstAvaliableSpot(bool? print_occupied_spots = false)
    {
        List<int> occupiedSpots = new List<int>();
        List<int> availableSpots = new List<int>();
        foreach (KeyValuePair<int, ParkingSession> pair in sessionSpots)
        {
            occupiedSpots.Add(pair.Key);
        }
        for (int i = 1; i <= numSpots; i++)
        {
            if(!occupiedSpots.Contains(i))
            {
                availableSpots.Add(i);
            }
        }
        if (print_occupied_spots == true)
        {
            Console.WriteLine($"Occupied spots: {string.Join(", ", occupiedSpots)}");
        }
        return availableSpots.Min();
    }

    public bool hasExpiredVehicles()
    {
        foreach (KeyValuePair<int, ParkingSession> kvp in sessionSpots)
        {
            kvp.Value.IsExpired();
            if(kvp.Value.isExpired == true)
            {
                return true;
            }
        }
        return false;
    }

}