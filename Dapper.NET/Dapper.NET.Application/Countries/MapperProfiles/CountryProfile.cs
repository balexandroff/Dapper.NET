using AutoMapper;
using Dapper.NET.Domain.Entities;

namespace Dapper.NET.Application.ViewModels.MapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();
        }
    }
}
