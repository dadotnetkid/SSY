using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;

namespace SSY.Blazor.Pages.Products.Components.PricingAndAccounting.Pricing
{
    public partial class Pricing
    {
        #region Injections

        [Inject]
        public IWebHostEnvironment env { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }
        #endregion

        private PricingService _pricingService { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public PricingModel PricingModel { get; set; } = new();

        public CreatePricingModel CreatePricingModel { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _pricingService = new(js, ClientFactory, NavigationManager, Configuration);

            PricingModel = new();
        }

        public async Task OnSubmit()
        {
            CreatePricingModel input = new()
            {
                NetPrice = PricingModel.NetPrice,
                ShippingPremium = PricingModel.ShippingPremium,
                RetailPrice = PricingModel.RetailPrice
            };

            await _pricingService.CreatePricing(input);
        }
    }
}