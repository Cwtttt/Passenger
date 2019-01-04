using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Servicess
{
    public interface IUserServices
    {
        UserDto Get(string email);
        void Register(string email, string username, string password);
    }
}