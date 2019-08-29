using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;
using UserManagement.API.Services;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        const string Status_Error = "Your request cannot be completed, Please contact administrator";

        public UserController(IUserService userService)
        {
            service = userService;
        }
        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}", Name = "GetByUserId")]
        public IActionResult Get(int id)
        {
            var user = service.GetUserById(id);
            return Ok(user);
        }
        // GET api/<controller>/
        [HttpGet]
        public IActionResult Get()
        {
            var user = service.GetAllUsers();
            return Ok(user);
        }
        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]User user)
        {
            var _user = service.RegisterUser(user);
            return Created("api/User", _user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            var result = service.UpdateUser(id, user);
            return Ok(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.DeleteUser(id);
            return Ok(result);
        }
    }
}