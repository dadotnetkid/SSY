using Microsoft.AspNetCore.Components;


namespace SSY.Blazor.Pages.Inventory.Yarn
{
    public partial class Index
    {
        public Index()
        {
        }

        private string Module = "Yarn";
        private bool IsEditable = true;
        private string ModuleMessage = "";
        private int CategoryId = 5;
    }
}