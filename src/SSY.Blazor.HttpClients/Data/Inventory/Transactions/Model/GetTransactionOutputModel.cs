using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Transactions.Model
{
    public class GetTransactionOutputModel
    {
        [JsonPropertyName("result")]
        public TransactionModel Result { get; set; }
    }
}

