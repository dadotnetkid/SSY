using Blazorise.DataGrid;

namespace SSY.Blazor.Pages.Inventory.ReservationOverview
{
    public partial class ReservationOverview
    {
        public ReservationOverview()
        {
        }

        #region Injections

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private MaterialService _materialService { get; set; }
        private SubMaterialService _subMaterialService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        #endregion

        #region Models

        public List<MaterialModel> _materialsOriginal { get; set; } = new();
        public List<SubMaterialModel> _subMaterialsOriginal { get; set; } = new();

        public List<MaterialModel> _materials { get; set; } = new();
        public List<SubMaterialModel> _subMaterials { get; set; } = new();
        public List<UserDetailModel> _influencer { get; set; } = new();

        public UserDetailModel UserDetailModel { get; set; } = new();

        public ColorListModel ColorDropdownListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllWarehouseOutputModel WarehouseList { get; set; } = new() { Result = new() { Items = new() } };
        public TypeListModel MaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };

        List<string> multipleSelectionData = new();
        List<string> multipleSelectionTexts = new();
        public string[] Influencers { get; set; } = new string[] { };
        public string[] ColorIds { get; set; } = new string[] { };
        public string[] MaterialTypeIds { get; set; } = new string[] { };
        public string[] Warehouses { get; set; } = new string[] { };
        public List<MaterialModel> FilteredByColorMaterialListModel { get; set; } = new();
        public List<MaterialModel> FilteredByWarehouseMaterialListModel { get; set; } = new();
        public List<MaterialModel> FilteredByMaterialTypeMaterialListModel { get; set; } = new();

        private WarehouseService _warehouseService { get; set; }
        #endregion
        private string customFilterValue;

        private string Module = "Reservation Overview";
        private string ModuleMessage = "";
        private int CategoryId = 3;
        public string Details = "Inventory";

        bool IsVisibleMaterial = true;
        bool IsVisibleSubMaterial = true;
        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
                _warehouseService = new(js, ClientFactory, NavigationManager, Configuration);
                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

                WarehouseList = await _warehouseService.GetAllWarehouse(null, null, null, 100);
                ColorDropdownListModel = await _getDropdownService.GetAllColor(null, null, null, 100);
                MaterialTypeModel = await _getDropdownService.GetAllMaterialType(CategoryId, null, null, null, 100);

                var materialResponse = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000);
                var subMaterialmaterialResponse = await _subMaterialService.GetAllSubMaterial(null, null, null, null, 1000000);

                foreach (var material in materialResponse.Result.Items)
                {
                    if (material.RollsAndLocations != null || material.RollsAndLocations.Count() != 0)
                    {
                        if (material.RollsAndLocations.Exists(r => r.IsDisposal == false))
                        {
                            _materials.Add(material);
                            foreach (var roll in material.RollsAndLocations)
                            {
                                if (roll.RollReservations.Count != 0)
                                {
                                    material.Reservations.AddRange(roll.RollReservations);
                                }
                            }
                        }
                    }
                }

                _materials = _materials.OrderByDescending(l => l.Reservations.Count()).ToList();
                _subMaterials = subMaterialmaterialResponse.Result.Items.OrderByDescending(l => l.SubMaterialReservations.Count()).ToList();
                System.Console.WriteLine(JsonSerializer.Serialize(_materials));

                _materials.ForEach(material =>
                {
                    material.Reservations.GroupBy(x => x.CollectionId).ToList().ForEach(x =>
                    {
                        x.GroupBy(x => x.RollBuildingOrWarehouse).ToList().ForEach(y =>
                        {
                            ReservationOverviewModel reservationOverview = new();

                            reservationOverview.CollectionName = y.FirstOrDefault().CollectionName;
                            reservationOverview.Warehouse = y.FirstOrDefault().RollBuildingOrWarehouse;
                            reservationOverview.ReservedForCollection = 0;
                            reservationOverview.UsedForCollectionActual = 0;
                            reservationOverview.UsedForCollectionCalculated = 0;

                            y.ToList().ForEach(r =>
                            {
                                reservationOverview.ReservedForCollection = reservationOverview.ReservedForCollection + r.ReservationCount;
                            });

                            material.ReservationOverviews.Add(reservationOverview);
                        });

                    });
                });

                _subMaterials.ForEach(subMaterial =>
                {


                    subMaterial.SubMaterialReservations.GroupBy(x => x.CollectionId).ToList().ForEach(x =>
                    {
                        x.GroupBy(x => x.BuildingOrWarehouse).ToList().ForEach(y =>
                        {
                            ReservationOverviewModel reservationOverview = new();

                            reservationOverview.CollectionName = y.FirstOrDefault().CollectionName;
                            reservationOverview.Warehouse = y.FirstOrDefault().BuildingOrWarehouse;
                            reservationOverview.ReservedForCollection = 0;
                            reservationOverview.UsedForCollectionActual = 0;
                            reservationOverview.UsedForCollectionCalculated = 0;

                            y.ToList().ForEach(r =>
                            {
                                reservationOverview.ReservedForCollection = reservationOverview.ReservedForCollection + r.ReservationCount;
                            });

                            subMaterial.ReservationOverviews.Add(reservationOverview);
                        });

                    });
                });

                _materialsOriginal = _materials;
                _subMaterialsOriginal = _subMaterials;

                await base.OnInitializedAsync();

            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                }
                await js.InvokeVoidAsync("loadMultiSelectSearch");

                IsLoading = false;

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }

        }

        public async Task GetFilteredByWarehouse()
        {
            FilteredByWarehouseMaterialListModel.Clear();
            IList<string> warehousesList = (IList<string>)Warehouses;
            foreach (var warehouse in warehousesList)
            {
                foreach (var material in _materials)
                {
                    if (material.RollsAndLocations.Exists(r => r.BuildingOrWarehouse == warehouse))
                        FilteredByWarehouseMaterialListModel.Add(material);
                }
            }
            if (!Warehouses.Any())
                FilteredByWarehouseMaterialListModel.AddRange(_materialsOriginal);
        }

        public async Task GetFilteredByColor()
        {
            FilteredByColorMaterialListModel.Clear();
            IList<string> ids = (IList<string>)ColorIds;
            foreach (var id in ids) FilteredByColorMaterialListModel.AddRange(_materialsOriginal.FindAll(m => m.ColorId == Int32.Parse(id)));

            if (!ColorIds.Any())
                FilteredByColorMaterialListModel.AddRange(_materials);
        }

        public async Task GetFilteredByMaterialType()
        {
            FilteredByMaterialTypeMaterialListModel.Clear();
            IList<string> ids = (IList<string>)MaterialTypeIds;
            foreach (var id in ids) FilteredByMaterialTypeMaterialListModel.AddRange(_materialsOriginal.FindAll(m => m.TypeId == Int32.Parse(id)));

            if (!MaterialTypeIds.Any())
                FilteredByMaterialTypeMaterialListModel.AddRange(_materialsOriginal);
        }

        public async Task Search()
        {
            await GetFilteredByMaterialType();
            await GetFilteredByColor();
            await GetFilteredByWarehouse();

            _materials = _materialsOriginal;
            _materials = (List<MaterialModel>)_materials.Intersect(FilteredByMaterialTypeMaterialListModel);
            _materials = (List<MaterialModel>)_materials.Intersect(FilteredByColorMaterialListModel);
            _materials = (List<MaterialModel>)_materials.Intersect(FilteredByWarehouseMaterialListModel);

        }



        public async Task OnSearch(string value)
        {
            Console.WriteLine(value);
            _materialsOriginal.FindAll(x => x.Name.Contains(value));
            _subMaterialsOriginal.FindAll(x => x.Name.Contains(value));
            //Console.WriteLine(JsonSerializer.Serialize(_materialsOriginal));
            _materials = _materialsOriginal.FindAll(x => x.Name.Contains(value, StringComparison.OrdinalIgnoreCase));
            _subMaterials = _subMaterialsOriginal.FindAll(x => x.Name.Contains(value, StringComparison.OrdinalIgnoreCase));
        }

        public void OnRowStyling(MaterialModel MaterialModel, DataGridRowStyling styling)
        {
            styling.Style = "background-color:#808080;color:white;";
        }


    }


}

