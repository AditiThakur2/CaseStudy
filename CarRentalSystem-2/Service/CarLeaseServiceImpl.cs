using CarRentalSystem.Entities;
using CarRentalSystem.Repository;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Utility;
using CarRentalSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Service
{
    public class CarLeaseServiceImpl:ICarLeaseService
    {
        ICarLeaseRepository carLeaseRepository = new CarLeaseRepositoryImpl();
        public string connectionString;


        //Car Management

        #region GetAllVehicles
        public void GetAllVehicles()
        {
            var vehicles = carLeaseRepository.GetAllVehicles();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        #endregion
        #region AddCar
        public void AddCar()
        {
            Console.WriteLine("Enter the Make of the Car:: ");
            string make = Console.ReadLine();
            Console.WriteLine("Enter the Model of the Car:: ");
            string model = Console.ReadLine();
            Console.WriteLine("Enter the Manufactured Year of Car");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the status of the Car:: ");
            string status = Console.ReadLine();
            Console.WriteLine("Enter the dailyRate of the Car:: ");
            decimal dailyRate = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the passengercapacity of the Car:: ");
            int passengerCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the enginecapacity of the Car:: ");
            int engineCapacity = int.Parse(Console.ReadLine());
            int addCarStatus = carLeaseRepository.AddCar(new Vehicles() { Make = make, Model = model, Year = year, DailyRate = dailyRate, Status = status, PassengerCapacity = passengerCapacity, EngineCapacity = engineCapacity });
            if (addCarStatus > 0)
            {
                Console.WriteLine("Car Added Successfully !!!!!!!!!!\n");
            }
            else
            {
                Console.WriteLine("There Was Error while Adding Car !!!!!!!!!!!!!!!\n");
            }
        }
        #endregion
        #region RemoveCar
        public void RemoveCar()
        {
            try
            {
                Console.WriteLine("\nEnter the Id of the Car to be Deleted:: ");
                int carID = int.Parse(Console.ReadLine());
                int deleteCarStatus = carLeaseRepository.RemoveCar(carID);
                if (deleteCarStatus > 0)
                {
                    Console.WriteLine("Car Deleted SuccessFully !!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Console.WriteLine("There was some Error while Removing the Car !!!!!!!!!!!!\n");
                }
            }
            catch(CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region List of Available cars
        public void ListAvailableCars()
        {
            var vehicles = carLeaseRepository.ListAvailableCars();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        #endregion
        #region List of Rented Cars
        public void ListRentedCars()
        {
            var vehicles = carLeaseRepository.ListRentedCars();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        #endregion
        #region Find Car By Id
        public void FindCarById()
        {
            Console.WriteLine("Enter the Car ID:: ");
            int carID = int.Parse(Console.ReadLine());
            Vehicles foundCar = carLeaseRepository.FindCarById(carID);
            if (foundCar != null)
            {
                Console.WriteLine($"Found Car: ID: {foundCar.VehicleID}, Make: {foundCar.Make}, Model: {foundCar.Model}, Status: {foundCar.Status}\n");
            }
            else
            {
                Console.WriteLine($"Car with ID {carID} not Found !!!!!!!!!!!!!!!!!!!!!!!\n");
            }
        }
        #endregion


        //Customer Management

        #region List of All Customers
        public void GetAllCustomers()
        {
            var customers = carLeaseRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
        #endregion
        #region Add Customer
        public void AddCustomer()
        {
            Console.WriteLine("Enter the First Name of the Customer:: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name of the Customer:: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the Email of the Customer:: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the PhoneNumber of the Customer:: ");
            int phoneNumber = int.Parse(Console.ReadLine());
            int addCustomerStatus = carLeaseRepository.AddCustomer(new Customers() { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber});
            if (addCustomerStatus > 0)
            {
                Console.WriteLine("Customer Added Successfully !!!!!!!!!!!!!!!\n");
            }
            else
            {
                Console.WriteLine("There Was Error while Adding Customer !!!!!!!!!!!!!!\n");
            }
        }
        #endregion
        #region Remove Customer
        public void RemoveCustomer()
        {
            try
            {
                Console.WriteLine("\nEnter the Id of the Customer to be Deleted:: ");
                int customerID = int.Parse(Console.ReadLine());
                int deleteCustomerStatus = carLeaseRepository.RemoveCustomer(customerID);
                if (deleteCustomerStatus > 0)
                {
                    Console.WriteLine("Customer Deleted SuccessFully !!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Console.WriteLine("There was some Error while Removing the Customer !!!!!!!!!\n");
                }
            }
            catch (CustomerNotFoundException ex)
             {
               Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region Find Customer By Id
        public void FindCustomerById()
        {
            Console.WriteLine("Enter the Customer Id :: ");
            int customerID = int.Parse(Console.ReadLine());
            Customers foundCustomer = carLeaseRepository.FindCustomerById(customerID);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Found Customer: ID: {foundCustomer.CustomerID}, Name: {foundCustomer.FirstName} {foundCustomer.LastName}, Email: {foundCustomer.Email}, Phone: {foundCustomer.PhoneNumber}\n");
            }
            else
            {
                Console.WriteLine($"Customer with Id {customerID} not Found !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1\n");
            }
        }
        #endregion


        //Lease Management

        #region Lease History
        public void LeaseHistory()
        {
            var leases = carLeaseRepository.LeaseHistory();
            foreach (var lease in leases)
            {
                Console.WriteLine(lease);
            }
        }
        #endregion
        #region Create Lease
        public void CreateLease()
        {
            Console.WriteLine("Enter VehicleID ID:: ");
            int vehicleID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer ID: ");
            int customerID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Start Date (YYYY-MM-DD): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter End Date (YYYY-MM-DD): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Type of Lease('DailyLease','MonthlyLease'): ");
            string type = Console.ReadLine();
            try
            {
                int addLeaseStatus = carLeaseRepository.CreateLease(vehicleID, customerID, startDate, endDate, type);
                if (addLeaseStatus > 0)
                {
                    Console.WriteLine("\nLease Creating Successfully !!!!!!!!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Console.WriteLine("\nThere was Some Error while Creating Lease !!!!!!!!!!!!!!!!!!!!!!!!!\n");
                }
            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion
        #region Find Lease by Id
        public void FindLeaseById()
        {
            Console.WriteLine("Enter the Lease ID:: ");
            int leaseID = int.Parse(Console.ReadLine());
            
            Leases foundLease = carLeaseRepository.FindLeaseById(leaseID);
            if(foundLease != null)
            {
                Console.WriteLine($"Found Lease: ID: {foundLease.LeaseID}, VehicleID:: {foundLease.VehicleID}, CustomerID:: {foundLease.CustomerID}, StartDate:: {foundLease.StartDate}, EndDate:: {foundLease.EndDate}, Type:: {foundLease.Type}\n");
            }
            else
            {
                Console.WriteLine($"Lease with ID {leaseID} not Found !!!!!!!!!!!!!!!!!!!!!!!!\n");
            }
        }
        #endregion
        #region Active Lease
        public void ActiveLeases()
        {
            var activeLeases = carLeaseRepository.ActiveLeases();
            foreach (var lease in activeLeases)
            {
                Console.WriteLine(lease);
            }
        }
        #endregion


        //Payment Handling
        #region List Payments

        public void ListPayments()
        {
            var payments = carLeaseRepository.ListPayments();
            foreach (var payment in payments)
            {
                Console.WriteLine(payment);
            }
        }
        #endregion
        #region Record Payments
        public void RecordPayment()
        {
            Console.WriteLine("Enter the LeaseID :: ");
            int leaseID = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("Enter the Amount to be added:: ");
                decimal Amount = decimal.Parse(Console.ReadLine());
                int addPaymentStatus = carLeaseRepository.RecordPayment(leaseID, Amount);
                if (addPaymentStatus > 0)
                {
                    Console.WriteLine("Payment Added Successfully !!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Console.WriteLine("Payment Was Not Successfull !!!!!!!!!!!!!!!!!!\n");

                }
            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion

    }
}
