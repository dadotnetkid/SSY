using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSY.UserDetails.Dtos;
using Volo.Abp.Validation;

namespace SSY.UserDetails
{
    public class UserDetailAppService :
        CrudAppService<UserDetail, UserDetailDto, Guid, PagedAndSortedResultRequestDto, CreateUserDetailDto, UpdateUserDetailDto>, IUserDetailAppService
    {
        public UserDetailAppService(IRepository<UserDetail, Guid> repository) : base(repository)
        {
        }

        protected override async Task<IQueryable<UserDetail>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var res = await base.CreateFilteredQueryAsync(input);
            return res.Include(c => c.AppUser);
        }

        public override async Task<UserDetailDto> GetAsync(Guid id)
        {
            var res = await Repository.GetQueryableAsync();
            var item = res
                .Include(c => c.AppUser)
                .Include(c=>c.Addresses)
                .FirstOrDefault(c => c.Id == id);
            return await MapToGetListOutputDtoAsync(item);
        }

        public override Task<PagedResultDto<UserDetailDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            return base.GetListAsync(input);
        }
        [DisableValidation]
        public override Task<UserDetailDto> CreateAsync(CreateUserDetailDto input)
        {
            return base.CreateAsync(input);
        }
    }
}
