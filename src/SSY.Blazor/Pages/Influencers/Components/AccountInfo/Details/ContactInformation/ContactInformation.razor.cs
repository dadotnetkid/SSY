namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Details.ContactInformation
{
    public partial class ContactInformation
    {
        [CascadingParameter(Name = "MainPage")] public AccountInfo ActualInfos { get; set; }
    }
}
