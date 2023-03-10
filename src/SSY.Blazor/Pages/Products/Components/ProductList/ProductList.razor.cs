using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Drops.Model;

namespace SSY.Blazor.Pages.Products.Components.ProductList
{
    public partial class ProductList
    {
        public ProductList()
        {
        }

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        public string Module = "Product";

        private ProductService _productService { get; set; }

        [Parameter]
        public List<DropModel> DropListModel { get; set; } = new();

        [Parameter]
        public ProductModel ProductModel { get; set; }

        [Parameter]
        public List<ProductModel> ChildProducts { get; set; } = new();

        [Parameter]
        public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };

        int count = 0;

        protected override async Task OnInitializedAsync()
        {
            _productService = new(js, ClientFactory, NavigationManager, Configuration);

            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                StateHasChanged();
            }
        }

        protected override async  Task OnParametersSetAsync()
        {
            await GetProductList();

            StateHasChanged();
        }

        public async Task GetProductList()
        {
            try
            {
                count = ChildProducts.Count();

                ChildProducts.Where(x => x.IsActive).ToList().ForEach(child =>
                {
                    child.ProductName = "child-product";
                    child.HexCode = child.ColorId == null ? "7B8E61" : ColorList.Result.Items.Find(x => x.Id == child.ColorId).HexCode;
                    child.ParentCount = count;

                    StateHasChanged();
                });

                ChildProducts.First().ProductName = ProductModel.Name;

            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }
        }
    }

}