namespace SSY.Blazor.Pages.Influencers.Components.LaunchPhases;

public partial class LaunchPhases
{
    public string Module = "Launch Phase";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    string selectedComponent = "Launch Phase";
    public string SelectedComponent { get; set; } = "Launch Phase";
    public Guid Id { get; set; }

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

