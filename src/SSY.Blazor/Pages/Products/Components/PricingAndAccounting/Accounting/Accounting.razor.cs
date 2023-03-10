using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;

namespace SSY.Blazor.Pages.Products.Components.PricingAndAccounting.Accounting;

public partial class Accounting
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

    private AccountingService _accountingService { get; set; }

    [Parameter]
    public bool IsEditable { get; set; }
    [Parameter]
    public AccountingModel AccountingModel { get; set; } = new();

    public CreateAccountingModel CreateAccountingModel { get; set; }


    protected override async Task OnInitializedAsync()
    {
        _accountingService = new(js, ClientFactory, NavigationManager, Configuration);

        AccountingModel = new();
    }

    public async Task OnSubmit()
    {
        CreateAccountingModel input = new()
        {
            TotalSales = AccountingModel.TotalSales,
            UnitSales = AccountingModel.UnitSales
        };

        await _accountingService.CreateAccounting(input);
    }
}