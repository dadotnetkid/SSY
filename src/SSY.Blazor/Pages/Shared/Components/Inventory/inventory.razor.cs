namespace SSY.Blazor.Pages.Shared.Components.Inventory
{

    public partial class Inventory
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

        public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public MaterialModel InventoryModel { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            unitOfMeasurementListModel = await _getDropdownService.GetAllUnitOfMeasurement(null, null, null, 100);

        }
        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }
    }
}