namespace SSY.Blazor.Pages.Inventory.Greige
{
    public partial class Edit
    {
        public Edit()
        {
        }

        private string Module = "Greige";
        private bool IsEditable = true;
        private string ModuleMessage = "";

        [Parameter]
        public Guid Id { get; set; }

    }
}

