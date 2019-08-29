using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.API.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string RegistrationNum { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
    }
}
