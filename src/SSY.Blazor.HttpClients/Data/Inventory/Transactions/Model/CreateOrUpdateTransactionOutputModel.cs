using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Transactions.Model
{
    public class CreateOrUpdateTransactionOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }
    }
}

