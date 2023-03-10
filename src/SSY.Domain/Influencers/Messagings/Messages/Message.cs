using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencers.Messagings.Folders;

namespace SSY.Influencers.Messagings.Messages
{
    public class Message : FullAuditedEntity<Guid>
    {
        public Message(Guid folderId, string messageBody)
        {
            FolderId = folderId;
            MessageBody = messageBody;
        }

        public virtual Guid FolderId { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual string MessageBody { get; protected set; }
        public virtual Folder Folder { get; set; }
    }
}
