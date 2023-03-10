namespace SSY.Blazor.Pages.Shared.Pages.Inventory.Material
{
    public partial class MaterialEdit
    {

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
        //private UserService _userService { get; set; }
        private MaterialService _materialService { get; set; }
        private ReservationService _reservationService { get; set; }
        private AdjustmentService _adjustmentService { get; set; }

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
        [Parameter]
        public int CategoryId { get; set; }
        [Parameter]
        public string MaterialCategory { get; set; }
        public string Crud = "Edit";
        [CascadingParameter(Name = "module")]
        #endregion

        #region Models

        private MaterialModel MaterialModel { get; set; } = new();

        private Guid MaterialId { get; set; }
        private double TotalCount { get; set; }

        private string SelectedTab { get; set; }

        #endregion


        protected override async Task OnInitializedAsync()
        {
            //_userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _reservationService = new(js, ClientFactory, NavigationManager, Configuration);
            _adjustmentService = new(js, ClientFactory, NavigationManager, Configuration);

            MaterialModel.CategoryId = CategoryId;
            await GetMaterial(Id);
            // await _reservationService.GetReservation(Id);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await _userService.CheckAdminCredential();
                StateHasChanged();
            }
        }

        public async Task GetMaterial(Guid id)
        {
            var greige = await _materialService.GetMaterial(Id);
            MaterialModel = greige.Result;
            MaterialId = MaterialModel.Id;
            TotalCount = MaterialModel.TotalCount;
            CategoryId = greige.Result.CategoryId;
            MaterialModel.CompositionAndConstruction.MinimumStockLevel = MaterialModel.MinimumStockLevel;
        }

        public async Task SupplierChanged(CompanyModel supplier)
        {
            MaterialModel.Company = supplier;
        }

        public async Task ChangeTab(string tab)
        {
            SelectedTab = tab;
        }

        public async Task HandleSubmit()
        {
            try
            {
                var decscriptionIsValid = DescriptionComponent.CanSubmit();
                var compositionAndConstructionIsValid = CompositionAndConstructionComponent.CanSubmit();
                var inventoryIsValid = InventoryComponent.CanSubmit();
                var miscellaneousIsValid = MiscellaneousComponent.CanSubmit();
                var rollAndLocationIsValid = MaterialModel.RollsAndLocations.Count > 0;

                if (decscriptionIsValid && compositionAndConstructionIsValid && inventoryIsValid && miscellaneousIsValid)
                {
                    Console.WriteLine("test999");
                    if (!rollAndLocationIsValid)
                    {
                        await js.InvokeVoidAsync("defaultMessage", "error", "Roll and Location is Required");
                        return;
                    }
                    else
                    {
                        MaterialModel.MinimumStockLevel = MaterialModel.CompositionAndConstruction.MinimumStockLevel;
                        await _materialService.UpdateMaterial(MaterialModel);
                        Console.WriteLine(JsonSerializer.Serialize("MaterialModel"));
                        Console.WriteLine(JsonSerializer.Serialize(MaterialModel));
                    }
                }
                await InvokeAsync(() =>
                {

                    StateHasChanged();
                });
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task DeleteReservation(RollReservationModel rollReservation)
        {
            MaterialModel.ReservedCount = MaterialModel.ReservedCount - rollReservation.ReservationCount;
            MaterialModel.AvailableCount = MaterialModel.AvailableCount + rollReservation.ReservationCount;

            var roll = MaterialModel.RollsAndLocations.FirstOrDefault(x => x.Id == rollReservation.RollId);
            roll.ReserveCount -= rollReservation.ReservationCount;
            roll.AvailableCount += rollReservation.ReservationCount;
        }

    }
}