namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Models
{
    public class GetProductOptionOutputModel
    {
        public Guid Id { get; set; }

        public int GenderId { get; set; }

        public int RiseId { get; set; }

        public int WaistBandId { get; set; }

        public virtual ICollection<GetWaistBandPocketOutputModel> WaistBandPockets { get; set; }

        public bool IsFrontSeam { get; set; }

        public int LengthId { get; set; }

        public virtual ICollection<GetPanelOutputModel> Panels { get; set; }
    }
}
