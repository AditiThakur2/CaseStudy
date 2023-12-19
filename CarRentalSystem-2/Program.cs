using CarRentalSystem.Entities;
using CarRentalSystem.Repository;
using CarRentalSystem.Service;
using CarRentalSystem.Exceptions;



ICarLeaseService carLeaseServiceImpl = new CarLeaseServiceImpl();
Console.WriteLine("\n-------------------------------------------  WELCOME TO LEASE MANAGEMENT SYSTEM! ---------------------------------------\n");

while (true)
{
    Console.WriteLine("----------------------VEHICLES------------------\n");
    Console.WriteLine("1. GetAllVehicles");
    Console.WriteLine("2. AddCar");
    Console.WriteLine("3. RemoveCar");
    Console.WriteLine("4. ListAvailableCars");
    Console.WriteLine("5. ListRentedCars");
    Console.WriteLine("6. FindCarById");
    Console.WriteLine("\n--------------------CUSTOMERS-----------------\n");
    Console.WriteLine("7. GetAllCustomers");
    Console.WriteLine("8. AddCustomers");
    Console.WriteLine("9. RemoveCustomer");
    Console.WriteLine("10. FindCustomerById");
    Console.WriteLine("\n---------------------LEASES-----------------\n");
    Console.WriteLine("11. LeaseHistory");
    Console.WriteLine("12. CreateLease");
    Console.WriteLine("13. FindLeaseById");
    Console.WriteLine("14. ActiveLeases");
    Console.WriteLine("\n--------------------PAYMENTS---------------\n");
    Console.WriteLine("15. ListPayments");
    Console.WriteLine("16. RecordPayment");
    Console.WriteLine("\nEnter Your Choice:: \n");
    int choice = int.Parse(Console.ReadLine()); 

    switch(choice)
    {
        case 1:
            carLeaseServiceImpl.GetAllVehicles();
            break;
        case 2:
            carLeaseServiceImpl.AddCar();
            break;
        case 3:
            carLeaseServiceImpl.RemoveCar();
            break;
        case 4:
            carLeaseServiceImpl.ListAvailableCars();
            break;
        case 5:
            carLeaseServiceImpl.ListRentedCars();
            break;
        case 6:
            carLeaseServiceImpl.FindCarById();
            break;
        case 7:
            carLeaseServiceImpl.GetAllCustomers();
            break;
        case 8:
            carLeaseServiceImpl.AddCustomer();
            break;
        case 9:
            carLeaseServiceImpl.RemoveCustomer();
            break;
        case 10:
            carLeaseServiceImpl.FindCustomerById();
            break;
        case 11:
            carLeaseServiceImpl.LeaseHistory();
            break;
        case 12:
            carLeaseServiceImpl.CreateLease();
            break;
        case 13:
            carLeaseServiceImpl.FindLeaseById();
            break;
        case 14:
            carLeaseServiceImpl.ActiveLeases();
            break;
        case 15:
            carLeaseServiceImpl.ListPayments();
            break;
        case 16:
            carLeaseServiceImpl.RecordPayment();
            break;
    }

}


