namespace SSY.Blazor.Pages.Influencers.Components.AccountInfo.Details.SamplingAddress
{
    public partial class SamplingAddress
    {
        [CascadingParameter(Name = "MainPage")] public AccountInfo ActualInfos { get; set; }
    }
}
