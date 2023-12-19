using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    public class Leases
    {
        public int LeaseID { get; set; }
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        public Leases() { }
        public Leases(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime endDate, string type)
        {
            LeaseID = leaseID;
            VehicleID = vehicleID;
            CustomerID = customerID;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }
        public override string ToString()
        {
            return $"LeaseID:: {LeaseID}, VehicleID:: {VehicleID}, CustomerID:: {CustomerID}, StartDate:: {StartDate}, EndDate:: {EndDate}, Type:: {Type}";
        }
    }
}
