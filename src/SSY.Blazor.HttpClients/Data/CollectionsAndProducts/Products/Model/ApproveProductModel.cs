namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class ApproveProductModel
    {
        public List<Guid> ProductIds { get; set; }
        public ApproveProductModel()
        {
            ProductIds = new();
        }
    }
}