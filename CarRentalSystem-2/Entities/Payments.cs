using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    public class Payments
    {
        public int PaymentID { get; set; }
        public int LeaseID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public Payments() { }
        public Payments(int paymentID, int leaseID, DateTime paymentDate, decimal amount)
        {
            PaymentID = paymentID;
            LeaseID = leaseID;
            PaymentDate = paymentDate;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"PaymentId:: {PaymentID}, LeaseId::{LeaseID}, PaymentDate:: {PaymentDate}, Amount:: {Amount}";
        }
    }
}
