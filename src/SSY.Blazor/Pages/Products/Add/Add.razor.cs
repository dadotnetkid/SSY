namespace SSY.Blazor.Pages.Products.Add
{
    public partial class Add
    {
        public Add()
        {
        }

        public string Module = "Create Parent Product";
        public string ModuleMessage = "";
        public string ModuleType = "Add";
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


        private ProductService _productService { get; set; }
        public CreateProductModel CreateProductModel { get; set; } = new();
        public InfluencerService _influencerService { get; set; }
        public UserDetailService _userDetailService { get; set; }

        public OverviewModel OverviewModel { get; set; } = new();
        public List<TypeModel> TypeModel { get; set; } = new();

        public List<InfluencerModel> InfluencerListModel { get; set; } = new();

        public CollectionService _collectionService { get; set; }
        public TypeService _typeService { get; set; }
        public ApprovalStatusService _approvalStatusService { get; set; }

        public GetDropdownService _getDropDownService { get; set; }
        public string collapseMaterialTypes = string.Empty;

        public int influencerId = 0;
        public List<int> collectionMaterialIds { get; set; } = new();

        public string selectedCollectionId = "";
        public string collapseInfluencers = string.Empty;

        public CollectionModel CollectionModel { get; set; } = new();
        public string InfluencerNamesValue = "Select Influencers";
        public string CollectionNamesValue = "Select Influencers";
        public List<Guid> InfluencersIds { get; set; } = new();
        public List<int> MaterialTypeIds { get; set; } = new();
        public List<string> InfluencersNames { get; set; } = new();
        public List<CollectionModel.MaterialProductTypes> MaterialProductTypeList { get; set; } = new();
        public List<InfluencersOutputModel> InfluencersOutputModelList { get; set; } = new();


        public GetAllCollectionList CollectionListModel { get; set; } = new() { Items = new() };
        public List<CollectionDto> CollectionsListModel { get; set; } = new();
        public CollectionDto SelectedCollection { get; set; } = new();
        public GetAllProductOutputModel ProductListModel { get; set; } = new() {  Items = new(), TotalCount = new()  };
        public ProductTypeListModel ProductTypeListModel { get; set; } = new() { Items = new() };
        public CreateProductInputModel CreateProductInputModel { get; set; } = new();
        public GetAllApprovalStatusOutputModel ApprovalStatusListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ProductModel ProductModel { get; set; } = new();
        public GetAllUserDetailCCOutputModel UserDetailListModel { get; set; } = new() { Result = new() { Items = new() } };
        public FirstDesignDraftModel FirstDesignDraftModel { get; set; }

        public GetAllProductOutputModel ProductsListModel { get; set; } = new() {  Items = new() };
        public string selectedMaterialType = string.Empty;
        public string isDisabled = string.Empty;
        public string displayMaterialForProductName = "";
        public string selectedProductType = "";
        public string collectionName = "";
        public string fullNameDistinct = "";
        //public bool IsLoading;
        public Modal ModalSaving;

        protected override async Task OnInitializedAsync()
        {
            _influencerService = new(js, ClientFactory, NavigationManager, Configuration);
            _typeService = new(js, ClientFactory, NavigationManager, Configuration);
            _productService = new(js, ClientFactory, NavigationManager, Configuration);
            _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropDownService = new(js, ClientFactory, NavigationManager, Configuration);
            _approvalStatusService = new(js, ClientFactory, NavigationManager, Configuration);
            _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);


            CollectionListModel = await _collectionService.GetAllCollectionV2(null, null, null, 100);
            ProductTypeListModel = await _getDropDownService.GetAllProductType(null, null, null, 100);
            TypeModel = (await _typeService.GetAllType(2, null, "orderNumber", null, 100)).Result.Items.OrderBy(x => x.Label).ToList();
            ApprovalStatusListModel = (await _approvalStatusService.GetAllApprovalStatus(null, null, null, 100));
            InfluencerListModel = await _influencerService.GetAllInfluencer();
            ProductListModel = await _productService.GetAllProduct(null, null, 999, true);
            UserDetailListModel = await _userDetailService.GetAllUserCC(null, null, null, null, null, 1000);
            ProductsListModel = await _productService.GetAllProduct(null, null, 100);
            OverviewModel.ColorOptionIdList.Add(new int());
            CollectionModel.Influencers = "Select Influencers";
            selectedMaterialType = "Material Type";

            StateHasChanged();
            
        }


        public async Task OnClickMaterialType()
        {
            if (collapseMaterialTypes.Equals("show"))
            {
                collapseMaterialTypes = "";
            }
            else
            {
                collapseMaterialTypes = "show";
            }
        }

        public async Task ClearAll()
        {

        }

        public async Task OnClickInfluencers()
        {
            if (collapseInfluencers.Equals("show"))
            {
                collapseInfluencers = "";
            }
            else
            {
                collapseInfluencers = "show";
            }
        }
        public async Task ChangeProductName()
        {
            CreateProductModel.Name = collectionName.Replace("Collection", "") + " " + selectedProductType;
        }



        public async Task onChangeInfluencer(Guid influencerId, string influencersName, bool isChecked)
        {
            CreateProductModel.CollectionId = Guid.Empty;
            CreateProductModel.InfluencersName = string.Empty;
            CollectionsListModel = new();
            InfluencerNamesValue = string.Empty;
            if (isChecked)
            {
                if (!InfluencersIds.Contains(influencerId))
                {
                    InfluencersIds.Add(influencerId);
                }

                if (!InfluencersNames.Contains(influencersName))
                {
                    InfluencersNames.Add(influencersName);
                }
            }
            else
            {
                if (InfluencersIds.Contains(influencerId))
                {
                    InfluencersIds.Remove(influencerId);
                }

                if (InfluencersNames.Contains(influencersName))
                {
                    InfluencersNames.Remove(influencersName);
                }
            }

            if (InfluencersNames.Count < 1)
            {
                InfluencerNamesValue = "Select Influencers";
                CollectionsListModel = new();
                CreateProductModel.InfluencerIds = JsonSerializer.Serialize(InfluencersIds);
                CreateProductModel.InfluencersName = string.Empty;
            }
            else
            {
                InfluencerNamesValue = ReplaceString(JsonSerializer.Serialize(InfluencersNames));
                CreateProductModel.InfluencerIds = JsonSerializer.Serialize(InfluencersIds);
                foreach (var collection in CollectionListModel.Items)
                {
                    var isExisting = true;
                    var collectionInfluencerids = collection.Influencers.Select(x => x.InfluencerId).ToList();
                    if (collectionInfluencerids.Count() == InfluencersIds.Count())
                    {
                        foreach (var id in InfluencersIds)
                        {
                            if (!collectionInfluencerids.Contains(id))
                            {
                                isExisting = false;
                                break;
                            }
                        }
                        if (isExisting)
                        {
                            CollectionsListModel.Add(collection);
                        }
                    }
                }
            }
        }

        public async Task onChangeCollection(string collectionId)
        {
            CreateProductModel.CollectionId = Guid.Parse(collectionId);
            SelectedCollection = CollectionsListModel.Find(x => x.Id == Guid.Parse(collectionId));
            CreateProductModel.InfluencersName = SelectedCollection.InfluencerNames;
        }

        public async Task onChangeMaterialTypeHandler(int typeId)
        {
            CreateProductModel.MaterialTypeId = typeId;
            foreach (var item in TypeModel)
            {
                item.IsChecked = false;
            }
            var isChecked = TypeModel.Find(x => x.Id == typeId);
            isChecked.IsChecked = true;
            var displayMaterial = TypeModel.Find(x => x.Id == typeId)?.Value;
            selectedMaterialType = "Material Type";
            CreateProductModel.TypeId = new();
        }

        public async Task Apply()
        {
            var materialTypeId = CreateProductModel.MaterialTypeId;
            var productTypeId = CreateProductModel.TypeId;
            var displayMaterial = TypeModel.Find(x => x.Id == materialTypeId)?.Value;
            var displayProduct = ProductTypeListModel.Items.Find(x => x.Id == productTypeId)?.Value;
            var collection = CollectionListModel.Items.Find(x => x.Id == CreateProductModel.CollectionId);
            selectedMaterialType = $"{displayMaterial} [{displayProduct}]";
            displayMaterialForProductName = $"{displayMaterial}";
            selectedProductType = $"{displayProduct}";
            collectionName = collection.Name.Replace("Collections", "");

            await ChangeProductName();
            await GenerateSKU();
        }

        public async Task onChangeApprovalStatus(string approvalStatusId)
        {
            CreateProductModel.ApprovalStatusId = int.Parse(approvalStatusId);
        }

        public async Task Save()
        {
            try
            {
                await ShowSavingModal();

                await _productService.CreateProduct(CreateProductModel);

                await HideSavingModal();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                Console.WriteLine($"Error: {ex.Message}{innerException} - OnInitializedAsync()");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task GenerateSKU()
        {
            List<string> parentSKU = new();

            // Get ShortName of Influencers

            var collection = CollectionListModel.Items.Find(x => x.Id == CreateProductModel.CollectionId);

            List<Guid> influencerIds = new();

            collection.Influencers.ForEach(x => {
                influencerIds.Add(x.InfluencerId);
            });

            List<string> influencerName = new();

            if (influencerIds.Count == 1)
            {
                foreach (var item in influencerIds)
                {
                    var influencer = UserDetailListModel.Result.Items.Find(x => x.Id == item);
                    influencerName.Add(influencer.Name[0] + "" + influencer.Surname[0]);
                }
            }
            else
            {
                foreach (var item in influencerIds)
                {
                    var influencer = UserDetailListModel.Result.Items.Find(x => x.Id == item);
                    influencerName.Add(influencer.Name[0] + "");
                }
            }

            var name = ReplaceString(JsonSerializer.Serialize(influencerName)).Replace(" ", "");

            parentSKU.Add(name);

            // 4 digit iteration

            var productTotalCount = ProductListModel.Items.Count();

            var productCount = (productTotalCount + 1).ToString().PadLeft(4, '0');

            parentSKU.Add(productCount);

            // Season

            var materialType = TypeModel.Find(x => x.Id == CreateProductModel.MaterialTypeId);
            string season = string.Empty;

            if (materialType.Value.Equals("Knitwear"))
            {
                season = "AW";
            }
            else
            {
                season = "SS";
            }

            parentSKU.Add(season);

            // Collection Year

            var collectionCreationTime = collection.CreationTime.Year.ToString();
            string collectionYear = string.Empty;

            collectionYear = collectionCreationTime.Substring(collectionCreationTime.Length - 2);

            parentSKU.Add(collectionYear);

            // Material type of Fabric

            string materialTypeOfFabric = string.Empty;

            materialTypeOfFabric = materialType.ShortCode;

            parentSKU.Add(materialTypeOfFabric);

            // Product Type

            var productType = ProductTypeListModel.Items.Find(x => x.Id == CreateProductModel.TypeId);
            string productTypeShortCode = string.Empty;

            productTypeShortCode = productType.ShortCode;

            parentSKU.Add(productTypeShortCode);

            // 2 Digit Iteration

            var products = ProductsListModel.Items.Select(x => x.TypeId).ToList();

            var productTypeCount = products.FindAll(x => x == CreateProductModel.TypeId).Count;

            var productLastCount = (productTypeCount + 1).ToString().PadLeft(2, '0');

            parentSKU.Add(productLastCount);

            CreateProductModel.Sku = JsonSerializer.Serialize(parentSKU).Replace("[", "").Replace("]", "").Replace(",", "").Replace("\"", "");

            Console.WriteLine(JsonSerializer.Serialize(CreateProductModel.Sku));
        }   

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

        private Task ShowSavingModal()
        {
            return ModalSaving.Show();
        }

        private Task HideSavingModal()
        {
            return ModalSaving.Hide();
        }

    }

}