using System;

class Program
{
    static void Demo()
    {
        ParkingLot RideauStreet = new ParkingLot(30, "290 Rideau");
        Console.WriteLine($"Total Spots: {RideauStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {RideauStreet.emptySpots}");
        RideauStreet.OccupySpot(4);
        Console.WriteLine($"Total Spots: {RideauStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {RideauStreet.emptySpots}");
        Console.WriteLine($"{RideauStreet.sessionSpots[4].lot_price}");

        
    }
    
    
    static void Main(string[] args)
    {
        Demo();
    }
}