using SSY.Blazor.Pages.Influencers.Shared.NavInfluencerDetail;
using SSY.UserDetails;

namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo;

public partial class AccountInfo
{
    [Parameter] public Guid Id { get; set; }
    public string Module = "Personal Information";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    private NavInfluencerDetail influencerNav;
    [Inject] public IUserDetailAppService UserDetailAppService { get; set; }
    public UserDetailDto UserDetail { get; set; } = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            UserDetail = await UserDetailAppService.GetAsync(id: Id);
            StateHasChanged();
        }
    }

    protected override void OnParametersSet()
    {
        influencerNav?.SetId(Id);
        base.OnParametersSet();
    }
}