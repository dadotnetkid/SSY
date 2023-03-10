using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;

public class ProductBOMModel
{
    public int PartNumber { get; set; }
    public string PartName { get; set; }
    public string ItemCode { get; set; }
    public double Consumption { get; set; }
    public string UnitOfMeasurement { get; set; }
    public string CuttableWidth { get; set; }
    public string ContentDescription { get; set; }
    public double Price { get; set; }
    public string Supplier { get; set; }

    public List<ColorWay> ColorWays { get; set; } = new();

    public class ColorWay
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}