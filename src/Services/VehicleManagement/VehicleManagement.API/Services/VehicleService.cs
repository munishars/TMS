using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.API.Exceptions;
using VehicleManagement.API.Models;
using VehicleManagement.API.Repositories.Interfaces;
using VehicleManagement.API.Services.Interfaces;

namespace VehicleManagement.API.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _repository = vehicleRepository;
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            var result = _repository.CreateVehicle(vehicle);
            return (result != null) ? result : null;
        }

        public bool DeleteVehicle(int vehicleId)
        {
            return _repository.DeleteVehicle(vehicleId);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _repository.GetAllVehicles();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _repository.GetVehicleById(vehicleId);
        }

        public bool UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            return _repository.UpdateVehicle(vehicleId, vehicle);
        }
    }
}
