using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencer.Agents.Dto;
using SSY.Influencers.Agencies;

namespace SSY.Influencer.Agents
{
    public class AgentAppService : CrudAppService<Agent, AgentDto, Guid, PagedAndSortedResultRequestDto, CreateAgentDto, UpdateAgentDto>, IAgentAppService
    {
        public AgentAppService(IRepository<Agent, Guid> repository) : base(repository)
        {
        }

        public async Task<List<AgentDto>> GetAgentsByUserId(Guid userId)
        {
            var res = await Repository.GetQueryableAsync();
            var result = ObjectMapper.Map<List<Agent>, List<AgentDto>>(res.Where(c => c.UserId == userId).ToList());
            return result;
        }
    }
}
