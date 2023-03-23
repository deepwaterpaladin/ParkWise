using System;

namespace ParkWise;

public class MonthlyParkingSession
{
    public string lot_id { get; set;}
    public DateTime payment_date { get; set; }

    public bool paymentIsDue { get; set; }
    public double monthlyRate { get; set; }
    public ParkingSpot spot { get; set; }
    


    public MonthlyParkingSession(string lot_id, ParkingSpot spot, DateTime payment_date, double monthlyRate)
    {
        this.lot_id = lot_id;
        this.spot = spot;
        this.monthlyRate = monthlyRate;
        this.payment_date = payment_date;
        this.paymentIsDue = false;
    }

    public void PaymentDue()
    {
        // payment_date 
        // get current date
        // if current date is past payment_date, set payment is due -> true
        if (paymentIsDue == false && (DateTime.Now > payment_date))
        {
            paymentIsDue = true;
        }
        else
        {
            paymentIsDue = false;
        }
    }

    public void HasPaid()
    {
        paymentIsDue = false;
    }
}