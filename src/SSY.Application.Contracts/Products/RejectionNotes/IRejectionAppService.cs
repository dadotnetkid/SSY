using System;
using Volo.Abp.Application.Services;
using SSY.Products.RejectionNotes.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.RejectionNotes;

public interface IRejectionAppService : ICrudAppService<RejectionNoteDto, Guid, PagedAndSortedResultRequestDto, CreateRejectionNoteDto>
{
}