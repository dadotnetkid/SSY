using Blazorise.DataGrid;

namespace SSY.Blazor.Pages.Inventory.PurchaseOrder.Component;


public partial class ReceivePurchaseOrderTable
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

    #region Models
    [Parameter]
    public List<PurchaseOrderWithRollsModel> ListReceivedPurchaseOrder { get; set; } = new();

    [Parameter]
    public List<SubMaterialModel> ListSubMaterialPurchaseOrder { get; set; } = new();

    [Parameter]
    public List<PurchaseOrderISTModel> ListPurchaseOrderIST { get; set; } = new();

    [Parameter]
    public bool IsEditable { get; set; }
    #endregion

    [Parameter]
    public Guid Id { get; set; }

    public List<Guid> PurchaseOrderIds { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {

    }

    public void OnRowStyling(SubMaterialModel subMaterial, DataGridRowStyling styling)
    {
        if (subMaterial.IsReceived)
        {
            styling.Style = "background-color:#ced6c2;";
        }

    }

    public void OnRowStylingRoll(PurchaseOrderWithRollsModel purchaseOrderWithRoll, DataGridRowStyling styling)
    {
        if (purchaseOrderWithRoll.IsReceived)
        {
            styling.Style = "background-color:#ced6c2;";
        }
    }
    protected override async Task OnParametersSetAsync()
    {
        
        if (IsEditable)
        {
            foreach (var po in ListReceivedPurchaseOrder)
            {
                po.IsReceived = true;
                if (po.Roll.ReceivedCount == null)
                {
                    po.IsReceived = false;
                    po.Roll.ReceivedCount = po.Roll.TotalCount;
                }
            }

            foreach (var po in ListSubMaterialPurchaseOrder)
            {
                po.IsReceived = true;
                if (po.ReceivedCount == null)
                {
                    po.IsReceived = false;
                    po.ReceivedCount = po.TotalCount;
                }
            }
        }        
    }
}




