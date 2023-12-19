using CarRentalSystem.Entities;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Repository;
using CarRentalSystem.Service;

namespace CarRentalSystemTest
{
    public class Tests
    {
        private const string connectionString = "Server=DESKTOP-ILIQSA6;Database=CRS;Trusted_Connection=True";

        [Test]
        public void TestToAddCar()
        {
            //Assign
            CarLeaseRepositoryImpl carLeaseRepositoryImpl = new CarLeaseRepositoryImpl();
            //carLeaseRepositoryImpl.connectionString = connectionString;

            //Act
            int addCarStatus = carLeaseRepositoryImpl.AddCar(new CarRentalSystem.Entities.Vehicles
            {
                Make = "Maruti",
                Model = "800",
                Year = 2023,
                DailyRate = 50.0m,
                Status = "available",
                PassengerCapacity = 5,
                EngineCapacity = 2000
            });

            Assert.AreEqual(1, addCarStatus);
        }

        [Test]

        public void TestToCreateLease()
        {
            CarLeaseRepositoryImpl carLeaseRepositoryImpl = new CarLeaseRepositoryImpl();
            //carLeaseRepositoryImpl.connectionString = connectionString;

            DateTime startDate = new DateTime(2023, 12, 17);
            DateTime endDate = new DateTime(2024, 01, 17);
            int addLeaseStatus = carLeaseRepositoryImpl.CreateLease(1, 1, startDate, endDate, "MonthlyLease");

            Assert.AreEqual(1, addLeaseStatus);

        }

        [Test]

        public void TestToRetrieveLease()
        {
            CarLeaseRepositoryImpl carLeaseRepositoryImpl = new CarLeaseRepositoryImpl();
            //carLeaseRepositoryImpl.connectionString = connectionString;

            Leases lease = carLeaseRepositoryImpl.FindLeaseById(2);

            Assert.IsNotNull(lease);
        }

        [Test]

        public void TestToCarNotFoundException()
        {
            CarLeaseRepositoryImpl carLeaseRepositoryImpl = new CarLeaseRepositoryImpl();
            carLeaseRepositoryImpl.connectionString = connectionString;

            Assert.Throws<CarNotFoundException>(() => carLeaseRepositoryImpl.FindCarById(3));
        }

        [Test]

        public void TestToCustomerNotFoundException()
        {
            CarLeaseRepositoryImpl carLeaseRepositoryImpl = new CarLeaseRepositoryImpl();
            //carLeaseRepositoryImpl.connectionString = connectionString;

            Assert.Throws<CustomerNotFoundException>(() => carLeaseRepositoryImpl.FindCustomerById(100));
        }

        [Test]

        public void TestToLeaseNotFoundException()
        {
            CarLeaseRepositoryImpl carLeaseRepositoryImpl = new CarLeaseRepositoryImpl();
            //carLeaseRepositoryImpl.connectionString = connectionString;

            Assert.Throws<LeaseNotFoundException>(() => carLeaseRepositoryImpl.FindLeaseById(100));
        }

    }
}