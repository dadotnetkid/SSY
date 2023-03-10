namespace SSY.Blazor.Pages.Shared.Components.SupplierDetail
{
    public partial class SupplierDetail
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private CompanyService _companyService { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public CompanyModel SupplierModel { get; set; } = new();
        [Parameter]
        public EventCallback<CompanyModel> OnChangeSupplier { get; set; }

        [Parameter]
        public MaterialModel MaterialModel { get; set; } = new();

        public List<CompanyModel> SuppliersModel { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            _companyService = new(js, ClientFactory, NavigationManager, Configuration);

            var supplier = await _companyService.GetAllCompany(null, null, null, 100);
            SuppliersModel = supplier.Result.Items;

            StateHasChanged();
        }

        public async Task SupplierHandler(string id)
        {
            System.Console.WriteLine(id);

            var supplier = SuppliersModel.Find(x => x.Id == int.Parse(id));
            await OnChangeSupplier.InvokeAsync(supplier);
            StateHasChanged();
        }

        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }
    }
}