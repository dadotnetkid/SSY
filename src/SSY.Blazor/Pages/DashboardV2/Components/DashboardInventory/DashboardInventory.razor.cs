
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Drops.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ChildProducts.Model;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes.Model;
using SSY.Blazor.HttpClients.Models.Requests;
using SSY.Blazor.Pages.Shared.Components.Collection.CollectionColorOption;
using SSY.Blazor.Pages.Shared.Components.Collection.DesignBriefs;
using static SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model.CollectionModel;
using static SSY.Blazor.Pages.Shared.Components.Collection.CollectionColorOption.CollectionColorOption;

namespace SSY.Blazor.Pages.DashboardV2.Components.DashboardInventory
{
    public partial class DashboardInventory
    {
         private string Module = "Dashboard Inventory";
        private bool IsEditable = true;
        private string ModuleMessage = "";
        private int CategoryId = 1;

        public string ModuleChange = "";
        public string CollectionDetails = "CollectionDetails";
        public string CollectionName = "";
        public string TabName = "Overview";
        public Guid CollectionId;

        [Inject] private ITypeFormApi typeFormApi { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject] ICalendarApi calendarApi { get; set; }

        [Parameter]
        public Guid Id { get; set; }

   

        [Parameter]
        public bool IsModuleAdd { get; set; } = false;

        private DesignBriefs? designBriefRef;

        public CollectionService _collectionService { get; set; }
        public TypeService _typeService { get; set; }
        public GetDropdownService _getDropdownService { get; set; }
        public MaterialService _materialService { get; set; }
        public RollAndLocationService _rollAndLocationService { get; set; }
        public ProductService _productService { get; set; }
        public UserDetailService _userDetailService { get; set; }
        public AdditionRequestTypeService _additionRequestTypeService { get; set; }
        public ReservationService _reservationService { get; set; }

        public GetCollectionOutputModel CollectionOutputModel { get; set; } = new() { Result = new() };
        public OverviewModel OverviewModel { get; set; } = new();

        public CollectionModel CollectionModel { get; set; } = new();
        public CollectionDto CollectionDto { get; set; }
        public TypeFormResponseDto DesignBriefContent { get; set; }
        public UpdateCollectionInputModel CollectionModelOld { get; set; } = new();
        public UpdateCollectionInputModel CollectionModelNew { get; set; } = new();

        public CollectionDropdownDto CollectionDropdown { get; set; } = new();
        [Parameter]
        public List<TypeModel> TypeListModel { get; set; } = new();
        [Parameter]
        public List<FactoryModel> FactoryListModel { get; set; } = new();
        [Parameter]
        public List<ShippingTypeModel> ShippingTypeListModel { get; set; } = new();
        [Parameter]
        public List<MarketingTypeModel> MarketingTypeListModel { get; set; } = new();
        [Parameter]
        public List<SeasonModel> SeasonListModel { get; set; } = new();
        [Parameter]
        public List<PricePointModel> PricePointListModel { get; set; } = new();
        [Parameter]
        public ProductTypeListModel ProductTypeListModel { get; set; } = new() { Items = new() };
        [Parameter]
        public List<ProductSizeModel> ProductSizeListModel { get; set; } = new();
        [Parameter]
        public List<UserDetailModelCC> UserDetailListModel { get; set; } = new();
        [Parameter]
        public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };
        [Parameter]
        public List<CollectionStatusModel> StatusListModel { get; set; } = new();
        [Parameter]
        public List<DropModel> DropListModel { get; set; } = new();

        [Parameter]
        public GetAllMaterialOutputModel MaterialListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public GetAllProductOutputModel ProductListModel { get; set; } = new() { Items = new() };
        public List<ProductModel> CollectionParentProductList { get; set; } = new();
        public List<ProductModel> ChildProducts { get; set; } = new();

        [Parameter]
        public List<AdditionRequestTypeModel> AdditionRequestTypeListModel { get; set; } = new();
        [Parameter]
        public MaterialCategoryListModel MaterialCategoryListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public AssignedToModel AssignedToModel { get; set; } = new();

        public string collapseInfluencer = string.Empty;
        public string collapseMaterialType = string.Empty;
        public string selectedMaterialType = string.Empty;
        public List<string> materialTypeName = new();
        public List<int> MaterialTypeIds { get; set; } = new();
        public List<int> ProductTypeIds { get; set; } = new();
        public List<string> ProductTypeNames { get; set; } = new();

        public List<CreateProductModel> Products { get; set; } = new();

        public ApproveProductModel ApproveProductModel { get; set; } = new();

        private bool IsLoading;
        private Modal ModalSaving;

        public int ConfirmedStatusId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                _productService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
                _typeService = new(js, ClientFactory, NavigationManager, Configuration);
                _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);
                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _rollAndLocationService = new(js, ClientFactory, NavigationManager, Configuration);
                _additionRequestTypeService = new(js, ClientFactory, NavigationManager, Configuration);
                _reservationService = new(js, ClientFactory, NavigationManager, Configuration);

                CollectionDropdown = await _collectionService.GetCollectionDropdowns();

                // Collection Dropdowns
                SeasonListModel = CollectionDropdown.SeasonList.Items;
                PricePointListModel = CollectionDropdown.PricePointList.Items;
                FactoryListModel = CollectionDropdown.FactoryList.Items;
                ShippingTypeListModel = CollectionDropdown.ShippingTypeList.Items;
                MarketingTypeListModel = CollectionDropdown.MarketingTypeList.Items;
                ProductSizeListModel = CollectionDropdown.SizeList.Items;
                DropListModel = CollectionDropdown.DropList.Items;
                StatusListModel = CollectionDropdown.StatusList.Items;
                UserDetailListModel = (await _userDetailService.GetAllUserCC(null, null, null, null, null, 999)).Result.Items;
                TypeListModel = (await _typeService.GetAllType(2, null, "orderNumber", null, 100)).Result.Items;
                ProductTypeListModel = await _getDropdownService.GetAllProductType(null, null, null, 100);
                ColorList = await _getDropdownService.GetAllColor(null, null, null, 100);

                MaterialListModel = await _materialService.GetAllMaterial(2, null, null, null, null, 10000);
                AdditionRequestTypeListModel = (await _additionRequestTypeService.GetAllAdditionRequestType(null, null, null, 100)).Result.Items;
                MaterialCategoryListModel = await _getDropdownService.GetAllMaterialCategory(null, null, null, 100);
                CollectionId = Id;

                ConfirmedStatusId = StatusListModel.Find(x => x.Value.Equals("Confirmed")).Id;

                await GetCollection();

                IsLoading = false;

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                Console.WriteLine($"Error: {ex.Message}{innerException} - OnInitializedAsync()");
            }
        }

        public async Task GetCollection()
        {
            try
            {
                CollectionModel = new();
                CollectionDto = await _collectionService.GetCollectionV2(Id);
                ModuleChange = CollectionDto.Name;
                CollectionName = CollectionDto.Name;

                #region Collection

                CollectionModel.Id = CollectionDto.Id;
                CollectionModel.Name = CollectionDto.Name;
                CollectionModel.FactoryId = CollectionDto.Factory.Id;
                CollectionModel.SeasonId = CollectionDto.Season.Id;
                CollectionModel.PricePointId = CollectionDto.PricePoint.Id;
                CollectionModel.ShippingTypeId = CollectionDto.ShippingType.Id;
                CollectionModel.MarketingTypeId = CollectionDto.MarketingType.Id;
                CollectionModel.IsPublished = CollectionDto.IsPublished;
                CollectionModel.Year = CollectionDto.Year;
                CollectionModel.DesignStatusId = CollectionDto.DesignStatus.Id;
                CollectionModel.StatusId = CollectionDto.Status.Id;
                CollectionModel.CollectionDevelopmentStartDate = CollectionDto.CreationTime;

                #endregion

                #region Influencers

                List<Guid> influencerIds = new();
                List<string> influencerNames = new();
                List<string> influencerFullNames = new();
                double influencerForecast = 0;

                CollectionDto.Influencers.ForEach(x =>
                {
                    var influencer = UserDetailListModel.Find(i => i.Id == x.InfluencerId);
                    influencerForecast += influencer.ProductQuantityForecast.Value;
                    influencerIds.Add(x.InfluencerId);
                    influencerNames.Add(influencer.Name);
                    influencerFullNames.Add(x.InfluencerFullName);

                    if (CollectionModel.influencers.Find(i => i.Id == x.InfluencerId) == null)
                        CollectionModel.influencers.Add(new() { Id = x.InfluencerId, InfluencerFullName = x.InfluencerFullName, Email = influencer.EmailAddress });
                });

                OverviewModel.ForecastQuantity = (int)influencerForecast;
                CollectionModel.ForecastQuantity = (int)influencerForecast;

                CollectionModel.InfluencerIdsList = influencerIds;
                OverviewModel.InfluencerIdsList = influencerIds;

                CollectionModel.Influencers = ReplaceString(string.Join(", ", influencerFullNames));
                OverviewModel.InfluencersFullName = influencerFullNames;
                OverviewModel.Influencers = influencerNames;

                #endregion

                #region MaterialProductTypes

                List<CollectionModel.MaterialProductTypes> materialProductTypes = new();
                List<TypeModel> materialTypes = new();
                List<string> materialTypeNames = new();

                // Set the Color Material Plan - Material Type
                CollectionDto.ProductTypes.ForEach(x =>
                {
                    var materialType = TypeListModel.Find(mt => mt.Id == x.ProductType.MaterialTypeId);

                    if (!materialTypes.Contains(materialType))
                        materialTypes.Add(materialType);

                    if (!MaterialTypeIds.Contains(x.ProductType.MaterialTypeId))
                        MaterialTypeIds.Add(x.ProductType.MaterialTypeId);

                    if (!materialTypeNames.Contains(materialType.Value))
                        materialTypeNames.Add(materialType.Value);
                });

                materialTypes.ForEach(materialType =>
                {

                    List<int> productTypeIds = new();
                    List<string> productTypeNames = new();
                    List<Items> productTypes = new();

                    CollectionDto.ProductTypes.ForEach(x =>
                    {
                        if (x.ProductType.MaterialTypeId == materialType.Id)
                        {
                            if (!productTypeIds.Contains(x.ProductType.Id))
                                productTypeIds.Add(x.ProductType.Id);

                            if (!productTypeNames.Contains(x.ProductType.Value))
                                productTypeNames.Add(x.ProductType.Value);
                        }

                        var product = ProductTypeListModel.Items.Find(pt => pt.Id == x.ProductType.Id);

                        if (product.MaterialTypeId == materialType.Id)
                        {
                            if (!productTypes.Contains(product))
                            {
                                product.IsSelected = true;
                                productTypes.Add(product);
                            }
                        }
                    });

                    // MaterialProductTypes

                    CollectionModel.MaterialProductTypes materialProduct = new()
                    {
                        MaterialTypeId = materialType.Id,
                        MaterialTypeName = materialType.Value,
                        ProductTypeIds = productTypeIds,
                        ProductTypeNames = productTypeNames,
                        IsApplied = true,

                        MaterialTypes = materialTypes,
                        ProductTypes = productTypes
                    };

                    // MaterialProductTypes
                    materialProductTypes.Add(new()
                    {
                        MaterialTypeId = materialType.Id,
                        MaterialTypeName = materialType.Value,
                        ProductTypeIds = productTypeIds,
                        ProductTypeNames = productTypeNames,
                        selectedProductTypeNames = ReplaceString(JsonSerializer.Serialize(productTypeNames)),
                        IsApplied = true,

                        MaterialTypes = materialTypes,
                        ProductTypes = productTypes
                    });

                });

                CollectionModel.MaterialTypeIdList = MaterialTypeIds;
                CollectionModel.MaterialProductTypeList = materialProductTypes;
                CollectionModel.MaterialTypeNames = ReplaceString(JsonSerializer.Serialize(materialTypeNames));

                selectedMaterialType = ReplaceString(JsonSerializer.Serialize(materialTypeNames));
                materialTypeName = materialTypeNames;

                var selecteds = CollectionModel.SelectedProductColors;
                selecteds.Clear();
                CollectionModel.MaterialProductTypeList.ForEach(x =>
                {
                    x.ProductTypes.ForEach(p =>
                    {
                        SelectedProductColor selectedProductColor = new() { MaterialTypeId = x.MaterialTypeId, ProductTypeId = p.Id };
                        if (!selecteds.Contains(selectedProductColor))
                            selecteds.Add(selectedProductColor);
                    });
                });

                await CalculateProductTypeForecast();

                await CalculationMaterialTypeForecast();

                #endregion

                #region ColorOptions

                CollectionModel.ColorSelectionList.Clear();

                List<CollectionModel.ColorSelection> colorSelections = new();
                CollectionDto.ColorOptions.ForEach(x =>
                {

                    List<int> productTypeIds = new();
                    List<Items> productTypes = new();

                    x.ProductTypes.ForEach(p =>
                    {

                        if (!productTypeIds.Contains(p.ProductTypeId))
                            productTypeIds.Add(p.ProductTypeId);

                        if (!productTypes.Contains(ProductTypeListModel.Items.Find(pt => pt.Id == p.ProductTypeId)))
                            productTypes.Add(ProductTypeListModel.Items.Find(pt => pt.Id == p.ProductTypeId));

                    });


                    CollectionModel.ColorSelection colorSelection = new();

                    colorSelection.Id = x.Id;
                    colorSelection.CollectionId = x.CollectionId;
                    colorSelection.ColorId = x.ColorId;
                    colorSelection.ColorValue = ColorList.Result.Items.Find(c => c.Id == x.ColorId)?.Value;
                    colorSelection.HexCode = ColorList.Result.Items.Find(c => c.Id == x.ColorId)?.HexCode;
                    colorSelection.MaterialTypeId = x.TypeId;
                    colorSelection.MaterialTypeName = TypeListModel.Find(t => t.Id == x.TypeId)?.Value;
                    colorSelection.ProductTypeIds = productTypeIds;
                    colorSelection.ProductTypes = productTypes;
                    colorSelection.Title = x.Title;

                    List<FabricSelection> fabrics = new();
                    int ordinalNumber = 1;
                    x.Fabrics.ForEach(fabric => {

                        FabricSelection fabricSelection = new();

                        List<Guid> rollAndLocationIds = new();
                        List<RollAndLocationModel> rollAndLocations = new();
                        List<RollAndLocationModel> selectedRollAndLocations = new();
                        List<string> selectedRollNames = new();
                        List<string> selectedWarehouse = new();

                        MaterialListModel.Result.Items.ForEach(m =>
                        {

                            if (m.Id == fabric.MaterialId)
                            {
                                m.RollsAndLocations.ForEach(r =>
                                {
                                    rollAndLocations.Add(r);
                                });
                            }
                        });

                        fabric.Rolls.ForEach(r =>
                        {

                            if (!selectedRollAndLocations.Contains(rollAndLocations.Find(rl => rl.Id == r.RollId)))
                                selectedRollAndLocations.Add(rollAndLocations.Find(rl => rl.Id == r.RollId));

                            if (!rollAndLocationIds.Contains(r.RollId))
                                rollAndLocationIds.Add(r.RollId);

                            if (!selectedRollNames.Contains($"{rollAndLocations.Find(rl => rl.Id == r.RollId)?.RollNumber}"))
                                selectedRollNames.Add($"{rollAndLocations.Find(rl => rl.Id == r.RollId)?.RollNumber}");

                        });

                        selectedRollAndLocations.ForEach(rl =>
                        {
                            if (!selectedWarehouse.Contains(rl.BuildingOrWarehouse))
                                selectedWarehouse.Add(rl.BuildingOrWarehouse);
                        });

                        bool isFabricOnSite = false;
                        var otherWarehouse = selectedWarehouse.DistinctBy(x => x).ToList().FindAll(x => !x.Equals("SSY Cebu F1") && !x.Equals("SSY Cebu F2"));

                        if (otherWarehouse.Count == 0)
                            isFabricOnSite = true;
                        else
                            isFabricOnSite = false;

                        fabricSelection.MaterialId = fabric.MaterialId;
                        fabricSelection.MaterialName = MaterialListModel.Result.Items.Find(m => m.Id == fabric.MaterialId)?.Name;
                        var image = MaterialListModel.Result.Items.Find(m => m.Id == fabric.MaterialId)?.Image;
                        fabricSelection.SwatchImage = image == null ? "NotFound" : (image.Length == 0 ? "NotFound" : image);
                        fabricSelection.HexCode = ColorList.Result.Items.Find(c => c.Id == x.ColorId)?.HexCode;
                        fabricSelection.OrdinalNumber = ordinalNumber;
                        fabricSelection.Ordinal = ConvertToOrdinal(ordinalNumber);
                        fabricSelection.SelectedRolls = selectedRollAndLocations;
                        fabricSelection.SelectedRollIds = rollAndLocationIds;
                        fabricSelection.SelectedRollNames = selectedRollNames;
                        fabricSelection.SelectRolls = ReplaceString(JsonSerializer.Serialize(selectedRollNames));
                        fabricSelection.RollAndLocations = rollAndLocations;
                        fabricSelection.SelectedRollWarehouse = selectedWarehouse;
                        fabricSelection.isFabricOnSite = isFabricOnSite;

                        ordinalNumber++;

                        if (!fabrics.Contains(fabricSelection))
                            fabrics.Add(fabricSelection);

                    });

                    colorSelection.FabricSelectionList = fabrics;
                    colorSelection.FabricCount = fabrics.Count;
                    colorSelection.IsApproved = x.IsApproved;
                    colorSelection.IsRejected = x.IsRejected;
                    colorSelection.ApprovedOn = x.ApprovedOn;
                    colorSelection.ApprovedBy = x.ApprovedBy;

                    if (!colorSelections.Contains(colorSelection))
                        colorSelections.Add(colorSelection);

                    var mpt = CollectionModel.MaterialProductTypeList.Find(mpt => mpt.MaterialTypeId == x.TypeId);
                    if (mpt != null)
                        if (!mpt.SelectedColorIds.Contains(x.ColorId))
                            mpt.SelectedColorIds.Add(x.ColorId);

                });

                CollectionModel.ColorSelectionList = colorSelections;

                #endregion

                #region Sizing Options

                CollectionModel.SizingOptionList.Clear();
                CollectionModel.SizingOptionIds.Clear();
                CollectionModel.SizingOptionNames.Clear();

                CollectionDto.Sizes.ForEach(x =>
                {
                    CollectionModel.SizingOptionList.Add(x.Size);
                    CollectionModel.SizingOptionIds.Add(x.Size.Id);
                    CollectionModel.SizingOptionNames.Add(x.Size.Value);
                });

                if (CollectionModel.SizingOptionNames.Count == 0)
                    CollectionModel.SizingOptionsName = "Select Sizes";
                else
                    CollectionModel.SizingOptionsName = ReplaceString(JsonSerializer.Serialize(CollectionModel.SizingOptionNames));

                #endregion

                #region Required Yardage

                CollectionModel.ColorSelectionList.ForEach(x =>
                {

                    SelectedColorProduct selectedColorProduct = new()
                    {
                        MaterialTypeId = x.MaterialTypeId,
                        ColorId = x.ColorId,
                        ColorValue = x.ColorValue,
                        ProductTypeIds = x.ProductTypeIds,
                        Title = x.Title,
                        ProductTypes = x.ProductTypes
                    };

                    if (!CollectionModel.SelectedColorProducts.Contains(selectedColorProduct))
                        CollectionModel.SelectedColorProducts.Add(selectedColorProduct);


                    x.ProductTypes.ForEach(product =>
                    {

                        SPT spt = new()
                        {
                            MaterialTypeId = x.MaterialTypeId,
                            ColorId = x.ColorId,
                            ColorValue = x.ColorValue,
                            ProductTypeId = product.Id,
                            Title = x.Title,
                            ProductTypeSalesPercentage = product.WeightedFQAC,
                            ProductType = product
                        };

                        if (!CollectionModel.SPTs.Contains(spt))
                            CollectionModel.SPTs.Add(spt);

                        var spc = CollectionModel.SelectedProductColors.Find(spc => spc.MaterialTypeId == x.MaterialTypeId && spc.ProductTypeId == product.Id);
                        if (spc != null)
                            spc.ColorIds.Add(x.ColorId);
                    });

                });

                CollectionModel.ColorSelectionList.ForEach(async x =>
                {
                    await Calculate(x.MaterialTypeId);
                });

                #endregion

                #region Max Quantity

                await CalculateProductTypeForecast();

                await CalculationMaterialTypeForecast();

                CollectionModel.ColorSelectionList.ForEach(async x =>
                {
                    await CalculateMaxQuantity(x);
                });

                #endregion

                #region Parent Product

                CollectionModel.ParentProducts = CollectionDto.Products.Where(x => x.IsActive == true && x.ParentId == null).ToList();

                List<ChildProductModel> childProducts = new();

                ChildProducts.Clear();

                CollectionModel.ParentProducts.Where(x => x.IsActive).ToList().ForEach(parent =>
                {
                    parent.ChildProducts.Where(x => x.IsActive).ToList().ForEach(child =>
                    {
                        child.ProductName = string.Empty;
                        child.HexCode = child.ColorId == null ? "7B8E61" : ColorList.Result.Items.Find(x => x.Id == child.ColorId).HexCode;
                        child.ParentCount = parent.ChildProducts.Where(x => x.IsActive).Count();
                        ChildProducts.Add(child);
                    });
                    parent.ChildProducts.Where(x => x.IsActive).ToList().First().ProductName = parent.Name;
                });

                #endregion

                #region BOM Material


                CollectionModel.ColorSelectionList.ForEach(x =>
                {
                    List<BOMMaterial> boms = new();

                    x.FabricSelectionList.ForEach(fabric => {

                        BOMMaterial bom = new();

                        var material = MaterialListModel.Result.Items.Find(m => m.Id == fabric.MaterialId);
                        double allocatedAmount = 0;
                        material.RollsAndLocations.ForEach(r =>
                        {
                            r.RollReservations.Where(z => z.CollectionId == x.CollectionId).ToList().ForEach(rr =>
                            {
                                allocatedAmount += rr.ReservationCount;
                            });
                        });

                        bom.Thumbnail = material.Image;
                        bom.ItemCode = material.ItemCode;
                        bom.ColorCode = material.ColorCode;
                        bom.ColorName = material.ColorValue;
                        bom.AllocatedAmount = allocatedAmount;
                        bom.RemainingAllocatedAfterSold = allocatedAmount;
                        bom.UnallocatedAmount = material.AvailableCount.Value;
                        bom.UnitOfMeasurement = material.UnitOfMeasurementValue;
                        bom.Consumption = x.ProductTypeConsumption;
                        bom.MaxQuantityUsingAllocatedAndUnallocated = x.MaxQuantityUsingAllocatedAndUnallocated;
                        bom.MaxQuantityUsingAllocated = CollectionModel.MaterialProductTypeList.Find(m => m.MaterialTypeId == x.MaterialTypeId).TotalMaxQuantity;
                        bom.ColorId = x.ColorId;

                        if (!boms.Contains(bom))
                            boms.Add(bom);

                    });

                    x.BOMMaterial = boms;
                });

                #endregion

                #region AssignedTo

                if (CollectionDto.AssignedTo == null)
                    CollectionModel.AssignedTo = new();
                else
                    CollectionModel.AssignedTo = CollectionDto.AssignedTo;

                CollectionModel.AssignedTo.CollectionId = CollectionDto.Id;
                AssignedToModel = CollectionModel.AssignedTo;

                #endregion

                #region Design Brief

                var res = await typeFormApi.GetTypeFormResponse(new TypeFormRequestModel()
                {
                    Type = string.Empty,
                    Email = CollectionModel.influencers.Select(c => c.Email).ToList()
                });
                if (res.IsSuccessStatusCode)
                {
                    DesignBriefContent = res.Content;
                }


                #endregion

                IsEditable = false;

                StateHasChanged();

            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - GetCollection()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender && IsLoading) return;

        }
        public async Task GetProducts()
        {
            ProductListModel = await _productService.GetAllProduct(null, null, 999);
        }

        public void OnApprovedCollection(ColorSelection colorSelection)
        {
            var selectedColorOption = CollectionModel.ColorSelectionList.Find(x => x.Id == colorSelection.Id);

            selectedColorOption = colorSelection;
        }

        public void OnRejectCollection(CollectionModel collection)
        {
            CollectionModel = collection;

            ChildProducts.Clear();
            collection.ParentProducts.ForEach(parent => {
                parent.ChildProducts.Where(x => x.IsActive).ToList().ForEach(child =>
                {
                    child.ProductName = string.Empty;
                    child.HexCode = child.ColorId == null ? "7B8E61" : ColorList.Result.Items.Find(x => x.Id == child.ColorId).HexCode;
                    child.ParentCount = parent.ChildProducts.Where(x => x.IsActive).Count();
                    ChildProducts.Add(child);
                });
                parent.ChildProducts.Where(x => x.IsActive).ToList().First().ProductName = parent.Name;
            });
        }

        public async Task OnPublishHandler()
        {
            try
            {
                var isPublished = await _collectionService.PublishCollectionV2(CollectionModel.Id);

                if (isPublished)
                    CollectionModel.IsPublished = true;
                else
                    CollectionModel.IsPublished = false;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task OnEditHandler()
        {
            try
            {
                // Module = "Edit";
                IsEditable = true;
                CollectionModelOld = new();
                CollectionModelOld = await Compile(CollectionModel);

                CollectionModelNew = new();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task<UpdateCollectionInputModel> Compile(CollectionModel input)
        {
            try
            {
                List<CreateColorOptionModel> colorOptions = new();
                GetCollectionOutputModel GetCollectionOutputModel = new();
                foreach (var item in input.ColorSelectionList)
                {
                    List<Guid> selectedRollsIds = new();

                    item.SelectedRollIds.ForEach(x => { selectedRollsIds.Add(x); });

                    colorOptions.Add(new CreateColorOptionModel()
                    {
                        Id = item.Id,
                        TenantId = input.TenantId,
                        IsActive = input.IsActive,
                        ProductTypeIds = item.ProductTypeIds,
                        Title = item.Title,
                        ColorId = item.ColorId,
                        TypeId = item.MaterialTypeId,
                        MaterialId = item.MaterialId,
                        RollIds = item.SelectedRollIds
                    });
                }

                List<UpdateMaterialProductTypes> materialProductTypes = new();
                input.MaterialProductTypeList.ForEach(item =>
                {
                    materialProductTypes.Add(new()
                    {
                        TypeId = item.MaterialTypeId,
                        ProductTypeIds = item.ProductTypeIds
                    });
                });

                UpdateCollectionInputModel updateCollectionInputModel = new()
                {
                    Id = input.Id,
                    TenantId = input.TenantId,
                    IsActive = input.IsActive,
                    InfluencerIds = input.InfluencerIdsList,
                    Name = input.Name,
                    SeasonId = input.SeasonId,
                    PricePointId = input.PricePointId,
                    FactoryId = input.FactoryId,
                    ShippingTypeId = input.ShippingTypeId,
                    MarketingTypeId = input.MarketingTypeId,
                    StatusId = input.StatusId,
                    MaterialProductTypeIds = materialProductTypes,
                    ColorOptions = colorOptions,
                    SizingOptionIds = input.SizingOptionIds
                };

                return updateCollectionInputModel;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");

                return null;
            }
        }

        public async Task OnDiscardHandler()
        {
            try
            {
                CollectionModelNew = new();
                CollectionModelNew = await Compile(CollectionModel);

                if (CollectionModelOld != CollectionModelNew)
                {
                    bool isConfirmed = await js.InvokeAsync<bool>("confirm", "warning", "Discard", $"Are you sure you want to discard your changes?");

                    if (isConfirmed)
                    {
                        Module = "Collection Detail";
                        IsEditable = false;

                        await GetCollection();
                    }
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task OnSubmitHandler()
        {
            //try
            //{
            await ShowSavingModal();

            Products.Clear();
            bool isSuccess = false;
            List<Guid> reservationIds = new();
            List<Guid> reservedRollIds = new();
            List<Guid> materialIdsNeedToReserve = new();
            List<Guid> rollIdsToCreateReservation = new();
            List<CreateRollReservationModel> rollReservations = new();

            #region Material Rolls need to Create Reservation

            // Get the Reserved Material Rolls
            CollectionModel.ColorSelectionList.ForEach(colorOption =>
            {
                colorOption.FabricSelectionList.ForEach(fabric => {

                    var material = MaterialListModel.Result.Items.Find(m => m.Id == fabric.MaterialId);
                    material?.RollsAndLocations.ForEach(r =>
                    {
                        r.RollReservations.ForEach(rr =>
                        {
                            reservationIds.Add(rr.ReservationId);
                            reservedRollIds.Add(rr.RollId);
                        });
                    });

                });

            });

            // List of Material Rolls need to Create Reservation
            CollectionModel.ColorSelectionList.ForEach(colorOption =>
            {
                colorOption.FabricSelectionList.ForEach(fabric => {
                    fabric.SelectedRollIds.ForEach(rollId =>
                    {
                        if (!reservedRollIds.Contains(rollId))
                        {
                            rollIdsToCreateReservation.Add(rollId);
                            materialIdsNeedToReserve.Add(colorOption.MaterialId);
                        }
                    });

                });
            });

            materialIdsNeedToReserve.ForEach(materialId =>
            {
                var material = MaterialListModel.Result.Items.Find(m => m.Id == materialId);
                Console.WriteLine(JsonSerializer.Serialize(material));
                List<RollReservation> RollReservations = new();

                rollIdsToCreateReservation.ForEach(rollId =>
                {
                    var roll = material.RollsAndLocations.Find(r => r.Id == rollId);

                    RollReservations.Add(new()
                    {
                        RollId = roll.Id,
                        RollNumber = roll.RollNumber,
                        ReservedCount = roll.TotalCount.Value
                    });
                });

                List<string> influencers = new();

                CollectionModel.influencers.ForEach(x => influencers.Add(x.InfluencerFullName));

                rollReservations.Add(new()
                {
                    CollectionId = CollectionDto.Id.ToString(),
                    IsActive = CollectionDto.IsActive,
                    MaterialId = materialId,
                    RollReservations = RollReservations,
                    CollectionName = CollectionModel.Name,
                    InfluencerNames = string.Join(", ", influencers)
                });
            });

            var res = await _materialService.CreateRollReservation(rollReservations);

            #endregion

            if (res)
            {
                #region Material Rolls need to Delete Reservation

                List<Guid> materialHaveReservation = new();
                List<MaterialRoll> materialRollNeedToDeleteReservation = new();
                List<MaterialRoll> materialRollNeedToCancelReservation = new();

                // List of Material Rolls Have Reservation
                CollectionDto.ColorOptions.ForEach(colorOption =>
                {
                    colorOption.Fabrics.ForEach(fabric =>
                    {
                        materialHaveReservation.Add(fabric.MaterialId);
                    });
                });

                // List of Material Rolls need to Delete Reservation
                CollectionModel.ColorSelectionList.ForEach(colorOption =>
                {
                    if (materialHaveReservation.Contains(colorOption.MaterialId))
                        materialHaveReservation.Remove(colorOption.MaterialId);
                });

                materialHaveReservation.ForEach(materialId =>
                {
                    CollectionDto.ColorOptions.ForEach(x => {
                        List<Guid> rolls = new();
                        var fab = x.Fabrics.Find(f => f.MaterialId == materialId);
                        if (fab != null)
                        {
                            fab.Rolls.ForEach(x => rolls.Add(x.RollId));
                            materialRollNeedToDeleteReservation.Add(new() { MaterialId = fab.MaterialId, Rolls = rolls });
                        }
                    });
                });

                if (materialRollNeedToDeleteReservation.Count != 0)
                    await CancelReservation(materialRollNeedToDeleteReservation, CollectionDto.Id);

                #endregion

                CollectionModel.ColorSelectionList.ForEach(x =>
                {
                    var coloroption = CollectionDto.ColorOptions.Find(c => c.Id == x.Id);
                    if (coloroption == null)
                        x.Id = Guid.Empty;
                });

                var result = await _collectionService.UpdateCollectionV2(CollectionModel);

                if (result.Item2)
                {
                    await GetCollection();
                }
                else
                {
                    rollReservations.ForEach(roll =>
                    {
                        List<Guid> rolls = new();
                        roll.RollReservations.ForEach(x => rolls.Add(x.RollId));
                        materialRollNeedToCancelReservation.Add(new() { MaterialId = roll.MaterialId, Rolls = rolls });
                    });

                    await CancelReservation(materialRollNeedToCancelReservation, CollectionDto.Id);
                }

            }

            await calendarApi.UpdateCollectionToCalendar(new(CollectionModel.Id, CollectionModel.StatusId, CollectionModel.ForecastQuantity, CollectionModel.CollectionDevelopmentStartDate));
            await HideSavingModal();

            StateHasChanged();
            //}
            //catch (Exception ex)
            //{
            //    string innerException = string.Empty;
            //    if (ex.InnerException != null)
            //        innerException = $"\nInnerException:{ex.InnerException.Message}";

            //    Console.WriteLine($"Error: {ex.Message}{innerException}");
            //    //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            //}
        }

        public async Task CancelReservation(List<MaterialRoll> materialRollNeedToDeleteReservation, Guid collectionId)
        {
            try
            {
                List<Guid> reservationIdsToDelete = new();

                materialRollNeedToDeleteReservation.ForEach(item =>
                {
                    var material = MaterialListModel.Result.Items.Find(x => x.Id == item.MaterialId);
                    material.RollsAndLocations.ForEach(x =>
                    {
                        x.RollReservations.ForEach(r =>
                        {
                            if (item.Rolls.Any(rl => rl == r.RollId))
                                reservationIdsToDelete.Add(r.ReservationId);
                        });
                    });
                });

                if (reservationIdsToDelete.Count != 0)
                    await _reservationService.DeleteMaterialReservationList(reservationIdsToDelete);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task CalculateProductTypeForecast()
        {
            try
            {
                // First: Categorize SubPercentage by Product Type Category

                var productByCatergories = CollectionModel.ProductByCatergories;

                CollectionModel.MaterialProductTypeList.ForEach(x =>
                {

                    x.ProductTypes.OrderBy(x => x.ProductCategoryId).ToList().ForEach(p =>
                    {
                        var prod = productByCatergories.Find(x => x.ProductCategoryId == p.ProductCategoryId);

                        if (p.ProductCategoryId != null && prod == null)
                        {
                            productByCatergories.Add(new() { ProductCategoryId = p.ProductCategoryId });
                        }

                        productByCatergories.ForEach(pc =>
                        {
                            if (pc.ProductCategoryId == p.ProductCategoryId)
                            {
                                pc.ProductTypes.Add(new()
                                {
                                    MaterialTypeId = p.MaterialTypeId,
                                    ProductTypeId = p.Id,
                                    AverageConsumption = p.AverageConsumption,
                                    Percentage = p.SalesPercentage.Value,
                                    SubPercentage = p.SubSalesPercentage
                                });
                            }
                        });
                    });
                });

                // Second: Calculate 

                CollectionModel.ProductByCatergories.ForEach(x =>
                {
                    // Total SubPercentage
                    double total = 0;
                    x.ProductTypes.ForEach(p =>
                    {
                        total += Math.Round(p.SubPercentage, 2);
                    });
                    x.TotalSubPercentage = total;
                });

                CollectionModel.ProductByCatergories.ForEach(x =>
                {
                    // Weighted SubPercentage
                    x.ProductTypes.ForEach(p =>
                    {
                        p.WeightedSubPercentage = Math.Round(p.SubPercentage / x.TotalSubPercentage, 2);
                    });
                });

                CollectionModel.ProductByCatergories.ForEach(x =>
                {
                    // Sales Percentage
                    x.ProductTypes.ForEach(p =>
                    {
                        p.SalesPercentage = Math.Round(p.WeightedSubPercentage * p.Percentage, 2);
                    });
                });

                double total = 0;
                CollectionModel.ProductByCatergories.ForEach(x =>
                {
                    // Total Product Sales Percentage
                    x.ProductTypes.ForEach(p =>
                    {
                        total += p.SalesPercentage;
                    });

                    CollectionModel.TotalProductSalesPercentage = total;
                });

                CollectionModel.ProductByCatergories.ForEach(x =>
                {
                    // Weighted Sales Percentage
                    x.ProductTypes.ForEach(p =>
                    {
                        p.WeightedSalesPercentage = Math.Round((p.SalesPercentage / CollectionModel.TotalProductSalesPercentage) * 100, 2);
                    });
                });

                CollectionModel.ProductByCatergories.ForEach(x =>
                {
                    // Weighted Forecast Quantity
                    x.ProductTypes.ForEach(p =>
                    {
                        p.WeightedForecastQuantity = Math.Round((p.WeightedSalesPercentage * OverviewModel.ForecastQuantity) / 100, 2);
                    });
                });

                CollectionModel.ProductByCatergories = productByCatergories;

                //Console.WriteLine(JsonSerializer.Serialize(CollectionModelResult.ProductByCatergories));

                await DistrubuteProductForecast();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task DistrubuteProductForecast()
        {
            try
            {
                var productTypesByCategories = CollectionModel.ProductByCatergories;

                if (productTypesByCategories != null)
                {
                    productTypesByCategories.ForEach(product =>
                    {
                        product.ProductTypes.ForEach(x =>
                        {
                            ProductTypeListModel.Items.Find(p => p.Id == x.ProductTypeId).WeightedSalesPercentage = Math.Round(x.WeightedSalesPercentage);
                            ProductTypeListModel.Items.Find(p => p.Id == x.ProductTypeId).WeightedForecastQuantity = Math.Round(x.WeightedForecastQuantity);
                            ProductTypeListModel.Items.Find(p => p.Id == x.ProductTypeId).WeightedFQAC = Math.Round(x.WeightedForecastQuantity * x.AverageConsumption);
                        });
                    });
                }

                var productTypes = CollectionModel.MaterialProductTypeList;

                if (productTypes != null)
                {
                    productTypes.ForEach(x =>
                    {
                        double total = 0;
                        x.ProductTypes.OrderBy(x => x.MaterialTypeId).ToList().ForEach(p =>
                        {
                            total += Math.Round(p.WeightedForecastQuantity);
                        });

                        x.TotalForecast = Math.Round(total);
                    });

                    //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.MaterialProductTypeList));
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task CalculationMaterialTypeForecast()
        {
            try
            {
                // Compute by Material Types

                List<int> materialTypeIds = new();

                List<TypeModel> selectedMaterialTypes = new();

                selectedMaterialTypes = TypeListModel.FindAll(x => CollectionModel.MaterialProductTypeList.Any(w => w.MaterialTypes.Any(m => m.Id == x.Id)));

                var total = selectedMaterialTypes.Sum(x => x.SalesPercentage.Value);

                selectedMaterialTypes.ForEach(x =>
                {
                    var avg = TypeListModel.FindAll(m => m.Id == x.Id);

                    var totalAverageConsumption = Math.Round(avg.Sum(s => s.SalesPercentage.Value));

                    var weightedPercentage = ((x.SalesPercentage / total) * 100);
                    var salesPercentage = (int)Math.Round(x.SalesPercentage.Value);
                    x.WeightedSalesPercentage = GetWeightedSalesPercentage(salesPercentage, total);
                    x.WeightedUnits = GetUnits(x.WeightedSalesPercentage, CollectionModel.ForecastQuantity);
                    x.TotalRequiredUnits = GetTotalRequiredUnits(x.WeightedUnits, (totalAverageConsumption / avg.Count));
                    x.TotalPercentageUnits = GetTotalPercentageUnits(CollectionModel.ForecastQuantity, salesPercentage);

                    x.Units = Math.Round((double)x.WeightedSalesPercentage * OverviewModel.ForecastQuantity / 100);

                    materialTypeIds.Add(x.Id);
                });
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task Calculate(int materialTypeId)
        {
            try
            {
                var colorProducts = CollectionModel.SPTs.FindAll(x => x.MaterialTypeId == materialTypeId && x.ColorId != 0);

                var productTypes = colorProducts.Select(x => new { x.ColorId, x }).ToList();

                List<string> colors = colorProducts.Select(c => c.ColorValue).ToList();
                var bothColors = colors.Contains("Black") && colors.Contains("Dark Blue");
                var notBothColors = !colors.Contains("Black") || !colors.Contains("Dark Blue");
                var remainingColors = bothColors ? colors.Count - 2 : colors.Count;

                colorProducts.ForEach(x =>
                {
                    var color = colorProducts.FindAll(c => c.ColorId == x.ColorId);

                    var product = colorProducts.FindAll(c => c.ProductTypeId == x.ProductTypeId).Count();

                    if (color.Count == 1)
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                    else if (color.Count == 2)
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                    else if (color.Count == 3)
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                    else if ((color.Count > 3))
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                });

                await ApplyCalculation(materialTypeId);

                //Console.WriteLine(JsonSerializer.Serialize(colorProducts));
            }
            catch (Exception ex)
            {

            }
        }

        public async Task ApplyCalculation(int materialTypeId)
        {
            try
            {
                var selected = CollectionModel.SPTs.Where(x => x.ColorId != 0).ToList();

                CollectionModel.SelectedMaterialProducts.Clear();

                selected.ForEach(x =>
                {
                    CollectionModel.SelectedMaterialProducts.Add(new()
                    {
                        MaterialTypeId = x.MaterialTypeId,
                        WeightedSalesPercentage = x.ColorSalesPercentage,
                        ColorId = x.ColorId,
                        ProductTypeId = x.ProductTypeId,
                        ProductType = x.ProductType
                    });
                });

                CollectionModel.SelectedProductTypes.Clear();

                var additionalPercentage = 1.15;

                CollectionModel.SelectedProductTypes = new();
                CollectionModel.SelectedMaterialProducts.ForEach(x =>
                {
                    CollectionModel.SelectedProductTypes.Add(new()
                    {
                        MaterialTypeId = x.MaterialTypeId,
                        ProductTypeId = x.ProductTypeId,
                        ColorId = x.ColorId,
                        RequiredYardage = Math.Round(x.ProductType.WeightedForecastQuantity * x.ProductType.AverageConsumption * (x.WeightedSalesPercentage / 100) * additionalPercentage)
                    });
                });

                List<Total> totals = new();
                CollectionModel.SelectedProductTypes.ForEach(x =>
                {
                    x.TotalRequiredYardage = CollectionModel.SelectedProductTypes.FindAll(x => x.ColorId == x.ColorId && x.ProductTypeId == x.ProductTypeId).Sum(x => x.RequiredYardage);
                });

                CollectionModel.SelectedMaterialProducts.ForEach(x =>
                {

                    x.TotalProductRequiredYardage = CollectionModel.SelectedProductTypes.FindAll(p => p.ColorId == x.ColorId && p.MaterialTypeId == x.MaterialTypeId).Sum(s => s.RequiredYardage);

                });

                //Console.WriteLine(JsonSerializer.Serialize(CollectionModelResult.SelectedProductTypes));
                //Console.WriteLine(JsonSerializer.Serialize(CollectionModelResult.SelectedMaterialProducts));
                //Console.WriteLine(JsonSerializer.Serialize(selected));
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task CalculateMaxQuantity(ColorSelection colorSelection)
        {
            try
            {
                var selected = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.Id == colorSelection.Id);

                if (selected != null)
                {
                    // Product Type
                    selected.ProductTypeConsumption = 0;
                    selected.ProductTypes.ForEach(x =>
                    {
                        selected.ProductTypeConsumption += x.AverageConsumption;
                        selected.ProductTypeForecastQuantity = x.WeightedForecastQuantity;
                    });

                    // Roll
                    selected.TotalRollYardage = 0;
                    selected.SelectedRolls.ForEach(x =>
                    {
                        selected.TotalRollYardage += Math.Round(x.TotalCount.Value, 0);
                    });

                    // Summation
                    selected.Summation = 0;
                    selected.Summation = Math.Round(selected.TotalRollYardage + selected.ProductTypeConsumption, 0);

                    // Material Type Forecast Quantity
                    var materialTypeForecastQty = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId).MaterialTypes.Find(x => x.Id == colorSelection.MaterialTypeId).WeightedSalesPercentage;

                    var totalForecastQty = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId).TotalForecast;

                    var fabric = MaterialListModel.Result.Items.FirstOrDefault(m => m.Id == selected.MaterialId);

                    double totalRequiredYardage = 0;
                    var productTypes = CollectionModel.SelectedMaterialProducts.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.ColorId == colorSelection.ColorId);
                    totalRequiredYardage = productTypes != null ? productTypes.TotalProductRequiredYardage : 0;

                    // Total Product Type Forecast Quantity
                    double totalPFQ = 0;
                    double totalPFQTY = 0;
                    selected.ProductTypes.ForEach(x =>
                    {
                        totalPFQ += x.WeightedForecastQuantity;

                        var productForecastQty = x.WeightedForecastQuantity;
                        //Console.WriteLine("PRODUCT: " + productForecastQty);

                        //Console.WriteLine("REQUIRED YARDAGE: " + totalRequiredYardage);

                        //Console.WriteLine("RESERVED YARDAGE: " + selected.TotalRollYardage);

                        var averageConsumption = x.AverageConsumption;
                        //Console.WriteLine("AVG: " + averageConsumption);

                        //Console.WriteLine("TOTAL FORECAST QTY: " + totalForecastQty);

                        selected.MaxQuantityUsingAllocatedAndUnallocated = 0;
                        selected.MaxQuantityUsingAllocatedAndUnallocated = Math.Round((selected.TotalRollYardage + fabric.AvailableCount.Value) / averageConsumption, 0);
                        //Console.WriteLine("MaxQuantityUsingAllocatedAndUnallocated: " + selected.MaxQuantityUsingAllocatedAndUnallocated);

                        var step1 = selected.TotalRollYardage / averageConsumption;
                        //Console.WriteLine("STEP1: " + step1);

                        var step2 = productForecastQty / totalForecastQty;
                        //Console.WriteLine("STEP2: " + step2);

                        var step3 = step1 * step2;
                        //Console.WriteLine("STEP3: " + step3);

                        totalPFQTY += step3;
                    });

                    // Reserved Yardage Percentage
                    selected.TotalRollYardagePercentage = 0;
                    if (totalRequiredYardage == 0)
                        selected.TotalRollYardagePercentage = 0;
                    else
                        selected.TotalRollYardagePercentage = Math.Round(selected.TotalRollYardage / totalRequiredYardage * 100);
                    //Console.WriteLine("RESERVED YARDAGE PERCENTAGE: " + selected.TotalRollYardagePercentage);

                    // Reserved Yardage
                    var reservedYardage = selected.TotalRollYardage;
                    //Console.WriteLine("totalPFQTY: " + totalPFQTY);

                    // Max Quantity
                    selected.MaxQuantity = 0;
                    if (selected.SelectedRollIds.Count > 0)
                    {
                        selected.MaxQuantity = 0;
                        selected.MaxQuantity = Math.Round(totalPFQTY, 0);
                    }

                    double totalMaxQuantity = 0;
                    var colorSelections = CollectionModel.ColorSelectionList.FindAll(x => x.MaterialTypeId == colorSelection.MaterialTypeId);
                    colorSelections.ForEach(x =>
                    {
                        totalMaxQuantity += x.MaxQuantity;
                    });

                    var selectedMaterial = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId);
                    if (selectedMaterial != null)
                    {
                        selectedMaterial.TotalMaxQuantity = 0;
                        selectedMaterial.TotalMaxQuantity = totalMaxQuantity;
                    }
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        private int GetTotalRequiredUnits(int units, double totalAverageConsumption)
        {
            return (int)Math.Round(units * totalAverageConsumption);
        }

        private int GetWeightedSalesPercentage(int salesPercentage, double totalSalesPercentage)
        {
            return (int)Math.Round((salesPercentage / totalSalesPercentage) * 100.00);
        }

        private int GetUnits(int weightedSalesPercentage, int forecastQuantity)
        {
            return (int)Math.Round((weightedSalesPercentage * forecastQuantity) / 100.00);
        }

        private int GetTotalPercentageUnits(int forecastQuantity, int salesPercentage)
        {
            return (int)Math.Round(forecastQuantity * (salesPercentage / 100.00));
        }

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

        public static string ConvertToOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        public async Task onAddParentProductBtnClicked()
        {
            try
            {
                var url = $"/collectionandproduct/product/add";
                NavigationManager.NavigateTo(url);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }
        public void ChangeTab(string tabName)
        {
            try
            {
                TabName = tabName;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }

        }

        public class MaterialRoll
        {
            public Guid MaterialId { get; set; }
            public List<Guid> Rolls { get; set; } = new();
        }

        private Task ShowSavingModal()
        {
            return ModalSaving.Show();
        }

        private Task HideSavingModal()
        {
            return ModalSaving.Hide();
        }
    }
}
   