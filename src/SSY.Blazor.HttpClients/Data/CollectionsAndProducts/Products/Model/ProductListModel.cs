using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class ProductListModel
    {
        public List<ProductModel> Products { get; set; } = new();
    }
}

