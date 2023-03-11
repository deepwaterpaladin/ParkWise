using System;

public class PrepaidSession: Payment
{
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public double totalSession;
    public double lot_price;
    public double payment_total { get; set; }  
    public string lot_id { get; set; }  
    private bool isExpired { get; set; }
    public ParkingSession session { get; set; }

    public PrepaidSession(string id, DateTime start_time, DateTime end_time)
    {
        totalSession = CalculateTotalTimeParked(start_time, end_time);
        lot_price = GetLot(id);
        lot_id = id;
        startTime = start_time;
        endTime = end_time;
        payment_total = lot_price*totalSession;
        session = new ParkingSession(id, start_time, end_time, payment_total);

    }
}