
namespace SSY.Blazor.Pages.DashboardV2
{
    public partial class DashboardV2
    {
        string selectedComponent = "salesandaccounting";
        [Parameter]
        public string SelectedComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SelectedComponent = selectedComponent;
        }

        async Task SetSelectedComponent(string selectedComponent)
        {
                 SelectedComponent = selectedComponent;
        }

        private string SetActiveIfSelected(string selectedComponent, string component)
        {
            if(selectedComponent == component)
            {
                return "active";
            }
            return "";
        }
    }
}
