using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    public class Vehicles
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; }
        public int PassengerCapacity { get; set; }
        public int EngineCapacity { get; set; }

        public Vehicles() { }

        public Vehicles(int vehicleID, string make, string model, int year, decimal dailyRate, string status, int passengerCapacity, int engineCapacity)
        {
            VehicleID = vehicleID;
            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            Status = status;
            PassengerCapacity = passengerCapacity;
            EngineCapacity = engineCapacity;
        }

        public override string ToString()
        {
            return $"VehicleID:: {VehicleID}, Make:: {Make}, Model:: {Model}, DailyRate:: {DailyRate}, Status:: {Status}";
        }


    }
}

