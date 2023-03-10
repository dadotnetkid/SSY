using Microsoft.AspNetCore.Components;


namespace SSY.Blazor.Pages.Inventory.Yarn
{
    public partial class Edit
    {
        public Edit()
        {
        }

        private string Module = "Yarn";
        private bool IsEditable = true;
        private string ModuleMessage = "";
        public string MaterialCategory = "Yarn";

        [Parameter]
        public Guid Id { get; set; }
    }
}

