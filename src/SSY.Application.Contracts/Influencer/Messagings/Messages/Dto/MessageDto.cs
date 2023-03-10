using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Influencer.Messagings.Messages.Dto
{
    public class MessageDto:FullAuditedEntityDto<Guid>
    {
        public virtual Guid FolderId { get;  set; }
        public virtual string Title { get;  set; }
        public virtual string MessageBody { get;  set; }
    }
    public class CreateMessageDto:FullAuditedEntityDto<Guid>
    {
        public virtual Guid FolderId { get;  set; }
        public virtual string Title { get; set; }
        public virtual string MessageBody { get;  set; }
    }
    public class UpdateMessageDto:FullAuditedEntityDto<Guid>
    {
        public virtual Guid FolderId { get; set; }
        public virtual string Title { get; set; }
        public virtual string MessageBody { get;  set; }
    }
}
