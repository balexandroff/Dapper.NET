using Dapper.NET.Domain.Entities;
using Dapper.NET.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.NET.Infrastructure.Data.Repositories
{
    public class CountryRepository: BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                return await db.QueryAsync<Country>("SELECT * FROM Countries").ConfigureAwait(false);
            }
        }

        public async Task<Country> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                return await db.QuerySingleOrDefaultAsync<Country>($"SELECT * FROM Countries WHERE Id = '{id}'", new { id }).ConfigureAwait(false);
            }
        }

        public async Task<bool> Create(Country model, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                int rowsAffected = await db.ExecuteAsync($"INSERT INTO Countries (Id, Name, CreatedDate, ModifiedDate) Values('{model.Id}', '{model.Name}', '{DateTime.Now.ToString("yyyy-dd-MM")}', '{DateTime.Now.ToString("yyyy-dd-MM")}')").ConfigureAwait(false);

                return await Task.FromResult(rowsAffected > 0);
            }
        }

        public async Task<bool> Update(Country model, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                int rowsAffected = await db.ExecuteAsync($"UPDATE Countries SET Name = '{model.Name}', ModifiedDate = '{DateTime.Now.ToString("yyyy-dd-MM")}' WHERE Id = '{model.Id}'").ConfigureAwait(false);

                return await Task.FromResult(rowsAffected > 0);
            }
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                int rowsAffected = await db.ExecuteAsync($"DELETE FROM Countries WHERE Id = '{id}'").ConfigureAwait(false);

                return await Task.FromResult(rowsAffected > 0);
            }
        }
    }
}
