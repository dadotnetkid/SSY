namespace SSY.Blazor.Pages.Shared.Pages.Inventory.SubMaterial
{
    public partial class SubMaterialEdit
    {
        public SubMaterialEdit()
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

      //  private UserService _userService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }
        private CompanyService _companyService { get; set; }

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
        #endregion

        #region Models

        public SubMaterialModel SubMaterialModel { get; set; }
        public TypeListModel TypeListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorListModel { get; set; } = new() { Result = new() { Items = new() } };
        public WeightListModel WeightListModel { get; set; } = new() { Result = new() { Items = new() } };
        public UnitOfMeasurementListModel UnitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CurrencyListModel CurrencyListModel { get; set; } = new() { Result = new() { Items = new() } };
        public List<CompanyModel> SuppliersModel { get; set; } = new();

        #endregion


        protected override async Task OnInitializedAsync()
        {
        //    _userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);

            _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _companyService = new(js, ClientFactory, NavigationManager, Configuration);
            SubMaterialModel = new();
            SuppliersModel = await GetAllSupplier();
            ColorListModel = await _getDropdownService.GetDropdown<ColorListModel>("Color");
            TypeListModel = await _getDropdownService.GetDropdown<TypeListModel>("MaterialType");
            WeightListModel = await _getDropdownService.GetDropdown<WeightListModel>("WeightUnit");
            UnitOfMeasurementListModel = await _getDropdownService.GetDropdown<UnitOfMeasurementListModel>("UnitOfMeasurement");
            CurrencyListModel = await _getDropdownService.GetDropdown<CurrencyListModel>("Currency");

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
             //   await _userService.CheckAdminCredential();
                await GetSubMaterial();
                StateHasChanged();
            }
            

        }
        public async Task SupplierChanged(CompanyModel supplier)
        {
            SubMaterialModel.Company = supplier;
        }

        public async Task<List<CompanyModel>> GetAllSupplier()
        {
            List<CompanyModel> result = new();

            var supplier = await _companyService.GetAllCompany(null, null, null, 1000);
            result = supplier.Result.Items;

            return result;
        }

        public async Task GetSubMaterial()
        {
            var subMaterial = await _subMaterialService.GetSubMaterial(Id);
            SubMaterialModel = subMaterial.Result;
        }
        public async Task UpdateActualCount(double count)
        {
            SubMaterialModel.TotalCount = count;
        }

        public async Task HandleSubmit(SubMaterialModel subMaterial)
        {
            //await _subMaterialService.UpdateSubMaterial(subMaterial, subMaterial.CategoryId, Module);
            try
            {
                if (DescriptionComponent.CanSubmit() && InventoryComponent.CanSubmit() &&
                    LocationComponent.CanSubmit())
                {
                    System.Console.WriteLine("submit");
                    Console.WriteLine(JsonSerializer.Serialize(subMaterial));
                    await _subMaterialService.UpdateSubMaterial(subMaterial, subMaterial.CategoryId, Module);
                }
                //Console.WriteLine(JsonSerializer.Serialize(DescriptionComponent.CanSubmit()));
                //Console.WriteLine(JsonSerializer.Serialize(InventoryComponent.CanSubmit()));
                //Console.WriteLine(JsonSerializer.Serialize(LocationComponent.CanSubmit()));
                ////Console.WriteLine(JsonSerializer.Serialize(MiscellaneousComponent.CanSubmit()));

                //// if (myTestComponent.CanSubmit())
                //// {

                //// }

                //Console.WriteLine(JsonSerializer.Serialize(SubMaterialModel));

                // MaterialModel.MinimumStockLevel = MaterialModel.CompositionAndConstruction.MinimumStockLevel;
                //var materialId = await _materialService.CreateMaterial(MaterialModel);

               
                
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }
        }

        public async Task DeleteSubMaterialReservation(SubMaterialReservationModel subMaterialReservation)
        {

            SubMaterialModel.ReservedCount = SubMaterialModel.ReservedCount - subMaterialReservation.ReservationCount;
            SubMaterialModel.AvailableCount = SubMaterialModel.AvailableCount + subMaterialReservation.ReservationCount;

        }
    }
}

