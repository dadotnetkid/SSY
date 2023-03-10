namespace SSY.Blazor.Pages.Shared.Components.CompositionAndConstruction
{
    public partial class CompositionAndConstruction
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

        public RecycledListModel recycledListModel { get; set; } = new() { Result = new() { Items = new() } };
        public PFPListModel pFPListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CompressionListModel compressionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public FabricStretchListModel fabricStretchListModel { get; set; } = new() { Result = new() { Items = new() } };
        public CreaseListModel creaseListModel { get; set; } = new() { Result = new() { Items = new() } };
        public PrintRepeatListModel printRepeatListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ExcessListModel excessListModel { get; set; } = new() { Result = new() { Items = new() } };
        public HandFeelListModel HandFeelListModel { get; set; } = new() { Result = new() { Items = new() } };


        public MaterialModel MaterialModel { get; set; } = new();

        [Parameter]
        public CompositionAndConstructionModel CompositionAndConstructionModel { get; set; } = new();
        [Parameter]
        public string MaterialCategory { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }
        public int handFeelId { get; set; }

        public string handFeelText = "No Selected Hand Feel";


        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }


        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            System.Console.WriteLine(JsonSerializer.Serialize(CompositionAndConstructionModel));
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                var recycled = await _getDropdownService.GetAllRecycled(null, null, null, 100);
                recycledListModel = recycled;

                var pfp = await _getDropdownService.GetAllPreparedForPrint(null, null, null, 100);
                pFPListModel = pfp;

                var compression = await _getDropdownService.GetAllCompression(null, null, null, 100);
                compressionListModel = compression;

                var fabricStretch = await _getDropdownService.GetAllFabricStretch(null, null, null, 100);
                fabricStretchListModel = fabricStretch;

                var crease = await _getDropdownService.GetAllCrease(null, null, null, 100);
                creaseListModel = crease;

                var printRepeat = await _getDropdownService.GetAllPrintRepeat(null, null, null, 100);
                printRepeatListModel = printRepeat;

                var excess = await _getDropdownService.GetAllExcess(null, null, null, 100);
                excessListModel = excess;

                var handfeel = await _getDropdownService.GetAllHandFeel(null, null, null, 100);
                HandFeelListModel = handfeel;

                await GenerateHandFeelText();

            }

            StateHasChanged();

        }

        public async Task GenerateHandFeelText()
        {
            handFeelText = "";
            foreach (var item in HandFeelListModel?.Result?.Items)
            {
                if (CompositionAndConstructionModel.HandFeelIdList.Contains(item.Id) == true)
                {
                    handFeelText += item.Label + ", ";
                }
            }

            if (!string.IsNullOrWhiteSpace(handFeelText))
            {
                handFeelText = handFeelText.Remove(handFeelText.Length - 2, 1);
            }
            else
            {
                handFeelText = "No Selected Hand Feel";
            }
        }


        public async Task OnChangeMinmumStockLevel(string input)
        {
            CompositionAndConstructionModel.MinimumStockLevel = double.Parse(input);
        }
        public async Task onChangeHandFeel(int value, bool checkedValue)
        {
            if (checkedValue)
            {
                if (!CompositionAndConstructionModel.HandFeelIdList.Contains(value))
                {
                    CompositionAndConstructionModel.HandFeelIdList.Add(value);
                }
            }
            else
            {
                if (CompositionAndConstructionModel.HandFeelIdList.Contains(value))
                {
                    CompositionAndConstructionModel.HandFeelIdList.Remove(value);
                }
            }
            await GenerateHandFeelText();
        }
    }
}