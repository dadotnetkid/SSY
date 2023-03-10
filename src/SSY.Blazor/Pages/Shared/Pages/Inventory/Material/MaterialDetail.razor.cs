namespace SSY.Blazor.Pages.Shared.Pages.Inventory.Material
{
    public partial class MaterialDetail
    {
        public MaterialDetail()
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
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }
        private MaterialService _materialService { get; set; }
        //private UserService _userService { get; set; }
        private ReservationService _reservationService { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public string ModuleMessage { get; set; }
        public string Crud = "Detail";
        public string ModuleType = "View";
        public string showCommentAndTimeline = "material-border";


        [CascadingParameter(Name = "module")]
        [Parameter]
        public int CategoryId { get; set; }

        [Parameter]
        public string MaterialCategory { get; set; }

        #endregion

        public BulkPurchaseOrderRequestService _bulkPurhcaseOrderRequestService { get; set; }

        #region Models

        public Guid MaterialId { get; set; }
        public double TotalCount { get; set; }
        public double OnHandCount { get; set; }

        private MaterialModel MaterialModel { get; set; } = new();

        [Parameter]
        public CompositionAndConstructionModel CompositionAndConstructionModel { get; set; } = new();

        #endregion

        bool _needReload = true;

        protected override async Task OnInitializedAsync()
        {
            //_userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _reservationService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            _bulkPurhcaseOrderRequestService = new(js, ClientFactory, NavigationManager, Configuration);
            _needReload = true;
            await GetMaterial(Id);
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await _userService.CheckAdminCredential();
                StateHasChanged();
            }
        }
        protected override bool ShouldRender()
        {
            if (_needReload)
            {
                return true;
            }
            else
            {
                _needReload = true;
                return false;
            }
        }
        public async Task GetMaterial(Guid id)
        {
            var material = await _materialService.GetMaterial(id);
            MaterialModel = material.Result;
            MaterialId = MaterialModel.Id;
            TotalCount = MaterialModel.TotalCount;
            CategoryId = MaterialModel.CategoryId;
            MaterialModel.CompositionAndConstruction.MinimumStockLevel = MaterialModel.MinimumStockLevel;
        }


        //create new function for delete reservation
        public async Task DeleteReservation(RollReservationModel rollReservation)
        {
            MaterialModel.ReservedCount = MaterialModel.ReservedCount - rollReservation.ReservationCount;
            MaterialModel.AvailableCount = MaterialModel.AvailableCount + rollReservation.ReservationCount;

            var roll = MaterialModel.RollsAndLocations.FirstOrDefault(x => x.Id == rollReservation.RollId);
            roll.ReserveCount -= rollReservation.ReservationCount;
            roll.AvailableCount += rollReservation.ReservationCount;
        }

        public async Task commentTimelineShow(string margin)
        {
            if (margin == "margin")
            {
                showCommentAndTimeline = "material-border";
            }
            else
            {
                showCommentAndTimeline = "";
            }
        }
    }
}