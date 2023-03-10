using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencers.Messagings.Messages;
using SSY.UserDetails;

namespace SSY.Influencers.Messagings.Folders
{
    public class Folder : FullAuditedEntity<Guid>
    {
        public Folder()
        {
            Messages = new HashSet<Message>();
        }
        public virtual string Name { get; protected set; }
        public virtual ICollection<InfluencersInFolder> InfluencersInFolders { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

    public class InfluencersInFolder : FullAuditedEntity<Guid>
    {
        public InfluencersInFolder(Guid userId, Guid folderId)
        {
            UserId = userId;
            FolderId = folderId;
        }

        [Description("Influencer UserId")]
        public Guid UserId { get; set; }
        public Guid FolderId { get; set; }
        public Folder Folder { get; set; }
        [Description("Influencer Table")]
        public UserDetail UserDetail { get; set; }
    }

}
