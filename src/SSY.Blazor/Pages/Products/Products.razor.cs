using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Statuses.Model;

namespace SSY.Blazor.Pages.Products
{
    public partial class Products
    {
        public Products()
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

        private IEnumerable<ProductListDto> _products;

        public GetAllApprovalStatusOutputModel ApprovalStatusListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllProductStatusOutputModel ProductStatusListModel { get; set; } = new() { Result = new() { Items = new() } };
        private string customFilterValue;

        // public string Module = "Products";

        public ProductListModel ProductListModel { get; set; } = new();


        //for sorting
        private bool isSortedAscending;
        private string activeSortColumn;

        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                _productService = new(js, ClientFactory, NavigationManager, Configuration);
            }
            catch(Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await GetAllProducts();
                }

                IsLoading = false;

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
            
        }

        private async Task GetAllProducts()
        {
            var response = await _productService.GetAllProductList();

            _products = response.Items;
        }

        private bool OnCustomFilter(ProductListDto model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;

        }
        public async Task OnClickRow(Guid id)
        {

            var url = $"/collectionandproduct/product/{id}";
            NavigationManager.NavigateTo(url);
        }

        public async Task OnDeleteClicked(Guid id)
        {
            await _productService.DeleteProduct(id);
            await GetAllProducts();
        }
    }
}