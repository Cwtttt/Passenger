using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Servicess
{
    public interface IUserServices
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string username, string password);
        
    }
}