using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripManagement.API.Models;
using TripManagement.API.Services;

namespace TripManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _service;
        private const string STATUS_ERROR = "Your request cannot be completed, Please contact administrator";
        public TripController(ITripService tripService)
        {
            _service = tripService;
        }

        // GET api/Trip
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            List<Trip> trips= _service.GetAllTrips();
            return Ok(trips);
        }

        //GET api/Trip/GetTripsByEmployeeId
        [HttpGet("{id}")]
        [Authorize(Roles = "Employee")]
        public IActionResult Get(int employeeId)
        {
            var trips = _service.GetTripsByEmployeeId(employeeId);
            return Ok(trips);
        }

        // POST api/Trip
        [HttpPost]
        public IActionResult Post([FromBody] Trip trip)
        {
            var _trip = _service.BookTrip(trip);
            return Created("api/v1/Trip", _trip);
        }

        // PUT
        [HttpPut]
        [Route("{id}", Name = "UpdateTrip")]
        public IActionResult UpdateTrip(int id, [FromBody] Trip trip)
        {
            var result = _service.ConfirmTrip(id, trip);
            return Ok(trip);
        }

        // DELETE api/Trip/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int tripId)
        {
            var result = _service.DeleteTrip(tripId);
            return Ok(result);
        }
    }
}