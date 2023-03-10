using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace SSY.Blazor.HttpClients.Models.Banners
{

    public class DesignBannerModel
    {
        public BaseBannerModel Banner { get; set; }

        public DesignBannerModel()
        {
            Banner = new() { Icons = new() };
            Banner.Icons.Add(new IconList()
            {
                IconTitle = "Inspiration",
                Icon = "fa-heart",
                IconUrl = "design/inspiration"
            });
            Banner.Icons.Add(new IconList()
            {
                IconTitle = "Design Images",
                Icon = "fa-paint-brush",
                IconUrl = "design/designimage"
            });
            Banner.Icons.Add(new IconList()
            {
                IconTitle = "Virtual Fitting",
                Icon = "fa-cube",
                IconUrl = "design/virtualfitting"
            });
            Banner.Icons.Add(new IconList()
            {
                IconTitle = "Sample Images",
                Icon = "fa-heart",
                IconUrl = "design/sampleimages"
            });
            Banner.Header = "Your Designs";
            Banner.Description = "All of your inspiration and creations are here";
        }

    }


}


