using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.OrderStatus.Model;

public class OrderStatusListModel
{
    [JsonPropertyName("productStatuses")]
    public List<OrderStatusModel> ProductOrderStatuses { get; set; } = new();
}

