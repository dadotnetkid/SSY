namespace SSY.Blazor.Pages.Inventory.Warehouse.Component
{
    public partial class WarehouseTable
    {


        #region Injections

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private MaterialService _materialService { get; set; }
        private PurchaseOrderService _purchaseOrderService { get; set; }


        #endregion

        #region Parameters


        [Parameter]
        public string Module { get; set; }
        #endregion

        public IEnumerable<MaterialModel> _materials;
        private List<PurchaseOrderModel> _purchaseOrder { get; set; }
        private List<Guid> purchaseOrderIds { get; set; } = new();
        private IEnumerable<WarehousePO> _warehouse { get; set; }

        [Parameter]
        public string POIds { get; set; }

        public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };
        public List<PurchaseOrderWithRollsModel> PurchaseOrderWithRollsList { get; set; } = new();

        #region Overview Warehouse

        public WarehouseOverviewModel WarehouseOverviewModel { get; set; }

        public List<WarehousePO> SSYCebuPurchaseOrders { get; set; } = new();
        public List<WarehousePO> YTICebuPurchaseOrders { get; set; } = new();
        public List<WarehousePO> CambodiaPurchaseOrders { get; set; } = new();
        public List<WarehousePO> GjmPurchaseOrders { get; set; } = new();
        public List<WarehousePO> SkechersPurchaseOrders { get; set; } = new();
        public List<WarehousePO> TmsPurchaseOrders { get; set; } = new();
        public List<WarehousePO> OthersPurchaseOrders { get; set; } = new();

        public string SelectedModalPO = "";

        #endregion

        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;

                WarehouseOverviewModel = new();

                _materialService = new(js, ClientFactory, NavigationManager, Configuration);
                _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);
                PurchaseOrderListModel = await _purchaseOrderService.GetAllPurchaseOrder(null, null, null, 100);

                _purchaseOrder = PurchaseOrderListModel.Result.Items;

                _purchaseOrder.ForEach(x =>
                {
                    purchaseOrderIds.Add(x.Id);
                });

                PurchaseOrderWithRollsList = await _purchaseOrderService.GetRollsWithPurchaseOrder(JsonSerializer.Serialize(purchaseOrderIds));

                PurchaseOrderWithRollsList.ForEach(x =>
                {
                    if (x.Roll.BuildingOrWarehouse == "YTI Cebu")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!YTICebuPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            YTICebuPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                    if (x.Roll.BuildingOrWarehouse == "SSY Cebu F1" || x.Roll.BuildingOrWarehouse == "SSY Cebu F2")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!SSYCebuPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            SSYCebuPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                    if (x.Roll.BuildingOrWarehouse == "Cambodia")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!CambodiaPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            CambodiaPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                    if (x.Roll.BuildingOrWarehouse == "Gjm")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!GjmPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            GjmPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                    if (x.Roll.BuildingOrWarehouse == "Skechers")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!SkechersPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            SkechersPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                    if (x.Roll.BuildingOrWarehouse == "Tms")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!TmsPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            TmsPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                    if (x.Roll.BuildingOrWarehouse == "Others")
                    {
                        var poId = _purchaseOrder.FirstOrDefault(po => po.Number == x.Roll.PONumber).Id;
                        if (!OthersPurchaseOrders.Exists(x => x.Id == poId))
                        {
                            OthersPurchaseOrders.Add(new WarehousePO()
                            {
                                Id = poId,
                                PONumber = x.Roll.PONumber
                            });
                        }
                    }

                });

                await GetWarehouseCapacityPerMaterialType();

                IsLoading = false;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}"); // comment out? 
            }
        }

        private async Task OnClickModal(string value)
        {
            SelectedModalPO = value;

            if (SelectedModalPO == "SSY CEBU") _warehouse = YTICebuPurchaseOrders;
            if (SelectedModalPO == "YTI Cebu") _warehouse = YTICebuPurchaseOrders;
            if (SelectedModalPO == "Cambodia") _warehouse = CambodiaPurchaseOrders;
            if (SelectedModalPO == "Gjm") _warehouse = CambodiaPurchaseOrders;
            if (SelectedModalPO == "Skechers") _warehouse = CambodiaPurchaseOrders;
            if (SelectedModalPO == "Tms") _warehouse = CambodiaPurchaseOrders;
            if (SelectedModalPO == "Others") _warehouse = CambodiaPurchaseOrders;
        }

        private async Task GetWarehouseCapacityPerMaterialType()
        {

            var material = await _materialService.GetWarehouseCapacityPerMaterialType(0);

            if (material != null)
            {
                var wom = WarehouseOverviewModel;
                #region Warehouse Capacity (in yards)

                wom.SsyCebuWarehouseCapacity = (int)material.Result.SsyCebuWarehouseCapacity;
                wom.YtiCebuWarehouseCapacity = (int)material.Result.YtiCebuWarehouseCapacity;
                wom.CambodiaWarehouseCapacity = (int)material.Result.CambodiaWarehouseCapacity;
                wom.GjmWarehouseCapacity = (int)material.Result.GjmWarehouseCapacity;
                wom.SkechersWarehouseCapacity = (int)material.Result.SkechersWarehouseCapacity;
                wom.TmsWarehouseCapacity = (int)material.Result.TmsWarehouseCapacity;
                wom.OthersWarehouseCapacity = (int)material.Result.OthersWarehouseCapacity;

                #endregion

                #region Current Total Inventory (in yards)

                wom.SsyCebuCurrentTotalInventory = (int)material.Result.SsyCebuCurrentTotalInventory;
                wom.YtiCebuCurrentTotalInventory = (int)material.Result.YtiCebuCurrentTotalInventory;
                wom.CambodiaCurrentTotalInventory = (int)material.Result.CambodiaCurrentTotalInventory;
                wom.GjmCurrentTotalInventory = (int)material.Result.GjmCurrentTotalInventory;
                wom.SkechersCurrentTotalInventory = (int)material.Result.SkechersCurrentTotalInventory;
                wom.TmsCurrentTotalInventory = (int)material.Result.TmsCurrentTotalInventory;
                wom.OthersCurrentTotalInventory = (int)material.Result.OthersCurrentTotalInventory;

                #endregion

                #region Reserved Fabrics Inventory

                wom.SsyCebuReservedFabricsInventory = (int)material.Result.SsyCebuReservedFabricsInventory;
                wom.YtiCebuReservedFabricsInventory = (int)material.Result.YtiCebuReservedFabricsInventory;
                wom.CambodiaReservedFabricsInventory = (int)material.Result.CambodiaReservedFabricsInventory;
                wom.GjmReservedFabricsInventory = (int)material.Result.GjmReservedFabricsInventory;
                wom.SkechersReservedFabricsInventory = (int)material.Result.SkechersReservedFabricsInventory;
                wom.TmsReservedFabricsInventory = (int)material.Result.TmsReservedFabricsInventory;
                wom.OthersReservedFabricsInventory = (int)material.Result.OthersReservedFabricsInventory;

                #endregion

                #region Unreserved Fabrics Inventory

                wom.SsyCebuUnreservedFabricsInventory = (int)material.Result.SsyCebuUnreservedFabricsInventory;
                wom.YtiCebuUnreservedFabricsInventory = (int)material.Result.YtiCebuUnreservedFabricsInventory;
                wom.CambodiaUnreservedFabricsInventory = (int)material.Result.CambodiaUnreservedFabricsInventory;
                wom.GjmUnreservedFabricsInventory = (int)material.Result.GjmUnreservedFabricsInventory;
                wom.SkechersUnreservedFabricsInventory = (int)material.Result.SkechersUnreservedFabricsInventory;
                wom.TmsUnreservedFabricsInventory = (int)material.Result.TmsUnreservedFabricsInventory;
                wom.OthersUnreservedFabricsInventory = (int)material.Result.OthersUnreservedFabricsInventory;

                #endregion

                #region Incoming Fabric Deliveries (in yards)

                wom.SsyCebuIncomingFabricsDeliveries = (int)material.Result.SsyCebuIncomingFabricsDeliveries;
                wom.YtiCebuIncomingFabricsDeliveries = (int)material.Result.YtiCebuIncomingFabricsDeliveries;
                wom.CambodiaIncomingFabricsDeliveries = (int)material.Result.CambodiaIncomingFabricsDeliveries;
                wom.GjmIncomingFabricsDeliveries = (int)material.Result.GjmIncomingFabricsDeliveries;
                wom.SkechersIncomingFabricsDeliveries = (int)material.Result.SkechersIncomingFabricsDeliveries;
                wom.TmsIncomingFabricsDeliveries = (int)material.Result.TmsIncomingFabricsDeliveries;
                wom.OthersIncomingFabricsDeliveries = (int)material.Result.OthersIncomingFabricsDeliveries;

                #endregion

                #region Fabric for Disposal (in yards)

                wom.SsyCebuFabricForDisposal = (int)material.Result.SsyCebuFabricForDisposal;
                wom.YtiCebuFabricForDisposal = (int)material.Result.YtiCebuFabricForDisposal;
                wom.CambodiaFabricForDisposal = (int)material.Result.CambodiaFabricForDisposal;
                wom.GjmFabricForDisposal = (int)material.Result.GjmFabricForDisposal;
                wom.SkechersFabricForDisposal = (int)material.Result.SkechersFabricForDisposal;
                wom.TmsFabricForDisposal = (int)material.Result.TmsFabricForDisposal;
                wom.OthersFabricForDisposal = (int)material.Result.OthersFabricForDisposal;

                #endregion

                #region Available Space PRE - DISPOSAL (in yards)

                wom.SsyCebuAvailableSpacePreDisposal = (int)material.Result.SsyCebuAvailableSpacePreDisposal;
                wom.YtiCebuAvailableSpacePreDisposal = (int)material.Result.YtiCebuAvailableSpacePreDisposal;
                wom.CambodiaAvailableSpacePreDisposal = (int)material.Result.CambodiaAvailableSpacePreDisposal;
                wom.GjmAvailableSpacePreDisposal = (int)material.Result.GjmAvailableSpacePreDisposal;
                wom.SkechersAvailableSpacePreDisposal = (int)material.Result.SkechersAvailableSpacePreDisposal;
                wom.TmsAvailableSpacePreDisposal = (int)material.Result.TmsAvailableSpacePreDisposal;
                wom.OthersAvailableSpacePreDisposal = (int)material.Result.OthersAvailableSpacePreDisposal;


                #endregion

                #region Available Space POST - DISPOSAL (in yards)

                wom.SsyCebuAvailableSpacePostDisposal = (int)material.Result.SsyCebuAvailableSpacePostDisposal;
                wom.YtiCebuAvailableSpacePostDisposal = (int)material.Result.YtiCebuAvailableSpacePostDisposal;
                wom.CambodiaAvailableSpacePostDisposal = (int)material.Result.CambodiaAvailableSpacePostDisposal;
                wom.GjmAvailableSpacePostDisposal = (int)material.Result.GjmAvailableSpacePostDisposal;
                wom.SkechersAvailableSpacePostDisposal = (int)material.Result.SkechersAvailableSpacePostDisposal;
                wom.TmsAvailableSpacePostDisposal = (int)material.Result.TmsAvailableSpacePostDisposal;
                wom.OthersAvailableSpacePostDisposal = (int)material.Result.OthersAvailableSpacePostDisposal;

                #endregion

                #region Total

                wom.WarehouseCapacityTotal = (int)material.Result.WarehouseCapacityTotal;
                wom.CurrentTotalInventoryTotal = (int)material.Result.CurrentTotalInventoryTotal;
                wom.ReservedFabricsInventoryTotal = (int)material.Result.ReservedFabricsInventoryTotal;
                wom.UnreservedFabricsInventoryTotal = (int)material.Result.UnreservedFabricsInventoryTotal;
                wom.IncomingFabricsDeliveriesTotal = (int)material.Result.IncomingFabricsDeliveriesTotal;
                wom.FabricForDisposalTotal = (int)material.Result.FabricForDisposalTotal;
                wom.AvailableSpacePreDisposalTotal = (int)material.Result.AvailableSpacePreDisposalTotal;
                wom.AvailableSpacePostDisposalTotal = (int)material.Result.AvailableSpacePostDisposalTotal;

                #endregion

            }


        }

    }
}
