namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Details.ResidentialAddress
{
    public partial class ResidentialAddress
    {
        [CascadingParameter(Name = "MainPage")] public AccountInfo ActualInfos { get; set; }
    }
}
