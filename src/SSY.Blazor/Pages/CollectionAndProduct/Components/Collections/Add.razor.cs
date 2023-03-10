
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Drops.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes.Model;
using SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes;
using SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model;
using SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationProductTypes;
using SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationProductTypes.Model;
using SSY.Blazor.HttpClients.Models.Products.Collections.Calendars;
using SSY.Blazor.Pages.Shared.Components.Collection.CollectionColorOption;
using SSY.Blazor.Pages.Shared.Components.Collection.DesignBriefs;
using Volo.Abp;
using static SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model.CollectionModel;
using static SSY.Blazor.Pages.Shared.Components.Collection.CollectionColorOption.CollectionColorOption;
using CollectionStatusModel = SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model.CollectionStatusModel;

namespace SSY.Blazor.Pages.CollectionAndProduct.Components.Collections
{
    public partial class Add
    {
        public Add()
        {
        }

        public string Module = "Add Collections";
        public string ModuleMessage = "";
        private bool IsLoading;
        private Modal ModalSaving;

        public string showMaterialType = "";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject] private ITypeFormApi typeFormApi { get; set; }
        [Inject] private ICalendarApi calendarApi { get; set; }
        public GetDropdownService _getDropdownService { get; set; }
        public TypeService _typeService { get; set; }
        public CollectionService _collectionService { get; set; }
        public ProductService _productService { get; set; }
        public ReservationMaterialTypeService _reservationMaterialTypeService { get; set; }
        public ReservationProductTypeService _reservationProductTypeService { get; set; }
        public UserDetailService _userDetailService { get; set; }
        public MaterialService _materialService { get; set; }
        public AdditionRequestTypeService _additionRequestTypeService { get; set; }
        public AdditionRequestService _additionRequestService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; } = true;

        [Parameter]
        public bool IsModuleAdd { get; set; } = true;

        public CollectionModel CollectionModel { get; set; } = new();

        public OverviewModel OverviewModel { get; set; } = new();
        public ColorOptionModel ColorOptionModel { get; set; } = new();

        public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };
        public MaterialCategoryListModel MaterialCategoryListModel { get; set; } = new() { Result = new() { Items = new() } };

        public List<ColorOptionModel> ColorOptions { get; set; }

        public List<ColorListModel> ColorListModel = new();
        public GetAllProductOutputModel ProductsListModel { get; set; } = new() { Items = new() };
        public List<AdditionRequestTypeModel> AdditionRequestTypeListModel { get; set; } = new();

        public GetAllCollectionOutputModel CollectionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllReservationMaterialTypeOutputModel GetAllReservationMaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllReservationProductTypeOutputModel GetAllReservationProductTypeModel { get; set; } = new() { Result = new() { Items = new() } };

        // Collection Dropdowns
        public CollectionDropdownDto CollectionDropdown { get; set; } = new();
        public List<SeasonModel> SeasonListModel { get; set; } = new();
        public List<PricePointModel> PricePointListModel { get; set; } = new();
        public List<FactoryModel> FactoryListModel { get; set; } = new();
        public List<ShippingTypeModel> ShippingTypeListModel { get; set; } = new();
        public List<MarketingTypeModel> MarketingTypeListModel { get; set; } = new();
        public List<ProductSizeModel> SizeListModel { get; set; } = new();
        public List<DropModel> DropListModel { get; set; } = new();
        public List<CollectionStatusModel> StatusListModel { get; set; } = new();
        public List<CollectionDesignStatusModel> DesignStatusListModel { get; set; } = new();
        public List<UserDetailModelCC> InfluencerListModel { get; set; } = new();
        public List<TypeModel> MaterialTypeListModel { get; set; } = new();
        public List<int> YearList { get; set; } = new();
        public List<string> InfluencerSelectedEmail { get; set; } = new();
        public string collapseInfluencers = string.Empty;
        public string collapseMaterialTypes = string.Empty;
        public string influencers = string.Empty;

        public string selectedMaterialType = string.Empty;
        public List<string> materialTypeName = new();
        private DesignBriefs designBriefRef;

        public CreateProductModel CreateProductModel { get; set; } = new();
        public ProductTypeListModel ProductTypeListModel { get; set; } = new() { Items = new() };

        public List<int> MaterialTypeIds { get; set; } = new();
        public List<int> ProductTypeIds { get; set; } = new();
        public List<string> ProductTypeNames { get; set; } = new();

        public List<CollectionModel.MaterialProductTypes> MaterialProductTypeList { get; set; } = new();

        [Parameter]
        public GetAllMaterialOutputModel MaterialModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public GetAllProductOutputModel ProductListModel { get; set; } = new() { Items = new() };

        // for new setup for product
        public List<CreateProductModel> Products { get; set; } = new();
        public List<CreateProductDto> ProductsDto { get; set; } = new();

        public GetCollectionOutputModel GetCollectionOutputModel { get; set; } = new();
        public CollectionDto CollectionDto { get; set; } = new();

        public List<Guid> AdditionRequestIds { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
                _typeService = new(js, ClientFactory, NavigationManager, Configuration);
                _productService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
                _reservationMaterialTypeService = new(js, ClientFactory, NavigationManager, Configuration);
                _reservationProductTypeService = new(js, ClientFactory, NavigationManager, Configuration);
                _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);
                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _additionRequestTypeService = new(js, ClientFactory, NavigationManager, Configuration);
                _additionRequestService = new(js, ClientFactory, NavigationManager, Configuration);

                CollectionModel.Influencers = "Select Influencers";
                selectedMaterialType = "Select Material Types";

                CollectionDropdown = await _collectionService.GetCollectionDropdowns();

                // Collection Dropdowns
                SeasonListModel = CollectionDropdown.SeasonList.Items;
                PricePointListModel = CollectionDropdown.PricePointList.Items;
                FactoryListModel = CollectionDropdown.FactoryList.Items;
                ShippingTypeListModel = CollectionDropdown.ShippingTypeList.Items;
                MarketingTypeListModel = CollectionDropdown.MarketingTypeList.Items;
                SizeListModel = CollectionDropdown.SizeList.Items;
                DropListModel = CollectionDropdown.DropList.Items;
                StatusListModel = CollectionDropdown.StatusList.Items;
                DesignStatusListModel = CollectionDropdown.DesignStatusList.Items;
                InfluencerListModel = (await _userDetailService.GetAllUserCC(null, null, null, null, null, 999)).Result.Items;
                MaterialTypeListModel = (await _typeService.GetAllType(2, null, "orderNumber", null, 100)).Result.Items;
                ProductTypeListModel = await _getDropdownService.GetAllProductType(null, null, null, 1000);
                ColorList = await _getDropdownService.GetAllColor(null, null, null, 100);

                AdditionRequestTypeListModel = (await _additionRequestTypeService.GetAllAdditionRequestType(null, null, null, 100)).Result.Items;
                MaterialCategoryListModel = await _getDropdownService.GetAllMaterialCategory(null, null, null, 100);

                OverviewModel.ColorOptionIdList.Add(new int());

                CollectionModel.MarketingTypeId = MarketingTypeListModel.Find(x => x.Value.Equals("TBD")).Id;
                CollectionModel.StatusId = StatusListModel.Find(x => x.Value.Equals("In Progress")).Id;
                CollectionModel.DesignStatusId = DesignStatusListModel.Find(x => x.Value.Equals("Collection Development")).Id;

                await GetYearList();

                IsLoading = false;

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                MaterialModel = await _materialService.GetAllMaterial(2, null, null, null, null, 10000);
            }
        }

        public async Task GetYearList()
        {
            var today = DateTime.Now.Year;

            int max = 10;

            for (int i = 0; i < max; i++)
            {
                YearList.Add(today + i);
            }
        }

        public async Task AdditionRequests(List<Guid> additionRequestIds)
        {
            AdditionRequestIds = additionRequestIds;
        }

        public async Task OnDiscard()
        {
            if (AdditionRequestIds.Count != 0)
                await _additionRequestService.CancelRequests(AdditionRequestIds);

            NavigationManager.NavigateTo("/collectionandproduct/collection", true);
        }

        public async Task onChangeFactory(string value)
        {
            try
            {
                var factory = FactoryListModel.Find(x => x.Id == int.Parse(value));
                if (factory != null)
                {
                    CollectionModel.FactoryId = factory.Id;

                    var type = MaterialTypeListModel.Find(x => x.Value.Equals("Knitwear"));

                    if (type != null)
                    {
                        if (factory.Value.Equals("Cebu"))
                            MaterialTypeListModel.ForEach(x => x.IsActive = x.Value.Equals("Knitwear") ? false : true);
                        else if (factory.Value.Equals("Tien Hu"))
                            MaterialTypeListModel.ForEach(x => x.IsActive = x.Value.Equals("Knitwear") ? true : false);
                        else
                            MaterialTypeListModel.ForEach(x => x.IsActive = true);

                        //await ClearAll();

                        //CollectionModel.ColorSelectionList.Clear();
                        //CollectionModel.MaterialProductTypeList.Clear();
                        //CollectionModel.MaterialProductTypeList.ForEach(x => x.SelectedColorIds.Clear());
                        //CollectionModel.ProductByCatergories.Clear();
                        //CollectionModel.SelectedMaterialProducts.Clear();
                        //CollectionModel.ColorSelectionList.Clear();
                        //CollectionModel.SelectedColorProducts.Clear();
                        //CollectionModel.SelectedProductTypes.Clear();
                        //CollectionModel.SPTs.Clear();
                        //CollectionModel.SelectedProductColors.Clear();
                        showMaterialType = "show";
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

        public async Task onChangeMaterialTypeHandler(int typeId, TypeModel typeModel, bool checkedValue)
        {
            try
            {
                if (checkedValue)
                {
                    if (!MaterialTypeIds.Contains(typeId))
                    {
                        MaterialTypeIds.Add(typeId);
                    }

                    if (!materialTypeName.Contains(typeModel.Value))
                    {
                        materialTypeName.Add(typeModel.Value);
                        selectedMaterialType = (string.Join(", ", materialTypeName));
                    }

                    if (CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == typeId) == null)
                    {
                        CollectionModel.MaterialProductTypes materialProduct = new()
                        {
                            MaterialTypeId = typeId,
                            MaterialTypeName = typeModel.Value,
                            MaterialTypeShortCode = typeModel.ShortCode
                        };

                        materialProduct.MaterialTypes.Add(typeModel);

                        CollectionModel.MaterialProductTypeList.Add(materialProduct);
                    }
                }
                else
                {
                    if (MaterialTypeIds.Contains(typeId))
                    {
                        MaterialTypeIds.Remove(typeId);
                    }

                    if (materialTypeName.Contains(typeModel.Value))
                    {
                        materialTypeName.Remove(typeModel.Value);
                        selectedMaterialType = (string.Join(", ", materialTypeName));
                    }

                    var materialType = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == typeId);
                    if (materialType != null)
                    {
                        CollectionModel.MaterialProductTypeList.Remove(materialType);
                        materialType.ProductTypeIds.Clear();
                        materialType.ProductTypeNames.Clear();
                        materialType.selectedProductTypeNames = "Select Product Types";
                    }
                }

                if (selectedMaterialType.Equals(string.Empty))
                {
                    selectedMaterialType = "Select Material Types";
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

        public async Task onChangeProductTypeHandler(Items input, TypeModel materialType, bool checkedValue)
        {
            try
            {
                var materialProductTypes = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == materialType.Id);

                if (materialProductTypes != null)
                {
                    if (checkedValue)
                    {
                        if (!materialProductTypes.ProductTypeIds.Contains(input.Id))
                        {
                            materialProductTypes.ProductTypeIds.Add(input.Id);
                        }

                        if (!materialProductTypes.ProductTypeNames.Contains(input.Value))
                        {
                            materialProductTypes.ProductTypeNames.Add(input.Value);
                        }

                        if (!materialProductTypes.ProductTypes.Contains(input))
                        {
                            input.IsSelected = false;
                            materialProductTypes.ProductTypes.Add(input);
                        }
                    }
                    else
                    {
                        if (materialProductTypes.ProductTypeIds.Contains(input.Id))
                        {
                            materialProductTypes.ProductTypeIds.Remove(input.Id);
                        }

                        if (materialProductTypes.ProductTypeNames.Contains(input.Value))
                        {
                            materialProductTypes.ProductTypeNames.Remove(input.Value);
                        }

                        CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == materialType.Id).ProductTypes.Remove(input);

                        if (materialProductTypes.ProductTypes.Contains(input))
                        {
                            materialProductTypes.ProductTypes.Remove(input);
                        }
                    }

                    materialProductTypes.selectedProductTypeNames = ReplaceString(JsonSerializer.Serialize(materialProductTypes.ProductTypeNames));

                    if (materialProductTypes.selectedProductTypeNames.Equals(string.Empty))
                    {
                        materialProductTypes.selectedProductTypeNames = "Select Product Types";
                    }

                    if (!materialProductTypes.MaterialTypes.Contains(materialType))
                    {
                        materialProductTypes.MaterialTypes.Add(materialType);
                    }
                }

                await Recalculate();
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

        public async Task onChangeInfluencerHandler(string value, UserDetailModelCC input, bool checkedValue)
        {
            try
            {
                OverviewModel.InfluencersName = string.Empty;
                CollectionModel.Name = string.Empty;

                if (checkedValue)
                {
                    // For UI
                    if (!OverviewModel.Influencers.Contains(value))
                    {
                        OverviewModel.Influencers.Add(value);
                        OverviewModel.InfluencersName = (string.Join(" & ", OverviewModel.Influencers));
                    }

                    // For Model
                    if (!CollectionModel.InfluencerIdsList.Contains(input.Id))
                    {
                        CollectionModel.InfluencerIdsList.Add(input.Id);
                    }

                    if (!OverviewModel.InfluencersFullName.Contains(input.FullName))
                    {
                        OverviewModel.InfluencersFullName.Add(input.FullName);
                        CollectionModel.Influencers = (string.Join(", ", OverviewModel.InfluencersFullName));
                    }

                    if (CollectionModel.influencers.Find(x => x.Id == input.Id) == null)
                    {
                        CollectionModel.influencers.Add(new() { Id = input.Id, InfluencerFullName = input.FullName, InfluencerName = input.Name, InfluencerSurame = input.Surname });
                    }

                    OverviewModel.ForecastQuantity = OverviewModel.ForecastQuantity + (int)input.ProductQuantityForecast;
                    CollectionModel.ForecastQuantity = CollectionModel.ForecastQuantity + (int)input.ProductQuantityForecast;

                }
                else
                {
                    // For UI
                    if (OverviewModel.Influencers.Contains(value))
                    {
                        OverviewModel.Influencers.Remove(value);
                        OverviewModel.InfluencersName = (string.Join(" & ", OverviewModel.Influencers));
                        if (OverviewModel.Influencers.Count < 1)
                            OverviewModel.InfluencersName = string.Empty;

                        if (OverviewModel.Influencers.Count < 1)
                            CollectionModel.Influencers = string.Empty;
                    }

                    // For Model
                    if (CollectionModel.InfluencerIdsList.Contains(input.Id))
                    {
                        CollectionModel.InfluencerIdsList.Remove(input.Id);
                    }

                    if (OverviewModel.InfluencersFullName.Contains(input.FullName))
                    {
                        OverviewModel.InfluencersFullName.Remove(input.FullName);
                        CollectionModel.Influencers = (string.Join(", ", OverviewModel.InfluencersFullName));
                    }

                    var influencer = CollectionModel.influencers.Find(x => x.Id == input.Id);
                    if (influencer != null)
                    {
                        CollectionModel.influencers.Remove(influencer);
                    }

                    OverviewModel.ForecastQuantity = OverviewModel.ForecastQuantity - (int)input.ProductQuantityForecast;
                    CollectionModel.ForecastQuantity = CollectionModel.ForecastQuantity - (int)input.ProductQuantityForecast;
                }

                CollectionModel.Name = OverviewModel.InfluencersName + " Collection";

                if (CollectionModel.Influencers.Equals(string.Empty))
                {
                    CollectionModel.Influencers = "Select Influencers";
                }

                await GenerateTypeForm(checkedValue, input);
                await GenerateCollectionName();

                await Recalculate();
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

        public async Task Recalculate()
        {
            #region Max Quantity

            CollectionModel.ColorSelectionList.ForEach(async x =>
            {
                await Calculate(x.MaterialTypeId);
            });

            await CalculateProductTypeForecast();

            CollectionModel.ColorSelectionList.ForEach(async x =>
            {
                await CalculateMaxQuantity(x);
            });

            #endregion
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

                    var fabric = MaterialModel.Result.Items.FirstOrDefault(m => m.Id == selected.MaterialId);

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

        private async Task GenerateTypeForm(bool checkedValue, UserDetailModelCC item)
        {
            if (checkedValue)
            {
                InfluencerSelectedEmail.Add(item.EmailAddress);
            }
            else
            {
                InfluencerSelectedEmail.Remove(item.EmailAddress);
            }
            var result = await typeFormApi.GetTypeFormResponse(new()
            {
                Email = InfluencerSelectedEmail,
                Type = string.Empty
            });
            if (result.IsSuccessStatusCode)
            {
                designBriefRef.RefreshActiveWearDesignResponse(result.Content);
            }
        }

        public async Task onChangeSeason(string value)
        {
            try
            {
                var season = SeasonListModel.Find(x => x.Id == int.Parse(value));
                if (season != null)
                {
                    CollectionModel.SeasonId = season.Id;
                }

                await GenerateCollectionName();
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

        public async Task onChangeYear(string value)
        {
            try
            {
                var year = YearList.Find(x => x == int.Parse(value));

                CollectionModel.Year = year;

                await GenerateCollectionName();
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

        public async Task GenerateCollectionName()
        {
            try
            {
                var name = OverviewModel.InfluencersName;

                string season = string.Empty;

                if (CollectionModel.SeasonId != 0)
                {
                    season = SeasonListModel.Find(x => x.Id == CollectionModel.SeasonId).Label;
                }

                string year = string.Empty;

                if (CollectionModel.Year != 0)
                {
                    var selectedYear = CollectionModel.Year.ToString();
                    year = $"{selectedYear[2]}{selectedYear[3]}";
                }

                var collectionName = $"{name} {season}{year} Collection";

                CollectionModel.Name = string.Empty;
                CollectionModel.Name = collectionName;
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
            try
            {
                await ShowSavingModal();

                Products.Clear();
                ProductsDto.Clear();

                (CollectionDto, bool) result = (new(), false);

                var materialTypeHasNoProductTypes = CollectionModel.MaterialProductTypeList.Find(x => x.ProductTypeIds.Count == 0 && x.MaterialTypeId > 0);

                if (materialTypeHasNoProductTypes != null)
                {
                    await js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Product Type/s for {materialTypeHasNoProductTypes.MaterialTypeName}.");
                }
                else
                {
                    var selectedRolls = CollectionModel.ColorSelectionList.Any(x => x.FabricSelectionList.Any(f => f.SelectedRollIds.Count == 0));

                    var insufficientRoll = CollectionModel.ColorSelectionList.Any(x => x.RequiredYardage > x.TotalRollYardage);

                    List<string> colorOptionsThatHasInsufficientRolls = new();
                    CollectionModel.ColorSelectionList.ForEach(x =>
                    {
                        if (x.RequiredYardage > x.TotalRollYardage)
                            colorOptionsThatHasInsufficientRolls.Add($"{x.MaterialTypeName} : {x.Title}");
                    });

                    bool isContinue;

                    if (selectedRolls)
                        await js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Roll/s on Roll Selection.");
                    else
                    {
                        if (insufficientRoll)
                        {
                            isContinue = await js.InvokeAsync<bool>("confirm", "warning", $"Warning!", $"Not enough rolls selected to fulfill yardage requirements. \n Do you want to continue?", new { });

                            if (isContinue)
                                result = await CreateCollection();
                        }
                        else
                        {
                            result = await CreateCollection();
                        }
                    }

                    if (result.Item2)
                    {
                        #region Roll Reservations

                        CollectionDto = result.Item1;

                        List<CreateRollReservationModel> rollReservations = new();

                        CollectionModel.ColorSelectionList.ForEach(x =>
                        {
                            x.FabricSelectionList.ForEach(fabric => {

                                var material = MaterialModel.Result.Items.Find(m => m.Id == fabric.MaterialId);

                                List<RollReservation> RollReservations = new();

                                fabric.SelectedRolls.ForEach(rl =>
                                {

                                    var roll = material.RollsAndLocations.Find(r => r.Id == rl.Id);

                                    RollReservations.Add(new()
                                    {
                                        RollId = roll.Id,
                                        RollNumber = roll.RollNumber,
                                        ReservedCount = roll.TotalCount.Value
                                    });
                                });

                                List<string> influencers = new();

                                CollectionDto.Influencers.ForEach(x => influencers.Add(x.InfluencerFullName));

                                rollReservations.Add(new()
                                {
                                    CollectionId = CollectionDto.Id.ToString(),
                                    IsActive = CollectionDto.IsActive,
                                    MaterialId = fabric.MaterialId,
                                    RollReservations = RollReservations,
                                    CollectionName = CollectionDto.Name,
                                    InfluencerNames = ReplaceString(JsonSerializer.Serialize(influencers))
                                });

                            });

                        });

                        var res = await _materialService.CreateRollReservation(rollReservations);

                        if (res)
                        {
                            await js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Collection Successfully Added!", "", $"/collectionandproduct/collection");

                            #region Assign Collection Id to Addition Request

                            List<AssignAdditionRequestModel> assignAdditionRequests = new();

                            AdditionRequestIds.ForEach(x =>
                            {
                                assignAdditionRequests.Add(new() { CollectionId = CollectionDto.Id, Id = x });
                            });

                            if (assignAdditionRequests.Count != 0)
                                await _additionRequestService.AssignRequests(assignAdditionRequests);

                            #endregion
                        }
                        else
                            await _collectionService.CancelCollectionV2(CollectionDto.Id);

                        #endregion

                    }

                    if (CollectionModel.StatusId == 1003)
                    {
                        await calendarApi.AddCollectionToCalendar(new()
                        {
                            SalesForecastQuantity = CollectionModel.ForecastQuantity,
                            CollectionDevelopmentTarget = DateTime.Now,
                            CollectionId = result.Item1.Id,

                        });
                    }
                }


                await HideSavingModal();
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

        public async Task<(CollectionDto, bool)> CreateCollection()
        {
            return await _collectionService.CreateCollectionV2(CollectionModel);
        }

        public async Task Apply()
        {
            try
            {
                if (CollectionModel.InfluencerIdsList.Count == 0)
                {
                    await js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Influencer/s.");
                }

                if (CollectionModel.MaterialProductTypeList.Count == 0)
                {
                    await js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Material Type/s and Product Type/s.");
                }

                var materialTypeHasNoProductTypes = CollectionModel.MaterialProductTypeList.Find(x => x.ProductTypeIds.Count == 0 && x.MaterialTypeId > 0);

                if (materialTypeHasNoProductTypes != null && materialTypeHasNoProductTypes.IsApplied == false)
                {
                    await js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Product Type/s for {materialTypeHasNoProductTypes.MaterialTypeName}.");
                }

                if (CollectionModel.InfluencerIdsList.Count > 0 && CollectionModel.MaterialProductTypeList.Count > 0 && materialTypeHasNoProductTypes == null)
                {
                    collapseMaterialTypes = "";

                    var itemToDelete = CollectionModel.MaterialProductTypeList.FindAll(x => x.ProductTypeIds.Count == 0);
                    itemToDelete.ForEach(x => CollectionModel.MaterialProductTypeList.Remove(x));

                    var itemToApply = CollectionModel.MaterialProductTypeList.FindAll(x => x.ProductTypeIds.Count > 0);
                    itemToApply.ForEach(x =>
                    {
                        x.IsApplied = true;
                        x.ProductTypes.ForEach(p => p.IsSelected = true);
                    });

                    CollectionModel.ColorSelectionList.Clear();
                    CollectionModel.MaterialProductTypeList.ForEach(x => x.SelectedColorIds.Clear());
                    CollectionModel.ProductByCatergories.Clear();
                    CollectionModel.SelectedMaterialProducts.Clear();
                    CollectionModel.ColorSelectionList.Clear();
                    CollectionModel.SelectedColorProducts.Clear();
                    CollectionModel.SPTs.Clear();
                    CollectionModel.SelectedProductColors.Clear();

                    await CalculationMaterialTypeForecast();
                    await CalculateProductTypeForecast();

                    var selecteds = CollectionModel.SelectedProductColors;

                    selecteds.Clear();

                    CollectionModel.MaterialProductTypeList.ForEach(x =>
                    {

                        x.ProductTypes.ForEach(p =>
                        {

                            SelectedProductColor selectedProductColor = new() { MaterialTypeId = x.MaterialTypeId, ProductTypeId = p.Id };

                            if (!selecteds.Contains(selectedProductColor))
                            {
                                selecteds.Add(selectedProductColor);
                            }
                        });

                    });
                }

                //Console.WriteLine(JsonSerializer.Serialize(CollectionModel));
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

        public async Task ClearAll()
        {
            try
            {
                MaterialTypeIds.Clear();
                materialTypeName.Clear();
                selectedMaterialType = "Select Material Types";

                CollectionModel.MaterialProductTypeList.ForEach(x =>
                {
                    x.ProductTypeIds.Clear();
                    x.ProductTypeNames.Clear();
                    x.selectedProductTypeNames = "Select Product Types";
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

        public async Task OnClickMaterialType()
        {
            try
            {
                if (collapseMaterialTypes.Equals("show"))
                {
                    collapseMaterialTypes = "";
                }
                else
                {
                    collapseMaterialTypes = "show";
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
                        p.WeightedForecastQuantity = Math.Round((p.WeightedSalesPercentage * CollectionModel.ForecastQuantity) / 100, 2);
                    });
                });

                CollectionModel.ProductByCatergories = productByCatergories;

                //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.ProductByCatergories));

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

                selectedMaterialTypes = MaterialTypeListModel.FindAll(x => CollectionModel.MaterialProductTypeList.Any(w => w.MaterialTypes.Any(m => m.Id == x.Id)));

                var total = selectedMaterialTypes.Sum(x => x.SalesPercentage.Value);

                selectedMaterialTypes.ForEach(x =>
                {
                    var avg = MaterialTypeListModel.FindAll(m => m.Id == x.Id);

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