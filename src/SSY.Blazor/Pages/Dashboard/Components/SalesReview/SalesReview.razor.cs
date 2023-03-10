// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
// using System.Text.Json;
// using System.Text.Json.Serialization;
// using System.Threading.Tasks;
// using System.Net.Http;
// using System.Collections.Generic;
// using SSY.Web.Blazor.Core.Models;
// using Microsoft.JSInterop;
// using ChartJs.Blazor.BarChart;
// using ChartJs.Blazor.LineChart;
// using ChartJs.Blazor.PieChart;
// using System.Drawing;
// using ChartJs.Blazor.Util;
// using ChartJs.Blazor.Common;
// using ChartJs.Blazor.Common.Axes;
// using ChartJs.Blazor.Common.Axes.Ticks;
// using ChartJs.Blazor.Common.Enums;
// using ChartJs.Blazor.Common.Handlers;
// using ChartJs.Blazor.Common.Time;
// using ChartJs.Blazor.Interop;


// namespace SSY.Web.Blazor.Pages.Dashboard.SalesReport
// {
//     public partial class SalesReport
//     {
//         public SalesReport()
//         {
//         }

//         // protected override void OnInitialized()
//         // {
//         //     productListModel = new();
//         // }


//         public int Counter { get; set; } = 1;

//         [Inject]
//         public IJSRuntime js { get; set; }

//         [Inject]
//         public ProtectedSessionStorage SessionStorage { get; set; }
//         // [Inject]
//         //       public IHttpClientFactory ClientFactory { get; set; }
//         [Inject]
//         public NavigationManager NavigationManager { get; set; }

//         // public ProductListModel productListModel { get; set; }

//         public string Module = "Inventory";
//         public string ModuleMessage = "";

//         private BarConfig _barconfig;
//         private LineConfig _lineconfig;
//         private PieConfig _config;

//         protected override void OnInitialized()
//         {
//             // bar chart setup
//             _barconfig = new BarConfig
//             {
//                 Options = new BarOptions
//                 {
//                     Responsive = true,
//                     Title = new ChartJs.Blazor.Common.OptionsTitle
//                     {
//                         Display = true,
//                     }
//                 }
//             };

//             foreach (string color in new[] { "January", "Febuary", "March", "April", "may" })
//             {
//                 _barconfig.Data.Labels.Add(color);
//             }

//             BarDataset<int> bardataset = new BarDataset<int>(new[] { -6, 35, 11, 57, 46 })
//             {
//                 Label = "Bar 1",
//                 BackgroundColor = new[]{
//                 ColorUtil.ColorHexString(255, 99, 132),
//                 ColorUtil.ColorHexString(255, 99, 132),
//                 ColorUtil.ColorHexString(255, 99, 132),
//                 ColorUtil.ColorHexString(255, 99, 132),
//                 ColorUtil.ColorHexString(255, 99, 132),
//             }
//             };
//             _barconfig.Data.Datasets.Add(bardataset);
//             // _barconfig.Data.Datasets.Add(bardataset2);
//         }



//     }


// }

