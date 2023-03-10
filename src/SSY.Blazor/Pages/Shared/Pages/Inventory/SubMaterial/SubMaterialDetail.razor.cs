namespace SSY.Blazor.Pages.Shared.Pages.Inventory.SubMaterial
{
    public partial class SubMaterialDetail
    {
        public SubMaterialDetail()
        {
        }

        #region Injects

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

    //    private UserService _userService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }

        #endregion

        #region Parameters
        [Parameter]
        public string TableItems { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public string ModuleMessage { get; set; }
        public string Crud = "Detail";
        
        public int CategoryId { get; set; }

        #endregion

        #region Models

        private SubMaterialModel SubMaterialModel { get; set; } = new();


        #endregion


        protected override async Task OnInitializedAsync()
        {
          //  _userService = new(js, ClientFactory, NavigationManager, Configuration,LocalStorage);
            _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
            await GetSubMaterial(Id);
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
            //    await _userService.CheckAdminCredential();
                StateHasChanged();
            }
        }

        public async Task GetSubMaterial(Guid id)
        {
            var subMaterial = await _subMaterialService.GetSubMaterial(id);
            SubMaterialModel = subMaterial.Result;
        }

        public async Task UpdateActualCount(double count)
        {
            SubMaterialModel.TotalCount = count;
        }

        public async Task DeleteSubMaterialReservation(SubMaterialReservationModel subMaterialReservation)
        {

            SubMaterialModel.ReservedCount = SubMaterialModel.ReservedCount - subMaterialReservation.ReservationCount;
            SubMaterialModel.AvailableCount = SubMaterialModel.AvailableCount + subMaterialReservation.ReservationCount;

        }

    }
}

