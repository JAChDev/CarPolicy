using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.WebApi.Models
{
    public class PolicyModel
    {
        public string PolicyNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public DateTime CustomerBirth { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public string[] Coverages { get; set; }
        public decimal MaxPolicyAmount { get; set; }
        public string PlanName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerAddress { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleModel { get; set; }
        public bool Inspection { get; set; }
    }
}
