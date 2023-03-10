using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSY.Influencer.Sizings.Dto;
using SSY.Influencers.Sizings;
using SSY.UserDetails;

namespace SSY.Influencer.Sizings
{
    public class SizingAppService : CrudAppService<Sizing, SizingsDto, Guid, PagedAndSortedResultRequestDto, CreateSizingsDto, UpdateSizingsDto>, ISizingAppService
    {
        private readonly IRepository<UserDetail, Guid> _userDetailRepository;

        public SizingAppService(IRepository<Sizing, Guid> repository, IRepository<UserDetail, Guid> userDetailRepository) : base(repository)
        {
            _userDetailRepository = userDetailRepository;
        }

        public async Task<SizingsDto> GetByUserId(Guid id)
        {
            var res = await Repository.GetQueryableAsync();
            if (!res.Any(c => c.UserId == id))
            {
                return new();
            }

            return await MapToGetOutputDtoAsync(await res.FirstOrDefaultAsync(c => c.UserId == id));
        }

        public override async Task<SizingsDto> CreateAsync(CreateSizingsDto input)
        {/*
            var res = await _userDetailRepository.GetQueryableAsync();
            var userQuery = await _userDetailRepository.GetQueryableAsync();
            input.UserId =(await userQuery.FirstOrDefaultAsync(c => c.UserId == input.UserId)).Id;*/
            return await base.CreateAsync(input);
        }
    }
}
