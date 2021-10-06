using System;

namespace Dapper.NET.Domain.Entities
{
    public class Investment: AudutableEntity
    {
        public Guid StockId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal CurrentPL 
        {
            get => CurrentPrice - PurchasePrice;
        }
    }
}
