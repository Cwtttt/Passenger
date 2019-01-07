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

    public class UsersController : ApiControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices, 
                               ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userServices = userServices;
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
            await CommandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Email}", new Object());     
        }



    }
}
