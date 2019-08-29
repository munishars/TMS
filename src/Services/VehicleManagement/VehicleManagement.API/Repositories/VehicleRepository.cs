using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagement.API.DataAccess;
using VehicleManagement.API.Models;
using VehicleManagement.API.Repositories.Interfaces;

namespace VehicleManagement.API.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IVehicleContext _context;

        public VehicleRepository(IVehicleContext dbContext)
        {
            _context = dbContext;
        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            try
            {
                _context.Vehicles.Add(vehicle);
                int result = _context.SaveChanges();
                return (result > 0) ? vehicle : null;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public bool DeleteVehicle(int vehicleId)
        {
            var vehicle = GetVehicleById(vehicleId);
            _context.Vehicles.Remove(vehicle);
            int result = _context.SaveChanges();
            return (result > 0);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.AsEnumerable();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _context.Vehicles.Where(x => x.VehicleId == vehicleId).FirstOrDefault();
        }

        public bool UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            int result = 0;
            var existing = GetVehicleById(vehicleId);
            if (existing != null)
            {
                _context.Vehicles.Update(vehicle);
                result = _context.SaveChanges();
            }
            return (result > 0);
        }
    }
}
