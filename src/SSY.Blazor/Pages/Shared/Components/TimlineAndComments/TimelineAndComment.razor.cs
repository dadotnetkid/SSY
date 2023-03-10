namespace SSY.Blazor.Pages.Shared.Components.TimlineAndComments
{

    public partial class TimelineAndComment
    {

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
      

        [Parameter]
        public bool IsEditable { get; set; }   

        [Parameter]
        public string? PageName { get; set; } 
        private string SelectedTab { get; set; }

        public async Task ChangeTab(string tab)
        {
            SelectedTab = tab;
        }
    }
}
 