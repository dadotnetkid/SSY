using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.UserDetails;

namespace SSY.Influencers.Banks
{
    public class Bank : FullAuditedEntity<Guid>
    {
        public Bank(Guid? userId, BankType bankType, string emailAddress)
        {
            UserId = userId;
            BankType = bankType;
            EmailAddress = emailAddress;
        }

        public virtual Guid? UserId { get; protected set; }
        public BankType BankType { get; protected set; }
        public virtual string EmailAddress { get; protected set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
