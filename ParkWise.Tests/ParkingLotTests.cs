using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTests
{
    public class ParkingLotTests
    {
        [Fact]
        public void TestParkingLotConstructor()
        {
            // Arrange
            int numberOfSpots = 10;
            string ID = "101 Bank";

            // Act
            ParkingLot lot = new ParkingLot(numberOfSpots, ID);

            // Assert
            Assert.Equal(numberOfSpots, lot.GetNumSpots());
            Assert.Equal(ID, lot.lotID);
            Assert.Equal(numberOfSpots, lot.emptySpots);
            // Assert.Null(lot.numberOfFloors);
        }

        [Fact]
        public void TestOccupySpot()
        {
            // Arrange
            ParkingLot lot = new ParkingLot(10, "10 King");

            // Act
            lot.OccupySpot(1);

            // Assert
            Assert.Equal(9, lot.emptySpots);
        }

        [Fact]
        public void TestEmptySpot()
        {
            // Arrange
            ParkingLot lot = new ParkingLot(10, "101 Bank");
            lot.OccupySpot(1);

            // Act
            lot.EmptySpot(1);

            // Assert
            Assert.Equal(10, lot.emptySpots);
        }

        [Fact]
        public void TestGetFirstAvailableSpot()
        {
            // Arrange
            ParkingLot lot = new ParkingLot(10, "101 Bank");
            lot.OccupySpot(1);

            // Act
            int firstAvailableSpot = lot.GetFirstAvaliableSpot();

            // Assert
            Assert.Equal(2, firstAvailableSpot);
        }

        [Fact]
        public void TestOccupyPrepaidSpot()
        {
            // Arrange
            ParkingLot lot = new ParkingLot(10, "290 Rideau");
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddHours(1);

            // Act
            lot.OccupyPrepaidSpot(startTime, endTime);

            // Assert
            Assert.Equal(9, lot.emptySpots);
        }

            [Fact]
        public void ParkingLot_Constructor_ShouldCreateParkingLotWithCorrectNumberOfSpots()
        {
            // Arrange
            int numberOfSpots = 50;
            string ID = "101 Bank";
            int numberOfFloors = 5;
            
            // Act
            ParkingLot lot = new ParkingLot(numberOfSpots, ID, numberOfFloors);
            
            // Assert
            Assert.Equal(numberOfSpots, lot.numSpots);
        }

        [Fact]
        public void ParkingLot_Constructor_ShouldCreateParkingLotWithCorrectNumberOfFloors()
        {
            // Arrange
            int numberOfSpots = 50;
            string ID = "101 Bank";
            int numberOfFloors = 5;
            
            // Act
            ParkingLot lot = new ParkingLot(numberOfSpots, ID, numberOfFloors);
            
            // Assert
            Assert.Equal(numberOfFloors, lot.numberOfFloors);
        }

        [Fact]
        public void ParkingLot_Constructor_ShouldCreateParkingLotWithCorrectSpotsPerFloor()
        {
            // Arrange
            int numberOfSpots = 50;
            string ID = "101 Bank";
            int numberOfFloors = 5;
            int expectedSpotsPerFloor = 10;
            
            // Act
            ParkingLot lot = new ParkingLot(numberOfSpots, ID, numberOfFloors);
            
            // Assert
            Assert.Equal(expectedSpotsPerFloor, lot.spotsPerFloor);
        }
    }
}
