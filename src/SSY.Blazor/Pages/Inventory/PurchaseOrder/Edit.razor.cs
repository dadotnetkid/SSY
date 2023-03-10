namespace SSY.Blazor.Pages.Inventory.PurchaseOrder;


public partial class Edit
{
    #region Injections

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


    #endregion

    [Parameter]
    public Guid Id { get; set; }
    #region Models

    private IEnumerable<PurchaseOrderModel> _purchaseOrder { get; set; }

    #endregion

    private string customFilterValue;


    public bool IsEditable = true;


    public PurchaseOrderModel PurchaseOrderModel { get; set; } = new();

    public string Module = "Purchase Order";
    public string ModuleMessage = "";
    public string ModuleType = "View";
    public string Crud = "Edit";
    public string MaterialTypeText = "Edit";
    public string ModuleChange = "";




    protected override async Task OnInitializedAsync()
    {
        _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);
        PurchaseOrderModel = await _purchaseOrderService.GetPurchaseOrder(Id);
    }

    public async Task HandleSubmit()
    {
        await _purchaseOrderService.UpdatePurchaseOrder(PurchaseOrderModel);
        //Console.WriteLine(JsonSerializer.Serialize(PurchaseOrderModel));
    }
}
