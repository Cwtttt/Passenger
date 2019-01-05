using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();
        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public Task AddAsync(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Driver Get(Guid userId)
            =>_drivers.Single(x => x.UserId == userId);

        public IEnumerable<Driver> GetAll()
            =>_drivers;

        public Task<IEnumerable<Driver>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Driver driver)
        {
        }

        public Task UpdateAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}