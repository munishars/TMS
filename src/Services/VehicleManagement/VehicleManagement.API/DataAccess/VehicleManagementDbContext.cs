using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.API.Models;

namespace VehicleManagement.API.DataAccess
{
    public class VehicleContext: DbContext, IVehicleContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleContext(DbContextOptions<VehicleContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>().HasKey(m => m.VehicleId);
            builder.Entity<Vehicle>().Property(u => u.RegistrationNum).IsRequired();
            builder.Entity<Vehicle>().Property(u => u.Type).IsRequired();
            builder.Entity<Vehicle>().Property(u => u.Seats).IsRequired();
            builder.Entity<Vehicle>().ToTable("Vehicle");
            base.OnModelCreating(builder);
        }
    }
}
