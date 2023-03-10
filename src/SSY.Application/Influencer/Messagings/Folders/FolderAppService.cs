using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSY.Influencer.Messagings.Folders.Dto;
using SSY.Influencers.Messagings.Folders;
using Volo.Abp.ObjectMapping;

namespace SSY.Influencer.Messagings.Folders
{
    public class FolderAppService : CrudAppService<Folder, FolderDto, Guid, PagedAndSortedResultRequestDto, CreateFolderDto, UpdateFolderDto>, IFolderAppService
    {

        public FolderAppService(IRepository<Folder, Guid> repository) : base(repository)
        {
        }

        public async Task<List<FolderDto>> GetAllFoldersByUserId(Guid userId)
        {
            var query = await Repository.GetQueryableAsync();
            var result = query.Where(c => c.InfluencersInFolders.Any(iif => iif.UserId == userId)).ToList();
            return ObjectMapper.Map<List<Folder>, List<FolderDto>>(result);
        }

        public async Task<List<FolderDto>> GetAllFoldersByUserId(List<Guid> userId)
        {
            var query = await Repository.GetQueryableAsync();
            var result = query.Where(c => c.InfluencersInFolders.Any(iif => userId.Contains(iif.UserId))).ToList();
            return ObjectMapper.Map<List<Folder>, List<FolderDto>>(result);
        }

        public override async Task<FolderDto> CreateAsync(CreateFolderDto input)
        {
            var res = await base.CreateAsync(input);
            var query = await Repository.GetQueryableAsync();
            var obj = await query.Include(c => c.InfluencersInFolders).FirstOrDefaultAsync(c => c.Id == res.Id);
            obj.InfluencersInFolders.Clear();
            obj.InfluencersInFolders.Add(new (input.UserId,res.Id));
            await Repository.UpdateAsync(obj);
            return res;
        }
    }
}
