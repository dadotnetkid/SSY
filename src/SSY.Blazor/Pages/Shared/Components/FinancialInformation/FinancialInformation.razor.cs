namespace SSY.Blazor.Pages.Shared.Components.FinancialInformation
{
    public partial class FinancialInformation
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        // public InventoryModel InventoryModel = new();

        [CascadingParameter(Name = "ModuleType")]
        private string ModuleType { get; set; }

        [CascadingParameter(Name = "SupplierModel")]

        private CompanyModel SupplierModel { get; set; }

        //       SupplierModel SM = new SupplierModel()
        //  {
        //     CompanyName = "Sew Sew you",
        //     Website = "sewsewyou.ltd",
        //     Address1 = "Clark Pampanga",
        //     Country ="Philippines",
        //     Province ="Pamgpanga",
        //     City = "Pampanga",
        //     ZipCode = "32134",
        //     BankName ="BPI",
        //     AccountNumber ="42165436",
        //     AccountName="Jed Sena",
        //     Swift="B34d",
        //     Address="Pampnga Clark",
        //  };

        // [Inject]
        // public ProtectedLocalStorage LocalStorage { get; set; }
        // [Inject]
        // public IHttpClientFactory ClientFactory { get; set; }
        // [Inject]
        // public NavigationManager NavigationManager { get; set; }
        // [Inject]
        // public IConfiguration Configuration { get; set; }
        // private RegisterModel RegisterModel = new();
        protected override async Task OnInitializedAsync()
        {
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
            }
        }


    }
}
