namespace SSY.Blazor.Pages.Inventory.Others
{
    public partial class Detail
    {
        public Detail()
        {
        }

        private string Module = "Others";
        private bool IsEditable = false;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }
    }
}