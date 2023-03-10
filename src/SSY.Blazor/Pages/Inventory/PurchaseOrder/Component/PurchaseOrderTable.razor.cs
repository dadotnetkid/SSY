namespace SSY.Blazor.Pages.Inventory.PurchaseOrder.Component;


public partial class PurchaseOrderTable
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
    private GetDropdownService _getDropdownService { get; set; }

    public List<Guid> PurchaseOrderIds { get; set; } = new();
    public string POIds { get; set; }

    #region Models

    private IEnumerable<PurchaseOrderModel> _purchaseOrder { get; set; }
    public PurchaseOrderModel PurchaseOrderModel { get; set; } = new();
    public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };
    public TypeListModel MaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };

    #endregion

    private string customFilterValue;
    private bool IsLoading;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;

            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);
            PurchaseOrderListModel = await _purchaseOrderService.GetAllPurchaseOrder(null, null, null, 100);
            MaterialTypeModel = await _getDropdownService.GetAllMaterialType(null, null, null, null, 100);

            _purchaseOrder = PurchaseOrderListModel.Result.Items;
            await GeneratePOMaterialTypeText();

            IsLoading = false;
            //Console.WriteLine(JsonSerializer.Serialize(_purchaseOrder));
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out? 
        }



    }


    public async Task GeneratePOMaterialTypeText()
    {
        foreach (var po in _purchaseOrder)
        {
            foreach (var materialTypeId in po.Company.CompanyMaterialTypeKeys)
            {
                var type = MaterialTypeModel.Result.Items.Find(x=>x.Id == materialTypeId.MaterialTypeId);        
                po.MaterialTypeText += type.Label + ", ";
            }

            if (!string.IsNullOrWhiteSpace(po.MaterialTypeText))
            {
                po.MaterialTypeText = po.MaterialTypeText.Remove(po.MaterialTypeText.Length - 2, 1);
            }
            else
            {
                po.MaterialTypeText = "No Selected Material Type";
            }
        }

        
    }

    public async Task onChangeCheckBox(Guid id, bool checkedValue)
    {
        if (checkedValue)
        {
            if (!PurchaseOrderIds.Contains(id))
            {
                PurchaseOrderIds.Add(id);
            }
        }
        else
        {
            if (PurchaseOrderIds.Contains(id))
            {
                PurchaseOrderIds.Remove(id);
            }
        }
        Console.WriteLine(JsonSerializer.Serialize(PurchaseOrderIds));
    }
    public async Task onChangeCheckBoxAll(bool checkedValue)
    {
        PurchaseOrderIds.Clear();

        if (checkedValue)
        {
            foreach (var item in PurchaseOrderListModel.Result.Items)
            {
                PurchaseOrderIds.Add(item.Id);
            }
        }
        else
        {
            PurchaseOrderIds.Clear();
        }
        Console.WriteLine(JsonSerializer.Serialize(PurchaseOrderIds));

    }
    public async Task OnClickRow(Guid id)
    {
        var url = $"/inventory/purchaseorder/detail/{id}";
        NavigationManager.NavigateTo(url);
    }
    public async Task UnCheckAll()
    {
        PurchaseOrderIds.Clear();
    }

    public async Task GetPurchaseOrder()
    {
        PurchaseOrderListModel = await _purchaseOrderService.GetAllPurchaseOrder(null, null, null, 100);
        _purchaseOrder = PurchaseOrderListModel.Result.Items;
    }

    public async Task DeleteSelectedIds()
    {
        foreach (var id in PurchaseOrderIds)
        {
            await _purchaseOrderService.DeletePurchaseOrder(id);
        }

        PurchaseOrderIds.Clear();
        await GetPurchaseOrder();

    }

    public async Task ReceivedSelectedIds()
    {
        POIds = JsonSerializer.Serialize(PurchaseOrderIds);
        var url = $"/inventory/purchaseorder/received/{POIds}";
        NavigationManager.NavigateTo(url);
    }

}




