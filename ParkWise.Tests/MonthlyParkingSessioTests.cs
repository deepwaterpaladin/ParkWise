using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParkWise.Tests
{
    public class MonthlyParkingSessioTests
    {
        [Fact]
        public void TestMonthlyParkingSessionInitsPaymentDueFalse()
        {
            MonthlyParkingSession TestMonthlySession = new MonthlyParkingSession("1",new ParkingSpot(), DateTime.Now.AddDays(-20), 50);
            TestMonthlySession.PaymentDue(DateTime.Now);
            Assert.True(TestMonthlySession.paymentIsDue);
            TestMonthlySession.HasPaid();
            TestMonthlySession.PaymentDue(DateTime.Now);
            Assert.False(TestMonthlySession.paymentIsDue);

        }
    }
}