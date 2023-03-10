namespace SSY.Blazor.Pages.Shared.Pages.Inventory.Material
{
    public partial class MaterialAdd
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
        private MaterialService _materialService { get; set; }
        //private UserService _userService { get; set; }
        private RollAndLocationService _rollAndLocationService { get; set; }
        private AdjustmentService _adjustmentService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

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
        public string MaterialCategory { get; set; }

        #endregion

        #region Models

        private MaterialModel MaterialModel { get; set; } = new();
        public GetAllRollAndLocationOutputModel RollAndLocationListModel { get; set; } = new() { Result = new() { Items = new() } };
        public MaterialActionListModel MaterialActionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CompositionAndConstructionModel CompositionAndConstructionModel { get; set; } = new();
        public CareInstructionTypeListModel CareInstructionTypeListModel { get; set; } = new() { Result = new() { Items = new() } };

        #endregion


        protected override async void OnInitialized()
        {
            MaterialModel.CategoryId = CategoryId;
            //_userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _rollAndLocationService = new(js, ClientFactory, NavigationManager, Configuration);
            _adjustmentService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            MaterialActionListModel = await _getDropdownService.GetDropdown<MaterialActionListModel>("MaterialAction");
            MaterialModel.MinimumStockLevel = CompositionAndConstructionModel.MinimumStockLevel;

            CareInstructionTypeListModel = await _getDropdownService.GetAllCareInstructionType(null, null, null, null);

            var careInstruction = CareInstructionTypeListModel?.Result.Items
                                            .Where(x => x.Id == MaterialModel.CareInstructionTypeId).FirstOrDefault()?.Value;
            MaterialModel.CareInstruction = careInstruction;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await _userService.CheckAdminCredential();

                StateHasChanged();
            }
        }

        public async Task HandleSubmit()
        {
            try
            {
                var decscriptionIsValid = DescriptionComponent.CanSubmit();
                var compositionAndConstructionIsValid = CompositionAndConstructionComponent.CanSubmit();
                var inventoryIsValid = InventoryComponent.CanSubmit();
                var miscellaneousIsValid = MiscellaneousComponent.CanSubmit();
                var purchasingDetailIsValid = PurchasingDetailComponent.CanSubmit();
                var supplierIsValid = SupplierComponent.CanSubmit();
                var rollAndLocationIsValid = MaterialModel.RollsAndLocations.Count > 0;

                if (decscriptionIsValid && compositionAndConstructionIsValid && inventoryIsValid
                    && miscellaneousIsValid && purchasingDetailIsValid && supplierIsValid)
                {
                    if (!rollAndLocationIsValid)
                    {
                        await js.InvokeVoidAsync("defaultMessage", "error", "Roll and Location is Required");
                        return;
                    }
                    else
                    {
                        //call api from product using request id

                        //pass value to material model
                        //if (collection != null)
                        //{
                        //  collection.Influencers?.ForEach(x => MaterialModel.InfluencerNames.Add(x.Influencer.FullName));
                        //   MaterialModel.CollectionName = Collection.Name
                        //}
                        //
                        MaterialModel.MinimumStockLevel = MaterialModel.CompositionAndConstruction.MinimumStockLevel;
                        var materialId = await _materialService.CreateMaterial(MaterialModel);
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

        public async Task SupplierChanged(CompanyModel supplier)
        {
            MaterialModel.Company = supplier;
            StateHasChanged();
        }

        public async Task MaterialTypeChanged(string materialType)
        {
            //MaterialModel = material;
            if (materialType.ToLower() == "knitwear")
            {
                // dito ung knitwear
                var careInstructionType = CareInstructionTypeListModel.Result.Items.Find(x => x.Label == "Knitted Cotton Wool/Cashmere/Merino Wool");
                MaterialModel.CareInstructionTypeId = careInstructionType.Id;
                MaterialModel.CareInstructionTypeValue = careInstructionType.Value;
            }
            else
            {
                // activewear
                var careInstructionType = CareInstructionTypeListModel.Result.Items.Find(x => x.Label == "Activewear/Sweats");
                MaterialModel.CareInstructionTypeId = careInstructionType.Id;
                MaterialModel.CareInstructionTypeValue = careInstructionType.Value;
            }
            StateHasChanged();
        }
    }
}