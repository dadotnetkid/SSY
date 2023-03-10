using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.UserDetails;

namespace SSY.Influencers.Agencies
{
    public class Agent : FullAuditedEntity<Guid>
    {
        public Agent(Guid? userId, string agencyName, string agentName)
        {
            UserId = userId;
            AgencyName = agencyName;
            AgentName = agentName;
        }
        public virtual Guid? UserId { get; protected set; }
        public virtual string AgencyName { get; protected set; }
        public virtual string AgentName { get; protected set; }
        public virtual Guid? CategoryId { get; protected set; }
        public UserDetail UserDetail { get; set; }
    }
}
