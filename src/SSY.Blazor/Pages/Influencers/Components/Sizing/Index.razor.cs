using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using SSY.Blazor.Pages.Influencers.Shared.NavInfluencerDetail;
using SSY.Influencer.Sizings;
using SSY.Influencer.Sizings.Dto;
using Volo.Abp.ObjectMapping;

namespace SSY.Blazor.Pages.Influencers.Components.Sizing;

public partial class Index
{
    public string Module = "Sizing";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    private NavInfluencerDetail influencerNav;
    [Parameter] public Guid Id { get; set; }
    public SizingsDto SizingModel { get; set; } = new();
    [Inject] IObjectMapper Mapper { get; set; }
    [Inject] public ISizingAppService SizingAppService { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            SizingModel = await SizingAppService.GetByUserId(Id);
            StateHasChanged();
        }
    }

    protected override void OnParametersSet()
    {
        influencerNav?.SetId(Id);
        base.OnParametersSet();
    }

    private async Task OnSubmit(EditContext obj)
    {
        SizingModel.UserId = Id;
        if (SizingModel.Id == Guid.Empty)
        {
            var res = Mapper.Map<SizingsDto, CreateSizingsDto>(SizingModel);
            await SizingAppService.CreateAsync(res);
        }
        else
        {
            await SizingAppService.UpdateAsync(SizingModel.Id, Mapper.Map<SizingsDto, UpdateSizingsDto>(SizingModel));
        }
    }
}

