namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Details.PersonalInformation
{
    public partial class PersonalInformation
    {
        [CascadingParameter(Name = "MainPage")] public AccountInfo ActualInfos { get; set; }
    }
}
