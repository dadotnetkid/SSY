namespace SSY.Blazor.Pages.CollectionAndProduct.Components.BomSummaryReservations
{
    public partial class BomSummaryReservation
    {

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        public MaterialService _materialService { get; set; }
        public CollectionService _collectionService { get; set; }
        public GetDropdownService _getDropdownService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public GetAllMaterialOutputModel MaterialModel { get; set; } = new();

        [Parameter]
        public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public CollectionModel CollectionModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnParametersSetAsync()
        {

        }

    }
}