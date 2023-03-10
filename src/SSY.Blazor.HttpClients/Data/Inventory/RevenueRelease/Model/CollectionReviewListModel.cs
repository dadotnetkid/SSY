using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease.Model
{
    public class CollectionReviewListModel
    {
        public List<CollectionReviewModel> CollectionReview { get; set; } = new();

    }


}


