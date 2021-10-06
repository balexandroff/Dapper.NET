using Dapper.NET.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Dapper.NET.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> where T : AudutableEntity
    {
        protected readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("StocksConnection");
        }
    }
}
