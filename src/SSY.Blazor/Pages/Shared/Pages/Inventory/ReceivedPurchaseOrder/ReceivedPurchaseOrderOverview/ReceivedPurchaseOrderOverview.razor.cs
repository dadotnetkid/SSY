namespace SSY.Blazor.Pages.Shared.Pages.Inventory.ReceivedPurchaseOrder.ReceivedPurchaseOrderOverview;

public partial class ReceivedPurchaseOrderOverview
{
    public ReceivedPurchaseOrderOverview()
    {
    }


    #region Injects

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

 //   private UserService _userService { get; set; }

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

    public string Details = "Inventory";

    #endregion

    #region Models


    #endregion


    protected override async Task OnInitializedAsync()
    {
   //     _userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
       //     await _userService.CheckAdminCredential();
            StateHasChanged();
        }
    }


}



