
namespace SSY.Blazor.Pages.Settings.Components.MaterialTypeConfiguration;

public partial class MaterialTypeConfiguration
{
    public MaterialTypeConfiguration()
    {
    }

    public string Module = "MaterialType";
    public string ModuleMessage = "";
    public string ModuleType = "edit";

    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }
    private TypeService _typeService { get; set; }
    private GetDropdownService _getDropdownService { get; set; }

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public bool IsEditable { get; set; }
    public string panelText = "No Selected Panel";

    public TypeModel TypeModel { get; set; } = new();

    public GetAllPanelListModel PanelListModel { get; set; } = new() { Result = new() { Items = new() } };

    public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

    public CreateTypeModel CreateMaterialTypeModel { get; set; } = new();

    public GetAllTypeOutputModel TypeModelList { get; set; } = new() { Result = new() { Items = new() } };

    public bool IsAddMaterialType { get; set; } = true;

    public async Task ClearAll()
    {
        TypeModel.Id = 0;
        TypeModel.Value = string.Empty;
        TypeModel.Label = string.Empty;
        TypeModel.SalesPercentage = 0;
        TypeModel.OrderNumber = 0;
        TypeModel.ShortCode = string.Empty;
        TypeModel.PanelIds = 0;
        TypeModel.PanelIdList = new();
        TypeModel.Panels = new();
        panelText = "No Selected Panels";
    }

    protected override async Task OnInitializedAsync()
    {
        _typeService = new(js, ClientFactory, NavigationManager, Configuration);
        _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

        unitOfMeasurementListModel = await _getDropdownService.GetAllUnitOfMeasurement(null, null, null, 100);
        TypeModelList = await _typeService.GetAllType(2, null, null, null, 100);
        PanelListModel = await _getDropdownService.GetAllPanel(null, null, null, 100);

    }

    public async Task OnSubmit()
    {
        if (ModuleMessage != "Edit")
        {
            CreateTypeModel input = new()
            {
                Value = TypeModel.Value,
                Label = TypeModel.Value,
                SalesPercentage = TypeModel.SalesPercentage,
                OrderNumber = TypeModel.OrderNumber,
                ShortCode = TypeModel.ShortCode,
                CatergoryId = 2,
                UnitOfMeasurementId = TypeModel.UnitOfMeasurementId,
                Panels = TypeModel.Panels,
                PanelIdList = TypeModel.PanelIdList
            };

            await _typeService.CreateMaterialType(input);
        }

        else
        {
            UpdateTypeModel input = new()
            {
                Id = TypeModel.Id,
                Value = TypeModel.Value,
                Label = TypeModel.Value,
                SalesPercentage = TypeModel.SalesPercentage,
                OrderNumber = TypeModel.OrderNumber,
                ShortCode = TypeModel.ShortCode,
                CatergoryId = 2,
                UnitOfMeasurementId = TypeModel.UnitOfMeasurementId,
                Panels = TypeModel.Panels,
                PanelIdList = TypeModel.PanelIdList
            };

            await _typeService.UpdateMaterialType(input);
        }
        await ClearAll();

        await Refresh();
    }

    public async Task Refresh()
    {
        TypeModelList = await _typeService.GetAllType(2, null, null, null, 100);
    }

    public async Task EditMaterialType(int id)
    {
        IsAddMaterialType = false;

        List<int> PanelIdList = new();
        List<string> PanelList = new();
        var result = await _typeService.GetMaterialType(id);

        result.Result.Panels.ForEach(x =>
        {
            PanelIdList.Add(x.PanelId);
            PanelList.Add(x.PanelValue);
        });

        TypeModel.Id = result.Result.Id;
        TypeModel.Value = result.Result.Value;
        TypeModel.Label = result.Result.Value;
        TypeModel.SalesPercentage = result.Result.SalesPercentage;
        TypeModel.UnitOfMeasurementId = result.Result.UnitOfMeasurementId;
        TypeModel.OrderNumber = result.Result.OrderNumber;
        TypeModel.ShortCode = result.Result.ShortCode;
        TypeModel.PanelIdList = PanelIdList;
        TypeModel.Panels = result.Result.Panels;

        if (PanelList.Count == 0)
            TypeModel.SelectedPanels = "No Selected Panels";
        else
            TypeModel.SelectedPanels = ReplaceString(JsonSerializer.Serialize(PanelList));

        ModuleMessage = "Edit";

    }

    public async Task RemoveMaterialType(int id)
    {
        await _typeService.DeleteMaterialType(id);

        await Refresh();
    }


    public async Task GenerateSelectedPanel()
    {
        List<string> PanelList = new();

        TypeModel.PanelIdList.ForEach(x =>
        {
            var panel = PanelListModel.Result.Items.Find(p => p.Id == x);
            PanelList.Add(panel.Value);
        });

        if (PanelList.Count == 0)
            TypeModel.SelectedPanels = "No Selected Panels";
        else
            TypeModel.SelectedPanels = ReplaceString(JsonSerializer.Serialize(PanelList));

    }
    public async Task onChangePanel(int value, bool checkedValue, Items panel)
    {

        if (checkedValue)
        {
            if (!TypeModel.PanelIdList.Contains(value))
            {
                TypeModel.PanelIdList.Add(value);
            }

        }
        else
        {
            if (TypeModel.PanelIdList.Contains(value))
            {
                TypeModel.PanelIdList.Remove(value);
            }

        }
        await GenerateSelectedPanel();

    }

    private string ReplaceString(string input)
    {
        return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
    }

    public async Task AddMaterialTypeHandler()
    {
        IsAddMaterialType = true;
        await ClearAll();
    }

}