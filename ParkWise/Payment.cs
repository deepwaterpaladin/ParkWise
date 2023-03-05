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
