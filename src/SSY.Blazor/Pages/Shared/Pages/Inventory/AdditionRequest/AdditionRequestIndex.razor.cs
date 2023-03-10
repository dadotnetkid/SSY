using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model;

namespace SSY.Blazor.Pages.Shared.Pages.Inventory.AdditionRequest
{
	public partial class AdditionRequestIndex
	{
		public AdditionRequestIndex()
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

       // private UserService _userService { get; set; }
        public AdditionRequestService _additionRequestService { get; set; }
        public CollectionService  _collectionService { get; set; }

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

        public string Details = "Addition Request";

        #endregion

        #region Models

        private MaterialModel MaterialModel { get; set; } = new();
        public GetAllCollectionOutputModel CollectionListModel { get; set; } = new() { Result = new() { Items = new() } };

        public GetAllCollectionListDto GetAllCollectionList { get; set; } = new();

        #endregion

        public GetAllAdditionRequestOutputModel AdditionRequestListModel { get; set; } = new() { Result = new() { Items = new() } };
        public IEnumerable<AdditionRequestModel> _additionRequets;
        private string customFilterValue;

        public List<Status> Statuses { get; set; } = new();

        private bool IsLoading;

        protected override async void OnInitialized()
        {
            try
            {
                IsLoading = true;

                //_userService = new(js, ClientFactory, NavigationManager, Configuration, LocalStorage);
                _additionRequestService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionService = new(js, ClientFactory, NavigationManager, Configuration);

                AdditionRequestListModel = await _additionRequestService.GetAllAdditionRequest(null, null, null, null, 1000);
                GetAllCollectionList = await _collectionService.GetAllCollectionList();

                await GetAdditionRequests();
                await GetStatus();
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                 //   await _userService.CheckAdminCredential();
                }
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

        private bool OnCustomFilter(AdditionRequestModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return model.Id.ToString()?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task GetAdditionRequests()
        {
            try
            {
                _additionRequets = new AdditionRequestModel[] { };

                AdditionRequestListModel.Result.Items.ForEach(x => {
                    var collection = GetAllCollectionList.Items.Find(c => c.Id == x.CollectionId);
                    x.Collection = x.CollectionId.Equals(Guid.Empty) ? "" : collection != null ? collection.Name : "";
                    x.Influencers = x.Influencers == null || x.Influencers.Equals(string.Empty) ? "" : x.Influencers;

                });

                _additionRequets = AdditionRequestListModel.Result.Items;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out?
            }
        }

        public async Task GetStatus()
        {
            Statuses.Add(new Status { Id = 1, Value = "In Progress", HexCode = "FF8A34" });
            Statuses.Add(new Status { Id = 2, Value = "Completed", HexCode = "7B8E61" });
            Statuses.Add(new Status { Id = 3, Value = "Collection Cancelled", HexCode = "FF3C52" });
        }

        public async Task OnChangeStatus(string value, Guid id)
        {
            try
            {
                ChangeRequestStatusModel changeRequest = new() { Id = id, Status = int.Parse(value) };

                var selectedRequest = AdditionRequestListModel.Result.Items.Find(x => x.Id == id);
                if (selectedRequest != null)
                    if (changeRequest.Status == 2 && (selectedRequest.CollectionId.Equals(Guid.Empty) || selectedRequest.CollectionId.Equals(null)))
                        await js.InvokeVoidAsync("defaultMessage", "warning", "Warning", $"No Collection is connected on this Addition Request, you can't change the status to Completed.");
                    else
                        await _additionRequestService.ChangeRequestStatus(changeRequest);
                else
                    await js.InvokeVoidAsync("defaultMessage", "error", "Error", $"Addition Request not found.");
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public class Status
        {
            public int Id { get; set; }
            public string Value { get; set; }
            public string HexCode { get; set; }
        }

    }
}

