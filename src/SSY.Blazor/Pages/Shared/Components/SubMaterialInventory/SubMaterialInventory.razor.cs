namespace SSY.Blazor.Pages.Shared.Components.SubMaterialInventory
{
    public partial class SubMaterialInventory
    {
        public SubMaterialInventory()
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

        [Parameter]
        public SubMaterialModel InventoryModel { get; set; } = new();

        #endregion

        #region Models

        public UnitOfMeasurementListModel UnitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

        #endregion

        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            UnitOfMeasurementListModel = await _getDropdownService.GetAllUnitOfMeasurement(null, null, null, 100);
        }
    }
}


