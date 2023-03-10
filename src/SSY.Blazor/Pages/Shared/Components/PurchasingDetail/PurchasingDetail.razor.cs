using SSY.Blazor.HttpClients.Data.Administration.Users.Model;

namespace SSY.Blazor.Pages.Shared.Components.PurchasingDetail
{
    public partial class PurchasingDetail
    {
        public PurchasingDetail()
        { }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        private GetDropdownService _getDropdownService { get; set; }
        private CollectionService _collectiionService { get; set; }
        private BulkPurchaseOrderRequestService _bulkPurchaseOrderRequestService { get; set; }
        public UserDetailService _userDetailService { get; set; }

        public Currency Currency { get; set; } = new();
        public MOQCurrency MOQCurrency { get; set; } = new();
        public PurchasingUnitMeasurement PurchasingUnitMeasurement { get; set; } = new();
        public MOQUnitMeasurement MOQUnitMeasurement { get; set; } = new();
        public GeneralnformationUnitMeasurement GeneralnformationUnitMeasurement { get; set; } = new();
        public UpchargeTypeListModel UpchargeTypeListModel { get; set; } = new() { Result = new() { Items = new() } };
        public PricingTypeListModel PricingTypeListModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllUserDetailCCOutputModel GetAllUserDetailModel { get; set; } = new() { Result = new() { Items = new() } };

        public CurrencyListModel CurrencyListModel { get; set; } = new() { Result = new() { Items = new() } };
        public UnitOfMeasurementListModel UnitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

        //public List<CollectionOutputModel> CollectionsListModel { get; set; } = new();
        public string InfluencerNamesValue = "Select Influencers";
        public List<Guid> InfluencersIds { get; set; } = new();
        public List<string> InfluencersNames { get; set; } = new();
        public GetAllCollectionListDto CollectionList { get; set; } = new();
        public List<CollectionListDto> CollectionsListModel { get; set; } = new();


        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public PurchaseDetailModel PurchaseDetailModel { get; set; } = new();
        [Parameter]
        public MaterialModel OverviewModel { get; set; } = new();
        [Parameter]
        public SubMaterialModel SubMaterialModel { get; set; } = new();

        [Parameter]
        public CollectionModel CollectionModel { get; set; } = new();
        [Parameter]
        public EventCallback<List<Guid>> BulkPurchaseOrder { get; set; } = new();

        public List<Guid> BulkPurchaseOrderRequestIds { get; set; } = new();

        public BulkPurchaseOrderRequestModel BulkPurchaseOrderRequestModel { get; set;}

        public List<CollectionOutputModel> FilteredCollectionByInfluencerId { get; set; } = new();

        public CreateBulkPurchaseOrderRequestDto CreateBulkPurchaseOrderRequestDto { get; set; }

        public bool CanSubmit()
        {
            return editForm.EditContext.Validate();
        }

        protected override async Task OnInitializedAsync()
        {
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _collectiionService = new(js, ClientFactory, NavigationManager, Configuration);
            _bulkPurchaseOrderRequestService = new(js, ClientFactory, NavigationManager, Configuration);
            _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);

            Currency = new();
            MOQUnitMeasurement = new();
            PurchasingUnitMeasurement = new();
            MOQCurrency = new();
            GeneralnformationUnitMeasurement = new();
            BulkPurchaseOrderRequestModel = new();
            SubMaterialModel = new();

            CurrencyListModel = await _getDropdownService.GetAllCurrency(null, null, null, 100);
            UnitOfMeasurementListModel = await _getDropdownService.GetAllUnitOfMeasurement(null, null, null, 100);
            UpchargeTypeListModel = await _getDropdownService.GetAllUpchargeType(null, null, null, 100);
            PricingTypeListModel = await _getDropdownService.GetAllPricingTypeListModel(null, null, null, 100);
            GetAllUserDetailModel = await _userDetailService.GetAllUserCC("INFLUENCER", null, null, null, null, 1000);
            CollectionList = await _collectiionService.GetAllCollectionList();
        }

        protected override async Task OnParametersSetAsync()
        {
            BulkPurchaseOrderRequestModel.CategoryId = OverviewModel.CategoryId;
            BulkPurchaseOrderRequestModel.CategoryValue = OverviewModel.CategoryValue;
            BulkPurchaseOrderRequestModel.CategoryLabel = OverviewModel.CategoryLabel;
            BulkPurchaseOrderRequestModel.MaterialTypeId = OverviewModel.TypeId;
            BulkPurchaseOrderRequestModel.MaterialTypeValue = OverviewModel.TypeValue;
            BulkPurchaseOrderRequestModel.MaterialTypeLabel = OverviewModel.TypeLabel;
            BulkPurchaseOrderRequestModel.ColorValue = OverviewModel.ColorValue;
            BulkPurchaseOrderRequestModel.ItemCode = OverviewModel.ItemCode;
            BulkPurchaseOrderRequestModel.ColorCode = OverviewModel.ColorCode;
            BulkPurchaseOrderRequestModel.ColorGroup = OverviewModel.ColorGroup;
            BulkPurchaseOrderRequestModel.ColorLabel = OverviewModel.ColorLabel;
            BulkPurchaseOrderRequestModel.ColorId = OverviewModel.ColorId;
            BulkPurchaseOrderRequestModel.TCXCode = OverviewModel.Pantone;
            BulkPurchaseOrderRequestModel.CompanyId = OverviewModel.CompanyId;
            BulkPurchaseOrderRequestModel.Company.Name = OverviewModel.Company.Name;
            //BulkPurchaseOrderRequestModel.SupplierName = OverviewModel.Company.Name;
        }

        public async Task onChangeUpchargePrice(string upcharge)
        {
            try
            {
                var percentage = 100 / Double.Parse(upcharge);
                var percentagePrice = PurchaseDetailModel.Price / percentage;
                PurchaseDetailModel.UpchargePrice = PurchaseDetailModel.Price + percentagePrice;
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        public async Task onChangeUpchargeType(string upchargesType)
        {
            try
            {
                var upchargeType = UpchargeTypeListModel.Result.Items.FirstOrDefault(x => x.Id == Int32.Parse(upchargesType));

                if (upchargeType != null)
                {
                    if (upchargeType.Value.Equals("Percentage"))
                    {
                        PurchaseDetailModel.IsUpchargePercentage = true;
                    }
                    else
                    {
                        PurchaseDetailModel.IsUpchargePercentage = false;
                    }
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task OnChangeInfluencer(string id)
        {
            try
            {
                FilteredCollectionByInfluencerId.Clear();
                Guid InfluencersId = new Guid(id);
                BulkPurchaseOrderRequestModel.InfluencerId = InfluencersId;
                BulkPurchaseOrderRequestModel.Influencers = GetAllUserDetailModel.Result.Items.FirstOrDefault(x => x.Id == InfluencersId).FullName;

                foreach (var collection in CollectionList.Items)
                {
                    var isExisting = true;
                    var collectionInfluencerids = collection.InfluencerNames.Contains(BulkPurchaseOrderRequestModel.Influencers);
                    if (collectionInfluencerids)
                        CollectionsListModel.Add(collection);
                    else
                        CollectionsListModel.Remove(collection);
                }
                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task OnSelectCollection(string input)
        {
            try
            {
                var collection = CollectionList.Items.FirstOrDefault(x => x.Id == Guid.Parse(input));
                if (collection != null)
                {
                    BulkPurchaseOrderRequestModel.CollectionId = collection.Id;
                    BulkPurchaseOrderRequestModel.CollectionName = collection.Name;
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }

        public async Task OnSubmit()
        {
            try
            {
                var currentSession = await LocalStorage.GetAsync<UserSession>("userSession");

                CreateBulkPurchaseOrderRequestDto bulkPurchaseOrder = new();
                {
                    bulkPurchaseOrder.TenantId = OverviewModel.TenantId;
                    bulkPurchaseOrder.IsActive = OverviewModel.IsActive;
                    bulkPurchaseOrder.CategoryId = OverviewModel.CategoryId;
                    bulkPurchaseOrder.MaterialTypeId = (int)OverviewModel.TypeId;
                    bulkPurchaseOrder.ItemCode = OverviewModel.ItemCode;
                    bulkPurchaseOrder.ColorId = (int)OverviewModel.ColorId;
                    bulkPurchaseOrder.ColorCode = OverviewModel.ColorCode;
                    bulkPurchaseOrder.TCXCode = OverviewModel.Pantone;
                    bulkPurchaseOrder.RequiredYardage = (double)BulkPurchaseOrderRequestModel.RequiredYardage;
                    bulkPurchaseOrder.ApprovedByLabDipShade = BulkPurchaseOrderRequestModel.ApprovedByLabDipShade;
                    bulkPurchaseOrder.Price = (double)BulkPurchaseOrderRequestModel.Price;
                    bulkPurchaseOrder.CompanyId = OverviewModel.CompanyId;
                    bulkPurchaseOrder.Influencers = BulkPurchaseOrderRequestModel.Influencers;
                    bulkPurchaseOrder.InfluencerId = BulkPurchaseOrderRequestModel.InfluencerId;
                    bulkPurchaseOrder.CollectionId = (Guid)BulkPurchaseOrderRequestModel.CollectionId;
                    bulkPurchaseOrder.CollectionName = BulkPurchaseOrderRequestModel.CollectionName;
                    bulkPurchaseOrder.AddedBy = currentSession.Value.FullName;
                    bulkPurchaseOrder.Status = 1;
                    bulkPurchaseOrder.MaterialId = OverviewModel.Id;
                };

                await _bulkPurchaseOrderRequestService.CreateBulkPurchaseOrderRequest(bulkPurchaseOrder);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";
            }
        }
    }
}