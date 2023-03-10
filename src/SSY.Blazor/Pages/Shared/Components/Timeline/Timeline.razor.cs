using SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Timelines;

namespace SSY.Blazor.Pages.Shared.Components.Timeline
{

    public partial class Timeline
    {
        #region Injections

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }

        private TimelineService _timelineService { get; set; }

   
        #endregion

        #region Parameters

        [Parameter]
        public string? PageName { get; set; }

        [Parameter]
        public Guid? RootId { get; set; } 

        public int TotalCount = 0;

        #endregion
      
        #region Models


        
        public GetAllTimelineOutputModel GetAllTimelineOutputModel { get; set; } = new() { Result = new() { Items = new() } };

        #endregion

        protected override async Task OnInitializedAsync()
        {
            _timelineService = new(js, ClientFactory, NavigationManager, Configuration);

            GetAllTimelineOutputModel = await _timelineService.GetAllTimelines(null, null, null);

        }
    }
}
