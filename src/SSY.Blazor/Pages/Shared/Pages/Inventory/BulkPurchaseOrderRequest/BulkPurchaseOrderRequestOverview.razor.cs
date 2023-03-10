using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model;

namespace SSY.Blazor.Pages.Shared.Pages.Inventory.BulkPurchaseOrderRequest;


public partial class BulkPurchaseOrderRequestOverview
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

    [Inject]
    public ProtectedLocalStorage LocalStorage { get; set; }

    //private UserService _userService { get; set; }

    public BulkPurchaseOrderRequestService _bulkPurchaseOrderRequestService { get; set; }
    private GetDropdownService _getDropdownService { get; set; }

    #region Models

    private IEnumerable<BulkPurchaseOrderRequestModel> _bulkPurchaseOrderRequest { get; set; }
    public BulkPurchaseOrderRequestModel BulkPurchaseOrderRequestModel { get; set; } = new();
    public GetAllBulkPurchaseOrderRequestModel BulkPurchaseOrderRequestListModel { get; set; } = new() { Result = new() { Items = new() } };
    public List<Status> Statuses { get; set; } = new();
    #endregion

    #region Parameters

    [Parameter]
    public int CategoryId { get; set; }
    [Parameter]
    public bool IsEditable { get; set; }
    [Parameter]
    public string Module { get; set; }
    [Parameter]
    public string ModuleMessage { get; set; }

    public string Details = "Bulk Purchase Order Request";

    #endregion

    private string customFilterValue;
    private bool IsLoading;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;

            _bulkPurchaseOrderRequestService = new(js, ClientFactory, NavigationManager, Configuration);
            //_userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);

            BulkPurchaseOrderRequestListModel = await _bulkPurchaseOrderRequestService.GetAllBulkPurchaseOrderRequest(null, null, null, 100);

            _bulkPurchaseOrderRequest = BulkPurchaseOrderRequestListModel.Result.Items;
            await GetStatus();
        }
        catch(Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out? 
        }

    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (firstRender)
            {
                //await _userService.CheckAdminCredential();
            }
            IsLoading = false;

            StateHasChanged();
        }
        
        catch(Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out? 
        }
    }

    private bool OnCustomFilter(BulkPurchaseOrderRequestModel model)
    {
        // We want to accept empty value as valid or otherwise
        // datagrid will not show anything.
        if (string.IsNullOrEmpty(customFilterValue))
            return true;

        return model.Id.ToString()?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
    }

    public async Task GetStatus()
    {
        Statuses.Add(new Status { Id = 1, Value = "In Progress", HexCode = "FF8A34" });
        Statuses.Add(new Status { Id = 2, Value = "Completed", HexCode = "7B8E61" });
        Statuses.Add(new Status { Id = 3, Value = "Cancelled", HexCode = "FF3C52" });
    }


    public async Task OnChangeStatus(string value, Guid id)
    {
        try
        {
            ChangeRequestStatusModel changeRequest = new() { Id = id, Status = int.Parse(value) };

            var selectedRequest = BulkPurchaseOrderRequestListModel.Result.Items.Find(x => x.Id == id);
            if (selectedRequest != null)
                //if (changeRequest.Status == 2 && (selectedRequest.CollectionId.Equals(Guid.Empty) || selectedRequest.CollectionId.Equals(null)))
                //    await js.InvokeVoidAsync("defaultMessage", "warning", "Warning", $"No Collection is connected on this Addition Request, you can't change the status to Completed.");
                //else
                    await _bulkPurchaseOrderRequestService.ChangeRequestStatus(changeRequest);
            else
                await js.InvokeVoidAsync("defaultMessage", "error", "Error", $"Bulk Purchase Order Request not found.");
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string HexCode { get; set; }
    }
}