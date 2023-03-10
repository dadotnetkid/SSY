using Blazorise.Charts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSY.Blazor.Pages.Inventory.GraphV2
{
    public partial class GraphV2
    {
        public GraphV2()
        {
        }
        
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

        #region Services
        public MaterialService _materialService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }

         public CollectionService _collectionService { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int CategoryId { get; set; }

        [Parameter]
        public string Module { get; set; }

        [Parameter]
        public string PageName { get; set; }

        [Parameter]
        public List<UserDetailModelCC> UserDetailListModel { get; set; } = new();

        #endregion

        #region Models
        public ColorListModel ColorDropdownListModel { get; set; } = new() { Result = new() { Items = new() } };

        #endregion

        #region Most Available Color Bar Chart Setup

        Chart<double> AvailableColorsBarChart;
        List<string> MaterialPerColorLabels {get;set;}  = new();
        List<double> MaterialPerColorData { get; set; } = new();

        #endregion

        #region Most Available Materials Bar Chart Setup

        Chart<double> AvailableMaterialsBarChart;
        List<string> MaterialLabels {get;set;}  = new();
        List<double> MaterialData { get; set; } = new();

        #endregion

        #region Warehouse Capacity per Material Type Setup

        Chart<double> WarehouseCapacityPerMaterialTypeBarChart;
        
        List<string> WarehouseCapacityPerMaterialTypeLabels {get;set;}  = new();

         List<double> CountPerLocationUsed { get; set; } = new();
         List<double> CountPerLocationAvailable { get; set; } = new();
         List<double> CountPerLocationExcess { get; set; } = new();

        #endregion

        private IEnumerable<CollectionListDto> _CollectionList { get; set; }
        public GetAllCollectionListDto CollectionList { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            try
            {
                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
                _collectionService = new(js, ClientFactory, NavigationManager, Configuration);

                ColorDropdownListModel = await _getDropdownService.GetAllColor(null, null, null, 100);

                await GetMaterialPerColor();
                await GetMaterialPerMaterialTypes();
                await GetWarehousePerMaterialTypes();
                await GetAllCollection();
                await GetForecastQuantity();
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

        private async Task GetMaterialPerColor()
        {
            MaterialPerColorData.Clear();
            MaterialPerColorLabels.Clear();
            List<string> colors = new();
            List<string> borderColors = new();

            int? id = null;
            if (Module != "All")
            {
                id = CategoryId;
                if (Module == "Warehouse")
                {
                    id = null;
                }
            }
            var material = await _materialService.GetColor(2);
            Console.WriteLine(JsonSerializer.Serialize(material));
            if (material.Result.Any())
            {
                foreach (var item in material.Result)
                {
                    MaterialPerColorData.Add(item.Value + (double)10);
                    MaterialPerColorLabels.Add(item.Key);
                    colors.Add(ColorDropdownListModel.Result.Items.FirstOrDefault(x => x.Label == item.Key).HexCode);
                    borderColors.Add("#000000");
                }
            }
            await AvailableColorsBarChart.Clear();
            await AvailableColorsBarChart
                .AddLabelsDatasetsAndUpdate(
                    MaterialPerColorLabels,
                    GetBarChartDataset(
                        "MOST AVAILABLE COLORS",
                        MaterialPerColorData,
                        colors,
                        borderColors
                    )
                );
            
        }

        private async Task GetMaterialPerMaterialTypes()
        {

            // note : all commented code in this function is testing for doouble data dont clear just for testing
            MaterialLabels.Clear();
            MaterialData.Clear();
            List<string> colors = new();
            List<string> borderColors = new();
            // List<double> xxx = new();
            // List<string> xxxcolors = new();

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
                    // Random rnd = new Random();
                    MaterialData.Add(item.Value);
                    // xxx.Add(rnd.Next(100000,200000));
                    MaterialLabels.Add(item.Key);
                    colors.Add(ChartColor.FromRgba( 245, 199, 166, 1f ));
                    // xxxcolors.Add(ChartColor.FromRgba( 245, 245, 166, 1f ));
                    borderColors.Add("#000000");
                }
            }
            await AvailableMaterialsBarChart.Clear();
            await AvailableMaterialsBarChart
                .AddLabelsDatasetsAndUpdate(
                    MaterialLabels,
                    GetBarChartDataset(
                        "MOST AVAILABLE MATERIALS",
                        MaterialData,
                        colors,
                        borderColors
                    )
                    // ,
                    // GetBarChartDataset(
                    //     "Billy",
                    //     xxx,
                    //     xxxcolors,
                    //     borderColors
                    // )
                );
                
        }

        private async Task GetWarehousePerMaterialTypes()
        {

            // note : all commented code in this function is testing for doouble data dont clear just for testing
            MaterialLabels.Clear();
            MaterialData.Clear();
            List<string> colors = new();
            List<string> used = new();
            List<string> available = new();
            List<string> borderColors = new();
            // List<double> xxx = new();
            // List<string> xxxcolors = new();

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

            if (material != null)
            {       
                    // Random rnd = new Random();
                    CountPerLocationUsed.Add(material.Result.SsyCebuCurrentTotalInventory);
                    CountPerLocationUsed.Add(material.Result.CambodiaCurrentTotalInventory);
                    //CountPerLocationUsed.Add(material.Result.OthersCurrentTotalInventory);

                    CountPerLocationAvailable.Add(material.Result.SsyCebuAvailableSpacePreDisposal);
                    CountPerLocationAvailable.Add(material.Result.CambodiaAvailableSpacePreDisposal);
                    CountPerLocationAvailable.Add(0);

                    CountPerLocationExcess.Add(material.Result.SsyCebuWarehouseCapacity - material.Result.SsyCebuCurrentTotalInventory);
                    CountPerLocationExcess.Add(material.Result.CambodiaWarehouseCapacity - material.Result.CambodiaCurrentTotalInventory);
                    CountPerLocationExcess.Add(0);
                    // xxx.Add(rnd.Next(100000,200000));
                    WarehouseCapacityPerMaterialTypeLabels.Add("Cebu");
                    WarehouseCapacityPerMaterialTypeLabels.Add("Cambodia");
                    
                    used.Add(ChartColor.FromRgba(168,194,132, 1f));
                    available.Add(ChartColor.FromRgba(245, 199, 166, 1f));
                    borderColors.Add("#000000");
            }
            await WarehouseCapacityPerMaterialTypeBarChart.Clear();
            await WarehouseCapacityPerMaterialTypeBarChart
                .AddLabelsDatasetsAndUpdate(
                    WarehouseCapacityPerMaterialTypeLabels,
                    GetBarChartDataset(
                        "Used",
                        CountPerLocationUsed,
                        used,
                        borderColors
                    ),
                    GetBarChartDataset(
                        "Available",
                        CountPerLocationAvailable,
                        available,
                        borderColors
                    )
                );
        }

        private BarChartDataset<double> GetBarChartDataset(string label, List<double> data, List<string> bgColor, List<string> borderColors)
        {
            return new()
            {
                Label = label,
                Data = data,
                BackgroundColor = bgColor,
                BorderColor = borderColors,
                BorderWidth = 1
            };
        }
        

        //Collection
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

         ChartOptions options = new()
        {
           
            Plugins = new()
            {
                Legend = new()
                {
                    Display = false,
                }
                
            }
        };
    }
}
