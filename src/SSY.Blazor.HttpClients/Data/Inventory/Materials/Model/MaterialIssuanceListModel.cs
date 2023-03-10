using System;
namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class MaterialIssuanceListModel
    {
        public List<MaterialIssuanceModel> Issuance { get; set; } = new();
    }
}

