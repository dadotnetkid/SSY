using System;
namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class SubMaterialIssuanceListModel
    {
        public List<SubMaterialIssuanceModel> Issuance { get; set; } = new();
    }
}

