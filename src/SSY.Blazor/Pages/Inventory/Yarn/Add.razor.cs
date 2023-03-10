using Microsoft.AspNetCore.Components;


namespace SSY.Blazor.Pages.Inventory.Yarn
{
    public partial class Add
    {
        public Add()
        {
        }

        private string Module = "Yarn";
        private bool IsEditable = true;
        private string ModuleMessage = "";
        private int CategoryId = 5;
        public string MaterialCategory = "Yarn";
    }
}