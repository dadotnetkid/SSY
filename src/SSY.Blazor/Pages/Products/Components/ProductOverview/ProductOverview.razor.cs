using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.LaunchCategories.Dtos;

namespace SSY.Blazor.Pages.Products.Components.ProductOverview
{
    public partial class ProductOverview
    {
        public ProductOverview()
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

        [Parameter]
        public bool IsEditable { get; set; }

        public ProductService _productService { get; set; }


        [Parameter]
        public ProductModel ProductModel { get; set; } = new();

        [Parameter]
        public LaunchCategoryListModel LaunchCategoryList { get; set; } = new() { Items = new() };


        protected override async Task OnInitializedAsync()
        {
            _productService = new(js, ClientFactory, NavigationManager, Configuration);
        }

    }
}

