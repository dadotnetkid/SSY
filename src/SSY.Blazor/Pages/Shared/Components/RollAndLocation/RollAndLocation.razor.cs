
//using QRCoder;

namespace SSY.Blazor.Pages.Shared.Components.RollAndLocation
{

    public partial class RollAndLocation
    {

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private AdjustmentService _adjustmentService { get; set; }
        private RollAndLocationService _rollAndLocationService { get; set; }
        private PurchaseOrderService _purchaseOrderService { get; set; }


        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public MaterialModel MaterialModel { get; set; } = new();

        private IEnumerable<RollAndLocationModel> _rolls {get; set;}

        private RollAndLocationModel RollAndLocationModel { get; set; } = new();
        public ShadingListModel ShadingListModel { get; set; } = new() { Result = new() { Items = new() } };
        public MaterialActionListModel MaterialActionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };


        private bool isSortedAscending;
        private string activeSortColumn;

        public bool isUpdating = false;
        public string roll { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _adjustmentService = new(js, ClientFactory, NavigationManager, Configuration);
            _rollAndLocationService = new(js, ClientFactory, NavigationManager, Configuration);
            _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);

            PurchaseOrderListModel = await _purchaseOrderService.GetAllPurchaseOrder(null, null, null, 1000);

            ShadingListModel = await _getDropdownService.GetAllShading(null, null, null, 100);
            RollAndLocationModel.DateAcquired = DateTime.Today;
            roll = "";
            // foreach (var roll in MaterialModel.RollsAndLocations)
            // {
            //    roll.QR = await GenerateQRCode($"{MaterialModel.Name} - {roll.RollNumber}");
            // }

            MaterialActionListModel = await _getDropdownService.GetDropdown<MaterialActionListModel>("MaterialAction");
        }

        protected override async Task OnParametersSetAsync()
        {
            _rolls = MaterialModel.RollsAndLocations;
            Console.WriteLine(JsonSerializer.Serialize(_rolls));
            Console.WriteLine(JsonSerializer.Serialize("_rolls"));
        }

        public async Task OnClickPurchaseOrder(string poNumber)
        {
            try
            {
                var po = PurchaseOrderListModel.Result.Items.Find(x => x.Number == poNumber);
                var url = $"/inventory/purchaseorder/detail/{po.Id}";
                NavigationManager.NavigateTo(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Purchase Order");
            }
        }

        public async Task OnSubmit()
        {
            if (isUpdating)
            {
                await UpdateRollAndLocation(roll);
                return;
            }
            else
            {
                if (MaterialModel.RollsAndLocations.Any(x => x.RollNumber == RollAndLocationModel.RollNumber))
                {
                    await js.InvokeVoidAsync("defaultMessage", "error", "Add Warning!", "Roll Number must not exist of the current list");

                    return;
                }

                RollAndLocationModel roll = new() {
                    RollNumber = RollAndLocationModel.RollNumber,
                    ShelfLife = RollAndLocationModel.ShelfLife,
                    TotalCount = RollAndLocationModel.TotalCount,
                    BuildingOrWarehouse = RollAndLocationModel.BuildingOrWarehouse,
                    PONumber = RollAndLocationModel.PONumber,
                    IncomingCount = RollAndLocationModel.IncomingCount,
                    ShippedCount = RollAndLocationModel.ShippedCount,
                    ReceivedCount = RollAndLocationModel.ReceivedCount,
                    TRackNumber = RollAndLocationModel.TRackNumber,
                    Rack = RollAndLocationModel.Rack,
                    ShadingId = RollAndLocationModel.ShadingId,
                    ShadingLabel = ShadingListModel.Result.Items.FirstOrDefault(x => x.Id == RollAndLocationModel.ShadingId)?.Label,
                    DateAcquired = RollAndLocationModel.DateAcquired,
                    ConsumeBeforeDate = RollAndLocationModel.DateAcquired.AddYears((int)RollAndLocationModel.ShelfLife),
                    MaterialId = MaterialModel.Id,
                    Action = MaterialActionListModel.Result.Items.Find(x => x.OrderNumber == 1002).Id,
                    OnHandCount = RollAndLocationModel.TotalCount - RollAndLocationModel.IncomingCount,
                    AvailableCount = RollAndLocationModel.TotalCount
                    // QR = await GenerateQRCode($"{MaterialModel.Name} - {RollAndLocationModel.RollNumber}")
                };
                // On Editing of Material
                if (MaterialModel.Id != Guid.Empty)
                {
                    await _rollAndLocationService.CreateRollAndLocation(roll);
                }
                MaterialModel.RollsAndLocations.Add(roll);
                Console.WriteLine(JsonSerializer.Serialize("rolltest"));
                Console.WriteLine(JsonSerializer.Serialize(roll));

                await ResetFormRollAndLocation();

                await AddMoreAdjustmentEntry(roll);
            }
        }

        public async Task ResetFormRollAndLocation()
        {
            RollAndLocationModel.RollNumber = "";
            RollAndLocationModel.ShelfLife = 0;
            RollAndLocationModel.TotalCount = 0;
            RollAndLocationModel.BuildingOrWarehouse = "";
            RollAndLocationModel.TRackNumber = "";
            RollAndLocationModel.Rack = "";
            RollAndLocationModel.ShadingId = 0;
            RollAndLocationModel.DateAcquired = DateTime.Today;
            RollAndLocationModel.ConsumeBeforeDate = DateTime.Today;
            isUpdating = false;
        }

        public async Task RemoveRollAndLocation(string rollNumber)
        {
            Console.WriteLine(rollNumber);
            Console.WriteLine(JsonSerializer.Serialize(MaterialModel.RollsAndLocations));
            var roll = MaterialModel.RollsAndLocations.FirstOrDefault(x => x.RollNumber == rollNumber);
            // adding
            if(MaterialModel.Id == Guid.Empty){
                MaterialModel.RollsAndLocations.RemoveAll(r => r.RollNumber == rollNumber);
            }else { // material exists
                await DeleteRollAndLocation(roll);
            }
        }

        public async Task setRoll(string rollNumber)
        {
            roll = rollNumber;
            isUpdating = true;
            var rollData = MaterialModel.RollsAndLocations.Find(x => x.RollNumber == rollNumber);
            RollAndLocationModel.RollNumber = rollData.RollNumber;
            RollAndLocationModel.ShelfLife = rollData.ShelfLife;
            RollAndLocationModel.TotalCount = rollData.TotalCount;
            RollAndLocationModel.BuildingOrWarehouse = rollData.BuildingOrWarehouse;
            RollAndLocationModel.TRackNumber = rollData.TRackNumber;
            RollAndLocationModel.Rack = rollData.Rack;
            RollAndLocationModel.ShadingId = rollData.ShadingId;
            RollAndLocationModel.DateAcquired = rollData.DateAcquired;
            RollAndLocationModel.PONumber = rollData.PONumber;
            RollAndLocationModel.ShippedCount = rollData.ShippedCount;
            RollAndLocationModel.ReceivedCount = rollData.ReceivedCount;
            RollAndLocationModel.IncomingCount = rollData.IncomingCount;
            RollAndLocationModel.ConsumeBeforeDate = rollData.DateAcquired.AddYears((int)RollAndLocationModel.ShelfLife);
        }

        public async Task UpdateRollAndLocation(string rollNumber)
        {
            var rollData = MaterialModel.RollsAndLocations.Find(x => x.RollNumber == rollNumber);

            rollData.RollNumber = RollAndLocationModel.RollNumber;
            rollData.ShelfLife = RollAndLocationModel.ShelfLife;
            rollData.TotalCount = RollAndLocationModel.TotalCount;
            rollData.PONumber = RollAndLocationModel.PONumber;
            rollData.ShippedCount = RollAndLocationModel.ShippedCount;
            rollData.ReceivedCount= RollAndLocationModel.ReceivedCount;
            rollData.IncomingCount = RollAndLocationModel.IncomingCount;
            rollData.BuildingOrWarehouse = RollAndLocationModel.BuildingOrWarehouse;
            rollData.TRackNumber = RollAndLocationModel.TRackNumber;
            rollData.Rack = RollAndLocationModel.Rack;
            rollData.ShadingId = RollAndLocationModel.ShadingId;
            rollData.ShadingLabel = ShadingListModel.Result.Items.FirstOrDefault(x => x.Id == RollAndLocationModel.ShadingId)?.Label;
            rollData.DateAcquired = RollAndLocationModel.DateAcquired;
            rollData.ConsumeBeforeDate = RollAndLocationModel.DateAcquired.AddYears((int)RollAndLocationModel.ShelfLife);
            rollData.MaterialId = MaterialModel.Id;
            rollData.OnHandCount = RollAndLocationModel.TotalCount - RollAndLocationModel.IncomingCount;
            rollData.AvailableCount = RollAndLocationModel.TotalCount;
            // rollData.QR = await GenerateQRCode($"{MaterialModel.Name} - {RollAndLocationModel.RollNumber}");

            await UpdateRollAndLocation(rollData);
        }

        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                MaterialModel.RollsAndLocations = MaterialModel.RollsAndLocations.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;

            }
            else
            {
                if (isSortedAscending)
                {
                    MaterialModel.RollsAndLocations = MaterialModel.RollsAndLocations.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    MaterialModel.RollsAndLocations = MaterialModel.RollsAndLocations.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
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

        public async Task UpdateRollAndLocation(RollAndLocationModel roll)
        {
            await _rollAndLocationService.UpdateRollAndLocation(roll);
        }

        public async Task AddMoreAdjustmentEntry(RollAndLocationModel input)
        {
            var roll = await _rollAndLocationService.GetAllRollAndLocation(input.MaterialId, null, null, null, null, 100);

            // On Creation of Material
            if (input.MaterialId == Guid.Empty)
            {
                await js.InvokeVoidAsync("defaultMessage", "success", "Adding Roll and Location Success!", "");
            }
            else // On Edit/Details
            {
                if (roll.Result.Items.Find(x => x.RollNumber == input.RollNumber) == null)
                {
                    await _rollAndLocationService.CreateRollAndLocation(input);

                    MaterialModel.RollsAndLocations = _rollAndLocationService.GetAllRollAndLocation(input.MaterialId, null, null, null, null, 100).Result.Items;
                    _rolls = MaterialModel.RollsAndLocations;
                }
            }
        }

        public async Task DeleteRollAndLocation(RollAndLocationModel input)
        {
            var roll = await _rollAndLocationService.GetAllRollAndLocation(input.MaterialId, null, null, null, null, 100);
           
            var rollToDelete = roll.Result.Items.FirstOrDefault(x => x.RollNumber == input.RollNumber);

            await _rollAndLocationService.DeleteRollAndLocation(rollToDelete.Id);

            MaterialModel.RollsAndLocations.RemoveAll(x => x.RollNumber == rollToDelete.RollNumber);
        }

    }
}