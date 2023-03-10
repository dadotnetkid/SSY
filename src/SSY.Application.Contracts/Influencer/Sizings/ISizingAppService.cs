using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencer.Sizings.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Sizings
{
    public interface ISizingAppService : ICrudAppService<SizingsDto, Guid, PagedAndSortedResultRequestDto, CreateSizingsDto, UpdateSizingsDto>
    {
        public Task<SizingsDto> GetByUserId(Guid id);
    }
}
