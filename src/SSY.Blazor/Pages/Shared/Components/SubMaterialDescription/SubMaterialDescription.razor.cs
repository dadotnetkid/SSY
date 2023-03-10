namespace SSY.Blazor.Pages.Shared.Components.SubMaterialDescription
{
    public partial class SubMaterialDescription
    {
        public SubMaterialDescription()
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

        public TypeListModel TypeListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorListModel { get; set; } = new() { Result = new() { Items = new() } };
        public WeightListModel WeightListModel { get; set; } = new() { Result = new() { Items = new() } };

        #endregion

        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            TypeListModel = await _getDropdownService.GetAllMaterialType(CategoryId, null, "orderNumber", null, 100);
            ColorListModel = await _getDropdownService.GetDropdown<ColorListModel>("Color");
            WeightListModel = await _getDropdownService.GetDropdown<WeightListModel>("WeightUnit");

        }
    }
}


