namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Create
{
    public partial class PersonalInformation
    {
        [CascadingParameter(Name = "MainPage")] public Index ActualInfos { get; set; }
    }
}
