namespace SSY.Blazor.Pages.Influencers.Components.Sizing
{
    public partial class ToziAccountInformation
    {
        private bool rememberMe;
        [CascadingParameter(Name = "MainPage")]public Index MainPage { get; set; }
        private Task OnRememberMeChanged(bool arg)
        {
            rememberMe = arg;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
