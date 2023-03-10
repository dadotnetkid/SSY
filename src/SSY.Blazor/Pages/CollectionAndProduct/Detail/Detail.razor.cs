namespace SSY.Blazor.Pages.CollectionAndProduct.Detail
{
    public partial class Detail
    {
        public Detail()
        {
        }

        public string Module = "Detail";
        public string ModuleMessage = "";
        public string ModuleType = "view";
  
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
      


        
    }
    
}