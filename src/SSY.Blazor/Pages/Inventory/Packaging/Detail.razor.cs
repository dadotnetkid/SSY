namespace SSY.Blazor.Pages.Inventory.Packaging
{
    public partial class Detail
    {
        public Detail()
        {
        }

        private string Module = "Packaging";
        private bool IsEditable = false;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}