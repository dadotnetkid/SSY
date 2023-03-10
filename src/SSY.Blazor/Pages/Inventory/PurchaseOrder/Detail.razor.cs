namespace SSY.Blazor.Pages.Inventory.PurchaseOrder;


public partial class Detail
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

    public PurchaseOrderInputIds PurchaseOrderInputIds { get; set; } = new() { PurchaseOrderIds = new() };

    public string POIds { get; set; }


    private IEnumerable<PurchaseOrderWithRollsModel> _receivedPurchaseOrder { get; set; }
    public List<PurchaseOrderWithRollsModel> PurchaseOrderWithRollsList { get; set; } = new();
    public List<PurchaseOrderISTModel> PurchaseOrderISTModelList { get; set; } = new();
    public PurchaseOrderWithRollsModel PurchaseOrderWithRollModel { get; set; } = new();
    public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };
    public List<RollAndLocationModel> ReceivedPurchaseOrder { get; set; } = new();

    public PurchaseOrderWithSubMaterialsModel PurchaseOrderWithSubMaterialModel { get; set; } = new();

    private IEnumerable<PurchaseOrderModel> _purchaseOrder { get; set; }

    #endregion

    private string customFilterValue;

    public bool IsEditable = false;

    public string Module = "Purchase Order";
    public string ModuleMessage = "";
    public string ModuleType = "View";
    public string Crud = "Detail";
    public string MaterialTypeText = "Detail";
    public string ModuleChange = "";


    public PurchaseOrderModel PurchaseOrderModel { get; set; } = new();

    [Parameter]
    public List<PurchaseOrderWithRollsModel> ListReceivedPurchaseOrder { get; set; } = new();

    [Parameter]
    public List<PurchaseOrderISTModel> ListPurchaseOrderIST { get; set; } = new();

    [Parameter]
    public List<SubMaterialModel> ListSubMaterialPurchaseOrder { get; set; } = new();

    public ReceivedPurchaseOrderModel ReceivedPurchaseOrderModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        PurchaseOrderIds.Add(Id);
        POIds = JsonSerializer.Serialize(PurchaseOrderIds);
        _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);

        PurchaseOrderModel = await _purchaseOrderService.GetPurchaseOrder(Id);
        PurchaseOrderWithRollsList = await _purchaseOrderService.GetRollsWithPurchaseOrder(POIds);
        PurchaseOrderISTModelList = await _purchaseOrderService.GetPurchaseOrderIST(Id);
        PurchaseOrderWithSubMaterialModel = await _purchaseOrderService.GetSubMaterialWithPurchaseOrder(POIds);
    }

    protected override async Task OnParametersSetAsync()
    {
        if (IsEditable == false)
        {
            foreach (var po in PurchaseOrderWithRollsList)
            {
                po.IsReceived = true;
                if (po.Roll.ReceivedCount == null)
                {
                    po.IsReceived = false;
                    //po.Roll.ReceivedQuantity = po.Roll.RollCount;
                }
            }

            foreach (var po in PurchaseOrderWithSubMaterialModel.Result)
            {
                po.IsReceived = true;
                if (po.ReceivedCount == null)
                {
                    po.IsReceived = false;
                    //po.ReceivedQuantity = po.ActualCount;
                }
            }
        }
    }
}