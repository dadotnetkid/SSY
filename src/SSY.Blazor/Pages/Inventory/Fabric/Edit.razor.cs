namespace SSY.Blazor.Pages.Inventory.Fabric
{
    public partial class Edit
    {
        public Edit()
        {
        }

        private string Module = "Fabric";
        private bool IsEditable = true;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}

