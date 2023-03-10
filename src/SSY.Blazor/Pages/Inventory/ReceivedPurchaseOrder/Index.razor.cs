namespace SSY.Blazor.Pages.Inventory.ReceivedPurchaseOrder;


public partial class Index
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

    #endregion


    public PurchaseOrderService _purchaseOrderService { get; set; }

    public PurchaseOrderInputIds PurchaseOrderInputIds { get; set; } = new() { PurchaseOrderIds = new() };

    private string Module = "Receive Purchase Order";
    private bool IsEditable = true;
    private string ModuleMessage = "";
    [Parameter]
    public string POIds { get; set; }

    #region Models

    private IEnumerable<PurchaseOrderWithRollsModel> _receivedPurchaseOrder { get; set; }
    public List<PurchaseOrderWithRollsModel> PurchaseOrderWithRollsList { get; set; } = new();
    public PurchaseOrderWithRollsModel PurchaseOrderWithRollModel { get; set; } = new();
    public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };
    public List<RollAndLocationModel> ReceivedPurchaseOrder { get; set; } = new();

    #endregion

    protected override async Task OnInitializedAsync()
    {
        _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);

        PurchaseOrderWithRollsList = await _purchaseOrderService.GetRollsWithPurchaseOrder(POIds);
        _receivedPurchaseOrder = PurchaseOrderWithRollsList;

    }

    public async Task OnSubmit()
    {
        foreach (var po in _receivedPurchaseOrder)
        {
            ReceivedPurchaseOrder.Add(po.Roll);
        }

        //await _purchaseOrderService.ReceivedPurchaseOrder(ReceivedPurchaseOrder);
        //Console.WriteLine(JsonSerializer.Serialize(ReceivedPurchaseOrder));

    }
}




