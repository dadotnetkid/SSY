namespace SSY.Blazor.Pages.Shared.Components.Miscellaneous
{
    public partial class Miscellaneous
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

        public CareInstructionTypeListModel CareInstructionTypeListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public MaterialModel MaterialModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                var careInstructionType = await _getDropdownService.GetAllCareInstructionType(null, null, null, null);
                CareInstructionTypeListModel = careInstructionType;
                var careInstruction = CareInstructionTypeListModel?.Result.Items
                                            .Where(x => x.Id == MaterialModel.CareInstructionTypeId).FirstOrDefault()?.Value;
                MaterialModel.CareInstruction = careInstruction;
            }

            StateHasChanged();
        }


        public async Task onChangeCareInstruction(string id)
        {
            var careInstructionType = CareInstructionTypeListModel.Result.Items.Find(x => x.Id == int.Parse(id));
            MaterialModel.CareInstructionTypeValue = careInstructionType?.Value;
        }
        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }
    }
}