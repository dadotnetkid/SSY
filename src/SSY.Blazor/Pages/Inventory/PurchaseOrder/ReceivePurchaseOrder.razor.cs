namespace SSY.Blazor.Pages.Inventory.PurchaseOrder;


public partial class ReceivePurchaseOrder
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

    public List<PurchaseOrderWithRollsModel> PurchaseOrderWithRollsList { get; set; } = new();
    

    public PurchaseOrderWithRollsModel PurchaseOrderWithRollModel { get; set; } = new();
    public PurchaseOrderWithSubMaterialsModel PurchaseOrderWithSubMaterialModel { get; set; } = new();
    public ReceivedPurchaseOrderModel ReceivedPurchaseOrderModel { get; set; } = new();
    public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };
    

    #endregion

    protected override async Task OnInitializedAsync()
    {
        _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);

        PurchaseOrderWithRollsList = await _purchaseOrderService.GetRollsWithPurchaseOrder(POIds);
        PurchaseOrderWithSubMaterialModel = await _purchaseOrderService.GetSubMaterialWithPurchaseOrder(POIds);

    }

    public async Task OnSubmit()
    {
        foreach (var po in PurchaseOrderWithRollsList)
        {
            if (po.IsReceived == false)
            {
                if (po.Roll.ReceivedCount == null)
                {
                    po.Roll.ReceivedCount = null;
                }
            }
            
            ReceivedPurchaseOrderModel.Rolls.Add(po.Roll);
        }

        foreach (var po in PurchaseOrderWithSubMaterialModel.Result)
        {
            if (po.IsReceived == false)
            {
                if (po.ReceivedCount == null)
                {
                    po.ReceivedCount = null;
                }
            }

            ReceivedPurchaseOrderModel.SubMaterials.Add(po);
        }

        await _purchaseOrderService.ReceivedPurchaseOrder(ReceivedPurchaseOrderModel);
        

    }
}