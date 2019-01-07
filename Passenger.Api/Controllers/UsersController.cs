using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Servicess;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ICommandDispatcher _commandDispatcher;
        public UsersController(IUserServices userServices, ICommandDispatcher commandDispatcher)
        {
            _userServices = userServices;
            _commandDispatcher = commandDispatcher;
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await  _userServices.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
            
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Email}", new Object());     
        }


    }
}
