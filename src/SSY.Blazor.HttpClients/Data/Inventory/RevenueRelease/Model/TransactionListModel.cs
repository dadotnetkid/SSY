using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease.Model
{
    public class TransactionListModel
    {
        public List<TransactionModel> Transaction { get; set; } = new();

    }


}


