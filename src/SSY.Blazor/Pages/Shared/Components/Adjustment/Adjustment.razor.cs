using SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model;
using SSY.Blazor.HttpClients.Data.Inventory.RollAdjustments.Model;

namespace SSY.Blazor.Pages.Shared.Components.Adjustment
{
    public partial class Adjustment
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private AdjustmentService _adjustmentService { get; set; }
        private RollAndLocationService _rollAndLocationService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

        public Adjustment()
        {
        }
        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public MaterialModel MaterialModel { get; set; } = new();
        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public Guid SubMaterialId { get; set; }

        [Parameter]
        public Guid MaterialId { get; set; }

        public List<Guid> MaterialIds { get; set; } = new();

        [Parameter]
        public double TotalCount { get; set; }

        [Parameter]
        public string UoM { get; set; }

        public string ModuleMessage = "";
        public string ModuleType = "edit";

        [Parameter]
        public EventCallback<Guid> OnAdjustmentSubmit { get; set; }

        [Parameter]
        public EventCallback<double> OnSubAdjustmentSubmit { get; set; }

        public AdjustmentListModel CheckAdjustmentListModel { get; set; } = new();
        public List<AdjustmentModel> AdjustmentListModel { get; set; } = new();
        public MaterialActionListModel MaterialActionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public AdjustmentModel AdjustmentModel { get; set; } = new();
        public RollAndLocationModel RollAndLocationModel { get; set; } = new();
        public GetAllRollAndLocationOutputModel GetAllRollAndLocationOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllRollAndLocationOutputModel RollAndLocationListModel { get; set; } = new() { Result = new() { Items = new() } };

        public List<GetAllAdjustmentModel> SubMaterialAdjustments { get; set; } = new();

        public string InventoryType { get; set; }
        private string SelectedRoll1 { get; set; }
        private bool isSortedAscending;
        private string activeSortColumn;
        public int Increment { get; set; }
        public int Decrement { get; set; }
        public int Disposal { get; set; }
        public bool IsAdjust { get; set; } = true;
        public int Action { get; set; } = 2;

        public List<RollAndLocationModel> SelectedRollAndLocation = new();
        public List<AdjustmentModel> SelectedAdjustment = new();

        public List<RollAdjustmentModel> RollAdjustmentListModel = new();


        protected override async Task OnInitializedAsync()
        {
            _adjustmentService = new(js, ClientFactory, NavigationManager, Configuration);
            _rollAndLocationService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);

            if (MaterialId == Guid.Empty)
            {
                // await GetAdjustments(SubMaterialId);
                AdjustmentModel.MaterialId = SubMaterialId;
                AdjustmentModel.From = TotalCount;
                await GetSubMaterialAdjustments();
            }
            else
            {
                // await GetAdjustments(MaterialId);
                await GetRollAndLocation(MaterialId);
                AdjustmentModel.MaterialId = MaterialId;
            }

            AdjustmentModel.From = TotalCount;

            MaterialActionListModel = await _getDropdownService.GetDropdown<MaterialActionListModel>("MaterialAction");

            Increment = MaterialActionListModel.Result.Items.Find(x => x.Value == "Increment").Id;
            Decrement = MaterialActionListModel.Result.Items.Find(x => x.Value == "Decrement").Id;
            Disposal = MaterialActionListModel.Result.Items.Find(x => x.Value == "Disposal").Id;

            StateHasChanged();
        }

        public async Task GetSubMaterialAdjustments()
        {
            var adjustment = await _subMaterialService.GetAllAdjustment(SubMaterialId);
            SubMaterialAdjustments = adjustment.Result;
        }

        public async Task GetRollAndLocation(Guid id)
        {
            GetAllRollAndLocationOutputModel = await _rollAndLocationService.GetAllRollAndLocation(id, null, true, null, null, null);

            // For Adjustment table
            GetAllRollAndLocationOutputModel.Result.Items.ForEach(x =>
            {
                x.RollAdjustments.ForEach(roll =>
                {
                    RollAdjustmentListModel.Add(roll);
                });
            });

            // For Roll Dropdown
            RollAndLocationListModel = await _rollAndLocationService.GetAllRollAndLocation(id, null, null, null, null, null);
        }

        public async Task OnSubmit()
        {
            try
            {
                if (MaterialId != Guid.Empty)
                {
                    AdjustmentModel.MaterialId = MaterialId;

                    var a = SelectedAdjustment.FindAll(x => x.To == 0 && Action == 2);
                    if (a.Count > 0)
                    {
                        await js.InvokeVoidAsync("defaultMessage", "error", "Add Warning!", $"Adjusment *To* must have value");
                    }

                    SelectedAdjustment.ForEach(x =>
                    {

                        if (x.From > x.To)
                        {
                            x.ActionId = Decrement;
                            x.Date = AdjustmentModel.Date;
                            x.Remarks = $"Decrement Roll {x.RollNumber}: {AdjustmentModel.Remarks}";
                        }

                        if (x.From < x.To)
                        {
                            x.ActionId = Increment;
                            x.Date = AdjustmentModel.Date;
                            x.Remarks = $"Increment Roll {x.RollNumber}: {AdjustmentModel.Remarks}";
                        }

                        if (x.To == 0)
                        {
                            x.ActionId = Disposal;
                            x.Date = AdjustmentModel.Date;
                            x.Remarks = $"Disposal Roll {x.RollNumber}: {AdjustmentModel.Remarks}";
                        }

                    });

                    await _adjustmentService.CreateMaterialAdjustment(SelectedAdjustment);

                    await GetRollAndLocation(MaterialId);

                    if (Module == "Greige")
                    {
                        NavigationManager.NavigateTo("/inventory/greige/detail/" + MaterialId, true);
                    }
                    if (Module == "Fabric")
                    {
                        NavigationManager.NavigateTo("/inventory/fabric/detail/" + MaterialId, true);
                        //await OnAdjustmentSubmit.InvokeAsync(MaterialId);
                    }
                }
                else
                {
                    if (Action == 2)
                    {

                        if (AdjustmentModel.From > AdjustmentModel.To)
                        {
                            AdjustmentModel.ActionId = Decrement;
                            AdjustmentModel.Date = AdjustmentModel.Date;
                            AdjustmentModel.Remarks = $"Decrement: {AdjustmentModel.Remarks}";
                        }

                        if (AdjustmentModel.From < AdjustmentModel.To)
                        {
                            AdjustmentModel.ActionId = Increment;
                            AdjustmentModel.Date = AdjustmentModel.Date;
                            AdjustmentModel.Remarks = $"Increment: {AdjustmentModel.Remarks}";
                        }
                    }
                    else
                    {
                        if (AdjustmentModel.To == 0)
                        {
                            AdjustmentModel.ActionId = Disposal;
                            AdjustmentModel.Date = AdjustmentModel.Date;
                            AdjustmentModel.Remarks = $"Disposal: {AdjustmentModel.Remarks}";
                        }
                    }
                    var isSuccess = await _adjustmentService.CreateSubMaterialAdjustment(AdjustmentModel);
                    if(isSuccess){
                        await OnSubAdjustmentSubmit.InvokeAsync(AdjustmentModel.To);
                        AdjustmentModel.From = AdjustmentModel.To;
                        await GetSubMaterialAdjustments();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(ex.Message));
            }
        }

        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                AdjustmentListModel = AdjustmentListModel.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;

            }
            else
            {
                if (isSortedAscending)
                {
                    AdjustmentListModel = AdjustmentListModel.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    AdjustmentListModel = AdjustmentListModel.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
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

        public async Task ChangeRoll1(RollAndLocationModel rollAndLocation, Guid rollId, bool isChecked)
        {
            try
            {
                var selectedRoll = SelectedRollAndLocation.Find(x => x == rollAndLocation);

                var selectedAdjustment = SelectedAdjustment.Find(x => x.RollId == rollAndLocation.Id);

                if (isChecked == true)
                {
                    if (selectedRoll == null)
                    {
                        SelectedRollAndLocation.Add(rollAndLocation);
                    }

                    if (selectedAdjustment == null)
                    {
                        List<CreateRollAdjustmentModel> rollAdjustment = new();
                        rollAdjustment.Add(new CreateRollAdjustmentModel()
                        {
                            TenantId = rollAndLocation.TenantId,
                            IsActive = rollAndLocation.IsActive,
                            MaterialId = rollAndLocation.MaterialId,
                            RollId = rollAndLocation.Id
                        });

                        SelectedAdjustment.Add(new AdjustmentModel()
                        {
                            TenantId = rollAndLocation.TenantId,
                            IsActive = rollAndLocation.IsActive,
                            MaterialId = rollAndLocation.MaterialId,
                            RollId = rollAndLocation.Id,
                            RollNumber = rollAndLocation.RollNumber,
                            From = (double)rollAndLocation.TotalCount,
                            RollAdjustments = rollAdjustment
                        });
                    }
                }
                else
                {
                    SelectedRollAndLocation.Remove(rollAndLocation);
                    SelectedAdjustment.Remove(selectedAdjustment);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(ex.Message));
            }
        }

        public async void OnChangeRollCount(Guid rollId, double rollCount)
        {
            try
            {

                var selectedAdjustment = SelectedAdjustment.Find(x => x.RollId == rollId);

                if (selectedAdjustment != null)
                {
                    selectedAdjustment.To = rollCount;
                    selectedAdjustment.RollAdjustments.Find(x => x.RollId == rollId).TotalCount = rollCount;

                    if (selectedAdjustment.From > selectedAdjustment.To)
                    {
                        selectedAdjustment.ActionId = Decrement;
                    }

                    if (selectedAdjustment.From < selectedAdjustment.To)
                    {
                        selectedAdjustment.ActionId = Increment;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(ex.Message));
            }
        }

        public async void OnChangeAction(string input)
        {
            try
            {
                Action = int.Parse(input);
                AdjustmentModel.Remarks = "";
                if (Action == 1)
                {
                    SelectedAdjustment.ForEach(x =>
                    {
                        x.ActionId = Disposal;
                        x.To = 0;
                        x.Date = AdjustmentModel.Date;
                        x.Remarks = $"Disposal: {AdjustmentModel.Remarks}";
                    });

                    IsAdjust = false;
                }
                else
                {
                    SelectedAdjustment.ForEach(x =>
                    {
                        x.To = x.RollAdjustments.Find(q => q.RollId == x.RollId).TotalCount;

                        if (x.From > x.To)
                        {
                            x.ActionId = Decrement;
                            x.Date = AdjustmentModel.Date;
                            x.Remarks = $"Decrement Roll {x.RollNumber}: {AdjustmentModel.Remarks}";
                        }

                        if (x.From < x.To)
                        {
                            x.ActionId = Increment;
                            x.Date = AdjustmentModel.Date;
                            x.Remarks = $"Increment Roll {x.RollNumber}: {AdjustmentModel.Remarks}";
                        }

                    });

                    IsAdjust = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(ex.Message));
            }
        }

        public void OnClose()
        {
            SelectedAdjustment = new();
            SelectedRollAndLocation = new();
        }

    }
}

