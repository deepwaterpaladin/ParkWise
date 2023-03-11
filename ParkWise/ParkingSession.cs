using System;

public class ParkingSession : Payment
{
    public DateTime timeIn { get; set; }
    public DateTime? timeOut { get; set; }
    public double? totalSession { get; set; }
    public double lot_price { get; set; }
    public double? payment_total { get; set; }
    public string lot_id { get; set; }

    public double GetPayment()
    {
        return (double)(this.lot_price * this.totalSession);
    }


    public ParkingSession(string lot_id, DateTime? timeIn)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
    }

    public ParkingSession(string lot_id, DateTime timeIn, DateTime end_time)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
    }

    public void isExpired()
    {
        // method to determine if parking spot is expired.
    }
}