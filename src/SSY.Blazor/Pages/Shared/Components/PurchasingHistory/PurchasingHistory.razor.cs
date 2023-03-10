namespace SSY.Blazor.Pages.Shared.Components.PurchasingHistory
{
    public partial class PurchasingHistory
    {
        public PurchasingHistory()
        {
        }

        public string Module = "Inventory";
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
        public PurchasingHistoryService _purchasingHistoryService { get; set; }
        public GetDropdownService _getDropdownService { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public int CategoryId { get; set; }

        public List<PurchasingHistoryModel> PurchasingHistoryList { get; set; } = new();

        public PurchasingHistoryModel PurchasingHistoryModel { get; set; } = new();

        public UnitOfMeasurementListModel UnitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };
        private bool isSortedAscending;
        private string activeSortColumn;
    
        protected override async Task OnInitializedAsync()
        {
            _purchasingHistoryService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            UnitOfMeasurementListModel = await _getDropdownService.GetAllUnitOfMeasurement(null, null, null, 100);

            await GetAllPurchasingHistory();
        }

        public async Task GetAllPurchasingHistory()
        {
            var results = await _purchasingHistoryService.GetAllPurchasingHistory(Id);

            PurchasingHistoryList = results.Result.Items;
        }

        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                CreatePurchasingHistoryModel input = new()
                {
                    MaterialId = Id,
                    OrderStatus = PurchasingHistoryModel.OrderStatus,
                    OrderNumber = PurchasingHistoryModel.OrderNumber,
                    OrderQuantity = PurchasingHistoryModel.OrderQuantity,
                    UnitOfMeasurementId = PurchasingHistoryModel.UnitOfMeasurementId,
                    OrderDate = PurchasingHistoryModel.OrderDate,
                    OrderBy = PurchasingHistoryModel.OrderBy
                };

                if (CategoryId == 1 || CategoryId == 2)
                {
                    input.MaterialId = Id;

                    await _purchasingHistoryService.CreateMaterialPurchasingHistory(input);
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    input.MaterialId = Id;

                    await _purchasingHistoryService.CreateSubMaterialPurchasingHistory(input);
                }
            }
            else
            {
                UpdatePurchasingHistoryModel input = new()
                {
                    Id = PurchasingHistoryModel.Id,
                    MaterialId = PurchasingHistoryModel.MaterialId,
                    OrderStatus = PurchasingHistoryModel.OrderStatus,
                    OrderNumber = PurchasingHistoryModel.OrderNumber,
                    OrderQuantity = PurchasingHistoryModel.OrderQuantity,
                    UnitOfMeasurementId = PurchasingHistoryModel.UnitOfMeasurementId,
                    OrderDate = PurchasingHistoryModel.OrderDate,
                    OrderBy = PurchasingHistoryModel.OrderBy
                };

                if (CategoryId == 1 || CategoryId == 2)
                {
                    input.MaterialId = Id;

                    await _purchasingHistoryService.UpdateMaterialPurchasingHistory(input);
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    input.MaterialId = Id;

                    await _purchasingHistoryService.UpdateSubMaterialPurchasingHistory(input);
                }
            }

            await ClearAll();
        }

        public async Task ClearAll()
        {
            PurchasingHistoryModel.OrderStatus = string.Empty;
            PurchasingHistoryModel.OrderNumber = string.Empty;
            PurchasingHistoryModel.OrderQuantity = 0;
            PurchasingHistoryModel.UnitOfMeasurementId = 0;
            PurchasingHistoryModel.OrderDate = DateTime.Now;
            PurchasingHistoryModel.OrderBy = string.Empty;
            ModuleMessage = "";

            await GetAllPurchasingHistory();
        }

        public async Task EditPurchasingHistory(Guid id)
        {
            var result = await _purchasingHistoryService.GetPurchasingHistory(id);
            PurchasingHistoryModel.Id = result.Result.Id;
            PurchasingHistoryModel.MaterialId = result.Result.MaterialId;
            PurchasingHistoryModel.OrderStatus = result.Result.OrderStatus;
            PurchasingHistoryModel.OrderNumber = result.Result.OrderNumber;
            PurchasingHistoryModel.OrderQuantity = result.Result.OrderQuantity;
            PurchasingHistoryModel.UnitOfMeasurementId = result.Result.UnitOfMeasurementId;
            PurchasingHistoryModel.OrderDate = result.Result.OrderDate;
            PurchasingHistoryModel.OrderBy = result.Result.OrderBy;

            ModuleMessage = "Edit";
        }

        public async Task RemovePurchasingHistory(Guid id)
        {
            if (CategoryId == 1 || CategoryId == 2)
            {
                await _purchasingHistoryService.DeleteMaterialPurchasingHistory(id);
            }
            if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
            {
                await _purchasingHistoryService.DeleteSubMaterialPurchasingHistory(id);
            }

            await ClearAll();
        }

          private void SortTable(string columnName)
    {
        if (columnName != activeSortColumn)
        {
            PurchasingHistoryList = PurchasingHistoryList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            isSortedAscending = true;
            activeSortColumn = columnName;

        }
        else
        {
            if (isSortedAscending)
            {
                PurchasingHistoryList = PurchasingHistoryList.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            else
            {
                PurchasingHistoryList = PurchasingHistoryList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }

            isSortedAscending = !isSortedAscending;
        }
    }

    private string SetSortIcon(string columnName)
    {
        if (activeSortColumn != columnName)
        {
             return "fa fa-sort";
        }
        if (isSortedAscending)
        {
            return "fa fa-sort-up";
        }
        else
        {
            return "fa fa-sort-down";
        }
    }

    }
    
}