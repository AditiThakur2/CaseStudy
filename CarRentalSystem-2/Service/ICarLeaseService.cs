using CarRentalSystem.Entities;
using CarRentalSystem.Repository;
using CarRentalSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Service
{
    public interface ICarLeaseService
    {
        //CUSTOMER MANAGEMENT
        void GetAllVehicles();
        void AddCar();
        void RemoveCar();
        void ListAvailableCars();
        void ListRentedCars();
        void FindCarById();



        //CUSTOMER MANAGEMENT
        void GetAllCustomers();
        void AddCustomer();
        void RemoveCustomer();
        void FindCustomerById();



        //LEASE MANAGEMENT
        void LeaseHistory();
        void CreateLease();
        void FindLeaseById();
        void ActiveLeases();



        //PAYMENT HANDLING
        void ListPayments();
        void RecordPayment();


    }
}
