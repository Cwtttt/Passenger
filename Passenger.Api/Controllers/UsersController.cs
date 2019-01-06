using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Servicess;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
            =>await _userServices.GetAsync(email);
        
        [HttpPost("")]
        public async Task Post([FromBody]CreateUser request)
        {
            await _userServices.RegisterAsync(request.Email,request.Username, request.Password);
        }


    }
}
