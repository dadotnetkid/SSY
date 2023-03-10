namespace SSY.Blazor.Pages.CollectionAndProduct.Components.BOMs
{
    public partial class BOMs
    {
        public BOMs()
        {
        }

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        private CollectionService _collectionService { get; set; }
        private MaterialService _materialService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public string PageName { get; set; }

        public string Module = "BOMS";

        public GetAllCollectionList CollectionListModel { get; set; } = new() { Items = new() };
        public GetAllMaterialOutputModel MaterialListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };

        public List<BOM> BOMList { get; set; } = new();
        public List<BOMContent> BOMContentList { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

            CollectionListModel = await _collectionService.GetAllCollectionV2(null, null, null, 1000);
            MaterialListModel = await _materialService.GetAllMaterial(2, null, null, null, null, 10000);
            ColorList = await _getDropdownService.GetAllColor(null, null, null, 100);

            await GetBOM();
        }

        public async Task GetBOM()
        {
            BOMList.Clear();

            CollectionListModel.Items.ForEach(x =>
            {
                x.ColorOptions.ForEach(c =>
                {
                    c.Fabrics.ForEach(fabric => {
                        if (c.IsApproved != null && c.IsApproved == true)
                        {
                            BOMList.Add(new() { MaterialId = fabric.MaterialId, CollectionId = c.CollectionId });
                        }
                    });
                });
            });

            BOMContentList.Clear();

            BOMList.ForEach(x =>
            {

                var material = MaterialListModel.Result.Items.Find(m => m.Id == x.MaterialId);

                if (material != null)
                {
                    List<UsedCollection> UsedCollections = new();

                    material.RollsAndLocations.ForEach(r =>
                    {
                        r.RollReservations.ForEach(rr =>
                        {
                            UsedCollections.Add(new() { ReservationCount = rr.ReservationCount, CollectionName = rr.CollectionName });
                        });
                    });

                    BOMContentList.Add(new()
                    {
                        MaterialId = x.MaterialId,
                        MaterialName = material.Name,
                        Thumbnail = material.Image,
                        ItemCode = material.ItemCode,
                        ColorCode = material.ColorCode,
                        ColorName = material.ColorValue,
                        TotalReservedAmount = material.ReservedCount.Value,
                        UnitOfMeasurement = material.UnitOfMeasurementValue,
                        UsedCollections = UsedCollections
                    });
                }
            });
        }

        public class BOM
        {
            public Guid MaterialId { get; set; }
            public Guid CollectionId { get; set; }
        }

        public class BOMContent
        {
            public Guid MaterialId { get; set; }
            public string MaterialName { get; set; }
            public string Thumbnail { get; set; }
            public string ItemCode { get; set; }
            public int ColorId { get; set; }
            public string ColorCode { get; set; }
            public string ColorName { get; set; }
            public double TotalReservedAmount { get; set; }
            public string UnitOfMeasurement { get; set; }
            public string ReservedForThisCollection { get; set; }
            public List<UsedCollection> UsedCollections { get; set; }
        }

        public class UsedCollection
        {
            public double ReservationCount { get; set; }
            public string CollectionName { get; set; }
        }
    }

}