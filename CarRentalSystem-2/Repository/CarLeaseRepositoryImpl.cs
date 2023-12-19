using CarRentalSystem.Repository;
using CarRentalSystem.Entities;
using CarRentalSystem.Utility;
using System.Data.SqlClient;
using CarRentalSystem.Exceptions;

namespace CarRentalSystem.Repository
{
    public class CarLeaseRepositoryImpl:ICarLeaseRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        public CarLeaseRepositoryImpl()
        {
            connectionString = DBConnection.GetConnectionString();
            cmd = new SqlCommand();
        }

        // CAR MANAGEMENT

        #region Display All Vehicles
        public List<Vehicles> GetAllVehicles()
        {
                List<Vehicles> vehicles = new List<Vehicles>();
            
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Vehicles";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Vehicles vehicle = new Vehicles();
                        vehicle.VehicleID = (int)reader["vehicleID"];
                        vehicle.Make = (string)reader["make"];
                        vehicle.Model = (string)reader["model"];
                        vehicle.Year = (int)reader["year"];
                        vehicle.DailyRate = (decimal)reader["dailyRate"];
                        vehicle.Status = (string)reader["status"];
                        vehicle.PassengerCapacity = (int)reader["passengerCapacity"];
                        vehicle.EngineCapacity = (int)reader["engineCapacity"];
                        vehicles.Add(vehicle);
                    }
                    return vehicles;
                }
        }
        #endregion
        #region Add Car

        public int AddCar(Vehicles car)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Vehicles VALUES(@Make ,@Model , @Year , @DailyRate , @Status , @PassengerCapacity , @EngineCapacity)";
                cmd.Parameters.AddWithValue("@Make", car.Make);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
                cmd.Parameters.AddWithValue("@Status", car.Status);
                cmd.Parameters.AddWithValue("@PassengerCapacity", car.PassengerCapacity);
                cmd.Parameters.AddWithValue("@EngineCapacity", car.EngineCapacity);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addCarStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return addCarStatus;
                
            }
        }
        #endregion
        #region Remove Car

        public int RemoveCar(int carID)
        {
            Vehicles foundCar = FindCarById(carID);

            if(foundCar == null)
            {
                throw new CarNotFoundException($"Car with Id {carID} to be Deleted was not found    !!!!!!!!!!!!!!!!\n");
            }

            using(SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                cmd.CommandText = "Delete from Vehicles Where vehicleId = @CrID";
                cmd.Parameters.AddWithValue("@CrID", carID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deleteCarStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return deleteCarStatus;
            }
        }
        #endregion
        #region Find Available Cars

        public List<Vehicles> ListAvailableCars()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles WHERE status = 'available'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vehicles vehicle = new Vehicles();
                    vehicle.VehicleID = (int)reader["vehicleID"];
                    vehicle.Make = (string)reader["make"];
                    vehicle.Model = (string)reader["model"];
                    vehicle.Year = (int)reader["year"];
                    vehicle.DailyRate = (decimal)reader["dailyRate"];
                    vehicle.Status = (string)reader["status"];
                    vehicle.PassengerCapacity = (int)reader["passengerCapacity"];
                    vehicle.EngineCapacity = (int)reader["engineCapacity"];
                    vehicles.Add(vehicle);
                }
                return vehicles;
            }
        }
        #endregion
        #region Find Rented Cars

        public List<Vehicles> ListRentedCars()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles WHERE status = 'notAvailable'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vehicles vehicle = new Vehicles();
                    vehicle.VehicleID = (int)reader["vehicleID"];
                    vehicle.Make = (string)reader["make"];
                    vehicle.Model = (string)reader["model"];
                    vehicle.Year = (int)reader["year"];
                    vehicle.DailyRate = (decimal)reader["dailyRate"];
                    vehicle.Status = (string)reader["status"];
                    vehicle.PassengerCapacity = (int)reader["passengerCapacity"];
                    vehicle.EngineCapacity = (int)reader["engineCapacity"];
                    vehicles.Add(vehicle);
                }
                return vehicles;
            }
        }
        #endregion
        #region Find Car By Id

        public Vehicles FindCarById(int carID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles WHERE vehicleID = @CarID";
                cmd.Parameters.AddWithValue("@CarID", carID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Vehicles car = new Vehicles();
                    car.VehicleID = (int)reader["vehicleID"];
                    car.Make = (string)reader["make"];
                    car.Model = (string)reader["model"];
                    car.Year = (int)reader["year"];
                    car.DailyRate = (decimal)reader["dailyRate"];
                    car.Status = (string)reader["status"];
                    car.PassengerCapacity = (int)reader["passengerCapacity"];
                    car.EngineCapacity = (int)reader["engineCapacity"];
                    return car;
                }
                return null;
            }
        }
        #endregion









        //CUSTOMERS MANAGEMENT
        #region Display All Customers
        public List<Customers> GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Customers";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customers customer = new Customers();
                    customer.CustomerID = (int)reader["customerID"];
                    customer.FirstName = (string)reader["firstName"];
                    customer.LastName = (string)reader["lastName"];
                    customer.Email = (string)reader["email"];
                    customer.PhoneNumber = (int)reader["phoneNumber"];
                    customers.Add(customer);
                }
                return customers;
            }
        }
        #endregion
        #region Add Customer

        public int AddCustomer(Customers customer)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Customers VALUES(@FirstName ,@LastName , @Email , @PhoneNumber)";
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addCustomerStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return addCustomerStatus;

            }
        }
        #endregion
        #region Remove Customer

        public int RemoveCustomer(int customerID)
        {
            Customers foundCustomer = FindCustomerById(customerID);

            if (foundCustomer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerID} to be Removed is not Found !!!!!!!!!!!!!!!!!!! \n");
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Delete from Customers Where customerId = @CustomerID";
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deleteCustomerStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return deleteCustomerStatus;
            }
        }
        #endregion
        #region Find Customer By Id

        public Customers FindCustomerById(int customerID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Customers WHERE customerID = @customerID";
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                if (reader.Read())
                {
                    Customers customer = new Customers();
                    customer.CustomerID = (int)reader["CustomerID"];
                    customer.FirstName = (string)reader["FirstName"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Email = (string)reader["Email"];
                    customer.PhoneNumber = (int)reader["PhoneNumber"];
                    return customer;
                }
                return null;
                
            }
        }
        #endregion








        //LEASE MANAGEMENT
        #region Lease History

        public List<Leases> LeaseHistory()
        {
            List<Leases> leases = new List<Leases>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Leases";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Leases lease = new Leases();
                    lease.LeaseID = (int)reader["leaseID"];
                    lease.VehicleID = (int)reader["vehicleID"];
                    lease.CustomerID = (int)reader["customerID"];
                    lease.StartDate = (DateTime)reader["startDate"];
                    lease.EndDate = (DateTime)reader["endDate"];
                    lease.Type = (string)reader["type"];
                    leases.Add(lease);
                }
                return leases;
            }
        }
        #endregion
        #region Create Lease
        public int CreateLease(int vehicleID, int customerID, DateTime startDate, DateTime endDate, string type)
        {
            var  customer = FindCustomerById(customerID);
            var car = FindCarById(vehicleID);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerID} not found.\n");
            }

            if (car == null || car.Status == "notAvailable")
            {
                throw new CarNotFoundException($"Car with ID {vehicleID} not found to Lease. Check the available Car List for Lease and Enter the Valid VehicleID !!!!!!!!!!!!!!!!\n");
            }

            //Update status of the car to "notAvailable"
            UpdateCarStatus(vehicleID, "notAvailable");

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Leases VALUES(@VehicleID,@CustID,@StartDate,@EndDate,@Type)";
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@CustID", customerID);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addLeaseStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return addLeaseStatus;
            }
        }

        private void UpdateCarStatus(int vehicleID, string status)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "UPDATE Vehicles SET status = @Status WHERE vehicleID = @vehicleID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }
        #endregion
        #region Find Lease By Id

        public Leases FindLeaseById(int leaseID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Leases WHERE leaseID = @LeaseID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@LeaseID", leaseID);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                if (reader.Read())
                {
                    Leases lease = new Leases();
                    lease.LeaseID = (int)reader["leaseID"];
                    lease.CustomerID = (int)reader["customerID"];
                    lease.VehicleID = (int)reader["vehicleID"];
                    lease.StartDate = (DateTime)reader["startDate"];
                    lease.EndDate = (DateTime)reader["endDate"];
                    lease.Type = (string)reader["Type"];
                    return lease;
                }
                return null;
            }
        }

        #endregion
        #region List of Active Leases

        public List<Leases> ActiveLeases()
        {
            List<Leases> activeLeases = new List<Leases>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Leases WHERE endDate >= GETDATE()";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Leases lease = new Leases();
                    lease.LeaseID = (int)reader["leaseID"];
                    lease.CustomerID = (int)reader["customerID"];
                    lease.VehicleID = (int)reader["vehicleID"];
                    lease.StartDate = (DateTime)reader["startDate"];
                    lease.EndDate = (DateTime)reader["endDate"];
                    lease.Type = (string)reader["type"];
                    activeLeases.Add(lease);
                }

                return activeLeases;
            }
        }
        #endregion


        //PAYMENT HANDLING
        #region List of All Payments

        public List<Payments> ListPayments()
        {
            List<Payments> payments = new List<Payments>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Payments";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payments payment = new Payments();
                    payment.PaymentID = (int)reader["paymentID"];
                    payment.LeaseID = (int)reader["leaseID"];
                    payment.PaymentDate = (DateTime)reader["paymentDate"];
                    payment.Amount = (decimal)reader["amount"];
                    payments.Add(payment);
                }
                return payments;
            }
        }
        #endregion
        #region Record Payment
        public int RecordPayment(int leaseID, decimal Amount)
        {
            Leases existingLeases = FindLeaseById(leaseID);

            if(existingLeases == null)
            {
                throw new LeaseNotFoundException("Entered Leased Id {leaseID} is not Found   !!!!!!!!!!!!!!!\n");
            }
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Payments VALUES (@leaseID, @PaymentDate, @Amount)";
                cmd.Parameters.AddWithValue("@leaseID", leaseID);
                cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addPaymentStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return addPaymentStatus;
            }
        }
        #endregion
    }
}
