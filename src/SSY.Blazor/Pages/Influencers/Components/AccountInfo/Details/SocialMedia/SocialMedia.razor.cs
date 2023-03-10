namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Details.SocialMedia
{
    public partial class SocialMedia
    {
        [CascadingParameter(Name = "MainPage")] public AccountInfo ActualInfos { get; set; }
    }
}
