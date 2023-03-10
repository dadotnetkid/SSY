namespace SSY.Blazor.Pages.Inventory.TrimsAndAccessories
{
    public partial class Edit
    {
        public Edit()
        {
        }

        private string Module = "Trims and Accessories";
        private bool IsEditable = true;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}