using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripManagement.API.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int VechileId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }
        public string Status { get; set; }
    }
}
