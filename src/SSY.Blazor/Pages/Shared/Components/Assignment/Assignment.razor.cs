namespace SSY.Blazor.Pages.Shared.Components.Assignment
{
    public partial class Assignment
    {
        public Assignment()
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
        public AssignmentService _assignmentService { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public int CategoryId { get; set; }
        [Parameter]
        public MaterialModel MaterialModel { get; set; } = new();
        [Parameter]
        public bool IsEditable { get; set; }

        public List<AssignmentModel> AssignmentList { get; set; } = new();
        public AssignmentModel AssignmentModel { get; set; } = new();

        private bool isSortedAscending;
        private string activeSortColumn;

        protected override async Task OnInitializedAsync()
        {
            _assignmentService = new(js, ClientFactory, NavigationManager, Configuration);

            await GetAllAssignment();

        }

        public async Task GetAllAssignment()
        {
            var assignment = await _assignmentService.GetAllAssignment(Id);

            AssignmentList = assignment.Result.Items;
        }

        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                CreateAssignmentModel input = new()
                {
                    MaterialId = Id,
                    ProductName = AssignmentModel.ProductName,
                    Consumption = AssignmentModel.Consumption,
                    ProductType = AssignmentModel.ProductType,
                    Collection = AssignmentModel.Collection,
                    Influencer = AssignmentModel.Influencer,
                    CreatedBy = AssignmentModel.CreatedBy
                };

                if (CategoryId == 1 || CategoryId == 2)
                {
                    input.MaterialId = Id;

                    await _assignmentService.CreateMaterialAssignment(input);
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    input.MaterialId = Id;

                    await _assignmentService.CreateSubMaterialAssignment(input);
                }
            }
            else
            {
                UpdateAssignmentModel input = new()
                {
                    Id = AssignmentModel.Id,
                    MaterialId = AssignmentModel.MaterialId,
                    ProductName = AssignmentModel.ProductName,
                    Consumption = AssignmentModel.Consumption,
                    ProductType = AssignmentModel.ProductType,
                    Collection = AssignmentModel.Collection,
                    Influencer = AssignmentModel.Influencer,
                    CreatedBy = AssignmentModel.CreatedBy
                };

                if (CategoryId == 1 || CategoryId == 2)
                {
                    input.MaterialId = Id;

                    await _assignmentService.UpdateMaterialAssignment(input);
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    input.MaterialId = Id;

                    await _assignmentService.UpdateSubMaterialAssignment(input);
                }
            }

            await ClearAll();
        }

        public async Task ClearAll()
        {
            AssignmentModel.ProductName = string.Empty;
            AssignmentModel.Consumption = 0;
            AssignmentModel.ProductType = string.Empty;
            AssignmentModel.Collection = string.Empty;
            AssignmentModel.Influencer = string.Empty;
            AssignmentModel.CreatedBy = string.Empty;
            ModuleMessage = "";

            await GetAllAssignment();
        }

        public async Task EditAssignment(Guid id)
        {
            var result = await _assignmentService.GetAssignment(id);
            AssignmentModel.Id = result.Result.Id;
            AssignmentModel.MaterialId = result.Result.MaterialId;
            AssignmentModel.ProductName = result.Result.ProductName;
            AssignmentModel.Consumption = result.Result.Consumption;
            AssignmentModel.ProductType = result.Result.ProductType;
            AssignmentModel.Collection = result.Result.Collection;
            AssignmentModel.Influencer = result.Result.Influencer;
            AssignmentModel.CreatedBy = result.Result.CreatedBy;

            ModuleMessage = "Edit";
        }

        public async Task RemoveAssignment(Guid id)
        {
            if (CategoryId == 1 || CategoryId == 2)
            {
                await _assignmentService.DeleteMaterialAssignment(id);
            }
            if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
            {
                await _assignmentService.DeleteSubMaterialAssignment(id);
            }

            await ClearAll();
        }


         private void SortTable(string columnName)
    {
        if (columnName != activeSortColumn)
        {
            AssignmentList = AssignmentList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            isSortedAscending = true;
            activeSortColumn = columnName;

        }
        else
        {
            if (isSortedAscending)
            {
                AssignmentList = AssignmentList.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            else
            {
                AssignmentList = AssignmentList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
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