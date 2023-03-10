using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.UserDetails;

namespace SSY.Influencers.RevenueShares
{
    public class RevenueShare : FullAuditedEntity<Guid>
    {
        public RevenueShare(Guid? userId, decimal from, decimal to, decimal percentage,RevenueShareType revenueShareType)
        {
            UserId = userId;
            From = from;
            To = to;
            Percentage = percentage;
            RevenueShareType = revenueShareType;
        }
        public Guid? UserId { get; protected set; }
        public virtual RevenueShareType RevenueShareType{ get; protected set; }
        public virtual decimal From { get; protected set; }
        public virtual decimal To { get; protected set; }
        public virtual decimal Percentage { get; protected set; }
        public virtual string Note { get; protected set; }
        public virtual  UserDetail  UserDetail{ get; set; }
    }
}
