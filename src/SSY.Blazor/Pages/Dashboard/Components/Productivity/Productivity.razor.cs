using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;

namespace SSY.Blazor.Pages.Dashboard.Components.Productivity
{
    public partial class Productivity
    {
        public Productivity()
        {
        }

    


        public int Counter { get; set; } = 1;

        [Inject]
        public IJSRuntime js { get; set; }

        [Inject]
        public ProtectedSessionStorage SessionStorage { get; set; }
        // [Inject]
        //       public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        // public ProductListModel productListModel { get; set; }


        private BarConfig _barconfig;
        private LineConfig _lineconfig;
        private PieConfig _config;

        protected override void OnInitialized()
        {
            // bar chart setup
            _barconfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Responsive = true,
                    Title = new ChartJs.Blazor.Common.OptionsTitle
                    {
                        Display = true,
                    }
                }
            };

            foreach (string color in new[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" })
            {
                _barconfig.Data.Labels.Add(color);
            }

            BarDataset<int> bardataset = new BarDataset<int>(new[] { -6, 35, 11, 57, 46, -6, 35, 11, 57, 46, 1, 2 })
            {
                Label = "Bar 1",
                BackgroundColor = new[]{
                ColorUtil.ColorHexString(123, 142, 97),
                ColorUtil.ColorHexString(215, 226, 200),
                ColorUtil.ColorHexString(123, 142, 97),
                ColorUtil.ColorHexString(215, 226, 200),
                ColorUtil.ColorHexString(123, 142, 97),
                ColorUtil.ColorHexString(215, 226, 200),
                ColorUtil.ColorHexString(123, 142, 97),
                ColorUtil.ColorHexString(215, 226, 200),
                ColorUtil.ColorHexString(123, 142, 97),
                ColorUtil.ColorHexString(215, 226, 200),
                ColorUtil.ColorHexString(123, 142, 97),
                ColorUtil.ColorHexString(215, 226, 200),
            }
        

            
            };
            _barconfig.Data.Datasets.Add(bardataset);
            // _barconfig.Data.Datasets.Add(bardataset2);
        }



    }


}

