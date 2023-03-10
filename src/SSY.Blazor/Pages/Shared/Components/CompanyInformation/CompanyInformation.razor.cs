namespace SSY.Blazor.Pages.Shared.Components.CompanyInformation
{
    public partial class CompanyInformation
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public CountryModel CountryModel { get; set; }
        public TypeService _typeService { get; set; }
        private CompanyService _companyService { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string ModuleType { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public CompanyModel SupplierModel { get; set; } = new();

        [Parameter]
        public List<int> CompanyTypeIds { get; set; } = new();

        private CompanyTypeKeysModel CompanyTypeKeysModel { get; set; } = new();
        public string CompanyType = "No Selected Company Type";

        public List<int> CompanyTypeIdList = new();
        public List<string> SelectedCompanyTypes = new();


        public CompanyModel CompanyModel { get; set; } = new();

        public List<CompanyTypes> CompanyTypeListModel { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            CountryModel = new();

            CompanyType = string.Empty;
            SelectedCompanyTypes.Clear();
            SupplierModel.CompanyTypeIds.Clear();

            _typeService = new(js, ClientFactory, NavigationManager, Configuration);
            _companyService = new(js, ClientFactory, NavigationManager, Configuration);

            CompanyTypeListModel.Add(new() { Id = 1, Value = "Supplier" });
            CompanyTypeListModel.Add(new() { Id = 2, Value = "OEM" });

            CompanyModel = (await _companyService.GetCompany(Id)).Result;

            if (CompanyModel != null)
            {
                List<CompanyTypeKeysModel> companyTypeKeys = new();

                foreach (var item in CompanyModel.CompanyTypeKeys)
                {
                    if (item.TypeId != null)
                    {
                        if (!CompanyTypeIdList.Contains(item.TypeId))
                        {
                            CompanyTypeIdList.Add(item.TypeId);
                        }

                        if (item.TypeId == 1)
                        {
                            if (!SelectedCompanyTypes.Contains("Supplier"))
                            {
                                SelectedCompanyTypes.Add("Supplier");
                            }
                        }

                        if (item.TypeId == 2)
                        {
                            if (!SelectedCompanyTypes.Contains("OEM"))
                            {
                                SelectedCompanyTypes.Add("OEM");
                            }
                        }
                    }
                }
            }

            CompanyType = JsonSerializer.Serialize(SelectedCompanyTypes).Replace("[", "").Replace("]", "").Replace("\"", "");

            if (CompanyType.Equals(string.Empty))
            {
                CompanyType = "No Selected Company Type";
            }

            CompanyTypeListModel.ForEach(x => {
                if (!SupplierModel.CompanyTypeIds.Contains(x.Id))
                {
                    SupplierModel.CompanyTypeIds.Add(x.Id);
                }
            });

            SupplierModel.CompanyTypeIds = CompanyTypeIdList;

            CompanyTypeIds = CompanyTypeIdList;
        }

        public async Task onChangeCompanyType(int value, string name, bool checkedValue)
        {
            SupplierModel.CompanyTypeKeys.Clear();

            CompanyTypeKeysModel companyType = new() { TenantId = 1, IsActive = true, CompanyId = SupplierModel.Id, TypeId = value };

            if (checkedValue)
            {
                if (!CompanyTypeIdList.Contains(value))
                {
                    CompanyTypeIdList.Add(value);
                }

                if (!SelectedCompanyTypes.Contains(name))
                {
                    SelectedCompanyTypes.Add(name);
                }

                if (!SupplierModel.CompanyTypeKeys.Contains(companyType))
                {
                    SupplierModel.CompanyTypeKeys.Add(companyType);
                }
            }
            else
            {
                if (CompanyTypeIdList.Contains(value))
                {
                    CompanyTypeIdList.Remove(value);
                }

                if (SelectedCompanyTypes.Contains(name))
                {
                    SelectedCompanyTypes.Remove(name);
                }

                if (SupplierModel.CompanyTypeKeys.Contains(companyType))
                {
                    SupplierModel.CompanyTypeKeys.Remove(companyType);
                }
            }
            //wait GenerateCompanyType();

            SupplierModel.CompanyTypeIds = CompanyTypeIdList;

            CompanyType = JsonSerializer.Serialize(SelectedCompanyTypes).Replace("[", "").Replace("]", "").Replace("\"", "");

            if (CompanyType.Equals(string.Empty))
            {
                CompanyType = "No Selected Company Type";
            }
        }

        public class CompanyTypes
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

    }
}
