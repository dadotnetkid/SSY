using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.DesignImages.Model
{
    public class DesignImagesListModel
    {
        public List<DesignImagesModel> DesignImages { get; set; } = new();


    }


}


