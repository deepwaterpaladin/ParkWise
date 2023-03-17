using System;

public class ParkingSession : Payment
{
    public DateTime timeIn { get; set; }
    public DateTime? expectedTimeOut { get; set; }
    public DateTime? timeOut { get; set; }
    public TimeSpan? expectedSession { get; set; }
    public TimeSpan? currentSession { get; set; }
    public double? totalSession { get; set; }
    public double lot_price { get; set; }
    public double? payment_total { get; set; }
    public string lot_id { get; set; }

    public Ticket ticket { get; set; }
    public bool isExpired { get; set; }

    public double GetPayment()
    {
        this.totalSession = CalculateTotalTimeParked(timeIn, (DateTime)timeOut);
        return (double)(this.lot_price * this.totalSession);
    }

    public void SetPayment()
    {
        this.payment_total = GetPayment();
    }

    public ParkingSession(string lot_id, DateTime timeIn)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
        this.timeIn = timeIn;
    }

    public ParkingSession(string lot_id, DateTime timeIn, DateTime end_time, double payment_total)
    {
        this.lot_price = GetLot(lot_id);
        this.lot_id = lot_id;
        this.payment_total = payment_total;
        this.timeIn = timeIn;
        this.expectedTimeOut = end_time;
        this.expectedSession = this.expectedTimeOut - this.timeIn;
    }

    public void CurrentSession()
    {
        this.currentSession = DateTime.Now-this.timeIn;
    }

    public void IsExpired()
    {
        this.CurrentSession();
        if (this.currentSession > this.expectedSession)
        {
            this.isExpired = true;
        }
    }

    public void EndSession()
    {
        this.currentSession = DateTime.Now-this.timeIn;
        this.timeOut = DateTime.Now;
        this.SetPayment();
        this.ticket = GetTicket();

    }

    public void EndSession(DateTime timeOut)
    {
        this.timeOut = timeOut;
        this.currentSession = timeOut-this.timeIn;
        this.SetPayment();
        this.ticket = GetTicket();
    }

    public Ticket GetTicket()
    {
        return new Ticket(this.lot_id, (double)this.payment_total);
    }
}
