namespace SSY.Blazor.Pages.Inventory.Greige
{
    public partial class Detail
    {
        public Detail()
        {
        }

        private string Module = "Greige";
        private bool IsEditable = false;
        private string ModuleMessage = "";
       

        [Parameter]
        public Guid Id { get; set; }
    }
}

