using Advantage.API.Dtos;
using Advantage.API.Models;
using AutoMapper;

namespace Advantage.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerForUpdateDto, Customer>();
        }
    }
}