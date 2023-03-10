namespace SSY.Blazor.Pages.Inventory.PurchaseOrder;


public partial class Add
{
    
    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }



    public PurchaseOrderService _purchaseOrderService { get; set; }

    public List<Guid> PurchaseOrderIds { get; set; } = new();

    public bool IsEditable = true;

    private string customFilterValue;

    public PurchaseOrderModel PurchaseOrderModel { get; set; } = new();

    private string Module = "Purchase Order";
    private string ModuleMessage = "";
    private int CategoryId = 2;


    protected override async Task OnInitializedAsync()
    {
        _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);
        StateHasChanged();

    }

    public async Task OnSubmit()
    {
        try
        {
            var purchaseOrderIsValid = PurchaseOrderDescriptionComponent.CanSubmit();

            if (purchaseOrderIsValid)
            {
                await _purchaseOrderService.CreatePurchaseOrder(PurchaseOrderModel);
                StateHasChanged();
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";
            await js.InvokeVoidAsync("defaultMessage", "error", "Invalid Request Id");
        }
        //Console.WriteLine(JsonSerializer.Serialize(PurchaseOrderModel));
    }
}