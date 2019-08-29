using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TripManagement.API.Controllers;
using TripManagement.API.Models;
using TripManagement.API.Services;
using Xunit;

namespace TripManagement.Test
{
    public class TripControllerTest
    {
        [Fact]
        public void GetTripsByEmployeeIdShouldReturnOk()
        {

            int employeeId = 1;
            List<Trip> trip = new List<Trip> { new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 } };
            var mockService = new Mock<ITripService>();
            mockService.Setup(service => service.GetTripsByEmployeeId(employeeId)).Returns(trip);
            var controller = new TripController(mockService.Object);

            var actual = controller.Get(employeeId);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetTripsByEmployeeIdShouldReturnAList()
        {
            int employeeId = 1;
            List<Trip> trip = new List<Trip> { new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 } };
            var mockService = new Mock<ITripService>();
            mockService.Setup(service => service.GetTripsByEmployeeId(employeeId)).Returns(trip);
            var controller = new TripController(mockService.Object);

            var actual = controller.Get(employeeId);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            Assert.IsAssignableFrom<IEnumerable<Trip>>(actionReult.Value);
        }

        [Fact]
        public void GetAllTripsShouldReturnOk()
        {

            List<Trip> trip = new List<Trip> { new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 } };
            var mockService = new Mock<ITripService>();
            mockService.Setup(service => service.GetAllTrips()).Returns(this.GetTrips());
            var controller = new TripController(mockService.Object);

            var actual = controller.Get();

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            
        }

        [Fact]
        public void GetAllTripsShouldReturnAList()
        {
            List<Trip> trip = new List<Trip> { new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 } };
            var mockService = new Mock<ITripService>();
            mockService.Setup(service => service.GetAllTrips()).Returns(this.GetTrips());
            var controller = new TripController(mockService.Object);

            var actual = controller.Get();

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            Assert.IsAssignableFrom<IEnumerable<Trip>>(actionReult.Value);
        }

        [Fact]
        public void DeleteTripShouldReturnOK()
        {
            var mockService = new Mock<ITripService>();
            mockService.Setup(service => service.DeleteTrip(201)).Returns(true);
            var controller = new TripController(mockService.Object);

            var actual = controller.Delete(201);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionReult.Value;
            var expected = true;
            Assert.Equal(expected, actualValue);
        }

        [Fact]
        public void BookTripShouldReturnCreated()
        {
            var mockService = new Mock<ITripService>();
            Trip trip = new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 };

            mockService.Setup(service => service.BookTrip(trip)).Returns(trip);
            var controller = new TripController(mockService.Object);

            var actual = controller.Post(trip);

            var actionReult = Assert.IsType<CreatedResult>(actual);
            var actualValue = actionReult.Value;
            Assert.IsAssignableFrom<Trip>(actualValue);
        }

        private List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip> { new Trip { TripId = 1, CustomerId = 1, EmployeeId = 1, VechileId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), From = "Coimbatore", To = "Mumbai", Status = "Booked", Fare = 0 } };
            return trips;
        }
    }
}
