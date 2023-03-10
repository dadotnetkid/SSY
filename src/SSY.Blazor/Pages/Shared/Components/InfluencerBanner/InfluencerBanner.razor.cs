namespace SSY.Blazor.Pages.Shared.Components.InfluencerBanner
{

    public partial class InfluencerBanner
    {

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }

        [Parameter]
        public BaseBannerModel BaseBannerModel { get; set; } = new() { Icons = new() };

        [Parameter]
        public string Module { get; set; } = "";

        [Parameter]
        public string NavModule { get; set; } = "";
        protected override async Task OnInitializedAsync()
        {
            System.Console.WriteLine(JsonSerializer.Serialize(BaseBannerModel));
        }


    }
}