using Microsoft.AspNetCore.Mvc;
using VehicleManagement.API.Models;
using VehicleManagement.API.Services.Interfaces;

namespace VehicleManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;
        private const string STATUS_ERROR = "Your request cannot be completed, Please contact administrator";
        public VehicleController(IVehicleService vehicleService)
        {
            _service = vehicleService;
        }

        // GET api/vehicles
        [HttpGet]
        public IActionResult Get()
        {
            var vehicles = _service.GetAllVehicles();
            return Ok(vehicles);
        }

        // GET api/vehicles/5
        [HttpGet]
        [Route("{id}", Name = "GetByVehicleId")]
        public IActionResult Get(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            return Ok(vehicle);
        }

        // POST api/vehicles
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            var _vehicle = _service.CreateVehicle(vehicle);
            return Created("api/v1/Vehicle", _vehicle);
        }

        // PUT api/vehicles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vehicle vehicle)
        {
            var result = _service.UpdateVehicle(id, vehicle);
            return Ok(vehicle);
        }

        // DELETE api/vehicles/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteVehicle(id);
            return Ok(result);
        }
    }
}
