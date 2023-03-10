using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SampleImages.Model
{
    public class SampleImagesListModel
    {
        public List<SampleImagesModel> SampleImages { get; set; } = new();


    }


}


