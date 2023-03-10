using System;
using SSY.UserDetails.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.UserDetails;

public interface IUserDetailAppService : ICrudAppService<UserDetailDto, Guid, PagedAndSortedResultRequestDto, CreateUserDetailDto, UpdateUserDetailDto>
{

}