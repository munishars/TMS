using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripManagement.API.Models;

namespace TripManagement.API.DataAccess
{
    public class TripContext : DbContext, ITripContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Trip>().HasKey(m => m.TripId);
            builder.Entity<Trip>().Property(u => u.CustomerId).IsRequired();
            builder.Entity<Trip>().Property(u => u.Status).IsRequired();
            builder.Entity<Trip>().Property(u => u.From).IsRequired();
            builder.Entity<Trip>().Property(u => u.To).IsRequired();
            builder.Entity<Trip>().ToTable("TripDetails");
            base.OnModelCreating(builder);
        }
    }
}
