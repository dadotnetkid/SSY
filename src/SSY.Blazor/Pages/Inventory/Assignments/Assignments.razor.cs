namespace SSY.Blazor.Pages.Inventory.Assignments
{
    public partial class Assignments
    {
        public Assignments()
        {
        }

        // protected override void OnInitialized()
        // {
        //     productListModel = new();
        // }


        public int Counter { get; set; } = 1;

        [Inject]
        public IJSRuntime js { get; set; }

        [Inject]
        public ProtectedSessionStorage SessionStorage { get; set; }
        // [Inject]
 //       public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        // public ProductListModel productListModel { get; set; }

        public string Module = "Adjustments";
        public string ModuleMessage = "";


     

    }


}

