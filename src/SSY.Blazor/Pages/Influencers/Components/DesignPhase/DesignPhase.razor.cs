using System.Threading.Tasks;

namespace SSY.Blazor.Pages.Influencers.Components.DesignPhase;

public partial class DesignPhase
{
    [Parameter] public Guid Id { get; set; }
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

