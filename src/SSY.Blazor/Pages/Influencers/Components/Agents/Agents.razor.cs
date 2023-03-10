using SSY.Influencer.Agents;
using SSY.Influencer.Agents.Dto;
using Volo.Abp.ObjectMapping;
using Guid = System.Guid;

namespace SSY.Blazor.Pages.Influencers.Components.Agents;

public partial class Agents
{
    public string Module = "Agents";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    [Parameter] public Guid Id { get; set; }
    [Inject] public IAgentAppService AgentAppService { get; set; }
    [Inject] public IObjectMapper ObjectMapper { get; set; }
    public List<AgentDto> AgentLists { get; set; } = new();
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            AgentLists = await AgentAppService.GetAgentsByUserId(Id);
            StateHasChanged();
        }
    }


    private void AddMore()
    {
        AgentLists.Add(new() { Id = Guid.NewGuid(), IsNew = true });
        StateHasChanged();
    }

    private async Task OnSave(AgentDto agentDto)
    {
        agentDto.UserId = Id;
        if (agentDto.IsNew)
        {
            agentDto.IsNew = false;
            var item = ObjectMapper.Map<AgentDto, CreateAgentDto>(agentDto);
            var res = await AgentAppService.CreateAsync(item);
        }
        else
        {
            var item = ObjectMapper.Map<AgentDto, UpdateAgentDto>(agentDto);
            var res = await AgentAppService.UpdateAsync(agentDto.Id, item);
        }

        StateHasChanged();
    }

    private async Task OnRemove(AgentDto agentDto)
    {
        if (!agentDto.IsNew)
        {
            await AgentAppService.DeleteAsync(agentDto.Id);
        }
        AgentLists.Remove(agentDto);
        StateHasChanged();
    }
}

