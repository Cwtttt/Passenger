using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task Given_valid_password_current_and_new_password_should_be_change()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2",
                
            };
            var payLoad = GetPayload(command);
            var response = await _client.PutAsync("account/password", payLoad);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    
        }
    }
}