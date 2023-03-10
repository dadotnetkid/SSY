namespace SSY.Blazor.Pages.Settings.Components.ColorConfiguration

{
    public partial class ColorConfiguration
    {
        public ColorConfiguration()
        {
        }

        public string Module = "ColorConfiguration";
        public string ModuleMessage = "";
        public string ModuleType = "Edit";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public ColorService _colorService { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        public ColorModel ColorModel { get; set; } = new();

        public CreateColorModel CreateColorModel { get; set; } = new();

        public GetAllColorOutputModel ColorListModel { get; set; } = new() { Result = new() { Items = new() } };

        public bool IsAddColor { get; set; } = true;

        public async Task ClearAll()
        {
            ColorModel.Id = default;
            ColorModel.Label = default;
            ColorModel.Value = default;
            ColorModel.SalesPercentage = default;
            ColorModel.OrderNumber = default;
            ColorModel.ShortCode = default;
            ColorModel.HexCode = default;
        }

        protected override async Task OnInitializedAsync()
        {
            _colorService = new(js, ClientFactory, NavigationManager, Configuration);

            ColorListModel = await _colorService.GetAllColor(null, null, null, 100);
        }


        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                CreateColorModel input = new()
                {
                    Label = ColorModel.Label,
                    Value = ColorModel.Label,
                    SalesPercentage = ColorModel.SalesPercentage,
                    OrderNumber = ColorModel.OrderNumber,
                    ShortCode = ColorModel.ShortCode,
                    HexCode = ColorModel.HexCode
                };

                await _colorService.CreateColor(input);

            }
            else
            {
                UpdateColorModel input = new()
                {
                    Id = ColorModel.Id,
                    Label = ColorModel.Label,
                    Value = ColorModel.Label,
                    SalesPercentage = ColorModel.SalesPercentage,
                    OrderNumber = ColorModel.OrderNumber,
                    ShortCode = ColorModel.ShortCode,
                    HexCode = ColorModel.HexCode,
                };

                await _colorService.UpdateColor(input);
            }

            await Refresh();
            await ClearAll();
        }

        public async Task Refresh()
        {
            ColorListModel = await _colorService.GetAllColor(null, null, null, 100);
        }

        public async Task EditColor(int id)
        {
            await ClearAll();
            IsAddColor = false;

            var result = await _colorService.GetColor(id);
            ColorModel.Id = result.Result.Id;
            ColorModel.Label = result.Result.Label;
            ColorModel.Value = result.Result.Label;
            ColorModel.SalesPercentage = result.Result.SalesPercentage;
            ColorModel.OrderNumber = result.Result.OrderNumber;
            ColorModel.ShortCode = result.Result.ShortCode;
            ColorModel.HexCode = result.Result.HexCode;
            ModuleMessage = "Edit";
        }

        public async Task RemoveColor(int id)
        {
            await _colorService.DeleteColor(id);
            await Refresh();
        }

        public async Task AddColorHandler()
        {
            IsAddColor = true;
            await ClearAll();
        }
    }
}