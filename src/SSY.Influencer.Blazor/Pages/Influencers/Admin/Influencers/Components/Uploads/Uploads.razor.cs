using System.Threading.Tasks;

namespace SSY.Influencer.Blazor.Pages.Influencers.Admin.Influencers.Components.Uploads;

public partial class Uploads
{
    public string Module = "Uploads";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    string selectedComponent = "Uploads";
    public string SelectedComponent { get; set; } = "Uploads";
    async Task SetSelectedComponent(string selectedComponent)
    {
        SelectedComponent = selectedComponent;
    }

    private string SetActiveIfSelected(string selectedComponent, string component)
    {
        if (selectedComponent == component)
        {
            return "active";
        }
        return "";
    }
}

