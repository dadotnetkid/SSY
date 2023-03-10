using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSY.Influencer.Messagings.Messages.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Messagings.Messages;

public interface IMessageAppService : ICrudAppService<MessageDto, Guid, PagedAndSortedResultRequestDto, CreateMessageDto, UpdateMessageDto>
{
    Task<IList<MessageDto>> GetMessagesByFolderId(Guid folderId);
}