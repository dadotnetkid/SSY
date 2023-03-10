using SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model;
using SSY.Blazor.HttpClients.Models.ProductReservations;
using ReservationColorModel = SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationColors.Model.ReservationColorModel;

namespace SSY.Blazor.Pages.CollectionAndProduct.Components.Dashboard
{
    public partial class Dashboard
    {
        public Dashboard()
        {
        }
        public string ModuleMessage = "";
        //public string ModuleType = "view";
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
       
     
        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public string PageName { get; set; }

        public ReservationMaterialTypeModel ReservationMaterialTypeModel { get; set; }

        public ReservationColorModel ReservationColorModel { get; set; }

        public ReservationProductTypeModel ReservationProductTypeModel { get; set; }

    }

}