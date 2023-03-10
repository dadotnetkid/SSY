using System.Threading.Tasks;

namespace SSY.Influencer.Blazor.Pages.Influencers.Admin.Influencers.Components.Messaging;

public partial class Messaging
{
    public string Module = "Messaging";
    public string ModuleMessage = "";
    public string ModuleChange = "";

    string selectedComponent = "Messaging";
    public string SelectedComponent { get; set; } = "Messaging";
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

