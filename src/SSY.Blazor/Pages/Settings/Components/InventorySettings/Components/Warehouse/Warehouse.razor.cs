namespace SSY.Blazor.Pages.Settings.Components.InventorySettings.Components.Warehouse;

public partial class Warehouse
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

    public WarehouseService _warehouseService { get; set; }

    #endregion

    public string Module = "Warehouse";
    public string ModuleMessage = "";
    public string ModuleType = "edit";

    #region Models

    private IEnumerable<WarehouseModel> _warehouse { get; set; }

    #endregion

    private string customFilterValue;

    public WarehouseModel WarehouseModel { get; set; } = new();
    public GetAllWarehouseOutputModel WarehouseListModel { get; set; } = new() { Result = new() { Items = new() } };


    protected override async Task OnInitializedAsync()
    {
        _warehouseService = new(js, ClientFactory, NavigationManager, Configuration);
        await GetWarehouse();
    }

    private bool OnCustomFilter(WarehouseModel model)
    {
        // We want to accept empty value as valid or otherwise
        // datagrid will not show anything.
        if (string.IsNullOrEmpty(customFilterValue))
            return true;

        return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
    }

    public async Task OnSubmit()
    {
        if (ModuleMessage != "Edit")
        {
            CreateWarehouseModel input = new()
            {
                Name = WarehouseModel.Name,
                Location = WarehouseModel.Location,
                MaximumCapacity = WarehouseModel.MaximumCapacity,
                OrderNumber = 0
            };

            await _warehouseService.CreateWarehouse(input);

        }
        else
        {
            UpdateWarehouseModel input = new()
            {
                Id = WarehouseModel.Id,
                Name = WarehouseModel.Name,
                Location = WarehouseModel.Location,
                MaximumCapacity = WarehouseModel.MaximumCapacity,
                OrderNumber = 0
            };

            await _warehouseService.UpdateWarehouse(input);
        }

        await GetWarehouse();
    }

    public async Task EditWarehouse(Guid id)
    {
        var result = await _warehouseService.GetWarehouse(id);
        WarehouseModel.Id = result.Result.Id;
        WarehouseModel.Name = result.Result.Name;
        WarehouseModel.Location = result.Result.Location;
        WarehouseModel.MaximumCapacity = result.Result.MaximumCapacity;
        WarehouseModel.OrderNumber = result.Result.OrderNumber;
        ModuleMessage = "Edit";
    }

    public async Task ClearAll()
    {
        WarehouseModel.Name = "";
        WarehouseModel.Location = "";
        WarehouseModel.MaximumCapacity = 0;
    }

    public async Task GetWarehouse()
    {
        WarehouseListModel = await _warehouseService.GetAllWarehouse(null, null, null, 100);
        _warehouse = WarehouseListModel.Result.Items;
    }

    public async Task RemoveWarehouse(Guid id)
    {
        await _warehouseService.DeleteWarehouse(id);

        await GetWarehouse();
    }
}

