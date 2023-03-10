using SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;

namespace SSY.Blazor.Pages.Shared.Components.Collection.AssignedTo;

public partial class AssignedTo
{
   public AssignedTo()
    {
    }

    public string Module = "";
    public string ModuleMessage = "";
    public string ModuleType = "";
    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }

    private IEnumerable<UserDetailModel> _userDetailDesigner { get; set; }
    private IEnumerable<UserDetailModel> _userDetail3dDesigner { get; set; }
    private IEnumerable<UserDetailModel> _userDetailSSYMerchandiser { get; set; }
    private IEnumerable<UserDetailModel> _userDetailOEMMerchandiser { get; set; }
    private IEnumerable<UserDetailModel> _userDetailOEMPatternMaker { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    [Parameter]
    public bool IsEditable { get; set; }

    public AssignedToService _assignedToService { get; set; }
    private UserDetailService _userDetailService { get; set; }

    [Parameter]
    public CollectionModel CollectionModel { get; set; } = new();

    [Parameter]
    public AssignedToModel AssignedToModel { get; set; } = new();

    [Parameter]
    public List<UserDetailModelCC> UserDetailListModel { get; set; } = new();
    [Parameter]
    public List<UserDetailModel> UserDetailListModels { get; set; } = new();


    public GetAllUserDetailCCOutputModel UserDetailslListModel { get; set; } = new() { Result = new() { Items = new() } };
    public GetAllAssignedToModel GetAllAssignedToModel { get; set; } = new() { Result = new() { Items = new() } };

    string selectionDesignerData;
    string selectionThreeDDesignerData;
    string selectionSSYMerchandiserData;
    string selectionOEMMerchandiserData;
    string selectionOEMPatternMakerData;
    string roles;
    private string selectedName = "Select Designer";
    private string selectedThreeDDesigner = "Select 3D Designer";
    private string selectedSSYMerchandiser = "Select SSY Merchandiser";
    private string selectedOEMMerchandiser = "Select OEM Merchandiser";
    private string selectedOEMPatternMaker = "Select OEM PatternMaker";
    private string searchText = "";
    private string searchTextThreeDDesigner = "";
    private string searchTextSSYMerchandiser = "";
    private string searchTextOEMMerchandiser = "";
    private string searchTextOEMPatternMaker = "";

    protected override async Task OnInitializedAsync()
    {
        _assignedToService = new(js, ClientFactory, NavigationManager, Configuration);

        _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);

        UserDetailslListModel = await _userDetailService.GetAllUserCC(null, null, null, null, null, 999);
    
        await AutoComplete();
        await GetDesignerId();
        StateHasChanged();
    }
    protected override async Task OnParametersSetAsync()
    {
    }
    private void OnSearchTextChange(ChangeEventArgs e)
    {
        searchText = e.Value.ToString().ToLower();
    }
    
    private void SelectNames(Guid id, string names, string assigntype)
    {
        if(assigntype == "Designer")
        {
            selectedName = names;
            AssignedToModel.DesignerName = names;
            AssignedToModel.DesignerId = id;
        }
        else if(assigntype == "ThreeD Designer")
        {
            selectedThreeDDesigner = names;
            AssignedToModel.ThreeDDesignerName = names;
            AssignedToModel.ThreeDDesignerId = id;
        }
        else if(assigntype == "SSY Merchandise")
        {
            selectedSSYMerchandiser = names;
            AssignedToModel.SSYMerchandiserName = names;
            AssignedToModel.SSYMerchandiserId = id;
        }
        else if(assigntype == "OEM Merchandise")
        {
            searchTextOEMMerchandiser = names;
            AssignedToModel.OEMMerchandiserName = names;
            AssignedToModel.OEMMerchandiserId = id;
        }
        else if(assigntype == "OEM Pattern Maker")
        {
            selectedOEMPatternMaker = names; 
            AssignedToModel.OEMPatternMakerName = names;
            AssignedToModel.OEMPatternMakerId = id;
        }
        searchText = string.Empty;
    }
    public async Task AutoComplete()
    {

        var response = await _userDetailService.GetAllUser(null, null, null, null, 100000);
       
        _userDetailDesigner = response.Result.Items.Where(x => x.FullName.Contains(searchText)).ToList();
        _userDetail3dDesigner = response.Result.Items.Where(x => x.FullName.Contains(searchTextThreeDDesigner)).ToList();
        _userDetailSSYMerchandiser = response.Result.Items.Where(x => x.FullName.Contains(searchTextSSYMerchandiser)).ToList();
        _userDetailOEMMerchandiser = response.Result.Items.Where(x => x.FullName.Contains(searchTextOEMMerchandiser)).ToList();
        _userDetailOEMPatternMaker = response.Result.Items.Where(x => x.FullName.Contains(searchTextOEMPatternMaker)).ToList();
        // var resourceNames = new List<string>();

        await base.OnInitializedAsync();
    }
    public async Task GetDesignerId()
    {
        foreach (var item in GetAllAssignedToModel?.Result?.Items)
        {
            if (item.DesignerId != null)
            {
                item.DesignerId = JsonSerializer.Deserialize<Guid?>(item.DesignerId);
            }
        }
    }

}
