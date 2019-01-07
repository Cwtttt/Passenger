using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Servicess;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserServices _userServices;
     
        public CreateUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
    
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userServices.RegisterAsync(command.Email, command.Username, command.Password);
        }
    }
}