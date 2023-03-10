using System;

class Program
{
    static void Demo()
    {
        ParkingLot RideauStreet = new ParkingLot(30, "290 Rideau");
        Console.WriteLine($"Total Spots: {RideauStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {RideauStreet.emptySpots}");
        RideauStreet.OccupySpot(4);
        RideauStreet.OccupySpot(2);
        RideauStreet.OccupySpot(8);
        RideauStreet.OccupySpot(10);
        RideauStreet.OccupySpot(15);
        RideauStreet.OccupySpot(28);
        RideauStreet.OccupySpot(1);
        RideauStreet.OccupySpot(9);
        Console.WriteLine($"Total Spots: {RideauStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {RideauStreet.emptySpots}");
        Console.WriteLine($"{RideauStreet.sessionSpots[4].lot_price}");
        Console.WriteLine($"First available spot: {RideauStreet.GetFirstAvaliableSpot()}");

        
    }
    
    
    static void Main(string[] args)
    {
        Demo();
    }
}