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
        this.totalSession = CalculateTotalTimeParked(timeIn, (DateTime)timeOut);
        return (double)(this.lot_price * this.totalSession);
    }

    public void SetPayment()
    {
        this.payment_total = GetPayment();
    }

    public ParkingSession(string lot_id, DateTime? timeIn)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
    }

    public ParkingSession(string lot_id, DateTime timeIn, DateTime end_time, double payment_total)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
        this.payment_total = payment_total;
    }

    public async void isExpired()
    {
        // method to determine if parking spot is expired.
    }
}