using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Time;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SSY.Blazor.Pages.Inventory.Graph
{
    public partial class Graph
    {
        public Graph()
        {
        }

        public int Counter { get; set; } = 1;

        [Inject]
        public IJSRuntime js { get; set; }

        [Inject]
        public ProtectedSessionStorage SessionStorage { get; set; }

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        private BarConfig _barconfig;

        private BarConfig _barconfig2;
        private BarConfig _barconfig3;
        private PieConfig _pieconfig;

        private BarConfig _colorBarConfig;
        private BarConfig _colorBarConfig1;

        [Parameter]
        public int CategoryId { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

        [Parameter]
        public string Module { get; set; }

        [Parameter]
        public List<UserDetailModelCC> UserDetailListModel { get; set; } = new();

        public MaterialService _materialService { get; set; }
        public SubMaterialService _subMaterialService { get; set; }
        public TypeService _typeService { get; set; }
        public CollectionService _collectionService { get; set; }

        private IEnumerable<CollectionOutputModel> _CollectionOutputModel { get; set; }
        private IEnumerable<CollectionListDto> _CollectionList { get; set; }

        public List<double?> UsedCountList { get; set; } = new();
        public List<string> UsedCountLabel { get; set; } = new();

        public List<double?> MaterialPerMaterialTypeList { get; set; } = new();
        public List<string> MaterialPerMaterialTypeLabel { get; set; } = new();

        public List<double?> MaterialPerColorList { get; set; } = new();
        public List<string> MaterialPerColorLabel { get; set; } = new();

        public List<double?> SubMaterialPerMaterialTypeList { get; set; } = new();
        public List<string> SubMaterialPerMaterialTypeLabel { get; set; } = new();

        public List<double?> SubMaterialPerColorList { get; set; } = new();
        public List<string> SubMaterialPerColorLabel { get; set; } = new();

        public List<double?> PieList { get; set; } = new();
        public List<string> PieLabel { get; set; } = new();

        public List<double?> CountPerLocationUsed { get; set; } = new();
        public List<double?> CountPerLocationAvailable { get; set; } = new();
        public List<double?> CountPerLocationExcess { get; set; } = new();
        [Parameter]
        public string PageName { get; set; }

        public GetAllCollectionOutputModel CollectionListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllCollectionListDto CollectionList { get; set; } = new();
        public TypeListModel MaterialTypeModel { get; set; } = new() { Result = new() { Items = new() } };

        public TypeListModel MaterialTypeAllModel { get; set; } = new() { Result = new() { Items = new() } };
        public ColorListModel ColorDropdownListModel { get; set; } = new() { Result = new() { Items = new() } };
        public MaterialModel OverviewModel { get; set; } = new();

        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
                _typeService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionService = new(js, ClientFactory, NavigationManager, Configuration);

                  // bar chart setup
                _barconfig = new BarConfig
                {
                    Options = new BarOptions
                    {
                        Responsive = true,
                        MaintainAspectRatio = false,

                        Title = new ChartJs.Blazor.Common.OptionsTitle
                        {
                            Display = true,
                        },
                         Legend = new Legend
                        {
                            Display = false
                        }
                        // Plugins = {
                        //     Tooltips = new Tooltips
                        // },
                        // Scales = new BarScales
                        // {
                        // XAxes = new List<CartesianAxis>
                        // {
                        //     new TimeAxis
                        //     {
                        //         Distribution = TimeDistribution.Linear,
                        //         Ticks = new TimeTicks
                        //         {
                        //             Source = TickSource.Data
                        //         },
                        //         Time = new TimeOptions
                        //         {
                        //             Unit = TimeMeasurement.Day,
                        //             Round = TimeMeasurement.Day,
                        //             TooltipFormat = "MM.DD.YYYY"
                        //         },
                        //         ScaleLabel = new ScaleLabel
                        //         {
                        //             LabelString = "Date"
                        //         }
                        //     }
                        // }
                        // },
                    }
                };

                // bar chart setup
                _barconfig2 = new BarConfig
                {
                    Options = new BarOptions
                    {
                        Responsive = true,
                        MaintainAspectRatio = false,

                        Title = new ChartJs.Blazor.Common.OptionsTitle
                        {
                            Display = true,
                        },
                         Legend = new Legend
                        {
                            Display = false
                        }
                    }
                };

                // Color Bar Setup
                _colorBarConfig = new BarConfig
                {
                    Options = new BarOptions
                    {
                        Responsive = true,
                        MaintainAspectRatio = false,

                        Title = new ChartJs.Blazor.Common.OptionsTitle
                        {
                            Display = true,
                        },
                         Legend = new Legend
                        {
                            Display = false
                        }
                    }
                };

                _colorBarConfig1 = new BarConfig
                {
                    Options = new BarOptions
                    {
                        Responsive = true,
                        MaintainAspectRatio = false,

                        Title = new ChartJs.Blazor.Common.OptionsTitle
                        {
                            Display = true,
                        },
                         Legend = new Legend
                        {
                            Display = false
                        }
                    }
                };

                _barconfig3 = new BarConfig
                {
                    Options = new BarOptions
                    {
                        Responsive = true,
                        MaintainAspectRatio = false,

                        Title = new ChartJs.Blazor.Common.OptionsTitle
                        {
                            Display = true,
                        }
                    }
                };

                await GetAllCollection();

                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

                ColorDropdownListModel = await _getDropdownService.GetAllColor(null, null, null, 100);


                if (Module == "All" || Module == "Warehouse")
                {
                    MaterialTypeModel = await _getDropdownService.GetAllMaterialType(1, null, null, null, 100);
                    MaterialTypeAllModel = await _getDropdownService.GetAllMaterialType(2, null, null, null, 100);
                }

                else if (Module == "Greige")
                {
                    if (CategoryId == 1)
                    {
                        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(1, null, null, null, 100);
                    }
                }

                else if (Module == "Fabric")
                {
                    if (CategoryId == 2)
                    {
                        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(2, null, null, null, 100);
                    }
                }

                else
                {
                    if (CategoryId == 3)
                    {
                        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(3, null, null, null, 100);
                    }

                    else if (CategoryId == 4)
                    {
                        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(4, null, null, null, 100);
                    }

                    else if (CategoryId == 99)
                    {
                        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(99, null, null, null, 100);
                    }
                }


                if (CategoryId == 1 || CategoryId == 2)
                {
                    await GetMaterialPerColor();
                    await GetTopUsedSoldMaterial();
                    await GetMaterialPerMaterialTypes();
                    await GetWarehouseCapacityPerMaterialType();
                    // await GetPieGraphData();
                }
                if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
                {
                    await GetSubMaterialPerColor();
                    await GetTopUsedSoldSubMaterial();
                    await GetSubMaterialPerMaterialTypes();
                    await GetWarehouseCapacityPerMaterialType();
                    // await GetPieGraphData();
                }

                await GetForecastQuantity();

                IsLoading = false;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out?
            }

        }

        public async Task GetForecastQuantity()
        {
            CollectionList.Items.ForEach(item => {
                double total = 0;

                item.InfluencerIds.ForEach(influencerId => {
                    var influencer = UserDetailListModel.Find(i => i.Id == influencerId);
                    total += influencer == null ? 0 : influencer.ProductQuantityForecast.Value;
                });

                item.CollectionForecastQuantity = total;

                item.CollectionForecastRevenue = total * 32;
            });
        }

        public async Task GetAllCollection()
        {
            CollectionList = await _collectionService.GetAllCollectionList();
            _CollectionList = CollectionList.Items;
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    //_getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

        //    //// ColorDropdownListModel = await _getDropdownService.GetAllColor(null, null, null, 100);


        //    //if (Module == "All" || Module == "Warehouse")
        //    //{
        //    //    MaterialTypeModel = await _getDropdownService.GetAllMaterialType(1, null, null, null, 100);
        //    //    MaterialTypeAllModel = await _getDropdownService.GetAllMaterialType(2, null, null, null, 100);
        //    //}

        //    //else if (Module == "Greige")
        //    //{
        //    //    if (CategoryId == 1)
        //    //    {
        //    //        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(1, null, null, null, 100);
        //    //    }
        //    //}

        //    //else if (Module == "Fabric")
        //    //{
        //    //    if (CategoryId == 2)
        //    //    {
        //    //        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(2, null, null, null, 100);
        //    //    }
        //    //}

        //    //else
        //    //{
        //    //    if (CategoryId == 3)
        //    //    {
        //    //        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(3, null, null, null, 100);
        //    //    }

        //    //    else if (CategoryId == 4)
        //    //    {
        //    //        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(4, null, null, null, 100);
        //    //    }

        //    //    else if (CategoryId == 99)
        //    //    {
        //    //        MaterialTypeModel = await _getDropdownService.GetAllMaterialType(99, null, null, null, 100);
        //    //    }
        //    //}


        //    //if (CategoryId == 1 || CategoryId == 2)
        //    //{
        //    //    await GetTopUsedSoldMaterial();
        //    //    await GetMaterialPerMaterialType();
        //    //    await GetWarehouseCapacityPerMaterialType();
        //    //    // await GetPieGraphData();
        //    //}
        //    //if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
        //    //{
        //    //    await GetTopUsedSoldSubMaterial();
        //    //    await GetSubMaterialPerMaterialType();
        //    //    await GetWarehouseCapacityPerMaterialType();

        //    //    // await GetPieGraphData();
        //    //}
        //}


        private async Task GetMaterialPerColor()
        {

            MaterialPerColorList.Clear();
            MaterialPerColorLabel.Clear();
            List<string> colors = new();


            int? id = null;
            if (Module != "All")
            {
                id = CategoryId;
                if (Module == "Warehouse")
                {
                    id = null;
                }
            }
            var material = await _materialService.GetColor(id);

            if (material != null)
            {
                foreach (var item in material.Result)
                {
                    MaterialPerColorList.Add(item.Value);
                    _colorBarConfig.Data.Labels.Add(item.Key);
                    colors.Add(ColorDropdownListModel.Result.Items.FirstOrDefault(x => x.Label == item.Key).HexCode);
                }

                string[] bgColors = colors.ToArray();

                BarDataset<double?> bardataset_1 = new BarDataset<double?>(MaterialPerColorList)
                {
                    Label = "",
                    BackgroundColor = bgColors
                };
                _colorBarConfig.Data.Datasets.Add(bardataset_1);
            }
        }

        private async Task GetSubMaterialPerColor()
        {

            SubMaterialPerColorList.Clear();
            SubMaterialPerColorLabel.Clear();
            List<string> colors = new();


            int? id = null;
            if (Module != "All")
            {
                id = CategoryId;
                if (Module == "Warehouse")
                {
                    id = null;
                }
            }
            var subMaterial = await _subMaterialService.GetSubMaterialColor(id);

            if (subMaterial != null)
            {
                foreach (var item in subMaterial.Result)
                {
                    SubMaterialPerColorList.Add(item.Value);
                    _colorBarConfig.Data.Labels.Add(item.Key);
                    colors.Add(ColorDropdownListModel.Result.Items.FirstOrDefault(x => x.Label == item.Key).HexCode);
                }

                string[] bgColors = colors.ToArray();

                BarDataset<double?> bardataset_1 = new BarDataset<double?>(SubMaterialPerColorList)
                {
                    Label = "",
                    BackgroundColor = bgColors
                };
                _colorBarConfig.Data.Datasets.Add(bardataset_1);
            }
        }

        private async Task GetMaterialPerMaterialTypes()
        {
            MaterialPerMaterialTypeList.Clear();
            MaterialPerMaterialTypeLabel.Clear();
            List<string> colors = new();

            int? id = null;
            if (Module != "All")
            {
                id = CategoryId;
                if (Module == "Warehouse")
                {
                    id = null;
                }
            }
            var material = await _materialService.GetMaterialPerMaterialTypes(id);

            if (material != null)
            {
                foreach (var item in material.Result)
                {
                    MaterialPerMaterialTypeList.Add(item.Value);
                    _colorBarConfig1.Data.Labels.Add(item.Key);
                    colors.Add(ColorUtil.ColorHexString(245, 199, 166));
                }

                string[] bgColors = colors.ToArray();

                BarDataset<double?> bardataset_1 = new BarDataset<double?>(MaterialPerMaterialTypeList)
                {
                    Label = "",
                    BackgroundColor = bgColors
                };
                _colorBarConfig1.Data.Datasets.Add(bardataset_1);
            }

            //if (material != null)
            //{
            //    foreach (var item in material.Result)
            //    {
            //        MaterialPerMaterialTypeList.Add(item.Value);
            //        MaterialPerMaterialTypeLabel.Add(item.Key);

            //    }

            //    foreach (string item in MaterialPerMaterialTypeLabel)
            //    {
            //        _barconfig2.Data.Labels.Add(item);

            //    }

            //    BarDataset<double?> bardataset_1 = new BarDataset<double?>(MaterialPerMaterialTypeList)
            //    {
            //        Label = "Bar 1",
            //        BackgroundColor = new[]{
            //    ColorUtil.ColorHexString(245,199,166),
            //    ColorUtil.ColorHexString(244,233,225),
            //    ColorUtil.ColorHexString(103,107,112),
            //    ColorUtil.ColorHexString(220,179,150),
            //    ColorUtil.ColorHexString(123,142,97),
            //    ColorUtil.ColorHexString(30,43,13),
            //    ColorUtil.ColorHexString(204,201,198),
            //    ColorUtil.ColorHexString(168,194,132),
            //    ColorUtil.ColorHexString(102,117,80),
            //    ColorUtil.ColorHexString(163,92,60),
            //    ColorUtil.ColorHexString(163,92,60),
            //     }
            //    };
            //    _barconfig2.Data.Datasets.Add(bardataset_1);
            //}
        }

        private async Task GetSubMaterialPerMaterialTypes()
        {
            SubMaterialPerMaterialTypeList.Clear();
            SubMaterialPerMaterialTypeLabel.Clear();
            List<string> colors = new();

            int? id = null;
            if (Module != "All")
            {
                id = CategoryId;
                if (Module == "Warehouse")
                {
                    id = null;
                }
            }
            var subMaterial = await _subMaterialService.GetSubMaterialPerMaterialTypes(id);

            if (subMaterial != null)
            {
                foreach (var item in subMaterial.Result)
                {
                    SubMaterialPerMaterialTypeList.Add(item.Value);
                    _colorBarConfig1.Data.Labels.Add(item.Key);
                    colors.Add(ColorUtil.ColorHexString(245, 199, 166));
                }

                string[] bgColors = colors.ToArray();

                BarDataset<double?> bardataset_1 = new BarDataset<double?>(SubMaterialPerMaterialTypeList)
                {
                    Label = "",
                    BackgroundColor = bgColors
                };
                _colorBarConfig1.Data.Datasets.Add(bardataset_1);
            }

            //if (subMaterial != null)
            //{
            //    foreach (var item in subMaterial.Result)
            //    {
            //        SubMaterialPerMaterialTypeList.Add(item.Value);
            //        SubMaterialPerMaterialTypeLabel.Add(item.Key);

            //    }

            //    foreach (string item in SubMaterialPerMaterialTypeLabel)
            //    {
            //        _barconfig2.Data.Labels.Add(item);

            //    }

            //    BarDataset<double?> bardataset_1 = new BarDataset<double?>(SubMaterialPerMaterialTypeList)
            //    {
            //        Label = "Bar 1",
            //        BackgroundColor = new[]{
            //    ColorUtil.ColorHexString(245,199,166),
            //    ColorUtil.ColorHexString(244,233,225),
            //    ColorUtil.ColorHexString(103,107,112),
            //    ColorUtil.ColorHexString(220,179,150),
            //    ColorUtil.ColorHexString(123,142,97),
            //    ColorUtil.ColorHexString(30,43,13),
            //    ColorUtil.ColorHexString(204,201,198),
            //    ColorUtil.ColorHexString(168,194,132),
            //    ColorUtil.ColorHexString(102,117,80),
            //    ColorUtil.ColorHexString(163,92,60),
            //     }
            //    };
            //    _barconfig2.Data.Datasets.Add(bardataset_1);
            //}
        }

        private async Task GetWarehouseCapacityPerMaterialType()
        {
            CountPerLocationUsed.Clear();
            CountPerLocationAvailable.Clear();
            CountPerLocationExcess.Clear();

            //int? id = null;
            //if (Module != "All" || Module != "Warehouse")
            //{
            //    id = CategoryId;
            //}

            int? id = null;
            if (Module != "All")
            {
                id = CategoryId;
                if (Module == "Warehouse")
                {
                    id = null;
                }
            }

            var material = await _materialService.GetWarehouseCapacityPerMaterialType(id);

            //Console.WriteLine(JsonSerializer.Serialize(material));

            if (material != null)
            {
                CountPerLocationUsed.Add(material.Result.SsyCebuCurrentTotalInventory);
                CountPerLocationUsed.Add(material.Result.CambodiaCurrentTotalInventory);
                //CountPerLocationUsed.Add(material.Result.OthersCurrentTotalInventory);

                CountPerLocationAvailable.Add(material.Result.SsyCebuAvailableSpacePreDisposal);
                CountPerLocationAvailable.Add(material.Result.CambodiaAvailableSpacePreDisposal);
                CountPerLocationAvailable.Add(0);

                CountPerLocationExcess.Add(material.Result.SsyCebuWarehouseCapacity - material.Result.SsyCebuCurrentTotalInventory);
                CountPerLocationExcess.Add(material.Result.CambodiaWarehouseCapacity - material.Result.CambodiaCurrentTotalInventory);
                CountPerLocationExcess.Add(0);

                _barconfig3.Data.Labels.Add("Cebu");
                _barconfig3.Data.Labels.Add("Cambodia");
                //_barconfig3.Data.Labels.Add("Others");

                BarDataset<double?> bardataset_1 = new BarDataset<double?>(CountPerLocationUsed)
                {
                    Label = "Used",
                    BackgroundColor = new[]{
                ColorUtil.ColorHexString(245,199,166),
                ColorUtil.ColorHexString(245,199,166),
                ColorUtil.ColorHexString(245,199,166),
                 }
                };

                BarDataset<double?> bardataset_2 = new BarDataset<double?>(CountPerLocationAvailable)
                {
                    Label = "Available",
                    BackgroundColor = new[]{
                ColorUtil.ColorHexString(168,194,132),
                ColorUtil.ColorHexString(168,194,132),
                ColorUtil.ColorHexString(168,194,132),


                }
                };
                //BarDataset<double?> bardataset_3 = new BarDataset<double?>(CountPerLocationExcess)
                //{
                //    Label = "Excess",
                //    BackgroundColor = new[]{
                //ColorUtil.ColorHexString(204,201,198),
                //ColorUtil.ColorHexString(204,201,198),
                //ColorUtil.ColorHexString(204,201,198),
                //}
                //};
                _barconfig3.Data.Datasets.Add(bardataset_1);
                _barconfig3.Data.Datasets.Add(bardataset_2);
                //_barconfig3.Data.Datasets.Add(bardataset_3);
            }

        }

        //private async Task GetSubMaterialPerMaterialType()
        //{
        //    SubMaterialPerMaterialTypeList.Clear();
        //    SubMaterialPerMaterialTypeLabel.Clear();
        //    var submaterial = await _subMaterialService.GetSubMaterialPerMaterialType(CategoryId);

        //    if (submaterial != null)
        //    {
        //        foreach (var item in submaterial.Result)
        //        {
        //            var key = item.Key;
        //            if (key.Length > 10)
        //                key = key.Substring(0, 10);

        //            SubMaterialPerMaterialTypeList.Add(item.Value);
        //            SubMaterialPerMaterialTypeLabel.Add(key);
        //        }

        //        foreach (string item in SubMaterialPerMaterialTypeLabel)
        //        {
        //            _barconfig2.Data.Labels.Add(item);

        //        }

        //        BarDataset<double?> bardataset_1 = new BarDataset<double?>(SubMaterialPerMaterialTypeList)
        //        {
        //            Label = "Bar 1",
        //            BackgroundColor = new[]{
        //        ColorUtil.ColorHexString(245,199,166),
        //        ColorUtil.ColorHexString(244,233,225),
        //        ColorUtil.ColorHexString(103,107,112),
        //        ColorUtil.ColorHexString(220,179,150),
        //        ColorUtil.ColorHexString(123,142,97),
        //        ColorUtil.ColorHexString(30,43,13),
        //        ColorUtil.ColorHexString(204,201,198),
        //        ColorUtil.ColorHexString(168,194,132),
        //        ColorUtil.ColorHexString(102,117,80),
        //        ColorUtil.ColorHexString(163,92,60),
        //         }
        //        };
        //        _barconfig2.Data.Datasets.Add(bardataset_1);
        //    }
        //}

        private async Task GetPieGraphData()
        {
            PieList.Clear();
            PieLabel.Clear();

            if (CategoryId == 1 || CategoryId == 2)
            {
                int? id = null;
                if (Module != "All" || Module != "Warehouse")
                {
                    id = CategoryId;
                }
                var material = await _materialService.GetMaterialCountPerInfluencerAndMaterialType(id);

                if (material != null)
                {
                    foreach (var item in material.Result)
                    {
                        PieList.Add(item.Value);
                        PieLabel.Add(item.Key.Substring(0, 10));
                    }

                    foreach (string item in PieLabel)
                    {
                        _pieconfig.Data.Labels.Add(item);
                    }

                    PieDataset<double?> piedataset = new PieDataset<double?>(PieList)
                    {
                        BackgroundColor = new[]{
                    ColorUtil.ColorHexString(138, 78, 51),
                    ColorUtil.ColorHexString(245, 200, 166),
                    ColorUtil.ColorHexString(168, 194, 132),
                    ColorUtil.ColorHexString(220, 179, 150),
                    ColorUtil.ColorHexString(102, 117, 80),
                    ColorUtil.ColorHexString(103, 107, 112),
                    ColorUtil.ColorHexString(245, 232, 225),
                    ColorUtil.ColorHexString(48, 69, 20),
                    ColorUtil.ColorHexString(163, 92, 61),
                    ColorUtil.ColorHexString(231, 226, 223),
                     ColorUtil.ColorHexString(123, 142, 97),
                    }
                    };

                    _pieconfig.Data.Datasets.Add(piedataset);
                }

            }
            if (CategoryId == 3 || CategoryId == 4 || CategoryId == 99)
            {
                var submaterial = await _subMaterialService.GetSubMaterialCountPerInfluencerAndMaterialType(CategoryId);

                if (submaterial != null)
                {
                    foreach (var item in submaterial.Result)
                    {
                        PieList.Add(item.Value);
                        PieLabel.Add(item.Key.Substring(0, 10));
                    }

                    foreach (string item in PieLabel)
                    {
                        _pieconfig.Data.Labels.Add(item);
                    }

                    PieDataset<double?> piedataset = new PieDataset<double?>(PieList)
                    {
                        BackgroundColor = new[]{
                    ColorUtil.ColorHexString(138, 78, 51),
                    ColorUtil.ColorHexString(245, 200, 166),
                    ColorUtil.ColorHexString(168, 194, 132),
                    ColorUtil.ColorHexString(220, 179, 150),
                    ColorUtil.ColorHexString(102, 117, 80),
                    ColorUtil.ColorHexString(103, 107, 112),
                    ColorUtil.ColorHexString(245, 232, 225),
                    ColorUtil.ColorHexString(48, 69, 20),
                    ColorUtil.ColorHexString(163, 92, 61),
                    ColorUtil.ColorHexString(231, 226, 223),
                     ColorUtil.ColorHexString(123, 142, 97),
                    }
                    };

                    _pieconfig.Data.Datasets.Add(piedataset);
                }

            }



        }

        public async Task GetTopUsedSoldMaterial()
        {
            UsedCountList.Clear();
            UsedCountLabel.Clear();
            int? id = null;
            if (Module != "All" || Module != "Warehouse")
            {
                id = CategoryId;
            }
            var material = await _materialService.GetTopUsedMaterial(id);

            if (material != null)
            {
                foreach (var item in material.Result)
                {
                    UsedCountList.Add(item.Value);
                    UsedCountLabel.Add(item.Key.Substring(0, 10));
                }

                foreach (string label in UsedCountLabel)
                {
                    _barconfig.Data.Labels.Add(label);
                }

                BarDataset<double?> bardataset = new BarDataset<double?>(UsedCountList)
                {
                    Label = "",
                    BackgroundColor = new[]{
                ColorUtil.ColorHexString(245,199,166),
                ColorUtil.ColorHexString(244,233,225),
                ColorUtil.ColorHexString(103,107,112),
                ColorUtil.ColorHexString(220,179,150),
                ColorUtil.ColorHexString(123,142,97),
                ColorUtil.ColorHexString(30,43,13),
                ColorUtil.ColorHexString(204,201,198),
                ColorUtil.ColorHexString(168,194,132),
                ColorUtil.ColorHexString(102,117,80),
                ColorUtil.ColorHexString(163,92,60),

                 }
                };
                _barconfig.Data.Datasets.Add(bardataset);
            }

        }

        public async Task GetTopUsedSoldSubMaterial()
        {
            UsedCountList.Clear();
            UsedCountLabel.Clear();
            var submaterial = await _subMaterialService.GetTopUsedSubMaterial(CategoryId);

            if (submaterial != null)
            {
                foreach (var item in submaterial.Result)
                {
                    var key = item.Key;
                    if (key.Length > 10)
                        key = key.Substring(0, 10);

                    UsedCountList.Add(item.Value);
                    UsedCountLabel.Add(key);

                }

                foreach (string label in UsedCountLabel)
                {
                    _barconfig.Data.Labels.Add(label);
                }

                BarDataset<double?> bardataset = new BarDataset<double?>(UsedCountList)
                {
                    Label = "",
                    BackgroundColor = new[]{
                "white",

                 }
                };
                _barconfig.Data.Datasets.Add(bardataset);
            }
        }

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

    }


}

