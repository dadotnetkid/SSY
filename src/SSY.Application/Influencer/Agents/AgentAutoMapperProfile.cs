using AutoMapper;
using SSY.Influencer.Agents.Dto;
using SSY.Influencers.Agencies;

namespace SSY.Influencer.Agents;

public class AgentAutoMapperProfile : Profile
{
    public AgentAutoMapperProfile()
    {
        CreateMap<Agent, AgentDto>().ReverseMap();
        CreateMap<Agent, CreateAgentDto>().ReverseMap();
        CreateMap<Agent, UpdateAgentDto>().ReverseMap();
        CreateMap<AgentDto, CreateAgentDto>().ReverseMap();
        CreateMap<AgentDto, UpdateAgentDto>().ReverseMap();
    }
}