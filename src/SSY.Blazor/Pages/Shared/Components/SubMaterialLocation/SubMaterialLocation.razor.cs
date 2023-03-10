namespace SSY.Blazor.Pages.Shared.Components.SubMaterialLocation
{
    public partial class SubMaterialLocation
    {
        public SubMaterialLocation()
        {
        }

        #region Injects

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public GetDropdownService _getDropdownService { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int CategoryId { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public string ModuleMessage { get; set; }
        [Parameter]
        public SubMaterialModel SubMaterialModel { get; set; }

        #endregion

        #region Models

        #endregion

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

        }
        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }
    }
}
