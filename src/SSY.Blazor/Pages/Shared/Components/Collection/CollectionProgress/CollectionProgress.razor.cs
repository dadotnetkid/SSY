using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;

namespace SSY.Blazor.Pages.Shared.Components.Collection.CollectionProgress
{
    public partial class CollectionProgress
    {
        public CollectionProgress()
        {
        }

        public string Module = "";
        public string ModuleMessage = "";
        public string ModuleType = "";
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Parameter]
        public CollectionModel CollectionModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            StateHasChanged();
        }



    }
}
