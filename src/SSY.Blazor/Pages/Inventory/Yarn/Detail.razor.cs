using Microsoft.AspNetCore.Components;


namespace SSY.Blazor.Pages.Inventory.Yarn
{
    public partial class Detail
    {
        public Detail()
        {
        }

        private string Module = "Yarn";
        private bool IsEditable = false;
        private string ModuleMessage = "";
        public string MaterialCategory = "Yarn";

        [Parameter]
        public Guid Id { get; set; }
    }
}

