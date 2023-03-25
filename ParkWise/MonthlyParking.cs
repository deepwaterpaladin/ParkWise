using System;

namespace ParkWise;

public class MonthlyParkingSession
{
    public string lot_id { get; set;}
    public DateTime payment_date { get; set; }

    public bool paymentIsDue { get; set; }
    public int monthlyRate { get; set; }
    public ParkingSpot spot { get; set; }

    public int monthsPaid { get; set; }
    


    public MonthlyParkingSession(string lot_id, ParkingSpot spot, DateTime payment_date, int monthlyRate)
    {
        this.lot_id = lot_id;
        this.spot = spot;
        this.monthlyRate = monthlyRate;
        this.payment_date = payment_date;
        this.paymentIsDue = false;
    }

    public void PaymentDue(DateTime currentTime)
    {
        // payment_date 
        // get current date
        // if current date is past payment_date, set payment is due -> true
        DateTime lastPaymentPlusOneMonth = this.payment_date.AddMonths(monthsPaid);
        if (paymentIsDue == false && (currentTime > (lastPaymentPlusOneMonth)))
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
        this.monthsPaid +=1;
    }
}