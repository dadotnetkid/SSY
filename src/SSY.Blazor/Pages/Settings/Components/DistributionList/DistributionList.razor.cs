namespace SSY.Blazor.Pages.Settings.Components.DistributionList
{
    public partial class DistributionList
    {
        public DistributionList()
        {
        }

        public string Module = "DistributionList";
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
        public ReservationColorService _reservationColorService { get; set; }
        public TypeService _typeService { get; set; }
        public GetDropdownService _dropDownService { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        public ReservationColorModel ReservationColorModel { get; set; } = new();

        public CreateReservationColorModel CreateReservationColorModel { get; set; } = new();

        public GetAllReservationColorOutputModel ReservationColorListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllTypeOutputModel TypeModelList { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetReservationColorOutputModel ReservationColor { get; set; } = new() { Result = new() };


        //protected override async Task OnInitializedAsync()
        //{
        //    _reservationColorService = new(js, ClientFactory, NavigationManager, Configuration);
        //    _typeService = new(js, ClientFactory, NavigationManager, Configuration);
        //    _dropDownService = new(js, ClientFactory, NavigationManager, Configuration);

        //    ReservationColorListModel = await _reservationColorService.GetAllReservationColor();
        //    ColorListModel = await _dropDownService.GetAllColor(null, null, null, 100);
        //    Console.WriteLine(JsonSerializer.Serialize(ReservationColorListModel));
        //}


        //public async Task OnSubmit()
        //{
        //    Console.WriteLine(ModuleMessage);
        //    if (ModuleMessage != "Edit")
        //    {
        //        CreateReservationColorModel input = new()
        //        {
        //            ColorId = ReservationColorModel.ColorId,
        //            SalesPercentage = ReservationColorModel.SalesPercentage,
        //            AverageConsumption = ReservationColorModel.AverageConsumption

        //        };

        //        await _reservationColorService.CreateProductReservationColor(input);

        //    }
        //    else
        //    {
        //        UpdateReservationColorModel input = new()
        //        {
        //            Id = ReservationColorModel.Id,
        //            ColorId = ReservationColorModel.ColorId,
        //            SalesPercentage = ReservationColorModel.SalesPercentage,
        //            AverageConsumption = ReservationColorModel.AverageConsumption

        //        };

        //        await _reservationColorService.UpdateProductReservationColor(input);
        //    }

        //    await Refresh();
        //}

        //public async Task Refresh()
        //{
        //    ReservationColorListModel = await _reservationColorService.GetAllReservationColor();
        //}

        //public async Task ClearAll()
        //{

        //}

        //public async Task EditProductReservationColor(int id)
        //{
        //    var result = await _reservationColorService.GetReservationColor(id);
        //    ReservationColorModel.Id = result.Result.Id;
        //    ReservationColorModel.ColorId = result.Result.ColorId;
        //    ReservationColorModel.SalesPercentage = result.Result.SalesPercentage;
        //    ReservationColorModel.AverageConsumption = result.Result.AverageConsumption;
        //    ModuleMessage = "Edit";
        //}

        //public async Task RemoveProductReservationColor(int id)
        //{
        //    await _reservationColorService.DeleteReservationColor(id);

        //    await Refresh();
        //}

    }
}