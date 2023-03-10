namespace SSY.Blazor.Pages.Inventory.Fabric
{
    public partial class Detail
    {
        public Detail()
        {
        }

        private string Module = "Fabric";
        private bool IsEditable = false;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}

