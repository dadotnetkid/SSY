namespace SSY.Blazor.Pages.Shared.Components.SupplierSourcing
{
    public partial class SupplierSourcing
    {

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        private GetDropdownService _getDropdownService { get; set; }

        [CascadingParameter(Name = "ModuleType")]
        private string ModuleType { get; set; }
        [Parameter]
        public EventCallback<string> OnChangeMaterialText { get; set; }
        public string MaterialTypeText = "No Selected Material Type";

        [Parameter]
        public List<CompanyMaterialTypeKeysModel> CompanyMaterialTypekeys { get; set; } = new();

        [Parameter]
        public List<int> CompanyMaterialTypeIds { get; set; } = new();

        public int excessReminder { get; set; } = new();

        [Parameter]
        public List<CompanyExcessReminderKeysModel> CompanyExcessReminderKeys { get; set; } = new();

        [Parameter]
        public List<int> CompanyExcessReminderIds { get; set; } = new();

        [Parameter]
        public bool IsExcessSupplier { get; set; }
        private CompanyMaterialTypeKeysModel CompanyMaterialTypekeysModel { get; set; } = new();
        private CompanyExcessReminderKeysModel CompanyExcessReminderKeysModel { get; set; } = new();

        [Parameter]
        public CompanyModel SupplierModel { get; set; } = new();

        public TypeListModel GreigeModel { get; set; } = new() { Result = new() { Items = new() } };
        public TypeListModel FabricModel { get; set; } = new() { Result = new() { Items = new() } };
        public ExcessReminderListModel ExcessReminderListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ExcessSupplierTypeListModel ExcessSupplierTypeListModel { get; set; } = new() { Result = new() { Items = new() } };

        public string ExcessReminderText = "No Selected Excess Reminder";

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            GreigeModel = await _getDropdownService.GetAllMaterialType(1, null, null, null, 100);

            FabricModel = await _getDropdownService.GetAllMaterialType(2, null, null, null, 100);

            CompanyMaterialTypekeysModel = new();
            CompanyExcessReminderKeysModel = new();
            foreach (var item in SupplierModel.CompanyMaterialTypeKeys)
            {
                if(item.MaterialTypeId != null)
                {
                    CompanyMaterialTypeIds.Add(item.MaterialTypeId);
                }
              
            }
            await GenerateMaterialTypeText();

            foreach (var item in SupplierModel.CompanyExcessReminderKeys)
            {
                if(item.ExcessReminder != null)
                {
                    CompanyExcessReminderIds.Add(item.ExcessReminder);
                }
            }
            await GenerateExcessReminderText();

            SupplierModel.MaterialTypeIds = CompanyMaterialTypeIds;
            SupplierModel.CompanyExcessReminderIds = CompanyExcessReminderIds;
        }

        public async Task onChangeAssignment(int value, bool checkedValue)
        {

            if (checkedValue)
            {
                if (!CompanyMaterialTypeIds.Contains(value))
                {
                    CompanyMaterialTypeIds.Add(value);
                }
            }
            else
            {
                if (CompanyMaterialTypeIds.Contains(value))
                {
                    CompanyMaterialTypeIds.Remove(value);
                }
            }

            await GenerateMaterialTypeText();
            SupplierModel.MaterialTypeIds = CompanyMaterialTypeIds;
            //  Console.WriteLine(JsonSerializer.Serialize(SupplierModel.MaterialTypeIds));
        }

        public async Task GenerateMaterialTypeText()
        {
            MaterialTypeText = "";
            foreach (var greige in GreigeModel?.Result?.Items)
            {
                if (CompanyMaterialTypeIds.Contains(greige.Id) == true)
                {
                    MaterialTypeText += greige.Label + ", ";
                }
            }

            foreach (var fabric in FabricModel?.Result?.Items)
            {
                if (CompanyMaterialTypeIds.Contains(fabric.Id) == true)
                {
                    MaterialTypeText += fabric.Label + ", ";
                }
            }

            if (!string.IsNullOrWhiteSpace(MaterialTypeText))
            {
                MaterialTypeText = MaterialTypeText.Remove(MaterialTypeText.Length - 2, 1);
            }
            else
            {
                MaterialTypeText = "No Selected Material Type";
            }
            await OnChangeMaterialText.InvokeAsync(MaterialTypeText);
        }

        public async Task onChangeExcessReminder(int value, bool checkedValue)
        {
            if (checkedValue)
            {
                if (!CompanyExcessReminderIds.Contains(value))
                {
                    CompanyExcessReminderIds.Add(value);
                }
            }
            else
            {
                if (CompanyExcessReminderIds.Contains(value))
                {
                    CompanyExcessReminderIds.Remove(value);
                }
            }
            await GenerateExcessReminderText();
            SupplierModel.CompanyExcessReminderIds = CompanyExcessReminderIds;
        }

        public async Task GenerateExcessReminderText()
        {
            ExcessReminderText = "";

            if (CompanyExcessReminderIds.Contains(1) == true)
            {
                ExcessReminderText += "January" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(2) == true)
            {
                ExcessReminderText += "February" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(3) == true)
            {
                ExcessReminderText += "March" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(4) == true)
            {
                ExcessReminderText += "April" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(5) == true)
            {
                ExcessReminderText += "May" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(6) == true)
            {
                ExcessReminderText += "June" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(7) == true)
            {
                ExcessReminderText += "July" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(8) == true)
            {
                ExcessReminderText += "August" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(9) == true)
            {
                ExcessReminderText += "Semptember" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(10) == true)
            {
                ExcessReminderText += "October" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(11) == true)
            {
                ExcessReminderText += "November" + ", ";
            }
            if (CompanyExcessReminderIds.Contains(12) == true)
            {
                ExcessReminderText += "December" + ", ";
            }

            if (!string.IsNullOrWhiteSpace(ExcessReminderText))
            {
                ExcessReminderText = ExcessReminderText.Remove(ExcessReminderText.Length - 2, 1);
            }
            else
            {
                ExcessReminderText = "No Selected Excess Reminder";
            }
        }

        public async Task OnChangeIsExcess(string value)
        {
            if (value == "1")
            {
                IsExcessSupplier = true;
            }
            else if (value == "0")
            {
                IsExcessSupplier = false;
            }

            SupplierModel.IsExcessSupplier = IsExcessSupplier;
        }
    }

}