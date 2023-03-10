using System.Threading.Tasks;

namespace SSY.Influencer.Blazor.Pages.Influencers.Admin.Influencers.Components.DesignPhase;

public partial class DesignPhase
{
    public string Module = "Design Phase";
    public string ModuleMessage = "";
    public string ModuleChange = "";

    string selectedComponent = "DesignPhase";
    public string SelectedComponent { get; set; } = "DesignPhase";
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

