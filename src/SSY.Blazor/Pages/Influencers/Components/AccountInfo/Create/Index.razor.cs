using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using SSY.UserDetails;
using Volo.Abp.Identity;

namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Create;
public partial class Index
{
    #region PARAMS
    [Parameter] public Guid Id { get; set; }
    #endregion
    #region DI
    [Inject] public IUserDetailAppService UserDetailAppService { get; set; }
    [Inject] public IIdentityUserAppService IdentityUserAppService { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] ILogger<Index> logger { get; set; }
    #endregion

    #region PublicProp
    public CreateUserDetailDto UserDetail { get; set; } = new();
    #endregion    
    public string Module = "Personal Information";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    private FluentValidationValidator fluentValidator;
    private bool isSaving;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private async Task OnSubmit(EditContext obj)
    {
        if (!(await fluentValidator.ValidateAsync())) return;

        try
        {
            isSaving = true;
            StateHasChanged();
            var userResult = await IdentityUserAppService.CreateAsync(new()
            {
                Password = UserDetail.Password,
                Email = UserDetail.Email,
                Name = UserDetail.FirstName,
                Surname = UserDetail.Surname,
                RoleNames = new string[] { "Influencer" },
                UserName = UserDetail.Email,
                IsActive = true,
            });
            if (userResult is null) return;
            UserDetail.UserId = userResult.Id;
            var userDetail = await UserDetailAppService.CreateAsync(UserDetail);
            if (userDetail is null) return;

            navigationManager.NavigateTo("/influencers", true);
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e.Message);
        }
        isSaving = false;
        StateHasChanged();
    }
}

