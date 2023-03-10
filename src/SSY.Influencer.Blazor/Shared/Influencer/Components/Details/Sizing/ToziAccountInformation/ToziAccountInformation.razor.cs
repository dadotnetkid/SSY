using System.Threading.Tasks;

namespace SSY.Influencer.Blazor.Shared.Influencer.Components.Details.Sizing.ToziAccountInformation;

public partial class ToziAccountInformation
{
    bool rememberMe;
    Task OnRememberMeChanged(bool value)
    {
        rememberMe = value;

        return Task.CompletedTask;
    }

}

