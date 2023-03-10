using AutoMapper;
using SSY.UserDetails.Dtos;
using Volo.Abp.AutoMapper;

namespace SSY.UserDetails
{
    public class UserDetailAutoMapperProfile : Profile
    {
        public UserDetailAutoMapperProfile()
        {
            CreateMap<UserDetail, UserDetailDto>();
            CreateMap<UserDetail, CreateUserDetailDto>();
            CreateMap<CreateUserDetailDto, UserDetail>()
                .Ignore(c => c.AppUser);


            CreateMap<UserDetail, UpdateUserDetailDto>();
        }
    }
}
