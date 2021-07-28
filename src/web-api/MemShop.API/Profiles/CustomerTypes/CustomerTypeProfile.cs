using AutoMapper;
using MemShop.API.Models.CustomerTypes;
using MemShop.Domain.CustomerTypes;

namespace MemShop.API.Profiles.CustomerTypes
{
    public class CustomerTypeProfile : Profile
    {
        public CustomerTypeProfile()
        {
            CreateMap<CustomerType, CustomerTypeDto>();
            CreateMap<CustomerTypeForCreationDto, CustomerType>();
            CreateMap<CustomerTypeForUpdateDto, CustomerType>().ReverseMap();
        }
    }
}
