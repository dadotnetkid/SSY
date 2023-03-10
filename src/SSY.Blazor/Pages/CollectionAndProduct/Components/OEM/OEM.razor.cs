using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.OEM;

namespace SSY.Blazor.Pages.CollectionAndProduct.Components.OEM
{
    public partial class OEM
    {
        public OEM()
        {
        }

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Parameter]
        public Guid Id { get; set; }
  
        [Parameter]
        public bool IsEditable { get; set; }

        public string Module = "OEM";

        public OEMListModel OEMListTable {get; set; } = new();

          protected override async Task OnInitializedAsync()
        {
            OEMListTable = new() {OEMs =new()};
        }
    }
    
}