using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.OrderStatus.Model;

public class GetOrderStatusOutputModel
{
    [JsonPropertyName("result")]
    public OrderStatusModel Result { get; set; } = new();
}

