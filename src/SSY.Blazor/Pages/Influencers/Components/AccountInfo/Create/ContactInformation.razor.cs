namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Create
{
    public partial class ContactInformation
    {
        [CascadingParameter(Name = "MainPage")] public Index ActualInfos { get; set; }
    }
}
