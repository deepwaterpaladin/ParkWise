using System;

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