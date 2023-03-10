using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencer.Agents.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Agents
{
    public interface IAgentAppService : ICrudAppService<AgentDto, Guid, PagedAndSortedResultRequestDto, CreateAgentDto, UpdateAgentDto>
    {
        Task<List<AgentDto>> GetAgentsByUserId(Guid userId);
    }
}
