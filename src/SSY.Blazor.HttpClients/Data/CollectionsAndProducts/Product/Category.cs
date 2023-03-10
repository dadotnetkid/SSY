using System;
using System.ComponentModel.DataAnnotations;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product
{
    public class Category
    {
        public int Id { get; set; }
        public int? RootId { get; set; }
        public int? ParentId { get; set; }
        public int OrderNumber { get; set; }
        public string Name { get; set; }
    }
}