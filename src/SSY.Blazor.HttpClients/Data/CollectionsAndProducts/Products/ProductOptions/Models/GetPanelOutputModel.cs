﻿namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Models
{
    public class GetPanelOutputModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Option1Id { get; set; }

        public int Option2Id { get; set; }

        public int Option3Id { get; set; }

        public double Consumption { get; set; }

        public double Yardage { get; set; }

        public int FabricId { get; set; }

        public int RollId { get; set; }
    }
}
