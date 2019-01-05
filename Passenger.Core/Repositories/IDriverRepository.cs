using System;
using Passenger.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository
    {
        Driver Get(Guid id);
        IEnumerable<Driver> GetAll();
        void Add(Driver driver);
        void Update(Driver driver);

        Task<Driver> GetAsync(Guid userId);
        Task<IEnumerable<Driver>> GetAllAsync();
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);

    }
}