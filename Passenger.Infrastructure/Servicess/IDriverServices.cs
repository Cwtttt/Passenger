using System;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Servicess
{
    public interface IDriverServices
    {
        Task<DriverDto> GetAsync(Guid userId);
    }
}