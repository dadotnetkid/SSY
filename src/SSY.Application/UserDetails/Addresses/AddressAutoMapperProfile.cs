using AutoMapper;
using SSY.UserDetails.Addresses.Dtos;

namespace SSY.UserDetails.Addresses
{
    public class AddressAutoMapperProfile : Profile
    {
        public AddressAutoMapperProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<Address, CreateAddressDto>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, UpdateAddressDto>();
        }
    }
}

