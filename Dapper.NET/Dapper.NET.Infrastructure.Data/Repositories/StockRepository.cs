using Dapper.NET.Domain.Entities;
using Dapper.NET.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.NET.Infrastructure.Data.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Stock>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                const string sql = @"
                    SELECT s.*, c.* 
                      FROM Stocks s
                INNER JOIN Countries c ON c.Id = s.CountryId";

                var types = new[] { typeof(Stock), typeof(Country) };

                Func<object[], Stock> mapper = (objects) =>
                {
                    var stock = (Stock)objects[0];
                    stock.Country = (Country)objects[1];
                    return stock;
                };

                return await db.QueryAsync<Stock>(sql, types, mapper).ConfigureAwait(false);
            }
        }

        public async Task<Stock> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                string sql = @"
                    SELECT s.*, c.* 
                      FROM Stocks s
                INNER JOIN Countries c ON c.Id = s.CountryId
                     WHERE Id = " + $"'{id.ToString()}'";

                var types = new[] { typeof(Stock), typeof(Country) };

                Func<object[], Stock> mapper = (objects) =>
                {
                    var stock = (Stock)objects[0];
                    stock.Country = (Country)objects[1];
                    return stock;
                };

                var result = await db.QueryAsync<Stock>(sql, types, mapper).ConfigureAwait(false);

                return await Task.FromResult(result.FirstOrDefault());
            }
        }

        public async Task<bool> Create(Stock model, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                int rowsAffected = await db.ExecuteAsync($"INSERT INTO Stocks (Id, Ticker, Name, Description, CountryId, CreatedDate, ModifiedDate) Values('{model.Id}', '{model.Ticker}', '{model.Name}', '{model.Description}', '{model.CountryId}', '{DateTime.Now.ToString("yyyy-dd-MM")}', '{DateTime.Now.ToString("yyyy-dd-MM")}')").ConfigureAwait(false);

                return await Task.FromResult(rowsAffected > 0);
            }
        }

        public async Task<bool> Update(Stock model, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                int rowsAffected = await db.ExecuteAsync($"UPDATE Stocks SET Ticker = '{model.Ticker}', Name = '{model.Name}', Description = '{model.Description}', CountryId = '{model.CountryId}', ModifiedDate = '{DateTime.Now.ToString("yyyy-dd-MM")}' WHERE Id = '{model.Id}'").ConfigureAwait(false);

                return await Task.FromResult(rowsAffected > 0);
            }
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = new SqlConnection(base._connectionString))
            {
                int rowsAffected = await db.ExecuteAsync($"DELETE FROM Stocks WHERE Id = '{id}'").ConfigureAwait(false);

                return await Task.FromResult(rowsAffected > 0);
            }
        }
    }
}
