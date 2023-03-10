using SSY.Blazor.HttpClients.Data.Inventory.ProductAssignments.Model;

namespace SSY.Blazor.Pages.Shared.Components.Description
{
    public partial class Description
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
        private ProductAssignmentService _productAssignmentService { get; set; }
        private MaterialService _materialService { get; set; }

        public ColorListModel ColorListModel { get; set; } = new() { Result = new() { Items = new() } };
        public TypeListModel MaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };
        public WeightListModel WeightListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllProductAssignmentOutputModel ProductAssignmentModel { get; set; } = new() { Result = new() { Items = new() } };
        public TypeListModel TypeListModel { get; set; } = new() { Result = new() { Items = new() } };
        public MaterialModel MaterialModelDto { get; set; } = new();

        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public MaterialModel OverviewModel { get; set; } = new();
        [Parameter]
        public string MaterialCategory { get; set; }


        [Parameter]
        public EventCallback<string> OnChangeMaterialType { get; set; }

        public List<MaterialModel> MaterialType { get; set; } = new();

        public string ProductAssignmentText = "No Selected Product Assignment";

        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _productAssignmentService = new(js, ClientFactory, NavigationManager, Configuration);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);

            //var materialType = await _materialService.GetAllMaterial(null, null, null, null, null, 1000);
            //MaterialType = materialType.Result.Items;

            MaterialTypeModel = await _getDropdownService.GetAllMaterialType(OverviewModel.CategoryId, null, null, null, 100);

            ColorListModel = await _getDropdownService.GetAllColor(null, null, null, 100);
            WeightListModel = await _getDropdownService.GetAllWeightUnit(null, null, null, 100);
            ProductAssignmentModel = await _productAssignmentService.GetAllProductAssignment(null, null, null, 100);
            await GenerateProductAssignmentText();
        }

        public async Task MaterialTypeHandler(string id)
        {
            System.Console.WriteLine(id);

            var material = MaterialTypeModel.Result.Items.FirstOrDefault(x => x.Id == int.Parse(id));
            await OnChangeMaterialType.InvokeAsync(material.Label);
            StateHasChanged();
        }

        public async Task GenerateProductAssignmentText()
        {
            ProductAssignmentText = "";
            foreach (var item in ProductAssignmentModel?.Result?.Items)
            {
                if (OverviewModel.AssignmentList.Contains(item.Id) == true)
                {
                    ProductAssignmentText += item.Label + ", ";
                }
            }

            if (!string.IsNullOrWhiteSpace(ProductAssignmentText))
            {
                ProductAssignmentText = ProductAssignmentText.Remove(ProductAssignmentText.Length - 2, 1);
            }
            else
            {
                ProductAssignmentText = "No Selected Product Assignment";
            }
        }

        public async Task onChangeAssignment(int value, bool checkedValue)
        {

            if (checkedValue)
            {
                if (!OverviewModel.AssignmentList.Contains(value))
                {
                    OverviewModel.AssignmentList.Add(value);
                }
            }
            else
            {
                if (OverviewModel.AssignmentList.Contains(value))
                {
                    OverviewModel.AssignmentList.Remove(value);
                }
            }
            await GenerateProductAssignmentText();

            System.Console.WriteLine(JsonSerializer.Serialize(OverviewModel.AssignmentList));
        }
    }
}