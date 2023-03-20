using System;
using System.Text;



public class Ticket
{
    public ParkingSession session { get; set; }

    public decimal payment_total { get; set; }
    public string lot_id { get; set; }
    public string ticket { get; set; }

    public Ticket(string lot_id, decimal payment_total)
    {
        this.payment_total = payment_total;
        this.lot_id = lot_id;
        this.ticket = CreateTicket();

    }

    public Ticket(ParkingSession session)
    {
        this.payment_total = (decimal)session.payment_total;
        this.lot_id = session.lot_id;
        this.ticket = this.CreateTicket();
    }
    public string CreateTicket()
    {
        string paymentString = $"Total amount due: ${decimal.Round(this.payment_total, 2, MidpointRounding.AwayFromZero)}";
        string locationString = $"Parking Ticket For {this.lot_id}";
        string timeParked = $"Total time parked: {this.session.expectedSession}";
        StringBuilder divider = new StringBuilder();
        StringBuilder ticket = new StringBuilder();
        divider.AppendLine("");
        if(paymentString.Length > locationString.Length)
        {
            foreach(char l in paymentString)
            {
                divider.Append("-");
            }
        }
        else
        {
            foreach(char l in locationString)
            {
                divider.Append("-");
            }
        }
        divider.AppendLine("");
        ticket.AppendLine(divider.ToString());
        ticket.AppendLine(locationString);
        ticket.AppendLine(divider.ToString());
        ticket.AppendLine(timeParked);
        ticket.AppendLine(paymentString);
        ticket.AppendLine(divider.ToString());
        return ticket.ToString();
    }

}