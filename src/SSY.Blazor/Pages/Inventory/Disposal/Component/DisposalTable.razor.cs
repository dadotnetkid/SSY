namespace SSY.Blazor.Pages.Inventory.Disposal.Component;

public partial class DisposalTable
{

    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }

    private MaterialService _materialService { get; set; }

    [Parameter]
    public string Module { get; set; }
    [Parameter]
    public int CategoryId { get; set; }

    public MaterialListModel MaterialListModel { get; set; } = new();

    public IEnumerable<MaterialModel> _materials;

    private string customFilterValue;
    public List<Guid> MaterialIds { get; set; } = new();

    private DeleteDataByIdService _deleteDataByIdService { get; set; }

    private bool IsLoading;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;

            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            MaterialListModel = new() { Materials = new() };
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
                await GetMaterial();
            }
            await js.InvokeVoidAsync("loadMultiSelectSearch");

            IsLoading = false;

            StateHasChanged();
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

    public async Task GetMaterial()
    {
        var result = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000);
        foreach (var item in result.Result.Items)
        {
            if (item.RollsAndLocations != null || item.RollsAndLocations.Count() != 0)
            {
                if (item.RollsAndLocations.Exists(r => r.IsDisposal == true))
                    MaterialListModel.Materials.Add(item);
            }
        }
        _materials = MaterialListModel.Materials;
    }

    private bool OnCustomFilter(MaterialModel model)
    {
        // We want to accept empty value as valid or otherwise
        // datagrid will not show anything.
        if (string.IsNullOrEmpty(customFilterValue))
            return true;

        return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
    }

    public async Task onChangeCheckBox(Guid id, bool checkedValue)
    {
        if (checkedValue)
        {
            if (!MaterialIds.Contains(id))
            {
                MaterialIds.Add(id);
            }
        }
        else
        {
            if (MaterialIds.Contains(id))
            {
                MaterialIds.Remove(id);
            }

        }
    }

    public async Task onChangeCheckBoxAll(bool checkedValue)
    {

        if (checkedValue)
        {

            if (Module == "All" || Module == "Greige" || Module == "Fabric")
            {
                foreach (var item in MaterialListModel.Materials)
                {
                    MaterialIds.Add(item.Id);
                }
            }
        }
        else
        {
            MaterialIds.Clear();

        }
    }
    public async Task OnClickRow(int categoryId, Guid id)
    {
        var module = "";
        if (categoryId == 1)
        {
            module = "greige";
        }
        if (categoryId == 2)
        {
            module = "fabric";
        }
        if (categoryId == 3)
        {
            module = "trimsandaccessories";
        }
        if (categoryId == 4)
        {
            module = "packaging";
        }
        if (categoryId == 99)
        {
            module = "others";
        }
        var url = $"/inventory/{module}/detail/{id}";
        NavigationManager.NavigateTo(url);
    }
    public async Task UnCheckAll()
    {
        MaterialIds.Clear();
    }
    public async Task DeleteSelectedIds()
    {

        foreach (var id in MaterialIds)
        {
            if (Module == "Greige" || Module == "Fabric" || Module == "All")
            {
                var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "Material");
            }

            if (Module == "Trims and Accessories" || Module == "Packaging" || Module == "Others")
            {
                var data = await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "SubMaterial");
            }
        }
        await GetMaterial();

        await js.InvokeVoidAsync("defaultMessage", "success", "Successfully Deleted!", "");
        MaterialIds.Clear();

    }
}