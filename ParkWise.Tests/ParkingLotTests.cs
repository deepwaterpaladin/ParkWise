using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParkWise.Tests
{
    public class ParkingLotTests
{
    [Fact]
    public void TestOccupyingSpot()
    {
        // Arrange
        ParkingLot parkingLot = new ParkingLot(10, "A");

        // Act
        parkingLot.OccupySpot(5);

        // Assert
        Assert.False(parkingLot.GetSpot(5).IsOccupied);
    }

    [Fact]
    public void TestEmptyingSpot()
    {
        // Arrange
        ParkingLot parkingLot = new ParkingLot(10, "A");

        // Act
        parkingLot.EmptySpot(5);

        // Assert
        Assert.True(parkingLot.GetSpot(5).IsOccupied);
    }

    [Fact]
    public void TestGettingNumSpots()
    {
        // Arrange
        ParkingLot parkingLot = new ParkingLot(10, "A");

        // Act
        int numSpots = parkingLot.GetNumSpots();

        // Assert
        Assert.Equal(10, numSpots);
    }

    [Fact]
    public void TestGettingFirstAvailableSpot()
    {
        // Arrange
        ParkingLot parkingLot = new ParkingLot(10, "A");
        parkingLot.OccupySpot(2);
        parkingLot.OccupySpot(4);
        parkingLot.OccupySpot(7);

        // Act
        int firstAvailableSpot = parkingLot.GetFirstAvaliableSpot();

        // Assert
        Assert.Equal(1, firstAvailableSpot);
    }
}

}