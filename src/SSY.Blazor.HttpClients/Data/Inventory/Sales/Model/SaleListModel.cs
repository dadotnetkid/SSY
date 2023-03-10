using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Sales.Model
{
    public class SaleListModel
    {
        public List<SaleModel> Sales { get; set; } = new();


    }


}


