using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {


        [Fact]
        public async Task Given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
            user.Email.Should().Be(email);
        }
        [Fact]
        public async Task Given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@email.com";
            var response = await _client.GetAsync($"users/{email}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Given_unique_email_user_should_be_created()
        {
            var command = new  CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };
            var payLoad = GetPayload(command);
            var response = await _client.PostAsync("users", payLoad);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().Be($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().Be(command.Email);
        }
        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return  JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}