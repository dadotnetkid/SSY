using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.VirtualFitting.Model
{
    public class VirtualFittingListModel
    {
        public List<VirtualFittingModel> VirtualFitting { get; set; } = new();


    }


}


