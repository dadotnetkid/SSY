using SSY.Blazor.HttpClients.Data.Inventory.ContactPersons;
using Volo.Abp;

namespace SSY.Blazor.Pages.Supplier
{
    public partial class Detail
    {
        public Detail()
        {
        }

        public string Module = "Suppliers";
        public string ModuleMessage = "";
        public string ModuleType = "View";
        public string Crud = "Detail";
        public string MaterialTypeText = "";

        // [Inject]
        // public ProtectedLocalStorage LocalStorage { get; set; }

        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private CompanyService _companyService { get; set; }
        private ContactPersonService _contactPersonService { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public CompanyModel SupplierModel { get; set; } = new();

        public List<CompanyTypeKeysModel> CompanyTypeKeys = new();
        public List<CompanyMaterialTypeKeysModel> CompanyMaterialTypeKeys = new();
        public List<CompanyExcessReminderKeysModel> CompanyExcessReminderKeys = new();

        public GetCompanyOutputModel CompanyModel { get; set; }

        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                _companyService = new(js, ClientFactory, NavigationManager, Configuration);

                await GetSupplier(Id);

                IsLoading = false;
            }
            catch(Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
            
        }

        public async Task GetSupplier(int id)
        {
            CompanyModel = await _companyService.GetCompany(id);
            SupplierModel = CompanyModel.Result;
            CompanyTypeKeys = CompanyModel.Result.CompanyTypeKeys;
            CompanyMaterialTypeKeys = CompanyModel.Result.CompanyMaterialTypeKeys;
            CompanyExcessReminderKeys = CompanyModel.Result.CompanyExcessReminderKeys;

            //System.Console.WriteLine(JsonSerializer.Serialize(SupplierModel));

        }

        public async Task UpdateMaterialTypeText(string text)
        {
            MaterialTypeText = text;
        }

    }
}