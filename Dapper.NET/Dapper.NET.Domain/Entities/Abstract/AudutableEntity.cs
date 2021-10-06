using System;

namespace Dapper.NET.Domain.Entities
{
    public abstract class AudutableEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
