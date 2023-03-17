using System;
using System.Text;



public class Ticket
{
    public ParkingSession session { get; set; }

    public double payment_total { get; set; }
    public string lot_id { get; set; }
    public string ticket { get; set; }

    public Ticket(string lot_id, double payment_total)
    {
        this.payment_total = payment_total;
        this.lot_id = lot_id;
        this.ticket = CreateTicket();

    }

    public Ticket(ParkingSession session)
    {
        this.payment_total = (double)session.payment_total;
        this.lot_id = session.lot_id;
        this.ticket = CreateTicket();
    }
    public string CreateTicket()
    {
        string paymentString = $"Total amount due: {this.payment_total}";
        string locationString = $"Parking Ticket For {this.lot_id}";
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
        ticket.AppendLine(paymentString);
        ticket.AppendLine(divider.ToString());
        return ticket.ToString();
    }

}