using System.Threading.Tasks;
using Moq;
using Xunit;
using Passenger.Core.Repositories;
using AutoMapper;

namespace Passenger.Tests.Services
{
    public class UserServicetests
    {
        [Fact]
        public async Task Test()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserServices(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@email.com", "user", "secret");
        }    
    }
}