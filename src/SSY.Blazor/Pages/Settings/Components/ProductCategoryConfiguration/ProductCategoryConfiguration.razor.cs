namespace SSY.Blazor.Pages.Settings.Components.ProductCategoryConfiguration

{
    public partial class ProductCategoryConfiguration
    {
        public ProductCategoryConfiguration()
        {
        }

        public string Module = "CategoryConfiguration";
        public string ModuleMessage = "";
        public string ModuleType = "Edit";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public ProductCategoryService _productCategoryService { get; set; }
        public ProductTypeService _productTypeService { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        public ProductCategoryModel CategoryModel { get; set; } = new();

        public CreateProductCategoryModel CreateProductCategoryModel { get; set; } = new();

        public GetAllProductCategoryOutputModel ProductCategoryListModel { get; set; } = new() { Items = new() };
        public GetAllProductTypeOutputModel ProductTypeListModel { get; set; } = new() { Items = new() };

        public bool IsAddProductCategory { get; set; } = true;

        public async Task CloseCategory()
        {
            CategoryModel.Id = default;
            CategoryModel.Label = default;
            CategoryModel.Value = default;
            CategoryModel.SalesPercentage = default;
            CategoryModel.OrderNumber = default;
        }

        protected override async Task OnInitializedAsync()
        {
            _productCategoryService = new(js, ClientFactory, NavigationManager, Configuration);

            ProductCategoryListModel = await _productCategoryService.GetAllProductCategory(null, null, null, 100);
            //ProductTypeListModel = await _productTypeService.GetAllProductType(null, null, null, 100);
        }


        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                CreateProductCategoryModel input = new()
                {
                    Label = CategoryModel.Label,
                    Value = CategoryModel.Label,
                    SalesPercentage = CategoryModel.SalesPercentage,
                    OrderNumber = CategoryModel.OrderNumber
                };

                await _productCategoryService.CreateProductCategory(input);
            }
            else
            {
                UpdateProductCategoryModel input = new()
                {
                    Id = CategoryModel.Id,
                    Label = CategoryModel.Label,
                    Value = CategoryModel.Label,
                    SalesPercentage = CategoryModel.SalesPercentage,
                    OrderNumber = CategoryModel.OrderNumber
                };

                await _productCategoryService.UpdateProductCategory(input);
            }

            await Refresh();
        }

        public async Task Refresh()
        {
            ProductCategoryListModel = await _productCategoryService.GetAllProductCategory(null, null, null, 100);
        }

        public async Task EditCategory(ProductCategoryModel model)
        {
            IsAddProductCategory = false;

            var result = await _productCategoryService.GetProductCategory(model.Id);

            CategoryModel.Id = result.Id;
            CategoryModel.Label = result.Label;
            CategoryModel.Value = result.Label;
            CategoryModel.SalesPercentage = result.SalesPercentage;
            CategoryModel.OrderNumber = result.OrderNumber;
            ModuleMessage = "Edit";
        }

        public async Task RemoveCategory(int id)
        {
            await _productCategoryService.DeleteProductCategory(id);

            await Refresh();
        }

        public async Task AddProductCategoryHandler()
        {
            IsAddProductCategory = true;
            await CloseCategory();
        }

    }
}