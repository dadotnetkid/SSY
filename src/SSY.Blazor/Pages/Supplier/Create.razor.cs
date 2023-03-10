using SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model;

namespace SSY.Blazor.Pages.Supplier
{
    public partial class Create
    {
        public string Module = "Supplier";
        public string ModuleMessage = "";
        public string ModuleType = "Add";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        private CompanyService _companyService { get; set; }

        private bool IsEditable { get; set; }

        public CompanyModel SupplierModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _companyService = new(js, ClientFactory, NavigationManager, Configuration);
            SupplierModel = new() { ContactPersons = new() };
            IsEditable = true;
        }

        public async Task ContactPersonAdded(ContactPersonsModel contactPerson)
        {
            SupplierModel.ContactPersons.Add(contactPerson);
        }

        public async Task HandleSubmit()
        {
            await _companyService.CreateCompanyAsync(SupplierModel);
        }
    }
}


