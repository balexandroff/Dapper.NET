using Dapper.NET.Application.Common;
using Dapper.NET.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.NET.Application.Countries.Commands
{
    public class DeleteCountryCommand : IRequestWrapper<bool>
    {
        public Guid Id { get; private set; }

        public DeleteCountryCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteCountryCommandHandler : IRequestHandlerWrapper<DeleteCountryCommand, bool>
    {
        private readonly ICountryService _countryService;

        public DeleteCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ServiceResult<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var result = await _countryService.Delete(request.Id, cancellationToken);

            return result ? ServiceResult.Success(result) : ServiceResult.Failed<bool>(ServiceError.NotFound);
        }
    }
}
