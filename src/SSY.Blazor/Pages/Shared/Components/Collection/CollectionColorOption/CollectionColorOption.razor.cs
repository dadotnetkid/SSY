using SSY.Blazor.HttpClients.Data.Administration.Users.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes.Model;
using SSY.Blazor.HttpClients.Data.Inventory.InventoryAdditionRequests.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations;
using static SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model.CollectionModel;
using MaterialProductTypes = SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model.CollectionModel.MaterialProductTypes;

namespace SSY.Blazor.Pages.Shared.Components.Collection.CollectionColorOption
{
    public partial class CollectionColorOption
    {
        public CollectionColorOption()
        {
        }

        public string Module = "Collections";
        public string ModuleMessage = "";

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        public GetDropdownService _getDropdownService { get; set; }
        public MaterialService _materialService { get; set; }
        public RollAndLocationService _rollAndLocationService { get; set; }
        public CollectionService _collectionService { get; set; }
        public ProductService _productService { get; set; }
        public ApprovalStatusService _approvalStatusService { get; set; }
        public UserDetailService _userDetailService { get; set; }
        public AdditionRequestService _additionRequestService { get; set; }
        private DeleteDataByIdService _deleteDataByIdService { get; set; }
        public ReservationService _reservationService { get; set; }

        //[Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        [Parameter]
        public bool IsModuleAdd { get; set; }

        [Parameter]
        public CollectionModel CollectionModel { get; set; } = new();

        [Parameter]
        public List<CollectionModel.MaterialProductTypes> MaterialProductTypeList { get; set; } = new() { };

        public List<CollectionModel.MaterialProductTypes> CollectionMaterialProductType { get; set; } = new();

        [Parameter]
        public OverviewModel OverviewModel { get; set; } = new();

        [Parameter]
        public ColorListModel ColorList { get; set; } = new();

        [Parameter]
        public GetAllMaterialOutputModel MaterialListModel { get; set; } = new() { Result = new() { Items = new() } };
        public List<MaterialModel> MaterialModelList { get; set; } = new();

        [Parameter]
        public ProductTypeListModel ProductTypeListModel { get; set; } = new();

        [Parameter]
        public GetAllProductOutputModel ProductListModel { get; set; } = new();

        [Parameter]
        public List<TypeModel> TypeListModel { get; set; } = new();

        [Parameter]
        public List<AdditionRequestTypeModel> AdditionRequestTypeListModel { get; set; } = new();

        [Parameter]
        public MaterialCategoryListModel MaterialCategoryListModel { get; set; } = new() { Result = new() { Items = new() } };

        [Parameter]
        public EventCallback<ColorSelection> OnApprovedCollection { get; set; }

        [Parameter]
        public EventCallback<CollectionModel> OnRejectCollection { get; set; }

        [Parameter]
        public List<CollectionStatusModel> StatusListModel { get; set; } = new();

        public GetAllRollAndLocationOutputModel RollAndLocationListModel { get; set; } = new() { Result = new() { Items = new() } };
        public ApproveProductModel ApproveProductModel { get; set; } = new();

        public string collapseSection = "show";

        public ColorSelection ColorSelectionModel { get; set; } = new();
        public List<MaterialModel> SelectedFabricList { get; set; } = new();
        public IEnumerable<MaterialModel> _materials = new MaterialModel[] { };
        private string customFabricFilterValue;

        public List<RollAndLocationModel> SelectedRollList { get; set; } = new();
        public List<Guid> SelectedRollIds { get; set; } = new();
        public IEnumerable<RollAndLocationModel> _rolls = new RollAndLocationModel[] { };
        private string customRollFilterValue;

        public InventoryAdditionRequestModel InventoryAdditionRequestModel { get; set; } = new();

        [Parameter]
        public EventCallback<List<Guid>> AdditionRequests { get; set; } = new();

        public List<Guid> AdditionRequestIds { get; set; } = new();

        public string currentUser { get; set; } = string.Empty;

        private Modal ModalWaiting;

        protected override async Task OnInitializedAsync()
        {
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _rollAndLocationService = new(js, ClientFactory, NavigationManager, Configuration);
            _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
            _productService = new(js, ClientFactory, NavigationManager, Configuration);
            _approvalStatusService = new(js, ClientFactory, NavigationManager, Configuration);
            _additionRequestService = new(js, ClientFactory, NavigationManager, Configuration);
            _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
            _reservationService = new(js, ClientFactory, NavigationManager, Configuration);

            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {
            MaterialModelList = MaterialListModel.Result.Items;

            await GetCollection();

            StateHasChanged();
        }

        public async Task GetCollection()
        {
            #region ColorOptions

            await CalculateProductTypeForecast();

            CollectionModel.ColorSelectionList.ForEach(x => {

                var mpt = CollectionModel.MaterialProductTypeList.Find(mpt => mpt.MaterialTypeId == x.MaterialTypeId);
                if (mpt != null)
                    if (!mpt.SelectedColorIds.Contains(x.ColorId))
                        mpt.SelectedColorIds.Add(x.ColorId);
            });

            CollectionModel.ColorSelectionList.ForEach(x => {
                x.FabricSelectionList.ForEach(async f => {
                    await CalculateMaxQuantity(x, f.Ordinal);
                });
            });

            #endregion

        }

        public async Task OnSubmitAdditionRequest()
        {
            try
            {
                var currentSession = await LocalStorage.GetAsync<UserSession>("userSession");

                if (CollectionModel.InfluencerIdsList.Count == 0)
                    await js.InvokeVoidAsync("defaultMessage", "warining", "Warning", $"Please select Influencer/s.");
                else
                {
                    CreateAdditionRequestModel additionRequest = new()
                    {
                        TenantId = CollectionModel.TenantId,
                        IsActive = CollectionModel.IsActive,
                        TypeId = InventoryAdditionRequestModel.TypeId,
                        CategoryId = InventoryAdditionRequestModel.CategoryId,
                        MaterialTypeId = InventoryAdditionRequestModel.MaterialTypeId,
                        ColorId = InventoryAdditionRequestModel.ColorGroupId,
                        ColorCode = InventoryAdditionRequestModel.ColorCode,
                        ItemCode = InventoryAdditionRequestModel.ItemCode,
                        TCXCode = InventoryAdditionRequestModel.TCXCode,
                        RequiredYardage = InventoryAdditionRequestModel.RequiredYardage,
                        Influencers = CollectionModel.Influencers,
                        CollectionId = CollectionModel.Id,
                        CollectionName = CollectionModel.Name,
                        Status = 1,
                        AddedBy = currentSession.Value.FullName
                    };

                    var result = await _additionRequestService.CreateAdditionRequest(additionRequest);

                    if (result != null)
                    {
                        await onCloseInventoryAdditionRequest();

                        AdditionRequestIds.Add(result.Result.Id);
                    }

                    await AdditionRequests.InvokeAsync(AdditionRequestIds);
                }

            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onCloseInventoryAdditionRequest()
        {
            InventoryAdditionRequestModel.TypeId = default;
            InventoryAdditionRequestModel.CategoryId = default;
            InventoryAdditionRequestModel.MaterialTypeId = default;
            InventoryAdditionRequestModel.ItemCode = string.Empty;
            InventoryAdditionRequestModel.ColorCode = string.Empty;
            InventoryAdditionRequestModel.ColorGroupId = default;
            InventoryAdditionRequestModel.TCXCode = string.Empty;
            InventoryAdditionRequestModel.RequiredYardage = default;
        }

        public async Task OnClickSection()
        {
            try
            {
                if (collapseSection.Equals("show"))
                    collapseSection = "";
                else
                    collapseSection = "show";
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onSelectFabric(ColorSelection colorSelection, int materialTypeId, string ordinal, FabricSelection fabricSelection)
        {
            try
            {
                _materials = new MaterialModel[] { };
                ColorSelectionModel = new();
                SelectedFabricList.Clear();
                ColorSelectionModel = colorSelection;

                double totalRequiredYardage = 0;
                var productTypes = @CollectionModel.SelectedMaterialProducts.Find(s => s.MaterialTypeId == colorSelection.MaterialTypeId && s.ColorId == colorSelection.ColorId);
                totalRequiredYardage = productTypes != null ? productTypes.TotalProductRequiredYardage : 0;

                var fabrics = MaterialModelList.Where(x => x.ColorId == colorSelection.ColorId && x.TypeId == materialTypeId);
                fabrics.ToList().ForEach(fabric => {

                    fabric.ColorOptionId = Guid.Empty;
                    fabric.Ordinal = ordinal;

                    var selected = colorSelection.MaterialId.Equals(fabric.Id) ? "selected-fabric" : "";
                    var show = (fabric.AvailableCount > (totalRequiredYardage / 2));
                    var validation = (fabric.RollsAndLocations.Any(x => (x.ReserveCount == 0 || x.ReserveCount == null) && x.IsDisposal == false));

                    if (IsEditable && colorSelection.IsApproved == null)
                    {
                        if (validation)
                        {
                            if (totalRequiredYardage == 0)
                            {
                                if (ColorSelectionModel.MaterialId.Equals(fabric.Id))
                                {
                                    fabric.ColorOptionId = colorSelection.Id;
                                    SelectedFabricList.Add(fabric);
                                }
                                else
                                {
                                    SelectedFabricList.Add(fabric);
                                }
                            }
                            else
                            {
                                if (fabric.CompositionAndConstruction.ExcessValue.Equals("Yes"))
                                {
                                    if (show)
                                    {
                                        if (ColorSelectionModel.MaterialId.Equals(fabric.Id))
                                        {
                                            fabric.ColorOptionId = colorSelection.Id;
                                            SelectedFabricList.Add(fabric);
                                        }
                                        else
                                        {
                                            SelectedFabricList.Add(fabric);
                                        }
                                    }
                                }
                                else
                                {
                                    if (ColorSelectionModel.MaterialId.Equals(fabric.Id))
                                    {
                                        fabric.ColorOptionId = colorSelection.Id;
                                        SelectedFabricList.Add(fabric);
                                    }
                                    else
                                    {
                                        SelectedFabricList.Add(fabric);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (ColorSelectionModel.MaterialId.Equals(fabric.Id))
                            {
                                fabric.ColorOptionId = colorSelection.Id;
                                SelectedFabricList.Add(fabric);
                            }
                            else
                            {
                                if (validation)
                                {
                                    SelectedFabricList.Add(fabric);
                                }
                            }
                        }

                    }
                    else
                    {
                        if (ColorSelectionModel.MaterialId.Equals(fabric.Id))
                        {
                            fabric.ColorOptionId = colorSelection.Id;
                            SelectedFabricList.Add(fabric);
                        }
                        else
                        {
                            if (validation)
                            {
                                SelectedFabricList.Add(fabric);
                            }
                        }
                    }

                });

                colorSelection.SelectedFabricIds.Clear();
                colorSelection.FabricSelectionList.ForEach(x =>
                {
                    if (!colorSelection.SelectedFabricIds.Contains(x.MaterialId))
                        colorSelection.SelectedFabricIds.Add(x.MaterialId);
                });

                colorSelection.SelectedFabricIds.ForEach(materialId =>
                {
                    var selectedFabric = SelectedFabricList.FirstOrDefault(x => x.Id == materialId);
                    if (selectedFabric != null)
                    {
                        if (fabricSelection.MaterialId != selectedFabric.Id)
                        {
                            SelectedFabricList.Remove(selectedFabric);
                        }
                    }
                });

                if (fabricSelection.MaterialId != Guid.Empty)
                {
                    if (SelectedFabricList.Find(x => x.Id == fabricSelection.MaterialId) == null)
                        SelectedFabricList.Add(MaterialListModel.Result.Items.Find(x => x.Id == fabricSelection.MaterialId));
                }

                _materials = new MaterialModel[] { };
                _materials = SelectedFabricList.OrderBy(x => x.Name);

                await CalculateMaxQuantity(colorSelection, ordinal);

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - onSelectFabric()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task OnSelectFabricHandler(bool isChecked, Guid colorSelectionId, int materialTypeId, Guid materialId, string ordinal)
        {
            try
            {
                var selectedColorOption = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == materialTypeId && x.Id == colorSelectionId);

                var material = MaterialListModel.Result.Items.Find(x => x.Id == materialId);

                var selectedFabric = selectedColorOption.FabricSelectionList.Find(x => x.Ordinal == ordinal);

                var previousSelectedMaterialId = selectedFabric.MaterialId;

                if (selectedFabric != null)
                {
                    if (isChecked)
                    {
                        if (material != null)
                        {
                            material.IsSelected = true;
                            material.SelectedOrdinal = ordinal;

                            selectedFabric.MaterialId = material.Id;

                            selectedFabric.RollAndLocations.Clear();
                            selectedFabric.MaterialName = material.Name;
                            selectedFabric.SwatchImage = material.Image;
                            selectedFabric.FabricComposition = material.CompositionAndConstruction.Content;
                            selectedFabric.CareInstruction = material.CareInstructionTypeValue;

                            selectedFabric.ColorCode = material.ColorCode;
                            selectedFabric.ItemCode = material.ItemCode;
                            selectedFabric.UnitOfMeasurement = material.UnitOfMeasurementValue;
                            selectedFabric.CuttableWidth = material.CuttableWidth;
                            selectedFabric.ContentDescription = material.CompositionAndConstruction.Content;
                            selectedFabric.Price = material.PurchaseDetail.Price == null ? 0 : material.PurchaseDetail.Price.Value;
                            selectedFabric.Supplier = material.Company.Name;

                            selectedFabric.collapseRoll = "";
                            selectedFabric.SelectRolls = "Select Rolls";
                            selectedFabric.SelectedRollWarehouse.Clear();
                            selectedFabric.SelectedRolls.Clear();
                            selectedFabric.SelectedRollIds.Clear();

                            RollAndLocationListModel = await _rollAndLocationService.GetAllRollAndLocation(material.Id, null, null, null, null, 1000);

                            if (RollAndLocationListModel.Result.Items != null)
                            {
                                selectedFabric.RollAndLocations = RollAndLocationListModel.Result.Items;
                                List<Guid> rollReservations = new();
                                selectedFabric.RollAndLocations.ForEach(x => {
                                    x.RollReservations.ForEach(r => {
                                        rollReservations.Add(r.RollId);
                                    });

                                });

                                if (rollReservations.Count == 0)
                                {
                                    selectedFabric.RollReservationMessage = "No Reservations Available";
                                }
                            }
                        }
                    }
                    else
                    {
                        await onChangeCheckBoxAll(false, selectedColorOption, ordinal);
                        selectedFabric.MaterialId = Guid.Empty;

                        selectedFabric.RollAndLocations.Clear();
                        selectedFabric.collapseRoll = "";
                        selectedFabric.SelectRolls = "Select Rolls";
                        selectedFabric.SelectedRollWarehouse.Clear();
                        selectedFabric.SelectedRolls.Clear();
                        selectedFabric.SelectedRollIds.Clear();
                        selectedFabric.SelectedRollAndLocation.Clear();

                        if (material != null)
                        {
                            material.IsSelected = false;
                            material.SelectedOrdinal = string.Empty;
                        }
                    }
                }

                selectedColorOption.SelectedFabricIds.Clear();
                selectedColorOption.FabricSelectionList.ForEach(x => {
                    if (!selectedColorOption.SelectedFabricIds.Contains(x.MaterialId))
                        selectedColorOption.SelectedFabricIds.Add(x.MaterialId);
                });

                await CalculateMaxQuantity(selectedColorOption, ordinal);

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - OnSelectFabricHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onCloseFabric()
        {
            _materials = new MaterialModel[] { };
            ColorSelectionModel = new();
            SelectedFabricList.Clear();
        }

        private bool OnCustomFabricFilter(MaterialModel model)
        {
            try
            {
                // We want to accept empty value as valid or otherwise
                // datagrid will not show anything.
                if (string.IsNullOrEmpty(customFabricFilterValue))
                    return true;

                return model.Name?.Contains(customFabricFilterValue, StringComparison.OrdinalIgnoreCase) == true;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
                return true;
            }
        }

        private bool OnCustomRollFilter(RollAndLocationModel model)
        {
            try
            {
                // We want to accept empty value as valid or otherwise
                // datagrid will not show anything.
                if (string.IsNullOrEmpty(customRollFilterValue))
                    return true;

                return model.RollNumber?.Contains(customRollFilterValue, StringComparison.OrdinalIgnoreCase) == true;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
                return true;
            }
        }

        public async Task onChangeCheckBoxAll(bool value, ColorSelection colorSelection, string ordinal)
        {
            try
            {
                if (value)
                {
                    _rolls.ToList().ForEach(async roll => {
                        await SelectRollHandler(colorSelection, roll, "true", ordinal);
                    });
                }
                else
                {
                    _rolls.ToList().ForEach(async roll => {
                        await SelectRollHandler(colorSelection, roll, "false", ordinal);
                    });
                }

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task AddColorOptionHandler(MaterialProductTypes materialProduct, TypeModel materialType)
        {
            try
            {
                var selected = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == materialProduct.MaterialTypeId);

                var currentCount = CollectionModel.ColorSelectionList.FindAll(x => x.MaterialTypeId == selected.MaterialTypeId).Count();

                var colorselection = CollectionModel.ColorSelectionList.FirstOrDefault(x => x.MaterialTypeId == selected.MaterialTypeId);

                selected.ProductTypes.ForEach(x => x.IsSelected = true);

                ColorSelection colorSelection = new()
                {
                    Id = Guid.NewGuid(),
                    MaterialTypeId = selected.MaterialTypeId,
                    MaterialTypeName = selected.MaterialTypeName,
                    Title = $"Color Option {currentCount + 1}",
                    FabricCount = 1
                };

                FabricSelection fabricSelection = new()
                {
                    Id = Guid.NewGuid(),
                    Ordinal = ConvertToOrdinal(1),
                    OrdinalNumber = 1,
                    ColorOptionId = colorSelection.Id,
                    CollectionId = colorSelection.CollectionId
                };

                colorSelection.FabricSelectionList.Add(fabricSelection);

                colorSelection.IsAvailableInAllColors = colorselection == null ? false : colorselection.IsAvailableInAllColors;

                CollectionModel.ColorSelectionList.Add(colorSelection);

                SelectedColorProduct selectedColorProduct = new()
                {
                    MaterialTypeId = selected.MaterialTypeId,
                    ColorId = new(),
                    ProductTypeIds = new(),
                    Title = $"Color Option {currentCount + 1}"
                };

                CollectionModel.SelectedColorProducts.Add(selectedColorProduct);

                materialProduct.ProductTypes.ForEach(async productType => {
                    await IsAvailableHandler(colorSelection, productType, colorSelection.IsAvailableInAllColors.ToString(), colorSelection.ColorId);
                });

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - AddColorOptionHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task RemoveColorOptionHandler(MaterialProductTypes materialProduct, TypeModel materialType, ColorSelection colorSelection)
        {
            try
            {
                var selected = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == materialProduct.MaterialTypeId && x.Id == colorSelection.Id && x.Title == colorSelection.Title);

                var selecteds = CollectionModel.SelectedProductColors.FindAll(x => x.MaterialTypeId == materialType.Id);

                var selectedcolor = ColorList.Result.Items.Find(x => x.Id == selected.ColorId);

                if (selected != null)
                {
                    CollectionModel.ColorSelectionList.Remove(selected);

                    var i = 1;
                    var newCount = CollectionModel.ColorSelectionList.FindAll(x => x.MaterialTypeId == selected.MaterialTypeId);
                    newCount.ForEach(x => {
                        x.Title = $"Color Option {i}";
                        i++;
                    });

                    var selectedMaterialProduct = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId);
                    if (selectedMaterialProduct != null)
                    {
                        if (selectedMaterialProduct.SelectedColorIds.Contains(selected.ColorId))
                        {
                            selectedMaterialProduct.SelectedColorIds.Remove(selected.ColorId);
                        }

                        if (selectedcolor != null)
                        {
                            if (selectedMaterialProduct.Colors.Contains(selectedcolor))
                            {
                                selectedMaterialProduct.Colors.Remove(selectedcolor);
                            }
                        }

                        if (CollectionModel.ColorSelectionList.Count == 0)
                        {
                            selectedMaterialProduct.SelectedColorIds.Clear();
                            selectedMaterialProduct.Colors.Clear();
                        }
                    }

                    // Remove selected color
                    selecteds.ForEach(x => {
                        x.ColorIds.Remove(selected.ColorId);
                    });

                    // Unselect Materials
                    selected.FabricSelectionList.ForEach(x => {
                        var material = MaterialListModel.Result.Items.Find(m => m.Id == x.MaterialId);
                        if (material != null)
                        {
                            material.IsSelected = false;
                            material.SelectedOrdinal = string.Empty;
                        }
                    });
                }

                var colorProduct = CollectionModel.SelectedColorProducts.Find(x => x.MaterialTypeId == materialProduct.MaterialTypeId && x.ColorId == colorSelection.ColorId);

                if (colorProduct != null)
                {
                    CollectionModel.SelectedColorProducts.Remove(colorProduct);
                }

                var spts = CollectionModel.SPTs.FindAll(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.ColorOptionId == colorSelection.Id);

                if (spts != null)
                    spts.ForEach(x =>
                    {
                        CollectionModel.SPTs.Remove(x);
                    });

                var j = 1;
                CollectionModel.SelectedColorProducts.ForEach(x => {
                    x.Title = $"Color Option {j}";
                    j++;
                });

                CollectionModel.ColorSelectionList.ForEach(colorselection => {
                    var spt = CollectionModel.SPTs.FindAll(x => x.MaterialTypeId == colorselection.MaterialTypeId && x.ColorOptionId == colorselection.Id);
                    spt.ForEach(x => x.Title = colorselection.Title);
                });

                materialProduct.ProductTypes.ForEach(async p => {
                    var smp = CollectionModel.SelectedMaterialProducts.Find(x => x.MaterialTypeId == materialType.Id && x.ColorId == colorSelection.ColorId && x.ProductTypeId == p.Id);
                    if (smp != null)
                    {
                        CollectionModel.SelectedMaterialProducts.Remove(smp);
                    }
                });

                CollectionModel.ColorSelectionList.ForEach(x => {
                    x.ProductTypes.ForEach(async p => await Calculate(colorSelection.MaterialTypeId, p.Id));
                });

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - RemoveColorOptionHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task IsAvailableHandler(ColorSelection colorSelection, Items productType, string isChecked, int colorId)
        {
            try
            {
                var selected = CollectionModel.ColorSelectionList.Find(x => x.Id == colorSelection.Id && x.MaterialTypeId == colorSelection.MaterialTypeId && x.ColorId == colorId);

                var selecteds = CollectionModel.SelectedProductColors.FindAll(x => x.MaterialTypeId == colorSelection.MaterialTypeId);

                var selectedProductType = selecteds.Find(x => x.ProductTypeId == productType.Id);

                var colorProduct = CollectionModel.SelectedColorProducts.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.Title == colorSelection.Title);

                var spt = CollectionModel.SPTs.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.ColorOptionId == colorSelection.Id && x.ProductTypeId == productType.Id);

                if (selected != null)
                {
                    if (isChecked.Equals("True"))
                    {
                        if (!selected.ProductTypeIds.Contains(productType.Id))
                        {
                            selected.ProductTypeIds.Add(productType.Id);
                        }

                        if (!selected.ProductTypes.Contains(productType))
                        {
                            productType.IsSelected = true;
                            selected.ProductTypes.Add(productType);
                        }

                        if (colorId != 0)
                        {
                            if (!selectedProductType.ColorIds.Contains(colorId))
                            {
                                selectedProductType.ColorIds.Add(colorId);
                            }
                        }

                        if (colorProduct != null)
                        {
                            if (!colorProduct.ProductTypeIds.Contains(productType.Id))
                                colorProduct.ProductTypeIds.Add(productType.Id);

                            if (!colorProduct.ProductTypes.Contains(productType))
                                colorProduct.ProductTypes.Add(productType);

                            if (spt == null)
                            {
                                SPT SelectedProductType = new()
                                {
                                    ColorOptionId = colorSelection.Id,
                                    MaterialTypeId = selected.MaterialTypeId,
                                    ColorId = colorSelection.ColorId,
                                    ColorValue = colorSelection.ColorValue,
                                    ProductTypeId = productType.Id,
                                    Title = colorSelection.Title,
                                    ProductTypeSalesPercentage = productType.WeightedFQAC,
                                    ProductType = productType
                                };

                                if (!CollectionModel.SPTs.Contains(SelectedProductType))
                                    CollectionModel.SPTs.Add(SelectedProductType);
                            }
                        }
                    }
                    else
                    {
                        if (selected.ProductTypeIds.Contains(productType.Id))
                        {
                            selected.ProductTypeIds.Remove(productType.Id);
                        }

                        if (selected.ProductTypes.Contains(productType))
                        {
                            selected.ProductTypes.Remove(productType);
                        }

                        if (colorId != 0)
                        {
                            if (selectedProductType.ColorIds.Contains(colorId))
                            {
                                selectedProductType.ColorIds.Remove(colorId);
                            }
                        }

                        if (colorProduct != null)
                        {
                            if (colorProduct.ProductTypeIds.Contains(productType.Id))
                                colorProduct.ProductTypeIds.Remove(productType.Id);

                            if (colorProduct.ProductTypes.Contains(productType))
                                colorProduct.ProductTypes.Remove(productType);

                            if (spt != null)
                                CollectionModel.SPTs.Remove(spt);
                        }
                    }

                    await Calculate(colorSelection.MaterialTypeId, productType.Id);

                    colorSelection.FabricSelectionList.ForEach(async x => {
                        await CalculateMaxQuantity(colorSelection, x.Ordinal);
                    });

                }

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - IsAvailableHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task IsAvailableInThisColorHandler(MaterialProductTypes materialProduct, TypeModel materialType, string isSelected)
        {
            try
            {
                bool isChecked = bool.Parse(isSelected);

                var colorSelections = CollectionModel.ColorSelectionList.FindAll(x => x.MaterialTypeId == materialProduct.MaterialTypeId);

                if (isChecked)
                {
                    colorSelections.ForEach(colorSelection => {

                        colorSelection.IsAvailableInAllColors = true;
                        materialProduct.ProductTypes.ForEach(async productType => {
                            await IsAvailableHandler(colorSelection, productType, "True", colorSelection.ColorId);
                        });
                    });
                }
                else
                {
                    colorSelections.ForEach(colorSelection => {

                        colorSelection.IsAvailableInAllColors = false;
                        materialProduct.ProductTypes.ForEach(async productType => {
                            await IsAvailableHandler(colorSelection, productType, "False", colorSelection.ColorId);
                        });
                    });
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - IsAvailableInThisColorHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task Calculate(int materialTypeId, int productTypeId)
        {
            try
            {
                var colorProducts = CollectionModel.SPTs.FindAll(x => x.MaterialTypeId == materialTypeId && x.ColorId != 0);

                var productTypes = colorProducts.Select(x => new { x.ColorId, x }).ToList();

                List<string> colors = colorProducts.Select(c => c.ColorValue).ToList();
                var bothColors = colors.Contains("Black") && colors.Contains("Dark Blue");
                var notBothColors = !colors.Contains("Black") || !colors.Contains("Dark Blue");
                var remainingColors = bothColors ? colors.Count - 2 : colors.Count;

                colorProducts.ForEach(x => {
                    var color = colorProducts.FindAll(c => c.ColorId == x.ColorId);

                    var product = colorProducts.FindAll(c => c.ProductTypeId == x.ProductTypeId).Count();

                    if (color.Count == 1)
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                    else if (color.Count == 2)
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                    else if (color.Count == 3)
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                    else if ((color.Count > 3))
                    {
                        if (product == 1)
                        {
                            x.ColorSalesPercentage = 100;
                        }
                        else if (product == 2)
                        {
                            if (bothColors)
                                x.ColorSalesPercentage = 50;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 70;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 70;
                            else
                                x.ColorSalesPercentage = 30;
                        }
                        else if (product == 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 60;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60;
                            else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 100 / remainingColors;
                            else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 20;
                            else
                                x.ColorSalesPercentage = 20;
                        }
                        else if (product > 3)
                        {
                            if (bothColors && x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 30;
                            else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 30;
                            else if (x.ColorValue.Contains("Black"))
                                x.ColorSalesPercentage = 40;
                            else if (x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40;
                            else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 60 / (remainingColors - 1);
                            else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                x.ColorSalesPercentage = 40 / (remainingColors);
                            else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                            {
                                x.ColorSalesPercentage = 100 / remainingColors;
                            }
                        }
                    }
                });

                await ApplyCalculation(materialTypeId);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - Calculate()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task SelectColorHandler(ColorSelection colorSelection, string colorId)
        {
            try
            {
                var selected = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.Id == colorSelection.Id);

                var currentColorId = selected.ColorId;
                var currentColor = ColorList.Result.Items.Find(x => x.Id == currentColorId);

                var selectedcolor = ColorList.Result.Items.Find(x => x.Id == int.Parse(colorId));
                var colorValue = selectedcolor.Value;

                if (selected != null)
                {
                    selected.ColorId = int.Parse(colorId);
                    selected.ColorValue = selectedcolor.Value;
                    selected.ColorShortCode = selectedcolor.ShortCode;

                    selected.FabricSelectionList.ForEach(async x => {
                        x.ColorId = selected.ColorId;

                        var selectedColor = ColorList.Result.Items.Find(c => c.Id == x.ColorId);
                        if (selectedColor != null)
                        {
                            x.ColorShortCode = selectedColor.ShortCode;
                            x.ColorValue = selectedColor.Value;
                            x.HexCode = selectedColor.HexCode;
                            x.SalesPercentage = selectedColor.SalesPercentage.Value;
                        }

                        var material = MaterialListModel.Result.Items.Find(m => m.Id == x.MaterialId);
                        if (material != null)
                        {
                            material.IsSelected = false;
                            material.SelectedOrdinal = string.Empty;
                        }

                        x.MaterialId = Guid.Empty;
                        x.RollAndLocations.Clear();
                        x.collapseRoll = "";
                        x.SelectRolls = "Select Rolls";
                        x.SelectedRollWarehouse.Clear();
                        x.SelectedRolls.Clear();
                        x.SelectedRollIds.Clear();
                        x.SelectedRollAndLocation.Clear();

                        await onChangeCheckBoxAll(false, selected, x.Ordinal);

                    });
                }

                var materialProduct = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId);

                if (materialProduct != null)
                {
                    if (currentColorId != null)
                    {
                        if (materialProduct.SelectedColorIds.Contains(currentColorId))
                        {
                            materialProduct.SelectedColorIds.Remove(currentColorId);
                        }
                    }

                    if (currentColor != null)
                    {
                        if (materialProduct.Colors.Contains(currentColor))
                        {
                            materialProduct.Colors.Remove(currentColor);
                        }
                    }

                    if (materialProduct.SelectedColorIds.Contains(int.Parse(colorId)))
                    {
                        materialProduct.SelectedColorIds.Remove(int.Parse(colorId));
                    }

                    if (materialProduct.Colors.Contains(selectedcolor))
                    {
                        materialProduct.Colors.Remove(selectedcolor);
                    }

                    materialProduct.SelectedColorIds.Add(int.Parse(colorId));
                    materialProduct.Colors.Add(selectedcolor);
                }

                var colorProduct = CollectionModel.SelectedColorProducts.Find(x => x.MaterialTypeId == materialProduct.MaterialTypeId && x.Title == colorSelection.Title);

                if (colorProduct != null)
                {
                    colorProduct.ColorId = int.Parse(colorId);
                    colorProduct.ColorValue = selectedcolor.Value;
                }

                var spts = CollectionModel.SPTs.FindAll(x => x.MaterialTypeId == materialProduct.MaterialTypeId && x.Title == colorSelection.Title);
                if (spts != null)
                {
                    spts.ForEach(spt => {
                        spt.ColorId = int.Parse(colorId);
                        spt.ColorValue = selectedcolor.Value;
                    });
                }

                var selecteds = CollectionModel.SelectedProductColors.FindAll(x => x.MaterialTypeId == colorSelection.MaterialTypeId);

                selected.ProductTypes.ForEach(async x =>
                {
                    var select = selecteds.Find(sl => sl.ProductTypeId == x.Id);

                    if (select.ColorIds.Contains(currentColorId))
                        select.ColorIds.Remove(currentColorId);

                    if (!select.ColorIds.Contains(int.Parse(colorId)))
                        select.ColorIds.Add(int.Parse(colorId));

                    selected.ProductTypes.Find(p => p.Id == x.Id).ColorId = int.Parse(colorId);
                });

                selecteds.Where(x => x.ColorIds.Count != 0).ToList().ForEach(async x => {
                    await Calculate(colorSelection.MaterialTypeId, x.ProductTypeId);
                });

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - SelectColorHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onClickRoll(ColorSelection colorSelection, double requiredYardage, string ordinal, FabricSelection fabricSelection)
        {
            try
            {
                SelectedRollIds.Clear();
                await onCloseFabric();
                _rolls = new RollAndLocationModel[] { };
                ColorSelectionModel = new();
                SelectedRollList.Clear();
                ColorSelectionModel = colorSelection;
                ColorSelectionModel.SelectedRolls.Clear();
                ColorSelectionModel.RequiredYardage = requiredYardage;
                ColorSelectionModel.TotalRollYardage = colorSelection.TotalRollYardage;
                ColorSelectionModel.TotalRollYardagePercentage = colorSelection.TotalRollYardagePercentage;

                var selectedFabric = colorSelection.FabricSelectionList.Find(x => x.Id == fabricSelection.Id);

                if (selectedFabric != null)
                {
                    selectedFabric.SelectedRollIds.ForEach(x => {
                        if (!SelectedRollIds.Contains(x))
                            SelectedRollIds.Add(x);
                    });

                    selectedFabric.RollAndLocations.ForEach(roll => {

                        roll.Ordinal = ordinal;

                        if (IsEditable && colorSelection.IsApproved == null)
                        {
                            if (roll.ReserveCount == null || roll.ReserveCount == 0)
                            {
                                if (roll.ShadingId == null)
                                {
                                    SelectedRollList.Add(roll);
                                }
                                else
                                {
                                    SelectedRollList.Add(roll);
                                }
                            }
                            else
                            {
                                if (selectedFabric.SelectedRollIds.Contains(roll.Id))
                                {
                                    SelectedRollList.Add(roll);
                                }
                            }
                        }
                        else
                        {
                            if (roll.ShadingId == null)
                            {
                                SelectedRollList.Add(roll);
                            }
                            else
                            {
                                SelectedRollList.Add(roll);
                            }
                        }

                    });

                    _rolls = new RollAndLocationModel[] { };
                    _rolls = SelectedRollList.OrderBy(x => x.RollNumber);

                    selectedFabric.SelectedRollAndLocation.Clear();
                    _rolls.ToList().ForEach(x => selectedFabric.SelectedRollAndLocation.Add(x));
                }



                await CalculateMaxQuantity(colorSelection, ordinal);

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - onClickRoll()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task SelectRollHandler(ColorSelection colorSelection, RollAndLocationModel roll, string isChecked, string ordinal)
        {
            try
            {
                SelectedRollIds.Clear();

                var selected = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.Id == colorSelection.Id);

                var fabricSelection = selected.FabricSelectionList.Find(x => x.Ordinal == ordinal);

                if (selected != null)
                {
                    if (fabricSelection != null)
                    {
                        if (bool.Parse(isChecked))
                        {
                            if (!fabricSelection.SelectedRollIds.Contains(roll.Id))
                            {
                                fabricSelection.SelectedRollIds.Add(roll.Id);
                            }

                            if (!fabricSelection.SelectedRolls.Contains(roll))
                            {
                                fabricSelection.SelectedRolls.Add(roll);
                            }

                            if (!fabricSelection.SelectedRollWarehouse.Contains(roll.BuildingOrWarehouse))
                            {
                                fabricSelection.SelectedRollWarehouse.Add(roll.BuildingOrWarehouse);
                            }

                            if (!fabricSelection.SelectedRollNames.Contains($"{roll.RollNumber}"))
                            {
                                fabricSelection.SelectedRollNames.Add($"{roll.RollNumber}");
                            }
                        }
                        else
                        {
                            if (fabricSelection.SelectedRollIds.Contains(roll.Id))
                            {
                                fabricSelection.SelectedRollIds.Remove(roll.Id);
                            }

                            if (fabricSelection.SelectedRolls.Contains(roll))
                            {
                                fabricSelection.SelectedRolls.Remove(roll);
                            }

                            if (fabricSelection.SelectedRollWarehouse.Contains(roll.BuildingOrWarehouse))
                            {
                                fabricSelection.SelectedRollWarehouse.Remove(roll.BuildingOrWarehouse);
                            }

                            if (fabricSelection.SelectedRollNames.Contains($"{roll.RollNumber}"))
                            {
                                fabricSelection.SelectedRollNames.Remove($"{roll.RollNumber}");
                            }
                        }

                        var otherWarehouse = fabricSelection.SelectedRollWarehouse.FindAll(x => !x.Equals("SSY Cebu F1") && !x.Equals("SSY Cebu F2"));

                        if (otherWarehouse.Count == 0)
                        {
                            fabricSelection.isFabricOnSite = true;
                        }
                        else
                        {
                            fabricSelection.isFabricOnSite = false;
                        }

                        if (fabricSelection.SelectedRollNames.Count == 0)
                        {
                            fabricSelection.SelectRolls = "Select Rolls";
                        }
                        else
                        {
                            fabricSelection.SelectRolls = string.Join(", ", fabricSelection.SelectedRollNames);
                        }

                        fabricSelection.SelectedRollIds.ForEach(x => {
                            if (!selected.SelectedRollIds.Contains(x))
                                selected.SelectedRollIds.Add(x);

                            if (!SelectedRollIds.Contains(x))
                                SelectedRollIds.Add(x);
                        });

                        await CalculateMaxQuantity(colorSelection, ordinal);

                        await Recalculate();

                        StateHasChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - SelectRollHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onCloseRoll()
        {
            _materials = new MaterialModel[] { };
            ColorSelectionModel = new();
            SelectedFabricList.Clear();

            _rolls = new RollAndLocationModel[] { };
            ColorSelectionModel = new();
            SelectedRollList.Clear();
            ColorSelectionModel.SelectedRolls.Clear();
        }

        public async Task onDeleteProductTypeHandler(Items input)
        {
            try
            {
                var itemToRemove = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == input.MaterialTypeId);

                if (itemToRemove != null)
                {
                    itemToRemove.ProductTypeIds.Remove(input.Id);
                    itemToRemove.ProductTypeNames.Remove(input.Value);
                    itemToRemove.ProductTypes.Remove(input);

                    itemToRemove.selectedProductTypeNames = ReplaceString(JsonSerializer.Serialize(itemToRemove.ProductTypeNames));
                }

                var newItem = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == input.MaterialTypeId);
                newItem = itemToRemove;

                if (newItem.ProductTypes.Count == 0)
                {
                    newItem.selectedProductTypeNames = "Select Product Type";
                    newItem.IsApplied = false;
                }

                // Remove selected product type
                CollectionModel.ColorSelectionList.ForEach(x => {
                    x.ProductTypeIds.Remove(input.Id);
                    x.ProductTypes.Remove(input);
                });
                CollectionModel.MaterialProductTypeList.ForEach(x => x.SelectedColorIds.Remove(input.Id));
                CollectionModel.SelectedColorProducts.ForEach(x => {
                    x.ProductTypes.Remove(input);
                    x.ProductTypeIds.Remove(input.Id);
                });
                CollectionModel.SPTs.FindAll(x => x.ProductTypeId == input.Id).ForEach(x => CollectionModel.SPTs.Remove(x));
                var selectedProductColor = CollectionModel.SelectedProductColors.Find(x => x.ProductTypeId == input.Id);
                CollectionModel.SelectedProductColors.Remove(selectedProductColor);

                await CalculateProductTypeForecast();

                await ApplyCalculation(input.MaterialTypeId);

                await Recalculate();

                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - onDeleteProductTypeHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onEditProductTypeHandler(Items input)
        {
            var selectedProductType = CollectionModel.MaterialProductTypeList.Find(x => x.ProductTypes.Contains(input)).ProductTypes.Find(x => x == input);
            selectedProductType.IsOnEdit = true;
            selectedProductType.IsSelected = true;

            //await CalculateProductTypeForecast();
        }

        public async Task onChangeProductTypeHandler(Items input, string productTypeId)
        {
            var currentProductType = CollectionModel.MaterialProductTypeList.Find(x => x.ProductTypes.Contains(input)).ProductTypes.Find(x => x == input);
            currentProductType.IsOnEdit = false;

            var item = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == input.MaterialTypeId);

            // Remove Current
            item.ProductTypes.Remove(currentProductType);
            item.ProductTypeIds.Remove(currentProductType.Id);
            item.ProductTypeNames.Remove(currentProductType.Value);
            item.selectedProductTypeNames = ReplaceString(JsonSerializer.Serialize(item.ProductTypeNames));

            // Add New
            var newProductType = ProductTypeListModel.Items.Find(x => x.Id == int.Parse(productTypeId));
            newProductType.IsOnEdit = false;
            newProductType.IsSelected = true;
            item.ProductTypeIds.Add(int.Parse(productTypeId));
            item.ProductTypeNames.Add(newProductType.Value);
            item.ProductTypes.Add(newProductType);
            item.selectedProductTypeNames = ReplaceString(JsonSerializer.Serialize(item.ProductTypeNames));


            // Remove selected product type
            CollectionModel.ColorSelectionList.ForEach(x => {
                x.ProductTypeIds.Remove(input.Id);
                x.ProductTypes.Remove(input);
            });
            CollectionModel.MaterialProductTypeList.ForEach(x => x.SelectedColorIds.Remove(input.Id));
            CollectionModel.SelectedColorProducts.ForEach(x => {
                x.ProductTypes.Remove(input);
                x.ProductTypeIds.Remove(input.Id);
            });
            CollectionModel.SPTs.FindAll(x => x.ProductTypeId == input.Id).ForEach(x => CollectionModel.SPTs.Remove(x));
            var selectedProductColor = CollectionModel.SelectedProductColors.Find(x => x.ProductTypeId == input.Id);
            CollectionModel.SelectedProductColors.Remove(selectedProductColor);

            // Add selected producty
            SelectedProductColor selectedProduct = new()
            {
                ColorIds = new(),
                MaterialTypeId = newProductType.MaterialTypeId,
                ProductTypeId = newProductType.Id
            };
            CollectionModel.SelectedProductColors.Add(selectedProduct);

            await CalculateProductTypeForecast();

            await ApplyCalculation(input.MaterialTypeId);

            await Recalculate();

            StateHasChanged();
        }

        public async Task CalculateForecastByColor(int materialTypeId)
        {
            var colorSelection = CollectionModel.ColorSelectionList.Where(x => !string.IsNullOrWhiteSpace(x.ColorValue) && x.MaterialTypeId == materialTypeId).ToList();

            if (colorSelection != null)
            {
                List<string> colors = colorSelection.Select(c => c.ColorValue).ToList();

                var bothColors = colors.Contains("Black") && colors.Contains("Dark Blue");

                var remainingColors = bothColors ? colors.Count - 2 : colors.Count;

                if (colors.Count == 1)
                {
                    colorSelection.ForEach(x => x.WeightedSalesPercentage = 100);
                }
                else if (colors.Count == 2)
                {
                    colorSelection.ForEach(x => {
                        if (bothColors)
                            x.WeightedSalesPercentage = 50;
                        else if (!bothColors)
                            x.WeightedSalesPercentage = 50;
                        else if (x.ColorValue.Contains("Black"))
                            x.WeightedSalesPercentage = 70;
                        else if (x.ColorValue.Contains("Dark Blue"))
                            x.WeightedSalesPercentage = 70;
                        else
                            x.WeightedSalesPercentage = 30;
                    });
                }
                else if (colors.Count == 3)
                {
                    colorSelection.ForEach(x => {
                        if (bothColors && x.ColorValue.Contains("Black"))
                            x.WeightedSalesPercentage = 40;
                        else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                            x.WeightedSalesPercentage = 40;
                        else if (!bothColors)
                            x.WeightedSalesPercentage = 100 / remainingColors;
                        else if (x.ColorValue.Contains("Black"))
                            x.WeightedSalesPercentage = 60;
                        else if (x.ColorValue.Contains("Dark Blue"))
                            x.WeightedSalesPercentage = 60;
                        else
                            x.WeightedSalesPercentage = 20;
                    });

                }
                else if (colors.Count > 3)
                {
                    colorSelection.ForEach(x => {
                        if (bothColors && x.ColorValue.Contains("Black"))
                            x.WeightedSalesPercentage = 30;
                        else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                            x.WeightedSalesPercentage = 30;
                        else if (!bothColors)
                            x.WeightedSalesPercentage = 100 / remainingColors;
                        else if (x.ColorValue.Contains("Black"))
                            x.WeightedSalesPercentage = 40;
                        else if (x.ColorValue.Contains("Dark Blue"))
                            x.WeightedSalesPercentage = 40;
                        else
                            x.WeightedSalesPercentage = bothColors ? Math.Round((double)(40.00 / remainingColors)) : !bothColors ? Math.Round((double)(60.00 / (remainingColors - 1))) : Math.Round((double)(60.00 / remainingColors));
                    });

                }

                //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.ColorSelectionList));
            }
        }

        public async Task CalculateRequiredYardage(int productTypeId, int materialTypeId, int colorId)
        {
            var colorSelection = CollectionModel.ColorSelectionList.Where(x => !string.IsNullOrWhiteSpace(x.ColorValue) && x.MaterialTypeId == materialTypeId).ToList();

            var selecteds = CollectionModel.SelectedProductColors.Find(x => x.MaterialTypeId == materialTypeId && x.ProductTypeId == productTypeId);

            int count = selecteds.ColorIds.Count();

            if (count != 0 && count > 0)
            {
                if (colorSelection != null)
                {
                    List<string> colors = colorSelection.Select(c => c.ColorValue).ToList();
                    var bothColors = colors.Contains("Black") && colors.Contains("Dark Blue");
                    var notBothColors = !colors.Contains("Black") || !colors.Contains("Dark Blue");
                    var remainingColors = bothColors ? colors.Count - 2 : colors.Count;

                    if (colors.Count == 1)
                    {
                        colorSelection.ForEach(x => { x.WeightedSalesPercentage = 100; });
                        Console.WriteLine(JsonSerializer.Serialize(colorSelection));
                    }
                    else if (colors.Count == 2)
                    {
                        if (count == 1)
                        {
                            colorSelection.ForEach(x => { x.WeightedSalesPercentage = 100; });
                            Console.WriteLine(JsonSerializer.Serialize(colorSelection));
                        }
                        else if (count == 2)
                        {
                            colorSelection.Where(x => x.ColorId == colorId).ToList().ForEach(x =>
                            {
                                if (bothColors)
                                    x.WeightedSalesPercentage = 50;
                                else if (x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 70;
                                else if (x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 70;
                                else
                                    x.WeightedSalesPercentage = 30;
                            });
                            Console.WriteLine(JsonSerializer.Serialize(colorSelection));
                        }
                    }
                    else if (colors.Count == 3)
                    {
                        if (count == 1)
                        {
                            colorSelection.ForEach(x => { x.WeightedSalesPercentage = 100; });
                        }
                        else if (count == 2)
                        {
                            colorSelection.ForEach(x =>
                            {
                                if (bothColors)
                                    x.WeightedSalesPercentage = 50;
                                else if (x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 70;
                                else if (x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 70;
                                else
                                    x.WeightedSalesPercentage = 30;
                            });
                        }
                        else if (count == 3)
                        {
                            colorSelection.ForEach(x =>
                            {
                                if (bothColors && x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 40;
                                else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 40;
                                else if (x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 60;
                                else if (x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 60;
                                else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 100 / remainingColors;
                                else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 20;
                                else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 20;
                                else
                                    x.WeightedSalesPercentage = 20;
                            });
                        }
                    }
                    else if (colors.Count > 3)
                    {
                        if (count == 1)
                        {
                            colorSelection.ForEach(x => { x.WeightedSalesPercentage = 100; });
                        }
                        else if (count == 2)
                        {
                            colorSelection.ForEach(x =>
                            {
                                if (bothColors)
                                    x.WeightedSalesPercentage = 50;
                                else if (x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 70;
                                else if (x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 70;
                                else
                                    x.WeightedSalesPercentage = 30;
                            });
                        }
                        else if (count == 3)
                        {
                            colorSelection.ForEach(x =>
                            {
                                if (bothColors && x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 40;
                                else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 40;
                                else if (x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 60;
                                else if (x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 60;
                                else if (!colors.Contains("Black") && !colors.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 100 / remainingColors;
                                else if (colors.Contains("Black") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 20;
                                else if (colors.Contains("Dark Blue") && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 20;
                                else
                                    x.WeightedSalesPercentage = 20;
                            });
                        }
                        else if (count > 3)
                        {
                            colorSelection.ForEach(x =>
                            {
                                if (bothColors && x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 30;
                                else if (bothColors && x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 30;
                                else if (x.ColorValue.Contains("Black"))
                                    x.WeightedSalesPercentage = 40;
                                else if (x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 40;
                                else if ((colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 60 / (remainingColors - 1);
                                else if ((!colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 60 / (remainingColors - 1);
                                else if ((colors.Contains("Black") && colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                    x.WeightedSalesPercentage = 40 / (remainingColors);
                                else if ((!colors.Contains("Black") && !colors.Contains("Dark Blue")) && !x.ColorValue.Contains("Black") && !x.ColorValue.Contains("Dark Blue"))
                                {
                                    x.WeightedSalesPercentage = 100 / remainingColors;
                                }
                            });
                        }
                    }
                }
            }
        }

        public async Task ApplyCalculation(int materialTypeId)
        {
            var selected = CollectionModel.SPTs.Where(x => x.ColorId != 0).ToList();

            CollectionModel.SelectedMaterialProducts.Clear();

            selected.ForEach(x => {
                CollectionModel.SelectedMaterialProducts.Add(new()
                {
                    MaterialTypeId = x.MaterialTypeId,
                    WeightedSalesPercentage = x.ColorSalesPercentage,
                    ColorId = x.ColorId,
                    ProductTypeId = x.ProductTypeId,
                    ProductType = x.ProductType
                });
            });

            CollectionModel.SelectedProductTypes.Clear();

            var additionalPercentage = 1.15;

            CollectionModel.SelectedProductTypes = new();
            CollectionModel.SelectedMaterialProducts.ForEach(x =>
            {
                CollectionModel.SelectedProductTypes.Add(new()
                {
                    MaterialTypeId = x.MaterialTypeId,
                    ProductTypeId = x.ProductTypeId,
                    ColorId = x.ColorId,
                    RequiredYardage = Math.Round(x.ProductType.WeightedForecastQuantity * x.ProductType.AverageConsumption * (x.WeightedSalesPercentage / 100) * additionalPercentage)
                });

                //Console.WriteLine($"Product Type Forecast Quantity: {x.ProductType.WeightedForecastQuantity}");
                //Console.WriteLine($"Product Type Average Consumption: {x.ProductType.AverageConsumption}");
                //Console.WriteLine($"Color Percentage: {x.WeightedSalesPercentage}");
                //Console.WriteLine($"Additional Percentage: {additionalPercentage}");
                //Console.WriteLine($"Required Yardage: {x.ProductType.WeightedForecastQuantity * x.ProductType.AverageConsumption * (x.WeightedSalesPercentage / 100) * additionalPercentage} \n");
            });

            List<Total> totals = new();
            CollectionModel.SelectedProductTypes.ForEach(x => {
                x.TotalRequiredYardage = 0;
                x.TotalRequiredYardage = CollectionModel.SelectedProductTypes.FindAll(x => x.ColorId == x.ColorId && x.ProductTypeId == x.ProductTypeId).Sum(x => x.RequiredYardage);
            });

            CollectionModel.SelectedMaterialProducts.ForEach(x => {
                x.TotalProductRequiredYardage = 0;
                x.TotalProductRequiredYardage = CollectionModel.SelectedProductTypes.FindAll(p => p.ColorId == x.ColorId && p.MaterialTypeId == x.MaterialTypeId).Sum(s => s.RequiredYardage);
            });
        }

        public async Task onChangeApprove(ColorSelection colorSelection)
        {
            colorSelection.ApprovalIsApprove = true;
            colorSelection.ApprovalIsReject = false;
        }

        public async Task onChangeReject(ColorSelection colorSelection)
        {
            colorSelection.ApprovalIsApprove = false;
            colorSelection.ApprovalIsReject = true;
        }

        public async Task onClickApprove(ColorSelection colorSelection)
        {
            try
            {
                await ShowWaitingModal();
                var currentSession = await LocalStorage.GetAsync<UserSession>("userSession");

                currentUser = currentSession.Value.FullName;

                if (colorSelection.ProductTypes.Count == 0)
                {
                    await js.InvokeVoidAsync("defaultMessage", "warning", "No Product selected for this Color Option!", "");
                }
                else
                {
                    ApproveRejectColorOptionModel model = new()
                    {
                        CollectionId = colorSelection.CollectionId,
                        ColorOptionId = colorSelection.Id,
                        ApprovedBy = currentSession.Value.FullName,
                        IsOnSite = colorSelection.isFabricOnSite
                    };

                    // Todo: move collection to product module then create 1 saving
                    var isSucess = await _collectionService.ApproveColorOptionV2(model);

                    if (isSucess)
                    {

                        colorSelection.IsApproved = true;
                        colorSelection.IsRejected = false;

                        // display on BOM
                        await OnApprovedCollection.InvokeAsync(colorSelection);

                        if (colorSelection.FabricSelectionList.Any(x => x.isFabricOnSite == false))
                        {
                            await js.InvokeVoidAsync("defaultMessage", "info", "You have approved a fabric that is currently off-site. An email has already been sent to the procurement team to initiate the transfer.", "");
                        }
                    }
                }
                await HideWaitingModal();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await HideWaitingModal();
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task onClickReject(ColorSelection colorSelection)
        {
            try
            {
                await ShowWaitingModal();
                ApproveRejectColorOptionModel model = new()
                {
                    CollectionId = colorSelection.CollectionId,
                    ColorOptionId = colorSelection.Id
                };

                var isSucess = await _collectionService.RejectColorOptionV2(model);

                if (isSucess)
                {
                    colorSelection.IsApproved = false;
                    colorSelection.IsRejected = true;

                    // Reset Approval
                    CollectionModel.ColorSelectionList.ForEach(x => {
                        if (x.IsApproved == true) { x.IsApproved = null; x.IsRejected = null; x.ApprovalIsApprove = false; x.ApprovalIsReject = false; }
                    });

                    // display on BOM
                    await OnApprovedCollection.InvokeAsync(colorSelection);

                    List<Guid> reservedRollIds = new();
                    colorSelection.FabricSelectionList.ForEach(fabric => {
                        fabric.SelectedRolls.ForEach(x => {
                            reservedRollIds.Add(x.Id);
                        });
                    });

                    List<Guid> reservationIds = new();

                    colorSelection.FabricSelectionList.ForEach(fabric => {

                        var material = MaterialListModel.Result.Items.FirstOrDefault(x => x.Id == fabric.MaterialId);

                        material.RollsAndLocations.ForEach(x => {
                            x.RollReservations.FindAll(f => f.CollectionId == colorSelection.CollectionId).ForEach(r => {
                                if (reservedRollIds.Any(a => a == r.RollId))
                                    reservationIds.Add(r.ReservationId);
                            });
                        });
                    });

                    if (reservationIds.Count != 0)
                        await _reservationService.DeleteMaterialReservationList(reservationIds);

                    var colorsection = CollectionModel.ColorSelectionList.Find(x => x.Id == colorSelection.Id);
                    if (colorsection != null)
                        CollectionModel.ColorSelectionList.Remove(colorsection);

                    List<ProductModel> childProductsTodelete = new();
                    CollectionModel.ParentProducts.ForEach(x => {
                        var childProduct = x.ChildProducts.FindAll(c => c.ColorOptionId == colorSelection.Id);
                        childProductsTodelete.AddRange(childProduct);
                    });

                    if (childProductsTodelete.Any())
                        childProductsTodelete.ForEach(child => {
                            CollectionModel.ParentProducts.ForEach(x => {
                                x.ChildProducts.Remove(child);
                            });
                        });

                    CollectionModel.StatusId = StatusListModel.Find(x => x.Value.Equals("In Progress")).Id;

                    await OnRejectCollection.InvokeAsync(CollectionModel);

                    colorSelection.FabricSelectionList.ForEach(async x => {
                        await CalculateMaxQuantity(colorSelection, x.Ordinal);
                    });
                }
                await HideWaitingModal();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await HideWaitingModal();
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task CalculateProductTypeForecast()
        {
            try
            {
                // First: Categorize SubPercentage by Product Type Category

                CollectionModel.ProductByCatergories.Clear();

                var productByCatergories = CollectionModel.ProductByCatergories;

                CollectionModel.MaterialProductTypeList.ForEach(x => {

                    x.ProductTypes.OrderBy(x => x.ProductCategoryId).ToList().ForEach(p =>
                    {
                        var prod = productByCatergories.Find(x => x.ProductCategoryId == p.ProductCategoryId);

                        if (p.ProductCategoryId != null && prod == null)
                        {
                            productByCatergories.Add(new() { ProductCategoryId = p.ProductCategoryId });
                        }

                        productByCatergories.ForEach(pc => {
                            if (pc.ProductCategoryId == p.ProductCategoryId)
                            {
                                pc.ProductTypes.Add(new()
                                {
                                    MaterialTypeId = p.MaterialTypeId,
                                    ProductTypeId = p.Id,
                                    AverageConsumption = p.AverageConsumption,
                                    Percentage = p.SalesPercentage.Value,
                                    SubPercentage = p.SubSalesPercentage
                                });
                            }
                        });
                    });
                });

                // Second: Calculate 

                CollectionModel.ProductByCatergories.ForEach(x => {
                    // Total SubPercentage
                    double total = 0;
                    x.ProductTypes.ForEach(p => {
                        total += Math.Round(p.SubPercentage, 2);
                    });
                    x.TotalSubPercentage = total;
                });

                CollectionModel.ProductByCatergories.ForEach(x => {
                    // Weighted SubPercentage
                    x.ProductTypes.ForEach(p => {
                        p.WeightedSubPercentage = Math.Round(p.SubPercentage / x.TotalSubPercentage, 2);
                    });
                });

                CollectionModel.ProductByCatergories.ForEach(x => {
                    // Sales Percentage
                    x.ProductTypes.ForEach(p => {
                        p.SalesPercentage = Math.Round(p.WeightedSubPercentage * p.Percentage, 2);
                    });
                });

                double total = 0;
                CollectionModel.ProductByCatergories.ForEach(x => {
                    // Total Product Sales Percentage
                    x.ProductTypes.ForEach(p => {
                        total += p.SalesPercentage;
                    });

                    CollectionModel.TotalProductSalesPercentage = total;
                });

                CollectionModel.ProductByCatergories.ForEach(x => {
                    // Weighted Sales Percentage
                    x.ProductTypes.ForEach(p => {
                        p.WeightedSalesPercentage = Math.Round((p.SalesPercentage / CollectionModel.TotalProductSalesPercentage) * 100, 2);
                    });
                });

                CollectionModel.ProductByCatergories.ForEach(x => {
                    // Weighted Forecast Quantity
                    x.ProductTypes.ForEach(p => {
                        p.WeightedForecastQuantity = Math.Round((p.WeightedSalesPercentage * CollectionModel.ForecastQuantity) / 100, 2);
                    });
                });

                CollectionModel.ProductByCatergories = productByCatergories;

                //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.ProductByCatergories));

                await DistrubuteProductForecast();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - CalculateProductTypeForecast()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task DistrubuteProductForecast()
        {
            try
            {
                var productTypesByCategories = CollectionModel.ProductByCatergories;

                if (productTypesByCategories != null)
                {
                    productTypesByCategories.ForEach(product => {
                        product.ProductTypes.ForEach(x => {
                            ProductTypeListModel.Items.Find(p => p.Id == x.ProductTypeId).WeightedSalesPercentage = Math.Round(x.WeightedSalesPercentage);
                            ProductTypeListModel.Items.Find(p => p.Id == x.ProductTypeId).WeightedForecastQuantity = Math.Round(x.WeightedForecastQuantity);
                            ProductTypeListModel.Items.Find(p => p.Id == x.ProductTypeId).WeightedFQAC = Math.Round(x.WeightedForecastQuantity * x.AverageConsumption);
                        });
                    });
                }

                var productTypes = CollectionModel.MaterialProductTypeList;

                if (productTypes != null)
                {
                    productTypes.ForEach(x => {
                        double total = 0;
                        x.ProductTypes.OrderBy(x => x.MaterialTypeId).ToList().ForEach(p => {
                            total += Math.Round(p.WeightedForecastQuantity);
                        });

                        x.TotalForecast = Math.Round(total);
                    });

                    //Console.WriteLine(JsonSerializer.Serialize(CollectionModel.MaterialProductTypeList));
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - DistrubuteProductForecast()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task CalculateMaxQuantity(ColorSelection colorSelection, string ordinal)
        {
            try
            {
                var selected = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.Id == colorSelection.Id);

                if (selected != null)
                {
                    var selectedFabric = selected.FabricSelectionList.Find(x => x.Ordinal == ordinal);

                    double totalRequiredYardage = 0;
                    var productTypes = CollectionModel.SelectedMaterialProducts.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.ColorId == colorSelection.ColorId);
                    totalRequiredYardage = productTypes != null ? productTypes.TotalProductRequiredYardage : 0;

                    double totalPFQ = 0;
                    double totalPFQTY = 0;

                    if (selectedFabric != null)
                    {
                        // Product Type
                        selectedFabric.ProductTypeConsumption = 0;
                        selected.ProductTypes.ForEach(x => {
                            selectedFabric.ProductTypeConsumption += x.AverageConsumption;
                            selectedFabric.ProductTypeForecastQuantity = x.WeightedForecastQuantity;
                        });

                        // Roll
                        selectedFabric.TotalRollYardage = 0;
                        selectedFabric.SelectedRolls.ForEach(x =>
                        {
                            selectedFabric.TotalRollYardage += Math.Round(x.TotalCount.Value, 0);
                        });

                        // Summation
                        selectedFabric.Summation = 0;
                        selectedFabric.Summation = Math.Round(selectedFabric.TotalRollYardage + selectedFabric.ProductTypeConsumption, 0);

                        // Material Type Forecast Quantity
                        var materialTypeForecastQty = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId).MaterialTypes.Find(x => x.Id == colorSelection.MaterialTypeId).WeightedSalesPercentage;

                        var totalForecastQty = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId).TotalForecast;

                        var fabric = MaterialListModel.Result.Items.FirstOrDefault(m => m.Id == selectedFabric.MaterialId);

                        // Total Product Type Forecast Quantity
                        selected.ProductTypes.ForEach(x =>
                        {
                            totalPFQ += x.WeightedForecastQuantity;

                            var productForecastQty = x.WeightedForecastQuantity;
                            //Console.WriteLine("PRODUCT: " + productForecastQty);

                            //Console.WriteLine("REQUIRED YARDAGE: " + totalRequiredYardage);

                            //Console.WriteLine("RESERVED YARDAGE: " + selected.TotalRollYardage);

                            var averageConsumption = x.AverageConsumption;
                            //Console.WriteLine("AVG: " + averageConsumption);

                            //Console.WriteLine("TOTAL FORECAST QTY: " + totalForecastQty);

                            selectedFabric.MaxQuantityUsingAllocatedAndUnallocated = 0;
                            selectedFabric.MaxQuantityUsingAllocatedAndUnallocated = Math.Round((selectedFabric.TotalRollYardage + fabric.AvailableCount.Value) / averageConsumption, 0);
                            //Console.WriteLine("MaxQuantityUsingAllocatedAndUnallocated: " + selected.MaxQuantityUsingAllocatedAndUnallocated);

                            var step1 = selectedFabric.TotalRollYardage / averageConsumption;
                            //Console.WriteLine("STEP1: " + step1);

                            var step2 = productForecastQty / totalForecastQty;
                            //Console.WriteLine("STEP2: " + step2);

                            var step3 = step1 * step2;
                            //Console.WriteLine("STEP3: " + step3);

                            totalPFQTY += step3;

                        });

                        // Reserved Yardage Percentage
                        selectedFabric.TotalRollYardagePercentage = 0;
                        if (totalRequiredYardage == 0)
                            selectedFabric.TotalRollYardagePercentage = 0;
                        else
                            selectedFabric.TotalRollYardagePercentage = Math.Round(selectedFabric.TotalRollYardage / totalRequiredYardage * 100);
                        //Console.WriteLine("RESERVED YARDAGE PERCENTAGE: " + selected.TotalRollYardagePercentage);

                        // Reserved Yardage
                        var reservedYardage = selectedFabric.TotalRollYardage;
                        //Console.WriteLine("totalPFQTY: " + totalPFQTY);

                        //Console.WriteLine("colorSelection : " + JsonSerializer.Serialize(colorSelections));
                        //Console.WriteLine("MaterialProductTypeList : " + JsonSerializer.Serialize(CollectionModel));
                    }

                    // Reserved Yardage
                    selected.TotalRollYardage = 0;
                    selected.FabricSelectionList.ForEach(x => {
                        selected.TotalRollYardage += Math.Round(x.TotalRollYardage, 0);
                    });

                    // Reserved Yardage Percentage
                    selected.TotalRollYardagePercentage = 0;
                    if (totalRequiredYardage == 0)
                        selected.TotalRollYardagePercentage = 0;
                    else
                        selected.TotalRollYardagePercentage = Math.Round(selected.TotalRollYardage / totalRequiredYardage * 100);

                    // Max Quantity
                    selected.MaxQuantity = 0;
                    if (selectedFabric.SelectedRollIds.Count > 0)
                    {
                        selected.MaxQuantity = 0;
                        selected.MaxQuantity = Math.Round(totalPFQTY, 0);
                    }

                    double totalMaxQuantity = 0;
                    var colorSelections = CollectionModel.ColorSelectionList.FindAll(x => x.MaterialTypeId == colorSelection.MaterialTypeId);
                    colorSelections.ForEach(x =>
                    {
                        totalMaxQuantity += x.MaxQuantity;
                    });

                    var selectedMaterial = CollectionModel.MaterialProductTypeList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId);
                    if (selectedMaterial != null)
                    {
                        selectedMaterial.TotalMaxQuantity = 0;
                        selectedMaterial.TotalMaxQuantity = totalMaxQuantity;
                    }
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - CalculateMaxQuantity()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task Recalculate()
        {
            #region Max Quantity

            await CalculateProductTypeForecast();

            CollectionModel.ColorSelectionList.ForEach(async x =>
            {
                x.ProductTypes.Where(a => a.IsSelected).ToList().ForEach(async p => {
                    await Calculate(x.MaterialTypeId, p.Id);
                });

                await ApplyCalculation(x.MaterialTypeId);

                x.FabricSelectionList.ForEach(async f => {
                    if (!f.MaterialId.Equals(Guid.Empty))
                        await CalculateMaxQuantity(x, f.Ordinal);
                });
            });

            #endregion
        }

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

        public async Task ColorCountHandler(ColorSelection colorSelection, string input)
        {
            try
            {
                var selected = CollectionModel.ColorSelectionList.Find(x => x.MaterialTypeId == colorSelection.MaterialTypeId && x.Id == colorSelection.Id && x.Title == colorSelection.Title);

                if (selected != null)
                {
                    var previousFabCount = selected.FabricCount;
                    selected.FabricCount = int.Parse(input);

                    // Create Fabric Selection
                    for (int count = 1; count <= selected.FabricCount; count++)
                    {
                        var fab = selected.FabricSelectionList.Find(x => x.OrdinalNumber == count);

                        var selectedColor = ColorList.Result.Items.Find(c => c.Id == selected.ColorId);

                        if (fab == null)
                        {
                            FabricSelection fabricSelection = new();

                            fabricSelection.Id = Guid.NewGuid();
                            fabricSelection.CollectionId = selected.CollectionId;
                            fabricSelection.ColorOptionId = selected.ColorOptionId;
                            fabricSelection.ColorId = selected.ColorId;
                            fabricSelection.Ordinal = ConvertToOrdinal(count);
                            fabricSelection.OrdinalNumber = count;

                            if (selectedColor != null)
                            {
                                fabricSelection.ColorShortCode = selectedColor.ShortCode;
                                fabricSelection.ColorValue = selectedColor.Value;
                                fabricSelection.HexCode = selectedColor.HexCode;
                                fabricSelection.SalesPercentage = selectedColor.SalesPercentage.Value;
                            }

                            selected.FabricSelectionList.Add(fabricSelection);

                            await CalculateMaxQuantity(colorSelection, ConvertToOrdinal(count));

                            await Recalculate();

                            StateHasChanged();
                        }
                    }

                    // Remove Fabric Selection
                    if (selected.FabricCount < previousFabCount)
                    {
                        for (var count = previousFabCount; count > selected.FabricCount; count--)
                        {
                            var previousFab = selected.FabricSelectionList.Find(x => x.Ordinal == ConvertToOrdinal(count));
                            if (previousFab != null)
                            {
                                if (previousFab.MaterialId != Guid.Empty)
                                {
                                    var material = MaterialListModel.Result.Items.Find(x => x.Id == previousFab.MaterialId);
                                    if (material != null)
                                        material.IsSelected = false;
                                }

                                selected.FabricSelectionList.Remove(previousFab);

                                await CalculateMaxQuantity(colorSelection, ConvertToOrdinal(count));

                                await Recalculate();

                                StateHasChanged();
                            }
                        }
                    }

                    //Console.WriteLine(JsonSerializer.Serialize(selected.FabricSelectionList));
                }


            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException} - ColorCountHandler()");
                //await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public static string ConvertToOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        public class Total
        {
            public int ColorId { get; set; }
            public double TotalRequiredYardage { get; set; }
        }

        private Task ShowWaitingModal()
        {
            return ModalWaiting.Show();
        }

        private Task HideWaitingModal()
        {
            return ModalWaiting.Hide();
        }
    }
}