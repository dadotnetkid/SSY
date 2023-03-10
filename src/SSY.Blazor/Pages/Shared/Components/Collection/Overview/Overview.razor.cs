using SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Factories.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.MarketingTypes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.PricePoints.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ProductSizes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Seasons.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ShippingTypes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;
using static SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model.CollectionModel;
using static SSY.Blazor.Pages.Shared.Components.Collection.CollectionColorOption.CollectionColorOption;

namespace SSY.Blazor.Pages.Shared.Components.Collection.Overview
{
    public partial class Overview
    {
        public Overview()
        {
        }

        public string Module = "";
        public string ModuleMessage = "";
        public string ModuleType = "";
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public GetCollectionOutputModel GetCollectionModel { get; set; } = new() { Result = new() };

        [Parameter]
        public CollectionModel CollectionModel { get; set; } = new();

        [Parameter]
        public OverviewModel OverviewModel { get; set; } = new();

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
        public EventCallback<CollectionModel> OnChangeCollectionModel { get; set; }
        [Parameter]
        public List<CollectionStatusModel> StatusListModel { get; set; } = new();
        [Parameter]
        public GetAllMaterialOutputModel MaterialListModel { get; set; } = new() { Result = new() { Items = new() } };

        public string collapseInfluencer = string.Empty;
        public string collapseMaterialType = string.Empty;
        public List<TypeModel> MaterialTypeListModel { get; set; } = new();
        public string selectedMaterialType = string.Empty;
        public List<string> materialTypeName = new();
        public List<int> MaterialTypeIds { get; set; } = new();
        public List<int> ProductTypeIds { get; set; } = new();
        public List<string> ProductTypeNames { get; set; } = new();

        public List<int> YearList { get; set; } = new();

        string materialValue;
        string showModal;
        protected override async Task OnInitializedAsync()
        {
            await GetYearList();
            await FactorySet();

            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {
            await GetCollection();

            StateHasChanged();
        }
        public async Task FactorySet()
        {
            if (CollectionModel.FactoryId == 1001)
            {
                showModal = "tienhu";
            }
            else if (CollectionModel.FactoryId == 1002)
            {
                showModal = "cebu";
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

        public async Task GetCollection()
        {
            #region Material ProductType

            List<CollectionModel.MaterialProductTypes> materialProductTypes = new();
            List<TypeModel> materialTypes = new();
            List<string> materialTypeNames = new();

            CollectionModel.MaterialProductTypeList.ForEach(x => {

                materialTypeNames.Add(TypeListModel.Find(t => t.Id == x.MaterialTypeId).Value);
                MaterialTypeIds.Add(x.MaterialTypeId);

                List<int> productTypeIds = new();
                List<string> productTypeNames = new();
                List<Items> productTypes = new();

                x.ProductTypes.ForEach(p => {
                    productTypeIds.Add(p.Id);
                    productTypeNames.Add(p.Value);

                    productTypes.Add(ProductTypeListModel.Items.Find(pt => pt.Id == p.Id));

                });

                // Material Type
                materialTypes.Add(TypeListModel.Find(t => t.Id == x.MaterialTypeId));

                // MaterialProductTypes
                materialProductTypes.Add(new()
                {
                    MaterialTypeId = x.MaterialTypeId,
                    MaterialTypeName = TypeListModel.Find(t => t.Id == x.MaterialTypeId).Value,
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
            CollectionModel.MaterialProductTypeList = materialProductTypes;

            selectedMaterialType = ReplaceString(JsonSerializer.Serialize(materialTypeNames));
            materialTypeName = materialTypeNames;

            #endregion
        }

        public async Task onChangeInfluencerHandler(string value, UserDetailModelCC input, bool checkedValue)
        {
            try
            {
                //OverviewModel.InfluencersName = string.Empty;
                //CollectionModel.Name = string.Empty;

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
                        CollectionModel.influencers.Add(new() { Id = input.Id, InfluencerFullName = input.FullName });
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

                CollectionModel.Name = OverviewModel.InfluencersName + " Collections";

                if (CollectionModel.Influencers.Equals(string.Empty))
                {
                    CollectionModel.Influencers = "Select Influencers";
                }

                await GenerateCollectionName();

                Console.WriteLine(JsonSerializer.Serialize(CollectionModel.ForecastQuantity));

                await Recalculate();

                StateHasChanged();
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
                var name = string.Join(" & ", OverviewModel.Influencers);

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

        public async Task onChangeMaterialTypeHandler(TypeModel value, bool checkedValue)
        {
            if (checkedValue)
            {
                // UI
                if (!OverviewModel.Types.Contains(value))
                {
                    value.Counter++;
                    OverviewModel.Types.Add(value);
                }

                // Model
                if (!CollectionModel.MaterialTypeIdList.Contains(value.Id))
                {
                    CollectionModel.MaterialTypeIdList.Add(value.Id);
                }

                if (!OverviewModel.MaterialTypeName.Contains(value.Value))
                {
                    OverviewModel.MaterialTypeName.Add(value.Value);
                    CollectionModel.MaterialTypeNames = (string.Join(",", OverviewModel.MaterialTypeName));
                }

                //await GetSalesPercentage(value.Value);
            }
            else
            {
                if (OverviewModel.Types.Contains(value))
                {
                    value.Counter--;
                    OverviewModel.Types.Remove(value);
                }

                // Model
                if (CollectionModel.MaterialTypeIdList.Contains(value.Id))
                {
                    CollectionModel.MaterialTypeIdList.Remove(value.Id);
                }

                if (OverviewModel.MaterialTypeName.Contains(value.Value))
                {
                    OverviewModel.MaterialTypeName.Remove(value.Value);
                    CollectionModel.MaterialTypeNames = (string.Join(",", OverviewModel.MaterialTypeName));
                }
            }

            await Recalculate();

            StateHasChanged();
        }

        public async Task OnClickInfluencers()
        {
            if (collapseInfluencer.Equals("show"))
            {
                collapseInfluencer = "";
            }
            else
            {
                collapseInfluencer = "show";
            }
        }

        public async Task OnClickMaterialTypes()
        {
            if (collapseMaterialType.Equals("show"))
            {
                collapseMaterialType = "";
            }
            else
            {
                collapseMaterialType = "show";
            }
        }
        public async Task onChangeFactory(string value)
        {
            if (value == "1001")
            {
                showModal = "tienhu";
                materialValue = "Knitwear";
            }
            else if (value == "1002")
            {
                showModal = "cebu";
            }
        }
        public async Task onChangeMaterialTypeHandler(int typeId, TypeModel typeModel, bool checkedValue)
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
                        MaterialTypeName = typeModel.Value
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

            CollectionModel.MaterialTypeNames = ReplaceString(JsonSerializer.Serialize(materialTypeName));

            await Recalculate();
        }

        public async Task onChangeProductTypeHandler(Items input, TypeModel materialType, bool checkedValue)
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

        public async Task onChangeSizingOptionsHandler(ProductSizeModel input, bool checkedValue)
        {
            try
            {
                if (checkedValue)
                {
                    if (!CollectionModel.SizingOptionIds.Contains(input.Id))
                    {
                        CollectionModel.SizingOptionIds.Add(input.Id);
                    }

                    if (!CollectionModel.SizingOptionNames.Contains(input.Value))
                    {
                        CollectionModel.SizingOptionNames.Add(input.Value);
                    }

                    if (!CollectionModel.SizingOptionList.Contains(input))
                    {
                        CollectionModel.SizingOptionList.Add(input);
                    }
                }
                else
                {
                    if (CollectionModel.SizingOptionIds.Contains(input.Id))
                    {
                        CollectionModel.SizingOptionIds.Remove(input.Id);
                    }

                    if (CollectionModel.SizingOptionNames.Contains(input.Value))
                    {
                        CollectionModel.SizingOptionNames.Remove(input.Value);
                    }

                    if (CollectionModel.SizingOptionList.Contains(input))
                    {
                        CollectionModel.SizingOptionList.Remove(input);
                    }
                }

                if (CollectionModel.SizingOptionIds.Count == 0)
                    CollectionModel.SizingOptionsName = "Select Sizes";
                else
                    CollectionModel.SizingOptionsName = ReplaceString(JsonSerializer.Serialize(CollectionModel.SizingOptionNames));

                Console.WriteLine(JsonSerializer.Serialize(CollectionModel.SizingOptionIds));
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

        public async Task Apply()
        {

            var approvedColorOption = CollectionModel.ColorSelectionList.FindAll(x => x.IsApproved == true);

            List<string> ApprovedColorOptions = new();
            if (approvedColorOption != null)
            {
                approvedColorOption.ForEach(x => {
                    ApprovedColorOptions.Add(x.Title);
                });

                if (ApprovedColorOptions.Count > 0)
                {
                    await js.InvokeVoidAsync("defaultMessage", "warning", "Warning", $"You are trying to modify an approved Material/Product Type. This will reset all approvals. \nDo you want to proceed?");
                }
            }

            await Recalculate();
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

            StateHasChanged();

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

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

    }
}
