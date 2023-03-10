using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections
{
	public interface ICollectionAppService : ICrudAppService<CollectionDto, Guid, PagedAndSortedResultRequestDto, CreateCollectionDto, UpdateCollectionDto>
    {
        //Task<IQueryable<Collection>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<CollectionDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<CollectionDto> CreateAsync(CreateCollectionDto input);
        Task<CollectionDto> UpdateAsync(Guid id, UpdateCollectionDto input);
        Task DeleteAsync(Guid id);
        Task UpdateApproveColorOptionAsync(ApproveRejectColorOptionDto input);
        Task UpdateRejectColorOptionAsync(ApproveRejectColorOptionDto input);
        Task UpdatePublishCollection(Guid collectionId);
        Task UpdateResetApprovalAsync(Guid collectionId);
        Task<List<CollectionTimelineDto>> GetCollectionTimeline();
        Task<GetAllCollectionListDto> GetCollectionListAsync();
    }
}

