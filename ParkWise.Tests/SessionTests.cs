using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SessionTests
{
    public class PrepaidSessionTests
    {
        [Fact]
        public void TestTickeMethodCreatesTicketForPrepaidSession()
        {
            DateTime startTime = DateTime.Now.AddHours(-2);
            DateTime endTime = DateTime.Now.AddHours(+1);
            PrepaidSession session = new PrepaidSession("290 Rideau", startTime,endTime);
            Assert.True(session.ticket != null);
            Assert.IsType<Ticket>(session.ticket);
            Assert.IsType<string>(session.ticket.ticket);
        }
    }  
    public class ParkingSessionTests
    {
        [Fact]
        public void TestTickeMethodCreatesTicketForParkingSession()
        {
            DateTime startTime = DateTime.Now.AddHours(-5);
            DateTime endTime = DateTime.Now.AddHours(-2);
            ParkingSession session = new ParkingSession("290 Rideau", startTime);
            session.EndSession(endTime);
            Assert.True(session.ticket != null);
            Assert.IsType<Ticket>(session.ticket);
            Assert.IsType<string>(session.ticket.ticket);
        }
    }
}