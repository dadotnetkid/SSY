using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Drops.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.LaunchCategories.Dtos;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;

namespace SSY.Blazor.Pages.Products.Detail;

public partial class Detail
{

    public string Module = "Product Detail";
    public string TabName = "Overview";
    public string CollectionName = "";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    public Guid CollectionId;

    public Guid ProductId;

    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }

    #region Services
    public ProductService _productService { get; set; }
    public ProductTypeService _productTypeService { get; set; }
    public TypeService _typeService { get; set; }
    public MediaFileService _mediaFileService { get; set; }
    public ShopifyService _shopifyService { get; set; }
    public MaterialService _materialService { get; set; }
    public GetDropdownService _getDropdownService { get; set; }
    public ProductOptionService _productOptionService { get; set; }
    public UserDetailService _userDetailService { get; set; }

    #endregion

    [Parameter]
    public Guid Id { get; set; }

    public CreateProductModel CreateProductModel { get; set; } = new();

    public List<ProductBomSummaryDto> BomSummaries { get; set; } = new();

    public bool IsEditable { get; set; } = false;
    public CollectionService _collectionService { get; set; }

    public ColorOptionService _colorOptionService { get; set; }

    public GetAllColorOptionOutputModel ColorOptionOutputModel { get; set; }

    public CollectionDropdownDto Dropdown { get; set; } = new();

    public ColorListModel ColorList { get; set; } = new() { Result = new() { Items = new() } };

    public List<DropModel> DropListModel { get; set; } = new();

    public LaunchCategoryListModel LaunchCategoryList { get; set; } = new() { Items = new() };

    public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

    public MaterialListModel MaterialListModel { get; set; } = new();

    public GetAllMaterialOutputModel MaterialList { get; set; } = new() { Result = new() { Items = new() } };

    // new setup for product revamp

    public List<UserDetailModelCC> InfluencerListModel { get; set; } = new();
    public ShopifyModel Shopify { get; set; }
    public ProductModel ProductModel { get; set; }
    public ProductTypeModel ProductTypeModel { get; set; }
    public LaunchCategoryDto LaunchCategoryModel { get; set; } = new();
    public List<PanelModel> Panels { get; set; }
    public List<ProductModel> ChildProducts { get; set; } = new();
    
    public List<Guid> ProductOptionRollIds = new();
    public List<Guid> ReservedRollIds = new();
    public double ForecastQuantity = 0;
    private bool IsLoading;
    private Modal ModalSaving;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;

            _productService = new(js, ClientFactory, NavigationManager, Configuration);
            _productOptionService = new(js, ClientFactory, NavigationManager, Configuration);
            _collectionService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _colorOptionService = new(js, ClientFactory, NavigationManager, Configuration);
            _typeService = new(js, ClientFactory, NavigationManager, Configuration);
            _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);
            _shopifyService = new(js, ClientFactory, NavigationManager, Configuration);
            _productTypeService = new(js, ClientFactory, NavigationManager, Configuration);
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);
            MaterialListModel = new() { Materials = new() };
            InfluencerListModel = (await _userDetailService.GetAllUserCC(null, null, null, null, null, 999)).Result.Items;


            ProductTypeModel = new() { Options = new() };
            Panels = new();
            LaunchCategoryList = await _getDropdownService.GetAllLaunchCategory(null, null, null, 100);
            Dropdown = await _collectionService.GetCollectionDropdowns();
            ColorList = await _getDropdownService.GetAllColor(null, null, null, 100);
            DropListModel = Dropdown.DropList.Items;

            ForecastQuantity = 0;
            ProductModel = new() { Shopify = new(), RejectionNotes = new(), ChildProducts = new() { } };
            ColorOptionOutputModel = new() { Result = new() { Items = new() } };

            // new setup for product revamp
            ProductModel = await _productService.GetProduct(Id);

            ProductTypeModel = await _productTypeService.GetProductTypeV2(ProductModel.TypeId);
            unitOfMeasurementListModel = await _getDropdownService.GetAllUnitOfMeasurement(null, null, null, 100);

            MaterialList = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000);

            var materialType = await _typeService.GetMaterialType((int)ProductModel.MaterialTypeId);
            Panels = materialType.Result.Panels;

            if (ProductModel.ProductMediaFiles.Any())
            {
                ProductModel.ProductMediaFiles.ForEach(x =>
                {
                    x.MediaFileId = x.MediaFile.Id;
                });
            }
            
            await GetForecastQuanity();
            await GetProductOptionRequirements();
            await GetRollsReserved();
            await AssignValues();

            IsLoading = false;

            StateHasChanged();

        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }

    public async Task OnSaveProductOption()
    {
        // MaterialList = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000);
        // MaterialListModel.Materials.Clear();
        // await GetRollsReserved();
        // StateHasChanged();
    }

    public async Task GetForecastQuanity()
    {
        if (ProductModel.CollectionInfluencers.Any())
        {
            foreach (var item in ProductModel.CollectionInfluencers)
            {
                var influencer = InfluencerListModel.FirstOrDefault(x => x.Id == item.InfluencerId);
                ForecastQuantity += (double) influencer.ProductQuantityForecast;
            }
        }
    }

    public async Task GetProductOptionRequirements()
    {
        var requiredCount = ForecastQuantity/2;

        foreach (var item in MaterialList.Result.Items)
        {
            // if (item.RollsAndLocations != null || item.RollsAndLocations.Count() != 0)
            // {
                // if (item.RollsAndLocations.Exists(r => r.IsDisposal == false) && requiredCount <= item.AvailableCount)
                    MaterialListModel.Materials.Add(item);
            // }
        }
    }

    public async Task GetRollsReserved()
    {
        ProductOptionRollIds.Clear();
        if (ProductModel.ChildProducts.Any())
        {
            foreach (var child in ProductModel.ChildProducts)
            {
                if (child.Options.Any())
                {
                    foreach (var option in child.Options)
                    {
                        // get all selected ids in rolls
                        if (!string.IsNullOrEmpty(option.RollIds))
                        {
                            var rollIds = JsonSerializer.Deserialize<List<Guid>>(option.RollIds);
                            var material = MaterialListModel.Materials.FirstOrDefault(x => x.Id == option.MaterialId);
                            if(rollIds.Any() && rollIds != null){
                                foreach (var rollId in rollIds)
                                {
                                    var roll =  material.RollsAndLocations.First(x => x.Id == rollId);
                                    var rollReservation = roll.RollReservations.FirstOrDefault();
                                    if(rollReservation != null ){
                                        ReservedRollIds.Add(rollReservation.ReservationId);
                                        ProductOptionRollIds.Add(rollId);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(JsonSerializer.Serialize("ReservedRollIds"));
        Console.WriteLine(JsonSerializer.Serialize(ReservedRollIds));
    }

    public async Task AssignValues()
    {
        ModuleChange = ProductModel.Name;
        CollectionName = ProductModel.CollectionName;
        CollectionId = ProductModel.CollectionId;
        ProductId = Id;

        List<string> names = new();
        ProductModel.CollectionInfluencers.ForEach(x => names.Add(x.InfluencerFullName));
        ProductModel.InfluencerNames = string.Join(", ", names);

        ProductModel.ChildProducts.ForEach(x =>
        {
            x.BillOfMaterial.ChildProductId = x.Id;
            BomSummaries.Add(x.BillOfMaterial);
        });

        ProductModel.ChildProducts.ForEach(x =>
        {
            x.ColorId = x.ColorId;
            x.ColorName = x.Sku.Substring(x.Sku.LastIndexOf("-") + 1);
            x.ColorCode = x.ColorCode;

            ChildProducts.Add(x);

            StateHasChanged();
        });

        LaunchCategoryModel.Id = LaunchCategoryList.Items.Find(x => x.Value == "Seasonal").Id;
        ProductModel.CategoryId = LaunchCategoryModel.Id;

    }

    public void Edit()
    {
        IsEditable = true;
        StateHasChanged();
    }

     public void Back()
    {
        try
        {
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
             js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }


    public async Task Save()
    {
        try
        {
            await ShowSavingModal();
            ProductModel.IsActive = true;

            await _productService.UpdateProductV2(ProductModel);
            await SaveShopify();
            IsEditable = false;

            ProductModel.ChildProducts.ForEach(x => x.BillOfMaterial.IsEdit = false);
            await HideSavingModal();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }
    public async Task AddProductOptionNotes(ProductModel product)
    {
        try
        {
            // var childProduct = ProductModel.ChildProducts.FirstOrDefault(x => x.Id == product.Id); 
            // childProduct.ProductOptionNotes = product.ProductOptionNotes;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";
            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }

    public async Task SaveParentProductOption()
    {
        try
        {
            List<UpdateProductOptionDto> productOptionDto = new();
            // check if equal to parent product of the updating option if yes apply to all child product if not apply to child only

            Console.WriteLine("All");
            ProductModel.ChildProducts.ForEach(x =>
            {
                x.Options = ProductModel.Options;
            });

            ProductModel.Options.ForEach(o =>
            {
                productOptionDto.Add(new UpdateProductOptionDto()
                {
                    ProductId = o.ProductId,
                    OptionId = o.OptionId,
                    MaterialId = o.MaterialId,
                    RollIds = o.RollIds,
                    UnitOfMeasurementId = o.UnitOfMeasurementId,
                    Consumption = o.Consumption,
                    RollNames = o.RollNames,
                    MaterialName = o.MaterialName,
                });
                ProductModel.ChildProducts.ForEach(c =>
                {
                    productOptionDto.Add(new UpdateProductOptionDto()
                    {
                        ProductId = c.Id,
                        OptionId = o.OptionId,
                        MaterialId = o.MaterialId,
                        RollIds = o.RollIds,
                        UnitOfMeasurementId = o.UnitOfMeasurementId,
                        Consumption = o.Consumption,
                        RollNames = o.RollNames,
                        MaterialName = o.MaterialName,
                    });
                });
            });
            await _productOptionService.UpdateProductOption(productOptionDto);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }

    private async Task SaveShopify()
    {
        try
        {
            List<UpdateShopifyModel> updateShopifies = new();

            ProductModel.ChildProducts.ForEach(x =>
            {
                var shopify = x.Shopify;
                List<CreateShopifyMediaFileModel> shopifyMediaFile = new();

                shopify.MediaFiles.ForEach(m =>
                {
                    shopifyMediaFile.Add(new CreateShopifyMediaFileModel()
                    {
                        OrderNumber = m.OrderNumber,
                        MediaFileId = m.MediaFile.Id
                    });
                });

                updateShopifies.Add(new UpdateShopifyModel()
                {
                    Id = shopify.Id,
                    ProductId = x.Id,
                    Name = shopify.Name,
                    Number = shopify.Number,
                    Price = shopify.Price,
                    Published = shopify.Published,
                    FabricComposition = shopify.FabricComposition,
                    CareInstruction = shopify.CareInstruction,
                    Tags = shopify.Tags,
                    Description = shopify.Description,
                    MediaFiles = shopifyMediaFile
                });
            });
            await _productService.UpdateShopifyList(updateShopifies);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }


    public async Task AddRejectionNote(RejectionNoteModel note)
    {
        try
        {
            if (note.ProductId == ProductModel.Id)
            {
                ProductModel.RejectionNotes.Add(note);
            }
            else
            {
                var child = ProductModel.ChildProducts.FirstOrDefault(x => x.Id == note.ProductId);
                child.RejectionNotes.Add(note);
            }

            StateHasChanged();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }

    public async Task UpdateProductOptionRollIds(Guid id)
    {
        try
        {
            if (ProductOptionRollIds.Contains(id))
            {
                ProductOptionRollIds.Remove(id);
            }
            else
            {
                ProductOptionRollIds.Add(id);
            }

            Console.WriteLine(JsonSerializer.Serialize("ProdzxczxczcxuctOptionRollIds"));
            Console.WriteLine(JsonSerializer.Serialize(ProductOptionRollIds));

            StateHasChanged();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
            await js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
        }
    }

    public async Task tabName(string tabName)
    {
        TabName = tabName;
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