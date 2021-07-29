using AutoMapper;
using MemShop.API.Models.Customers;
using MemShop.Domain.Customers;

namespace MemShop.API.Profiles.Customers
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
