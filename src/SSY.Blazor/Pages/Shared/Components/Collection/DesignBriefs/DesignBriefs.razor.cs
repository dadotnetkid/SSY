namespace SSY.Blazor.Pages.Shared.Components.Collection.DesignBriefs
{
    public partial class DesignBriefs
    {
        public DesignBriefs()
        {
        }


        public string Module = "Collections";
        public string ModuleMessage = "";
        public string ModuleType = "Add";
        private TypeFormResponseDto _typeFormResponseDto;

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public DesignBriefModel DesignBriefModel { get; set; } = new();


        [Parameter]
        public TypeFormResponseDto TypeFormResponseDto
        {
            get => _typeFormResponseDto;
            set
            {
                if(_typeFormResponseDto==value) return;
                _typeFormResponseDto=value;
                TypeFormResponseDtoChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<TypeFormResponseDto> TypeFormResponseDtoChanged { get; set; }
        protected override async Task OnInitializedAsync()
        {
            DesignBriefModel = new();
        }

        public void RefreshActiveWearDesignResponse(TypeFormResponseDto resultContent)
        {
            TypeFormResponseDto = resultContent;
            StateHasChanged();
        }


    }

}