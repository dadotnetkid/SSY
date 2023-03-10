using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSY.Influencer.Messagings.Folders.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Messagings.Folders;

public interface IFolderAppService : ICrudAppService<FolderDto, Guid, PagedAndSortedResultRequestDto, CreateFolderDto, UpdateFolderDto>
{
    Task<List<FolderDto>> GetAllFoldersByUserId(Guid userId);
    Task<List<FolderDto>> GetAllFoldersByUserId(List<Guid> userId);
}