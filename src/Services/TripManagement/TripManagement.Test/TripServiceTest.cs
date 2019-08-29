using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TripManagement.API.Models;
using TripManagement.API.Repositories;
using Xunit;

namespace TripManagement.Test
{
    public class TripServiceTest
    {
        [Fact]
        public void BookTripShouldReturnReminder()
        {
            var mockRepo = new Mock<ITripRepository>();
            Trip trip = new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 };
            mockRepo.Setup(repo => repo.BookTrip(trip)).Returns(trip);
            var service = new API.Services.TripService(mockRepo.Object);

            var actual = service.BookTrip(trip);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Trip>(actual);
        }

        [Fact]
        public void DeleteTripShouldReturnTrue()
        {
            var mockRepo = new Mock<ITripRepository>();
            int Id = 202;
            mockRepo.Setup(repo => repo.DeleteTrip(Id)).Returns(true);
            var service = new API.Services.TripService(mockRepo.Object);

            var actual = service.DeleteTrip(Id);

            Assert.True(actual);
        }
        [Fact]
        public void GetAllTripsShouldReturnAList()
        {
            var mockRepo = new Mock<ITripRepository>();
            mockRepo.Setup(repo => repo.GetAllTrips()).Returns(this.GetTrips());
            var service = new API.Services.TripService(mockRepo.Object);

            var actual = service.GetAllTrips();

            Assert.IsAssignableFrom<List<Trip>>(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void GetTripsByEmployeeIdShouldReturnAList()
        {
            int employeeId = 201;
            var mockRepo = new Mock<ITripRepository>();
            mockRepo.Setup(repo => repo.GetTripsByEmployeeId(employeeId)).Returns(this.GetTrips);
            var service = new API.Services.TripService(mockRepo.Object);

            var actual = service.GetTripsByEmployeeId(employeeId);

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<List<Trip>>(actual);
        }

        [Fact]
        public void ConfirmTripShouldReturnTrue()
        {
            int Id = 201;
            Trip trip = new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Confirmed", Fare = 0 };
            var mockRepo = new Mock<ITripRepository>();
            mockRepo.Setup(repo => repo.ConfirmTrip(Id, trip)).Returns(true);
            var service = new API.Services.TripService(mockRepo.Object);

            var actual = service.ConfirmTrip(Id, trip);
            Assert.True(actual);
        }
        private List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip> { new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 } };
            return trips;
        }
    }
}
