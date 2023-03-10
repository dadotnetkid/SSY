using System;
using SSY.Products.MediaFiles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.MediaFiles;

public interface IMediaFileAppService : ICrudAppService<MediaFileDto, Guid, PagedAndSortedResultRequestDto, CreateMediaFileDto, UpdateMediaFileDto>
{
}