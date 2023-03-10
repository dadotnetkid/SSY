namespace SSY.Blazor.Pages.Inventory.Packaging
{
    public partial class Edit
    {
        public Edit()
        {
        }

        private string Module = "Packaging";
        private bool IsEditable = true;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}