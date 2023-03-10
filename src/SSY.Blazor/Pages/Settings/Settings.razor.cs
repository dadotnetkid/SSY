using SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model;
using SSY.Blazor.HttpClients.Models.ProductReservations;
using SSY.Blazor.Pages.Settings.Components.DistributionList;
using ReservationColorModel = SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationColors.Model.ReservationColorModel;

namespace SSY.Blazor.Pages.Settings
{
    public partial class Settings
    {
        public Settings()
        {
        }

        public string Module = "Settings";
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

        public ReservationMaterialTypeModel ReservationMaterialTypeModel { get; set; }

        public ReservationColorModel ReservationColorModel { get; set; }

        public ReservationProductTypeModel ReservationProductTypeModel { get; set; }

        public DistributionList DistributionList { get; set; }

    }

}