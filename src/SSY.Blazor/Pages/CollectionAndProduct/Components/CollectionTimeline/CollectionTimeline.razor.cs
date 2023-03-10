using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Timelines;

namespace SSY.Blazor.Pages.CollectionAndProduct.Components.CollectionTimeline
{
    public partial class CollectionTimeline
    {
        public CollectionTimeline()
        {
        }

        

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public string PageName { get; set; } = "Timeline";

        private string Module = "All";
        private int CategoryId = 1;

        public TimelineListModel TimelineListTable { get; set; } = new();
        public List<CollectionTimelineOutputModel> CollectionTimelineList { get; set; } = new();

        [Parameter]
        public List<UserDetailModelCC> UserDetailListModel { get; set; } = new();

        #region Services

        public CollectionService _collectionService { get; set; }
        public UserDetailService _userDetailService { get; set; }

        #endregion

        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                
                TimelineListTable = new() { Timelines = new() };
                this._collectionService = new(js, ClientFactory, NavigationManager, Configuration);
                _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);

            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    this.CollectionTimelineList = await _collectionService.GetCollectionTimelineV2Async();
                    UserDetailListModel = (await _userDetailService.GetAllUserCC(null, null, null, null, null, 999)).Result.Items;
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
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
            
        }


    }

}