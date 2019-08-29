using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TripManagement.API.DataAccess;
using TripManagement.API.Models;

namespace TripManagement.Test
{
    public class DatabaseFixture : IDisposable
    {
        public ITripContext context;
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<TripContext>()
                .UseInMemoryDatabase(databaseName: "TripManagement")
                .Options;

            //Initializing DbContext with InMemory
            context = new TripContext(options);

            // Insert seed data into the database using one instance of the context
            context.Trips.Add(new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 });
            context.SaveChanges();
        }
        public void Dispose()
        {
            context = null;
        }

    }
}
