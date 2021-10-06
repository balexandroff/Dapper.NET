using Dapper.NET.Application.Common;
using Dapper.NET.Application.Interfaces;
using Dapper.NET.Application.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.NET.Application.Stocks.Queries
{
    public class GetStockByIdQuery : IRequestWrapper<StockViewModel>
    {
        public Guid Id { get; private set; }

        public GetStockByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetStockByIdQueryHandler : IRequestHandlerWrapper<GetStockByIdQuery, StockViewModel>
    {
        private readonly IStockService _stockService;

        public GetStockByIdQueryHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task<ServiceResult<StockViewModel>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await this._stockService.GetByIdAsync(request.Id, cancellationToken);

            return country != null ? ServiceResult.Success(country) : ServiceResult.Failed<StockViewModel>(ServiceError.NotFound);
        }
    }
}
