namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Models
{
    public class UpdateProductOptionModel
    {
        public Guid Id { get; set; }

        public int GenderId { get; set; }

        public int RiseId { get; set; }

        public int WaistBandId { get; set; }

        public virtual ICollection<UpdateWaistBandPocketModel> WaistBandPockets { get; set; }

        public bool IsFrontSeam { get; set; }

        public int LengthId { get; set; }

        public virtual ICollection<UpdatePanelModel> Panels { get; set; }
    }
}
