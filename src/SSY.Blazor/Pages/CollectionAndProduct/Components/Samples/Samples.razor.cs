namespace SSY.Blazor.Pages.CollectionAndProduct.Components.Samples
{
    public partial class Samples
    {
        public Samples()
        {
        }
        public string ModuleChange = "";
        public string Module = "Samples";
        public string ModuleMessage = "";
        public string CollectionDetails = "Samples";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
    }
}