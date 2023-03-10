namespace SSY.Blazor.Pages.Shared.Pages.Inventory.Material
{
    public partial class MaterialIndex
    {
        public MaterialIndex()
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

        //private UserService _userService { get; set; }
        public MaterialService _materialService { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int CategoryId { get; set; }
        [Parameter]
        public bool IsEditable { get; set; }
        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public string ModuleMessage { get; set; }

        public string Details = "Inventory";

        #endregion

        #region Models

        private MaterialModel MaterialModel { get; set; } = new();

        #endregion


        public MaterialListModel GreigeListTable { get; set; } = new();

        protected override void OnInitialized()
        {
            //_userService = new(js, ClientFactory, NavigationManager, Configuration,LocalStorage);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
          
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetMaterial();
             //   await _userService.CheckAdminCredential();
            }
            StateHasChanged();
        }

        public async Task GetMaterial()
        {
            var maxResultCount = 100;
            var material = await _materialService.GetAllMaterial(CategoryId, null, null, null, null, maxResultCount); 

            foreach (var item in material.Result.Items)
            {
            
                      GreigeListTable.Materials.Add(item);
        
              
            }

        }

    }


}

