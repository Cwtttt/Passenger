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
        public UserDto Get(string email)
            =>_userServices.Get(email);
        
        [HttpPost("")]
        public void Post([FromBody]CreateUser request)
        {
            _userServices.Register(request.Email,request.Username, request.Password);
        }


    }
}
