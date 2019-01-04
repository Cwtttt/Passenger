using System;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Servicess
{
    public interface IDriverServices
    {
        DriverDto Get(Guid userId);
    }
}