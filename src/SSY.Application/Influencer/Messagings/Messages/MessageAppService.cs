using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencer.Messagings.Messages.Dto;
using SSY.Influencers.Messagings.Folders;
using SSY.Influencers.Messagings.Messages;

namespace SSY.Influencer.Messagings.Messages
{
    public class MessageAppService : CrudAppService<Message, MessageDto, Guid, PagedAndSortedResultRequestDto, CreateMessageDto, UpdateMessageDto>, IMessageAppService
    {
        public MessageAppService(IRepository<Message, Guid> repository) : base(repository)
        {
        }

        public async Task<IList<MessageDto>> GetMessagesByFolderId(Guid folderId)
        {
            var query = await Repository.GetQueryableAsync();
            var list = query.Where(c => c.FolderId == folderId).ToList();
            return ObjectMapper.Map<List<Message>, List<MessageDto>>(list);
        }
    }
}
