CREATE DATABASE CRS
USE CRS

--Creating Table

-- Vehicle Table
CREATE TABLE Vehicles(
    vehicleID INT IDENTITY(1,1) PRIMARY KEY,
    make VARCHAR(255),
    model VARCHAR(255),
    year INT,
    dailyRate DECIMAL(10, 2),
    status VARCHAR(15) CHECK (status IN ('available', 'notAvailable')),
    passengerCapacity INT,
    engineCapacity INT
)

-- Customer Table
CREATE TABLE Customers(
    customerID INT IDENTITY(1,1) PRIMARY KEY,
    firstName VARCHAR(255),
    lastName VARCHAR(255),
    email VARCHAR(255),
    phoneNumber INT
)

-- Lease Table
CREATE TABLE Leases(
    leaseID INT IDENTITY(1,1) PRIMARY KEY,
    vehicleID INT,
    customerID INT,
    startDate DATE,
    endDate DATE,
    type VARCHAR(15) CHECK (type IN ('DailyLease', 'MonthlyLease')),
    FOREIGN KEY (vehicleID) REFERENCES Vehicles(vehicleID),
    FOREIGN KEY (customerID) REFERENCES Customers(customerID)
)

-- Payment Table
CREATE TABLE Payments(
    paymentID INT IDENTITY(1,1) PRIMARY KEY,
    leaseID INT,
    paymentDate DATE,
    amount DECIMAL(10, 2),
    FOREIGN KEY (leaseID) REFERENCES Leases(leaseID)
)

SELECT * FROM Vehicles
SELECT * FROM Customers
SELECT * FROM Leases
SELECT * FROM Payments

--Inserting Values
INSERT INTO Vehicles (make, model, year, dailyRate, status, passengerCapacity, engineCapacity)
VALUES
('Toyota', 'Camry', 2020, 50.00, 'available', 5, NULL),
('Honda', 'Civic', 2019, 45.00, 'available', 5, NULL),
('Ford', 'F-150', 2021, 70.00, 'notAvailable', 4, NULL),
('Harley-Davidson', 'Street Glide', 2022, 100.00, 'available', NULL, 1600),
('Chevrolet', 'Equinox', 2018, 60.00, 'available', 7, NULL),
('Yamaha', 'YZF-R6', 2020, 80.00, 'notAvailable', NULL, 600),
('Tesla', 'Model S', 2022, 120.00, 'available', 5, NULL),
('Kawasaki', 'Ninja 650', 2021, 75.00, 'available', NULL, 650),
('Hyundai', 'Tucson', 2019, 55.00, 'available', 5, NULL),
('BMW', 'X5', 2021, 90.00, 'notAvailable', 5, NULL)

INSERT INTO Customers (firstName, lastName, email, phoneNumber)
VALUES
('John', 'Doe', 'john.doe@email.com',123456789),
('Jane', 'Smith', 'jane.smith@email.com', 987654321),
('Robert', 'Johnson', 'robert.johnson@email.com', 555123456),
('Emily', 'Davis', 'emily.davis@email.com', 987112233),
('Michael', 'Taylor', 'michael.taylor@email.com', 654987321),
('Sophia', 'Anderson', 'sophia.anderson@email.com', 123789456),
('David', 'Clark', 'david.clark@email.com', 789456123),
('Olivia', 'Baker', 'olivia.baker@email.com', 321654987),
('William', 'Walker', 'william.walker@email.com', 456789012),
('Ava', 'Hill', 'ava.hill@email.com', 789012345)

INSERT INTO Leases (vehicleID, customerID, startDate, endDate, type)
VALUES
(1, 2, '2023-01-10', '2023-01-15', 'DailyLease'),
(3, 5, '2023-02-05', '2023-03-05', 'MonthlyLease'),
(7, 1, '2023-03-20', '2023-03-25', 'DailyLease'),
(5, 4, '2023-04-02', '2023-04-30', 'MonthlyLease'),
(9, 8, '2023-05-15', '2023-05-17', 'DailyLease'),
(2, 7, '2023-06-10', '2023-06-15', 'DailyLease'),
(6, 3, '2023-07-01', '2023-07-31', 'MonthlyLease'),
(4, 10, '2023-08-12', '2023-08-18', 'DailyLease'),
(8, 6, '2023-09-05', '2023-10-05', 'MonthlyLease'),
(10, 9, '2023-11-20', '2023-12-20', 'MonthlyLease')

INSERT INTO Payments (leaseID, paymentDate, amount)
VALUES
(1, '2023-01-15', 250.00),
(3, '2023-03-25', 150.00),
(5, '2023-05-17', 100.00),
(7, '2023-07-31', 300.00),
(9, '2023-10-05', 200.00),
(2, '2023-03-10', 500.00),
(4, '2023-04-15', 450.00),
(6, '2023-06-15', 200.00),
(8, '2023-08-18', 150.00),
(10, '2023-12-20', 400.00)


-------------------- Car Management ------------------

--Query 1 :- void addCar(Car car); where car inputs are given by user 
select * from Vehicles 

Declare @Make varchar(50) = 'Skoda ',
@Model varchar(50) = 'Octavia',
@Year int = 2023 ,
@DailyRate int = 100,
@Status varchar(50) = 'Available',
@PassengerCapacity int = 5,
@EngineCapacity int = Null ;

Insert into Vehicles (Make , Model , Year , DailyRate , Status , PassengerCapacity , EngineCapacity)
values 
(@Make ,@Model , @Year , @DailyRate , @Status , @PassengerCapacity , @EngineCapacity)

--Query 2 :- void removeCar(int carID);

Declare @CarId int = 18

Delete from Vehicles 
where VehicleID = @CarId 

select * from Vehicles 

--Query 3 :- List<Car> listAvailableCars(); --

Select Vehicles.VehicleID , Vehicles.Make , Vehicles.Model , Vehicles.Status
from Vehicles where Vehicles.Status = 'Available'

--Query 4 :- List<Car> listRentedCars();

select * from Vehicles
select * from Leases


select Vehicles.VehicleID , Vehicles.Make+' '+Vehicles.Model as RentedVehicles 
from Vehicles join Leases 
on Vehicles.VehicleID = Leases.VehicleID 

--Query 5 :- Car findCarById(int carID);

Declare @VehicleID int = 5

select Vehicles.Make+' '+Vehicles.Model as VehicleName
from Vehicles where Vehicles.VehicleID = @VehicleID 




------------ Customer Management ---------------

--Query 1 :- void addCustomer(Customer customer);

select * from Customers 

Declare @FirstName varchar(50) = 'Taylor',
@LastName varchar(50) ='Swift' ,
@Email varchar(60) = 'TaylorSwift@gmail.com' ,
@PhoneNumber bigint = 569874123

Insert into Customers (FirstName,LastName , Email,PhoneNumber) 
values 
(@FirstName , @LastName , @Email , @PhoneNumber)

--Query 2 :- void removeCustomer(int customerID);

Declare @CustID int = 1

Delete from Customers 
where CustomerID = @CustID


select * from Customers 

--Query 3 :- List<Customer> listCustomers();

select FirstName+' '+LastName as Customers , PhoneNumber 
from Customers 

--Query 4 :- Customer findCustomerById(int customerID);

Declare @CustomID int = 5

Select FirstName+' '+LastName as CustomerName , Email,PhoneNumber 
from Customers 
Where CustomerID = @CustomID 



-------------------Lease Management-----------------

---Query 1 :- Lease createLease(int customerID, int carID, Date startDate, Date endDate);

--Query 2 :- void returnCar(int leaseID);
select * from Leases 
select * from Vehicles

Declare @LeaseId int = 3

select Make+' '+Model from Vehicles 
join Leases on Vehicles.VehicleID = Leases.VehicleID 
where LeaseID = @LeaseId

--Query 3 :- List<Lease> listActiveLeases();

select * from Leases
where GETDATE()<EndDate

--Query 4 :- List<Lease> listLeaseHistory();

select * from Leases 
order by StartDate desc 

-------------------Payment Handling ------------------

--Query 1 :void recordPayment(Lease lease, int amount);

select * from Payments
select * from Leases

Declare @LeaID int = 13 , @Amount int = 1000

Insert into Payments (LeaseID , PaymentDate , Amount) 
values 
(@LeaId , GetDate() , @Amount)

--Query 2 :- List<Payment> listPayments(Lease lease);

select * from Payments
select * from Leases

select Payments.PaymentID ,Leases.CustomerID,Payments.PaymentDate, Payments.Amount , Leases.Type 
from Payments join Leases
on Payments.LeaseID = Leases.LeaseID
