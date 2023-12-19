using CarRentalSystem.Entities;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Repository
{
    public interface ICarLeaseRepository
    {
        //CAR MANAGEMENT
        List<Vehicles> GetAllVehicles();
        int AddCar(Vehicles car);
        int RemoveCar(int carID);
        List<Vehicles> ListAvailableCars();
        List<Vehicles> ListRentedCars();
        Vehicles FindCarById(int carID);



        //CUSTOMER MANAGEMENT
        List<Customers> GetAllCustomers();
        int AddCustomer(Customers customer);
        int RemoveCustomer(int customerId);
        Customers FindCustomerById(int carID);



        //LEASE MANAGEMENT
        List<Leases> LeaseHistory();
        int CreateLease(int customerID, int vehicleID, DateTime startDate, DateTime endDate, string type);
        Leases FindLeaseById(int leaseID);
        List<Leases> ActiveLeases();



        //PAYMENT HANDLING
        List<Payments> ListPayments();
        int RecordPayment(int leaseId, decimal Amount);

    }
}
 