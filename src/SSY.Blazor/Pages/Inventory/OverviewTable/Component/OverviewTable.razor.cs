namespace SSY.Blazor.Pages.Inventory.OverviewTable.Component
{
    public partial class OverviewTable
    {


        #region Injections

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private ProductAssignmentService _productAssignmentService { get; set; }
        private MaterialService _materialService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }

        private DeleteDataByIdService _deleteDataByIdService { get; set; }

        #endregion

        #region Parameters


        [Parameter]
        public string Module { get; set; }
        #endregion

        #region Models

        //for sorting
        bool collapse1Visible = true;
        bool collapse2Visible = false;
        bool collapse3Visible = false;


        #endregion

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

            }

        }

    }
}
