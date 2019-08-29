using System;
using System.Collections.Generic;
using System.Text;
using TripManagement.API.Models;
using TripManagement.API.Repositories;
using Xunit;

namespace TripManagement.Test
{
    public class TripRepositoryTest: IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;
        private readonly ITripRepository repository;

        public TripRepositoryTest(DatabaseFixture _fixture)
        {
            this.fixture = _fixture;
            repository = new TripRepository(fixture.context);
        }

        [Fact]
        public void BookTripShouldReturnTrip()
        {
            Trip trip = new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 };

            var actual = repository.BookTrip(trip);
            Assert.IsAssignableFrom<Trip>(actual);
        }

        [Fact]
        public void DeleteTripShouldReturnTrue()
        {
            int Id = 1;

            var actual = repository.DeleteTrip(Id);

            Assert.True(actual);
        }
        [Fact]
        public void GetAllTripsShouldReturnAList()
        {
            var actual = repository.GetAllTrips();
            Assert.IsAssignableFrom<List<Trip>>(actual);
        }

        [Fact]
        public void GetTripsByEmployeeIdShouldReturnAList()
        {
            Trip trip = new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 };

            var actual = repository.GetTripsByEmployeeId(1);

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<List<Trip>>(actual);
        }

        [Fact]
        public void ConfirmTripShouldReturnTrue()
        {
            Trip trip = new Trip { TripId = 1, CustomerId = 1, EmployeeId = 12, VechileId = 12, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Delhi", Status = "Confirmed", Fare = 0 };

            var actual = repository.ConfirmTrip(1, trip);
            Assert.True(actual);
        }
        private List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip> { new Trip { TripId = 2, CustomerId = 101, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 }, new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Confirmed", Fare = 0 } };
            return trips;
        }
    }
}
