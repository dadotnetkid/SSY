namespace SSY.Blazor.Pages.CollectionAndProduct.Components.Files
{
    public partial class Files
    {
        public Files()
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

        public string Module = "Files";

          protected override async Task OnInitializedAsync()
        {
       
        }
    }
    
}