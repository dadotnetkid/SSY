using SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model;
using SSY.Blazor.HttpClients.Data.Inventory.ContactPersons;

namespace SSY.Blazor.Pages.Supplier
{
    public partial class Edit
    {
        public Edit()
        {
        }

        public string Module = "Supplier";
        public string ModuleMessage = "";
        public string ModuleType = "Edit";
        public string Crud = "Edit";
        public string MaterialTypeText = "";

        [Inject]
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
        public bool IsEditable { get; set; } = true;

        [Parameter]
        public CompanyModel SupplierModel { get; set; } = new();

        public GetAllCompanyOutputModel SupplierData { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            _companyService = new(js, ClientFactory, NavigationManager, Configuration);
            _contactPersonService = new(js, ClientFactory, NavigationManager, Configuration);

            SupplierModel = new();
            SupplierModel = new() { ContactPersons = new() };
            SupplierData = new() { Result = new() { Items = new() } };
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetSupplier(Id);
            }

            StateHasChanged();
        }

        public async Task ContactPersonAdded(ContactPersonsModel contactPerson)
        {
            SupplierModel.ContactPersons.Add(contactPerson);

            StateHasChanged();
        }
        public async Task GetSupplier(int id)
        {
            var supplier = await _companyService.GetCompany(id);
            SupplierModel = supplier.Result;
        }
        public async Task HandleSubmit()
        {
            SupplierModel.CompanyTypeKeys.ForEach(x => { if (!SupplierModel.CompanyTypeIds.Contains(x.TypeId)) { SupplierModel.CompanyTypeIds.Add(x.TypeId); } });

            //Console.WriteLine(JsonSerializer.Serialize(SupplierModel));
            await _companyService.UpdateCompany(SupplierModel);
        }

        public async Task UpdateMaterialTypeText(string text)
        {
            MaterialTypeText = text;
        }
    }
}