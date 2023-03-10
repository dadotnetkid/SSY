using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Influencer.Agents.Dto
{
    public class AgentDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public string AgencyName { get; set; }
        public string AgentName { get; set; }
        public Guid? CategoryId { get; set; }
        public bool IsNew { get; set; }
    }
    public class CreateAgentDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public string AgencyName { get; set; }
        public string AgentName { get; set; }
        public Guid? CategoryId { get; set; }
    }
    public class UpdateAgentDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public string AgencyName { get; set; }
        public string AgentName { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
