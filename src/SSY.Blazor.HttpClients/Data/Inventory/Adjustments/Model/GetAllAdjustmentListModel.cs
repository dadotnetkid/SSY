using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model
{
    public class GetAllAdjustmentListModel
    {
        [JsonPropertyName("result")]
        public List<GetAllAdjustmentModel> Result { get; set; }
    }


}


