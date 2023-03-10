namespace SSY.Blazor.Pages.Inventory.TrimsAndAccessories
{
    public partial class Detail
    {
        public Detail()
        {
        }

        private string Module = "Trims and Accessories";
        private bool IsEditable = false;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}