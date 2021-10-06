using Dapper.NET.Application.Common;
using Dapper.NET.Application.Interfaces;
using Dapper.NET.Application.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.NET.Application.Countries.Queries
{
    public class GetCountryByIdQuery : IRequestWrapper<CountryViewModel>
    {
        public Guid Id { get; private set; }

        public GetCountryByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetCountryByIdQueryHandler : IRequestHandlerWrapper<GetCountryByIdQuery, CountryViewModel>
    {
        private readonly ICountryService _countryService;

        public GetCountryByIdQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ServiceResult<CountryViewModel>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await this._countryService.GetByIdAsync(request.Id, cancellationToken);

            return country != null ? ServiceResult.Success(country) : ServiceResult.Failed<CountryViewModel>(ServiceError.NotFound);
        }
    }
}
