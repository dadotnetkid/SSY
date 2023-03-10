namespace SSY.Blazor.Pages.Shared.Pages.Inventory.SubMaterial
{
    public partial class SubMaterialAdd
    {
        public SubMaterialAdd()
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

       // private UserService _userService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private CompanyService _companyService { get; set; }

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

        #endregion

        #region Models

        private SubMaterialModel SubMaterialModel { get; set; } = new();

        public TypeListModel TypeListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorListModel { get; set; } = new() { Result = new() { Items = new() } };
        public WeightListModel WeightListModel { get; set; } = new() { Result = new() { Items = new() } };

        public UnitOfMeasurementListModel UnitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CurrencyListModel CurrencyListModel { get; set; } = new() { Result = new() { Items = new() } };

        public List<CompanyModel> SuppliersModel { get; set; } = new();

        #endregion

        protected override async Task OnInitializedAsync()
        {
           // _userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);
            _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _companyService = new(js, ClientFactory, NavigationManager, Configuration);
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
          //      await _userService.CheckAdminCredential();
                SuppliersModel = await GetAllSupplier();
                ColorListModel = await _getDropdownService.GetDropdown<ColorListModel>("Color");
                TypeListModel = await _getDropdownService.GetDropdown<TypeListModel>("MaterialType");
                WeightListModel = await _getDropdownService.GetDropdown<WeightListModel>("WeightUnit");
                UnitOfMeasurementListModel = await _getDropdownService.GetDropdown<UnitOfMeasurementListModel>("UnitOfMeasurement");
                CurrencyListModel = await _getDropdownService.GetDropdown<CurrencyListModel>("Currency");

                StateHasChanged();

            }
        }

        public async Task<List<CompanyModel>> GetAllSupplier()
        {
            List<CompanyModel> result = new();

            var supplier = await _companyService.GetAllCompany(null, null, null, 1000);
            result = supplier.Result.Items;

            return result;
        }

        public async Task HandleSubmit(SubMaterialModel subMaterial)
        {

            try
            {
                if (DescriptionComponent.CanSubmit() && InventoryComponent.CanSubmit() &&
                    LocationComponent.CanSubmit())
                {
                    System.Console.WriteLine("submit");
                }
                //Console.WriteLine(JsonSerializer.Serialize(DescriptionComponent.CanSubmit()));
                //Console.WriteLine(JsonSerializer.Serialize(InventoryComponent.CanSubmit()));
                //Console.WriteLine(JsonSerializer.Serialize(LocationComponent.CanSubmit()));

                await _subMaterialService.CreateSubMaterial(subMaterial, CategoryId, Module);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }
        }


        public async Task SupplierChanged(CompanyModel supplier)
            {
                SubMaterialModel.Company = supplier;
                StateHasChanged();
            }


        }
    }
