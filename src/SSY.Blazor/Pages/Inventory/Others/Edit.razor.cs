namespace SSY.Blazor.Pages.Inventory.Others
{
    public partial class Edit
    {
        public Edit()
        {
        }

        private string Module = "Others";
        private bool IsEditable = true;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}