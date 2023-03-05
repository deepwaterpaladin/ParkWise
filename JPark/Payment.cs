//TODO: payment db
//TODO: 

using System;
using System.Collections.Generic;

public abstract class Payment
{
    public static Dictionary<string, double> lots = new Dictionary<string, double> {
        { "Lot A", 4.50 },
        { "290 Rideau", 5.25 },
        { "Lot C", 4.95 }
    };

    public static double GetLot(string key)
    {
        double lot_price = lots[key];
        return lot_price;
    }

    public static double GetPayment(int time)
    {
        double timeAsDouble = (double)time;
        return timeAsDouble * lots["Lot A"];
    }

    public static double CalculateTotalTimeParked(DateTime timeIn, DateTime timeOut)
    {
        TimeSpan duration = timeOut - timeIn;
        double totalHours = duration.TotalHours;
        return totalHours;
    }

}

public class ParkingSession : Payment
{
    public DateTime timeIn {get; set;}
    public DateTime? timeOut;
    public double? totalSession;
    public double lot_price; 
    public double? payment_total;
    public string lot_id;

    public double GetPayment()
    {
        return (double)(this.lot_price * this.totalSession);
    }
    

    public ParkingSession(string lot_id, DateTime? timeIn)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
    }
}