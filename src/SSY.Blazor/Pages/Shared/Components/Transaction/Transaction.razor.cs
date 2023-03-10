namespace SSY.Blazor.Pages.Shared.Components.Transaction
{
    public partial class Transaction
    {
        public Transaction()
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
        public TransactionService _transactionService { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public int CategoryId { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }

        public List<TransactionModel> TransactionList { get; set; } = new();

        public TransactionModel TransactionModel { get; set; } = new();

        private bool isSortedAscending;
        private string activeSortColumn;

        protected override async Task OnInitializedAsync()
        {
            _transactionService = new(js, ClientFactory, NavigationManager, Configuration);

            await GetAllTransactions();
        }

        public async Task GetAllTransactions()
        {
            var transaction = await _transactionService.GetAllTransaction(Id);

            TransactionList = transaction.Result.Items;
        }

        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                CreateTransactionModel input = new()
                {
                    MaterialId = Id,
                    OrderNumber = TransactionModel.OrderNumber,
                    OrderType = TransactionModel.OrderType,
                    Quantity = TransactionModel.Quantity,
                    OrderDate = TransactionModel.OrderDate
                };

                if (CategoryId == 1 || CategoryId == 2)
                {
                    input.MaterialId = Id;

                    await _transactionService.CreateMaterialTransaction(input);
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    input.MaterialId = Id;

                    await _transactionService.CreateSubMaterialTransaction(input);
                }
            }
            else
            {
                UpdateTransactionModel input = new()
                {
                    Id = TransactionModel.Id,
                    MaterialId = TransactionModel.MaterialId,
                    OrderNumber = TransactionModel.OrderNumber,
                    OrderType = TransactionModel.OrderType,
                    Quantity = TransactionModel.Quantity,
                    OrderDate = TransactionModel.OrderDate
                };

                if (CategoryId == 1 || CategoryId == 2)
                {
                    input.MaterialId = Id;

                    await _transactionService.UpdateMaterialTransaction(input);
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    input.MaterialId = Id;

                    await _transactionService.UpdateSubMaterialTransaction(input);
                }
            }

            await ClearAll();
        }

        public async Task ClearAll()
        {
            TransactionModel.OrderNumber = string.Empty;
            TransactionModel.OrderType = string.Empty;
            TransactionModel.Quantity = 0;
            TransactionModel.OrderDate = DateTime.Now;
            ModuleMessage = "";

            await GetAllTransactions();
        }

        public async Task EditTransaction(Guid id)
        {
            var result = await _transactionService.GetTransaction(id);
            TransactionModel.Id = result.Result.Id;
            TransactionModel.MaterialId = result.Result.MaterialId;
            TransactionModel.OrderNumber = result.Result.OrderNumber;
            TransactionModel.OrderType = result.Result.OrderType;
            TransactionModel.Quantity = result.Result.Quantity;
            TransactionModel.OrderDate = result.Result.OrderDate;

            ModuleMessage = "Edit";
        }

        public async Task RemoveTransaction(Guid id)
        {
            if (CategoryId == 1 || CategoryId == 2)
            {
                await _transactionService.DeleteMaterialTransaction(id);
            }
            if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
            {
                await _transactionService.DeleteSubMaterialTransaction(id);
            }

            await ClearAll();
        }

        private void SortTable(string columnName)
    {
        if (columnName != activeSortColumn)
        {
            TransactionList = TransactionList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            isSortedAscending = true;
            activeSortColumn = columnName;

        }
        else
        {
            if (isSortedAscending)
            {
                TransactionList = TransactionList.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            else
            {
                TransactionList = TransactionList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
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