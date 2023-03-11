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
        Console.WriteLine($"First available spot: {RideauStreet.GetFirstAvaliableSpot()}");
        RideauStreet.OccupySpot();
        Console.WriteLine($"Total Spots: {RideauStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {RideauStreet.emptySpots}");
        Console.WriteLine($"{RideauStreet.sessionSpots[4].lot_price}");
        Console.WriteLine($"First available spot: {RideauStreet.GetFirstAvaliableSpot()}");
        foreach(var i in RideauStreet.sessionSpots)
        {
            Console.WriteLine(i.Value.totalSession.ToString());
        }
    }

    static void Demo2()
    {
        ParkingLot BankStreet = new ParkingLot(40, "101 Bank");
        Console.WriteLine($"Total Spots: {BankStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {BankStreet.emptySpots}");
        BankStreet.OccupySpot(4);
        BankStreet.OccupySpot(2);
        BankStreet.OccupySpot(8);
        BankStreet.OccupySpot(10);
        BankStreet.OccupySpot(15);
        BankStreet.OccupySpot(28);
        BankStreet.OccupyPrepaidSpot(new DateTime(2023, 3, 11, 10, 0, 0), new DateTime(2023, 3, 11, 15, 0, 0));
        BankStreet.OccupyPrepaidSpot(new DateTime(2023, 5, 1, 8, 30, 0), new DateTime(2023, 5, 1, 14, 0, 0));
        Console.WriteLine($"Total Spots: {BankStreet.GetNumSpots()}");
        Console.WriteLine($"empty spots: {BankStreet.emptySpots}");
        foreach(var i in BankStreet.sessionSpots)
        {
            Console.WriteLine(i.Value.timeIn);
        }
    }
    
    
    static void Main(string[] args)
    {
        Demo();
    }
}