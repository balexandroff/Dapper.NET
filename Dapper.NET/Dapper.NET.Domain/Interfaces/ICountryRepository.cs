using Dapper.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.NET.Domain.Interfaces
{
    public interface ICountryRepository: IRepository
    {
        public Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Country> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<bool> Create(Country model, CancellationToken cancellationToken);
        public Task<bool> Update(Country model, CancellationToken cancellationToken);
        public Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    }
}
