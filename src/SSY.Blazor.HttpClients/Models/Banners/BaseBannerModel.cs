using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace SSY.Blazor.HttpClients.Models.Banners
{
    public class BaseBannerModel
    {
        public List<IconList> Icons { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
    }

    public class IconList
    {
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public string IconTitle { get; set; }
    }
}
