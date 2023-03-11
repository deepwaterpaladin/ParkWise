# ParkWise – Parking Lot Management System

## Contents

- [TO DO](#todo)
- [How to Use](#howto)
- [Contributing](#contributing)
- [ParkingLot.cs](#parkinglotcs)
- [ParkingSpot.cs](#parkingspotcs)
- [Payment.cs](#paymentcs)

## TO DO <a id="todo"> </a>

- [X] Create ParkingSpot class
- [X] Download xUnit & Write Tests
- [X] Create ParkingLot class
- [ ] Figure out a better way to determine the price/hour at a given lot (Payment.cs)
- [ ] Research [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-7.0) & [Razor Pages in ASP.NET](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio-code) for UI
- [ ] Implement database – [see ADO.NET](https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/create-sql-server-database-programmatically)

## How to use <a id="howto"> </a>

To use the Parking Lot Management System, you can create a new instance of the ParkingLot class and then call its methods to occupy or empty parking spots.

You can also retrieve information about the parking lot or calculate the cost of a parking session using the Payment class.

## Contributing

- Clone demo branch
- Document any new classes/methods in `README.md`
- Add unit tests for every new class/method in `./Tests`

## ParkingLot.cs

### ParkingLot Properties

- `numberOfFloors`: an integer that represents the number of floors in the parking lot.
- `numSpots`: an integer that represents the total number of spots in the parking lot.
- `emptySpots`: an integer that represents the number of empty spots in the parking lot.
- `lotID`: a string that represents the ID of the parking lot.
- `sessionSpots`: a dictionary that maps spot numbers to parking sessions.
- `_spots`: a list of `ParkingSpot` objects representing the parking spots in the lot.

### ParkingLot Methods

- `GetSpot(int spotNumber)`: retrieves a specific parking spot by spot number.
- `OccupySpot(int spotNumber)`: occupies a parking spot.
- `EmptySpot(int spotNumber)`: releases a parking spot.
- `GetNumSpots()`: returns the total number of spots in the lot.

## ParkingSpot.cs

### ParkingSpot Properties

- `SpotNumber`: an integer that represents the number of the parking spot.
- `IsOccupied`: a boolean that indicates whether the parking spot is occupied.
- `timeOccuipied`: a nullable `DateTime` that represents the time the spot was occupied.
- `timeEmpited`: a nullable `DateTime` that represents the time the spot was released.
- `ParentID`: a string that represents the ID of the parking lot that the spot belongs to.

## Payment.cs

### Payment Properties

- `lots`: a dictionary that maps parking lot names to their prices.

### Payment Methods

- `GetLot(string key)`: returns the price of a given parking lot.
- `GetPayment(int time)`: calculates the payment for a given amount of time parked.
- `CalculateTotalTimeParked(DateTime timeIn, DateTime timeOut)`: calculates the total time parked.

## ParkingSession.cs

### ParkingSession Properties

- `timeIn`: a `DateTime` that represents the time the parking session started.
- `timeOut`: a nullable `DateTime` that represents the time the parking session ended.
- `totalSession`: a nullable double that represents the total duration of the parking session.
- `lot_price`: a double that represents the price of the parking lot.
- `payment_total`: a nullable double that represents the total payment for the parking session.
- `lot_id`: a string that represents the ID of the parking lot.

### ParkingSession Method

- `GetPayment()`: returns the payment for the parking session.
