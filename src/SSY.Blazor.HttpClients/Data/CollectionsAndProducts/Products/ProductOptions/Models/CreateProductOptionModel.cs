namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Models
{
    public class CreateProductOptionModel
    {
        public int GenderId { get; set; }

        public int RiseId { get; set; }

        public int WaistBandId { get; set; }

        public virtual ICollection<CreateWaistBandPocketModel> WaistBandPockets { get; set; }

        public bool IsFrontSeam { get; set; }

        public int LengthId { get; set; }

        public virtual ICollection<CreatePanelModel> Panels { get; set; }

        public Guid ProductId { get; set; }
    }
}
