using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.API.Models;

namespace VehicleManagement.API.DataAccess
{
    public interface IVehicleContext
    {
        DbSet<Vehicle> Vehicles { get; }
        int SaveChanges();
    }
}
