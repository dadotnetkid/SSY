//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Collections.Generic;
//using SSY.Web.Blazor.Core.Models;
//using SSY.Web.Blazor.Core.Models.Materials;
//using Microsoft.JSInterop;
//using System.Data;
//using System.IO;
//using NPOI.XSSF.UserModel;
//using NPOI.SS.UserModel;
//using Microsoft.AspNetCore.Components.Forms;
//using System.Globalization;
//using System;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Collections.Generic;
//using System;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using Microsoft.Extensions.Configuration;

//using SSY.Web.Blazor.Core.Data.SubMaterials;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Overview;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.ColorOptions;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.Factories;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.Factories.Model;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.PricePoints;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.PricePoints.Model;
//using SSY.Web.Blazor.Core.Data.Dropdowns;
//using SSY.Web.Blazor.Core.Data.Dropdowns.Model;
//using SSY.Web.Blazor.Core.Data.Types;
//using SSY.Web.Blazor.Core.Data.Types.Model;
//using TypeModel = SSY.Web.Blazor.Core.Data.Types.Model.TypeModel;
//using OverviewModel = SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Overview.OverviewModel;
//using SSY.Web.Blazor.Core.Data.Influencers;
//using SSY.Web.Blazor.Core.Data.Influencers.Model;
//using static SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Overview.OverviewModel;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.Model;
//using SSY.Web.Blazor.Core.Data.Materials;
//using SSY.Web.Blazor.Core.Data.Materials.Model;
//using static SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.CollectionModel;
//using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.ColorOptions.Model;
//using SSY.Web.Blazor.Core.Data.Reservations;
//using SSY.Web.Blazor.Core.Data.Reservations.Model;
//using SSY.Web.Blazor.Core.Data.ProductReservations.ReservationProductTypes;
//using SSY.Web.Blazor.Core.Data.ProductReservations.ReservationProductTypes.Model;
//using SSY.Web.Blazor.Core.Data.ProductReservations.ReservationMaterialTypes;
//using SSY.Web.Blazor.Core.Data.ProductReservations.ReservationMaterialTypes.Model;

//namespace SSY.Web.Blazor.Shared.Components.Collection.CollectionMaterialPlan
//{
//    public partial class CollectionMaterialPlan
//    {
//        public CollectionMaterialPlan()
//        {
//        }

//        public string Module = "Collections";
//        public string ModuleMessage = "";
//        public string ModuleType = "Add";
//        [Inject]
//        public IJSRuntime js { get; set; }
//        [Inject]
//        public IHttpClientFactory ClientFactory { get; set; }
//        [Inject]
//        public NavigationManager NavigationManager { get; set; }
//        [Inject]
//        public IConfiguration Configuration { get; set; }

//        public FactoryService _factoryService { get; set; }
//        public PricePointService _pricePointService { get; set; }
//        public GetDropdownService _getDropdownService { get; set; }
//        public TypeService _typeService { get; set; }
//        public InfluencerService _influencerService { get; set; }
//        public CollectionService _collectionService { get; set; }
//        public MaterialService _materialService { get; set; }
//        public ColorOptionService _colorOptionService { get; set; }
//        public ReservationService _reservationService { get; set; }
//        public ReservationProductTypeService _reservationProductTypeService { get; set; }
//        public ReservationMaterialTypeService _reservationMaterialTypeService { get; set; }

//        [Parameter]
//        public Guid Id { get; set; }

//        [Parameter]
//        public bool IsEditable { get; set; }
//        [Parameter]
//        public GetAllCollectionOutputModel CollectionListModel { get; set; } = new();
//        [Parameter]
//        public GetCollectionOutputModel GetCollectionModel { get; set; }
//        [Parameter]
//        public CollectionModel CollectionModel { get; set; } = new() { ColorSelectionList = new() };

//        [Parameter]
//        public OverviewModel OverviewModel { get; set; }

//        public ColorOptionModel ColorOptionModel { get; set; } = new();

//        public List<FactoryModel> FactoryListModel { get; set; } = new();
//        public List<PricePointModel> PricePointListModel { get; set; } = new();
//        public TypeListModel TypeListModel { get; set; } = new() { Result = new() { Items = new() } };
//        public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };
//        public List<InfluencerModel> InfluencerListModel { get; set; } = new();

//        public List<ColorOptionModel> ColorOptionsModel { get; set; } = new();
//        public GetAllMaterialOutputModel MaterialModel { get; set; }
//        public List<MaterialModel> MaterialModelList { get; set; } = new();

//        public List<TypeModel> TypeModel { get; set; } = new();
//        public List<TypeModel> TypeModelList { get; set; } = new();
//        public List<ColorListModel> ColorListModel = new();
//        public GetAllColorOptionOutputModel ColorOptionOutputModel { get; set; } = new() { Result = new() { Items = new() } };
//        public GetAllReservationOutputModel ReservationListModel { get; set; } = new() { Result = new() { Items = new() } };
//        public GetAllReservationProductTypeOutputModel GetAllReservationProductTypeModel { get; set; } = new() { Result = new() { Items = new() } };
//        public GetAllReservationMaterialTypeOutputModel GetAllReservationMaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };

//        public string ColorValue { get; set; }
//        public string TypeValue { get; set; }
//        public string MaterialValue { get; set; }

//        [Parameter]
//        public RenderFragment ChildContent { get; set; }
//        [Parameter]
//        public string Text { get; set; }

//        protected override async Task OnInitializedAsync()
//        {
//            _factoryService = new(js, ClientFactory, NavigationManager, Configuration);
//            _pricePointService = new(js, ClientFactory, NavigationManager, Configuration);
//            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
//            _typeService = new(js, ClientFactory, NavigationManager, Configuration);
//            _influencerService = new(js, ClientFactory, NavigationManager, Configuration);
//            _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
//            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
//            _colorOptionService = new(js, ClientFactory, NavigationManager, Configuration);
//            _reservationService = new(js, ClientFactory, NavigationManager, Configuration);
//            _reservationProductTypeService = new(js, ClientFactory, NavigationManager, Configuration);
//            _reservationMaterialTypeService = new(js, ClientFactory, NavigationManager, Configuration);

//            FactoryListModel = (await _factoryService.GetAllFactory(null, "orderNumber", null, 100)).Result.Items;
//            PricePointListModel = (await _pricePointService.GetAllPricePoint(null, "orderNumber", null, 100)).Result.Items;
//            TypeListModel = await _getDropdownService.GetAllMaterialType(2, null, null, null, 100);
//            ColorList = await _getDropdownService.GetAllColor(null, null, null, 100);
//            TypeModel = (await _typeService.GetAllType(2, null, null, null, 100)).Result.Items;
//            InfluencerListModel = await _influencerService.GetAllInfluencer();
//            CollectionListModel = await _collectionService.GetAllCollection(null, null, null, null);
//            ColorOptionOutputModel = await _colorOptionService.GetAllColorOption(Id, 100);
//            ReservationListModel = await _reservationService.GetAllReservation(null, null, null, 100);
//            GetAllReservationProductTypeModel = await _reservationProductTypeService.GetAllReservationProductType();
//            GetAllReservationMaterialTypeModel = await _reservationMaterialTypeService.GetAllReservationMaterialType();

//            OverviewModel.ColorOptionIdList.Add(new int());

//            StateHasChanged();

//            MaterialModel = await _materialService.GetAllMaterial(2, null, null, null, null, 100);

//            GetCollectionModel.Result.ColorOptions = ColorOptionOutputModel.Result.Items.OrderBy(x => x.Title).ToList();

//            await GetColorOption();
//            await GetType();
//            await GetColor();
//            await GetMaterial();
//            await GetForecastQuantity();
//            await GetMaterialType();
//            await SetColorSelection();
//            await GetWeightedSalesUnit();
//        }

//        public async Task GetColorOption()
//        {
//            foreach (var item in GetCollectionModel.Result.ColorOptions)
//            {
//                if (ColorOptionsModel.Find(x => x.Id == item.Id) == null)
//                    ColorOptionsModel.Add(item);

//                item.MaterialModelList = MaterialModel.Result.Items.FindAll(x => x.ColorId == item.ColorId);

//                foreach (var res in ReservationListModel.Result.Items.FindAll(x => x.MaterialId == item.MaterialId))
//                {
//                    item.ReservedCount = res.ReservedCount;
//                    item.Influencer = res.InfluencersName;
//                    item.Collection = res.CollectionName;
//                }

//                ColorOptionsModel.ForEach(x =>
//                {
//                    x.MaxQuantity = GetMaxQuantityUnit(x.MaterialId, x.MaterialTypeId);
//                });
//            }
//        }

//        public async Task GetColor()
//        {
//            foreach (var item in GetCollectionModel.Result.ColorOptions)
//            {
//                item.ColorValue = ColorList.Result.Items.Find(x => x.Id == item.ColorId).Value;
//            }
//        }

//        public async Task GetType()
//        {
//            foreach (var item in GetCollectionModel.Result.ColorOptions)
//            {
//                item.MaterialTypeName = TypeListModel.Result.Items.Find(x => x.Id == item.MaterialTypeId).Value;
//            }
//        }

//        public async Task GetMaterial()
//        {
//            foreach (var item in GetCollectionModel.Result.ColorOptions)
//            {
//                var name = MaterialModel.Result.Items.Find(x => x.Id == item.MaterialId)?.Name;
//                if (name == null)
//                    item.MaterialName = "Not Available";

//                item.MaterialName = name;
//            }
//        }

//        public async Task SetColorSelection()
//        {
//            foreach (var item in GetCollectionModel.Result.ColorOptions)
//            {
//                ColorSelection color = new()
//                {
//                    Id = item.Id,
//                    ColorId = item.ColorId,
//                    ColorValue = item.ColorValue,
//                    MaterialTypeId = item.MaterialTypeId,
//                    MaterialTypeName = item.MaterialTypeName,
//                    Title = item.Title,
//                    CollectionId = item.CollectionId,
//                    MaterialId = item.MaterialId,
//                    MaterialName = item.MaterialName
//                };

//                if (CollectionModel.ColorSelectionList.Find(x => x.Id == color.Id) == null)
//                    CollectionModel.ColorSelectionList.Add(color);

//                List<OverviewModel.FabricModel> fabric = new();

//                foreach (var material in MaterialModel.Result.Items.FindAll(x => x.ColorId == item.ColorId))
//                {
//                    OverviewModel.FabricModel fab = new()
//                    {
//                        ColorId = item.ColorId,
//                        ColorTitle = item.Title,
//                        MaterialTypeId = item.MaterialTypeId,
//                        MaterialId = material.Id,
//                        MaterialName = material.Name
//                    };

//                    fabric.Add(fab);
//                }

//                ColorModel colorModel = new()
//                {
//                    Id = item.Id,
//                    ColorId = item.ColorId,
//                    Title = item.Title,
//                    MaterialId = item.MaterialTypeId,
//                    Value = item.ColorValue,
//                    MaterialModelList = fabric
//                };

//                if (OverviewModel.ColorOptions.Find(x => x.Id == colorModel.Id) == null)
//                    OverviewModel.ColorOptions.Add(colorModel);
//            }
//        }

//        public async Task GetForecastQuantity()
//        {
//            try
//            {
//                var fst = GetCollectionModel.Result.InfluencersIds.Replace("[", "");
//                var scd = fst.Replace("]", "");

//                var a = scd.Split(",");
//                var length = a.Length;
//                List<string> type = new();
//                var materialTypeName = string.Empty;

//                for (int i = 0; i < length; i++)
//                {
//                    var item = a[i];
//                    var influencer = InfluencerListModel.FirstOrDefault(x => x.Id == int.Parse(item));
//                    OverviewModel.ForecastQuantity = OverviewModel.ForecastQuantity + influencer.ProductQuantityForecast;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("GetForecastQuantity : " + ex.Message);
//            }
//        }

//        public async Task GetMaterialType()
//        {
//            try
//            {
//                var fst = GetCollectionModel.Result.MaterialTypeIdList.Replace("[", "");
//                var scd = fst.Replace("]", "");
//                var a = scd.Split(",");
//                var length = a.Length;
//                List<string> type = new();
//                var materialTypeName = string.Empty;

//                for (int i = 0; i < length; i++)
//                {
//                    var item = a[i];
//                    var materialType = TypeModel.FirstOrDefault(x => x.Id == int.Parse(item));
//                    type.Add(materialType.Label);
//                    materialTypeName = string.Join(", ", type);

//                    if (IsEditable)
//                    {
//                        if (OverviewModel.Types.Find(x => x.Id == materialType.Id) == null)
//                            OverviewModel.Types.Add(materialType);
//                    }
//                }

//                GetCollectionModel.Result.MaterialTypeIds = materialTypeName;

//                foreach (var item in OverviewModel.Types)
//                {
//                    await GetSalesPercentage(item.Value);

//                    int count = 0;
//                    List<int> counter = new();

//                    for (int i = 0; i < GetCollectionModel.Result.ColorOptions.FindAll(x => x.MaterialTypeId == item.Id).Count(); i++)
//                    {
//                        count++;
//                        counter.Add(i + 1);
//                    }

//                    item.CounterList = counter;
//                    item.Counter = count;
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("GetMaterialType : " + ex.Message);
//            }

//        }

//        public async Task GetSalesPercentage(string materialType)
//        {
//            if (materialType == "Activewear")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 60;
//            if (materialType == "Sweats")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Jersey")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Knitwear")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Mesh")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 5;
//            if (materialType == "Windbreaker")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 5;

//            if (materialType == "Leggings")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 60;
//            if (materialType == "Biker Shorts")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 20;
//            if (materialType == "Shorts")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 20;
//            if (materialType == "Bra")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Fitted Tank")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Loose Tank")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Tshirt")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;

//            if (materialType == "Hoodie")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Sweatshirt")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Jogger")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Sweatshorts")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;

//            if (materialType == "Windbreaker Jacket")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 50;
//            if (materialType == "Windbreaker Running Shorts")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;
//            if (materialType == "Windbreaker Pants")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 25;

//            if (materialType == "Lounge Pants")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Lounge Shirt")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Lounge Tank")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Lounge Bra")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Lounge Dress")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Lounge Skirt")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Cardigan")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Sweater")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 10;
//            if (materialType == "Beanie")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 5;
//            if (materialType == "Scarf")
//                OverviewModel.Types.First(x => x.Value == materialType).SalesPercentage = 5;

//        }

//        public async Task onChangeColorOptionHandle(string input, int materialId)
//        {
//            var color = OverviewModel.Types.First(x => x.Id == materialId);
//            color.Counter++;
//            color.CounterList.Add(color.Counter);

//            ColorSelection colorSelection = new()
//            {
//                Id = Guid.NewGuid(),
//                ColorId = new int(),
//                ColorValue = string.Empty,
//                MaterialTypeId = materialId,
//                Title = $"Color Option {color.Counter}"
//            };


//            CollectionModel.ColorSelectionList.Add(colorSelection);

//            //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.ColorSelectionList));

//            OverviewModel.ColorOptions.Add(new OverviewModel.ColorModel() { Id = colorSelection.Id, ColorId = colorSelection.ColorId, Value = colorSelection.ColorValue, Title = colorSelection.Title, MaterialId = materialId });

//            //Console.WriteLine(JsonSerializer.Serialize(OverviewModel.ColorOptions));

//            await RefreshAll();
//        }

//        public async Task onChangeColor(string value)
//        {
//            var colorid = (value.Split("-"))[1];
//            var title = (value.Split("-"))[0];
//            var colorname = (value.Split("-"))[2];
//            var materialId = (value.Split("-"))[3];

//            // To Assign in Model
//            var color = OverviewModel.ColorOptions.First(x => x.Title == title && x.MaterialId == int.Parse(materialId));
//            color.ColorId = int.Parse(colorid);
//            color.Value = colorname;

//            // For Fabric Dropdown
//            var fabric = MaterialModel.Result.Items.FindAll(x => x.ColorId == color.ColorId);
//            color.MaterialModelList = new();
//            foreach (var item in fabric)
//            {
//                OverviewModel.FabricModel fab = new()
//                {
//                    ColorId = color.ColorId,
//                    ColorTitle = color.Title,
//                    MaterialId = item.Id,
//                    MaterialName = item.Name,
//                    MaterialTypeId = color.MaterialId
//                };

//                color.MaterialModelList.Add(fab);
//            }

//            ColorSelection colorSelection = new()
//            {
//                Id = color.Id,
//                ColorId = color.ColorId,
//                ColorValue = color.Value,
//                MaterialTypeId = color.MaterialId,
//                MaterialTypeName = TypeListModel.Result.Items.Find(x => x.Id == int.Parse(materialId)).Value,
//                Title = color.Title
//            };

//            var check = CollectionModel.ColorSelectionList.FirstOrDefault(x => x.Id == colorSelection.Id);
//            if (check == null)
//                CollectionModel.ColorSelectionList.Add(colorSelection);
//            else
//            {
//                check.Id = color.Id;
//                check.ColorId = color.ColorId;
//                check.ColorValue = color.Value;
//                check.MaterialTypeId = int.Parse(materialId);
//                check.MaterialTypeName = TypeListModel.Result.Items.Find(x => x.Id == int.Parse(materialId)).Value;
//                check.Title = color.Title;
//                check.MaterialId = Guid.Empty;
//                check.MaterialName = string.Empty;
//            }

//        }

//        public async Task onChangeRemoveColorOptionHandler(Guid id, int materialId)
//        {
//            var colorToDelete = OverviewModel.ColorOptions.First(x => x.Id == id);
//            var colorToDelete2 = CollectionModel.ColorSelectionList.First(x => x.Id == id);

//            // Delete to Model
//            var itemToDelete = OverviewModel.ColorOptions.Find(x => x.Id == id);
//            var itemToDelete2 = CollectionModel.ColorSelectionList.Find(x => x.Id == id);

//            OverviewModel.ColorOptions.Remove(itemToDelete);
//            CollectionModel.ColorSelectionList.Remove(itemToDelete2);

//            // Decrement the Counter
//            var color = OverviewModel.Types.First(x => x.Id == materialId);
//            color.Counter--;
//            color.CounterList.Remove(color.CounterList.Last());

//            var i = 0;
//            var colorOption = OverviewModel.ColorOptions.FindAll(x => x.MaterialId == materialId);
//            foreach (var item in colorOption)
//            {
//                i++;
//                item.Title = $"Color Option {i}";
//            }

//            var colorSelections = CollectionModel.ColorSelectionList.FindAll(x => x.MaterialTypeId == materialId);
//            foreach (var item in colorSelections)
//            {
//                i++;
//                item.Title = $"Color Option {i}";
//            }


//            StateHasChanged();

//        }

//        public async Task RefreshAll()
//        {
//            //foreach (var item in CollectionModel.ColorSelectionList)
//            //{
//            //    Console.WriteLine(JsonSerializer.Serialize(item));
//            //}

//            //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.ColorSelectionList));
//        }

//        public async Task onChangeApprove(bool input, Guid id)
//        {
//            var res = ColorOptionsModel.Find(x => x.Id == id);
//            res.Approve = input;
//            res.Reject = false;
//        }

//        public async Task onChangeReject(bool input, Guid id)
//        {
//            var res = ColorOptionsModel.Find(x => x.Id == id);
//            res.Approve = false;
//            res.Reject = input;
//        }

//        public async Task onClickApprove(Guid colorOptionId, Guid collectionId)
//        {
//            var res = ColorOptionsModel.Find(x => x.Id == colorOptionId);
//            res.IsApproved = true;
//            res.Approve = false;
//            res.Reject = false;
//            res.ApprovedOn = DateTime.Now;

//            ApproveRejectColorOptionModel input = new()
//            {
//                CollectionId = collectionId,
//                ColorOptionId = colorOptionId
//            };

//            await _collectionService.ApproveColorOption(input);
//        }

//        public async Task onClickReject(Guid colorOptionId, Guid collectionId)
//        {
//            var res = ColorOptionsModel.Find(x => x.Id == colorOptionId);
//            ColorOptionsModel.Remove(res);

//            ApproveRejectColorOptionModel input = new()
//            {
//                CollectionId = collectionId,
//                ColorOptionId = colorOptionId
//            };

//            await _collectionService.RejectColorOption(input);
//        }

//        public async Task GetWeightedSalesUnit()
//        {
//            List<TypeModel> selectedMaterialTypes = new();

//            selectedMaterialTypes = TypeModel.FindAll(x => OverviewModel.Types.Any(w => w.Id == x.Id));

//            selectedMaterialTypes.ForEach(x =>
//            {
//                x.SalesPercentage = GetAllReservationMaterialTypeModel.Result.Items.Find(r => r.MaterialTypeId == x.Id).SalesPercentage;
//            });

//            var total = selectedMaterialTypes.Sum(x => x.SalesPercentage.Value);

//            selectedMaterialTypes.ForEach(x =>
//            {
//                var avg = GetAllReservationProductTypeModel.Result.Items.FindAll(m => m.MaterialTypeId == x.Id);

//                var totalAverageConsumption = Math.Round(avg.Sum(s => s.AverageConsumption));

//                var weightedPercentage = ((x.SalesPercentage / total) * 100);
//                var salesPercentage = (int)Math.Round(x.SalesPercentage.Value);
//                x.WeightedSalesPercentage = GetWeightedSalesPercentage(salesPercentage, total);
//                x.WeightedUnits = GetUnits(x.WeightedSalesPercentage, OverviewModel.ForecastQuantity);
//                x.TotalRequiredUnits = GetTotalRequiredUnits(x.WeightedUnits, (totalAverageConsumption / avg.Count));
//                x.TotalPercentageUnits = GetTotalPercentageUnits(OverviewModel.ForecastQuantity, salesPercentage);
//            });

//            OverviewModel.Types.ForEach(x =>
//            {
//                x.SalesPercentage = selectedMaterialTypes.FirstOrDefault(m => m.Id == x.Id).SalesPercentage;
//                x.WeightedUnits = selectedMaterialTypes.FirstOrDefault(m => m.Id == x.Id).WeightedUnits;
//                x.WeightedSalesPercentage = selectedMaterialTypes.FirstOrDefault(m => m.Id == x.Id).WeightedSalesPercentage;
//                x.TotalRequiredUnits = selectedMaterialTypes.FirstOrDefault(m => m.Id == x.Id).TotalRequiredUnits;
//                x.TotalPercentageUnits = selectedMaterialTypes.FirstOrDefault(m => m.Id == x.Id).TotalPercentageUnits;
//            });
//        }

//        private int GetTotalRequiredUnits(int units, double totalAverageConsumption)
//        {
//            return (int)Math.Round(units * totalAverageConsumption);
//        }

//        private int GetWeightedSalesPercentage(int salesPercentage, double totalSalesPercentage)
//        {
//            return (int)Math.Round((salesPercentage / totalSalesPercentage) * 100.00);
//        }

//        private int GetUnits(int weightedSalesPercentage, int forecastQuantity)
//        {
//            return (int)Math.Round((weightedSalesPercentage * forecastQuantity) / 100.00);
//        }

//        private int GetTotalPercentageUnits(int forecastQuantity, int salesPercentage)
//        {
//            return (int)Math.Round(forecastQuantity * (salesPercentage / 100.00));
//        }

//        public int GetMaxQuantityUnit(Guid fabricId, int materialTypeId)
//        {
//            var yards = MaterialModel.Result.Items.Find(x => x.Id == fabricId)?.ActualCount;

//            var avg = GetAllReservationProductTypeModel.Result.Items.FindAll(m => m.MaterialTypeId == materialTypeId);

//            var totalAverageConsumption = Math.Round(avg.Sum(s => s.AverageConsumption));

//            var unit = (yards / (totalAverageConsumption / avg.Count));

//            return (int)Math.Round((double)unit);
//        }

//    }
//}
