using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace SSY.Blazor.HttpClients.Models.Banners
{

    public class ProductBannerModel
    {
        public BaseBannerModel Banner { get; set; }

        public ProductBannerModel()
        {
            Banner = new() { Icons = new() };
            Banner.Icons.Add(new IconList()
            {
                IconTitle = "Ordered Samples",
                Icon = "fa-shopping-bag",
                IconUrl = "yourprod/orderedsamples"
            });
            Banner.Icons.Add(new IconList()
            {
                IconTitle = "Collections",
                Icon = "fa-picture-o",
                IconUrl = "yourprod/collections"
            });

            Banner.Header = "Your Designs";
            Banner.Description = "All of your inspiration and creations are here";
        }

    }


}


