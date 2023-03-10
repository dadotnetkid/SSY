using System.Threading.Tasks;

namespace SSY.Influencer.Blazor.Pages.Influencers.Admin.Influencers.Components.Financials;

public partial class Financials
{
    public string Module = "Financial";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    string selectedComponent = "Financials";
    public string SelectedComponent { get; set; } = "Financials";
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

