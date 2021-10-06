using System;

namespace Dapper.NET.Domain.Entities
{
    public class Stock: AudutableEntity
    {
        public string Ticker { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
