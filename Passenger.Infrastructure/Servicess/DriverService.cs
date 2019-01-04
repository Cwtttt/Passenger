using System;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Servicess
{
    public class DriverService : IDriverServices
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public DriverDto Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);

            return new DriverDto
            {
                //id
            };
        }
    }
}