using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.API.Models;

namespace VehicleManagement.API.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle CreateVehicle(Vehicle vehicle);
        Vehicle GetVehicleById(int vehicleId);
        IEnumerable<Vehicle> GetAllVehicles();
        bool UpdateVehicle(int vehicleId, Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);
    }
}
