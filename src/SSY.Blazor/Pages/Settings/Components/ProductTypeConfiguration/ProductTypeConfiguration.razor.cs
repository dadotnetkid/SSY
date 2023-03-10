using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.Administration.Users.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.BaseSizeSpecs;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.BaseSizeSpecs.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.OBJPatternBlocks;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.OBJPatternBlocks.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides.Model;

namespace SSY.Blazor.Pages.Settings.Components.ProductTypeConfiguration;

public partial class ProductTypeConfiguration
{
    public ProductTypeConfiguration()
    {
    }

    public string Module = "ReservationProductType";
    public string ModuleMessage = "";
    public string ModuleType = "Edit";

    #region Injections

    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }
    [Inject]
    public IWebHostEnvironment env { get; set; }
    private TypeService _typeService { get; set; }
    private ProductTypeService _productTypeService { get; set; }
    private ProductCategoryService _productCategoryService { get; set; }
    private BaseSizeSpecListService _baseSizeSpecService { get; set; }
    private OBJPatternBlockListService _objPatternBlockService { get; set; }
    private WorkmanshipGuideListService _workmanshipGuideListService { get; set; }
    //public GetDropdownService _getDropdownService { get; set; }

    #endregion

    #region Parameters

    [Parameter]
    public int Id { get; set; }
    [Parameter]
    public bool IsEditable { get; set; }

    #endregion

    #region Models

    public ProductTypeModel ProductTypeModel { get; set; }
    public BaseSizeSpecListModel BaseSizeSpecListModel { get; set; }
    public OBJPatternBlockListModel OBJPatternBlockListModel { get; set; }
    public WorkmanshipGuideListModel WorkmanshipGuideListModel { get; set; }

    public MediaFileModel MediaFileModel { get; set; }
    public List<string> UploadedFiles { get; set; } = new();
    private IEnumerable<WorkmanshipGuideListModel> _workmanshipGuideList { get; set; }
    private IEnumerable<BaseSizeSpecListModel> _baseSizeSpecList { get; set; }
    private IEnumerable<OBJPatternBlockListModel> _oBJPatternBlockList { get; set; }

    [Inject]
    public ProtectedLocalStorage LocalStorage { get; set; }

    public GetAllProductTypeOutputModel ProductTypeListModel { get; set; } = new() { Items = new() };
    public GetAllTypeOutputModel TypeListModel { get; set; }
    public GetAllProductCategoryOutputModel ProductCategoryListModel { get; set; }

    //public Core.Data.Dropdowns.Model.ProductTypeListModel ProductTypeListModel { get; set; } = new() { Items = new() };

    private List<IBrowserFile> loadedFiles = new();
    IReadOnlyList<IBrowserFile> selectedBaseSizeSpecFiles;
    IReadOnlyList<IBrowserFile> selectedOBJPatternBlockFiles;
    IBrowserFile selectedWorkmanshipGuideFile;
    private long maxFileSize = 1024 * 5000;
    private int maxAllowedFiles = 10;
    private bool isLoading;
    private string origFiles;
    string labelText = "";
    string labelNewText = "";
    string classAlert = "";

    public bool IsAddProductType { get; set; } = true;

    public async Task ClearAll()
    {
        ProductTypeModel.Id = 0;
        ProductTypeModel.MaterialTypeId = 0;
        ProductTypeModel.Label = string.Empty;
        ProductTypeModel.Value = string.Empty;
        ProductTypeModel.SalesPercentage = 0;
        ProductTypeModel.SubSalesPercentage = 0;
        ProductTypeModel.AverageConsumption = 0;
        ProductTypeModel.ProductCategoryId = 0;
        ProductTypeModel.OrderNumber = 0;
        ProductTypeModel.ShortCode = string.Empty;
        ProductTypeModel.FreeShippingFedExPrice = 0;
        ProductTypeModel.FreeShippingDHLPrice = 0;
        ProductTypeModel.TenUSDPrice = 0;
        ProductTypeModel.FiftenUSDPrice = 0;
        ProductTypeModel.TwentyUSDPrice = 0;
    }

    #endregion

    protected override async Task OnInitializedAsync()
    {
        _typeService = new(js, ClientFactory, NavigationManager, Configuration);
        _productTypeService = new(js, ClientFactory, NavigationManager, Configuration);
        _productCategoryService = new(js, ClientFactory, NavigationManager, Configuration);
        _workmanshipGuideListService = new(js, ClientFactory, NavigationManager, Configuration);
        _baseSizeSpecService = new(js, ClientFactory, NavigationManager, Configuration);
        _objPatternBlockService = new(js, ClientFactory, NavigationManager, Configuration);
        //_getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);

        ProductTypeModel = new();
        ProductTypeListModel = new() { Items = new() };
        TypeListModel = new() { Result = new() { Items = new() } };
        ProductCategoryListModel = new() { Items = new() };
        BaseSizeSpecListModel = new();
        OBJPatternBlockListModel = new();
        WorkmanshipGuideListModel = new();

        TypeListModel = await _typeService.GetAllType(2, null, null, null, 100);
        ProductTypeListModel = await _productTypeService.GetAllProductType(null, null, null, 1000);
        //ProductTypeListModel = await _getDropdownService.GetAllProductType(null, null, null, 1000);
        ProductCategoryListModel = await _productCategoryService.GetAllProductCategory(null, null, null, 100);
    }


    public async Task OnSubmit()
    {
        await RefreshCategory();

        if (ModuleMessage != "Edit")
        {
            CreateProductTypeModel input = new()
            {
                MaterialTypeId = ProductTypeModel.MaterialTypeId,
                Label = ProductTypeModel.Label,
                Value = ProductTypeModel.Label,
                ShortCode = ProductTypeModel.ShortCode,
                AverageConsumption = ProductTypeModel.AverageConsumption,
                ProductCategoryId = ProductTypeModel.ProductCategoryId,
                SalesPercentage = ProductTypeModel.SalesPercentage,
                SubSalesPercentage = ProductTypeModel.SubSalesPercentage,
                OrderNumber = ProductTypeModel.OrderNumber,
                FreeShippingDHLPrice = ProductTypeModel.FreeShippingDHLPrice,
                FreeShippingFedExPrice = ProductTypeModel.FreeShippingFedExPrice,
                TenUSDPrice = ProductTypeModel.TenUSDPrice,
                FiftenUSDPrice = ProductTypeModel.FiftenUSDPrice,
                TwentyUSDPrice = ProductTypeModel.TwentyUSDPrice

            };
            await AddBaseSizeSpec();
            await AddOBJPatternBlock();
            await AddWorkmanshipGuide();

            await _productTypeService.CreateProductType(input);

        }
        else
        {
            UpdateProductTypeModel input = new()
            {
                Id = ProductTypeModel.Id,
                MaterialTypeId = ProductTypeModel.MaterialTypeId,
                Label = ProductTypeModel.Label,
                Value = ProductTypeModel.Label,
                ShortCode = ProductTypeModel.ShortCode,
                AverageConsumption = ProductTypeModel.AverageConsumption,
                ProductCategoryId = ProductTypeModel.ProductCategoryId,
                SalesPercentage = ProductTypeModel.SalesPercentage,
                SubSalesPercentage = ProductTypeModel.SubSalesPercentage,
                OrderNumber = ProductTypeModel.OrderNumber,
                FreeShippingDHLPrice = ProductTypeModel.FreeShippingDHLPrice,
                FreeShippingFedExPrice = ProductTypeModel.FreeShippingFedExPrice,
                TenUSDPrice = ProductTypeModel.TenUSDPrice,
                FiftenUSDPrice = ProductTypeModel.FiftenUSDPrice,
                TwentyUSDPrice = ProductTypeModel.TwentyUSDPrice

            };
            await AddBaseSizeSpec();
            await AddOBJPatternBlock();
            await AddWorkmanshipGuide();

            await _productTypeService.UpdateProductType(input);
        }
        //await UploadBaseSizeSpec();
        //await UploadOBJPatternBlock();
        //await UploadWorkmanshipGuide();

        await Refresh();
    }

    public async Task Refresh()
    {
        //ProductTypeListModel = await _getDropdownService.GetAllProductType(null, null, null, 1000);
        ProductTypeListModel = await _productTypeService.GetAllProductType(null, null, null, 100);
    }

    public async Task RefreshCategory()
    {
        ProductCategoryListModel = await _productCategoryService.GetAllProductCategory(null, null, null, 100);
    }

    public async Task EditProductType(ProductTypeModel model)
    {
        await ClearAll();

        IsAddProductType = false;

        var result = await _productTypeService.GetProductType(model.Id);

        ProductTypeModel.Id = result.Id;
        ProductTypeModel.MaterialTypeId = result.MaterialTypeId;
        ProductTypeModel.Label = result.Label;
        ProductTypeModel.Value = result.Label;
        ProductTypeModel.SalesPercentage = result.SalesPercentage;
        ProductTypeModel.SubSalesPercentage = result.SubSalesPercentage;
        ProductTypeModel.AverageConsumption = result.AverageConsumption;
        ProductTypeModel.ProductCategoryId = result.ProductCategoryId;
        ProductTypeModel.OrderNumber = result.OrderNumber;
        ProductTypeModel.ShortCode = result.ShortCode;
        ProductTypeModel.FreeShippingFedExPrice = result.FreeShippingFedExPrice;
        ProductTypeModel.FreeShippingDHLPrice = result.FreeShippingDHLPrice;
        ProductTypeModel.TenUSDPrice = result.TenUSDPrice;
        ProductTypeModel.FiftenUSDPrice = result.FiftenUSDPrice;
        ProductTypeModel.TwentyUSDPrice = result.TwentyUSDPrice;
        ModuleMessage = "Edit";
    }

    public async Task RemoveProductType(int id)
    {
        await _productTypeService.DeleteProductType(id);

        await Refresh();
    }

    public async Task AddProductTypeHandler()
    {
        IsAddProductType = true;
        await ClearAll();
    }

    public async Task onChangeProductCategory(string input)
    {
        var productCategoryId = int.Parse(input);
        var productCategory = ProductCategoryListModel.Items.Find(x => x.Id == productCategoryId);

        ProductTypeModel.SalesPercentage = productCategory.SalesPercentage;
    }

    public async Task AddBaseSizeSpec()
    {
        try
        {
            var session = await LocalStorage.GetAsync<UserSession>("userSession");
            if (selectedBaseSizeSpecFiles != null)
            {

                // web server  path (do not delete)
                if (!Directory.Exists("../SSY.Content/Uploads/ProductTypes/" + Id + "/BaseSizeSpec/"))
                {
                    Directory.CreateDirectory("../SSY.Content/Uploads/ProductTypes/" + Id + "/BaseSizeSpec/");
                }


                // local development path (do not delete)(for s3 bucket intergration)
                //if (!Directory.Exists("../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/" + Id + "/BaseSizeSpec/"))
                //{
                //    Directory.CreateDirectory("../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/" + Id + "/BaseSizeSpec/");
                //}
                foreach (var file in selectedBaseSizeSpecFiles)
                {
                    Stream stream = file.OpenReadStream(maxFileSize);

                    // web server  path (do not delete)
                    var path = $@"../SSY.Content/Uploads/ProductTypes/{Id}/BaseSizeSpec/{file.Name}";

                    // local development path (do not delete)(for s3 bucket intergration)
                    //var path = $@"../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/{Id}/BaseSizeSpec/{selectedBaseSizeSpecFile.Name}";

                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    fs.Close();

                    BaseSizeSpecListModel.MediaFile.FilePath = $@"SSY.Content/Uploads/ProductTypes/{Id}/BaseSizeSpec/{file.Name}";
                    BaseSizeSpecListModel.MediaFile.Name = file.Name;
                    BaseSizeSpecListModel.MediaFile.FileName = file.Name;
                    BaseSizeSpecListModel.MediaFile.StorageFileName = file.Name;
                    BaseSizeSpecListModel.MediaFile.ContentType = file.ContentType;
                    BaseSizeSpecListModel.MediaFile.ContentDisposition = "";
                    BaseSizeSpecListModel.TypeId = Id;
                    //BaseSizeSpecListModel.AddedBy = session.Value.FullName;
                }
                await _baseSizeSpecService.CreateBaseSizeSpecList(BaseSizeSpecListModel);
                var response = await _baseSizeSpecService.GetAllBaseSizeSpecLists(null, Id, null, null, 100);
                _baseSizeSpecList = response.Result.Items;
                //await GetUploadedFiles();

            }
            else
            {
                labelText = "Please Insert your File";
                labelNewText = "Please use another file";
                classAlert = "Failed";
                StateHasChanged();
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
        }

    }

    public async Task AddOBJPatternBlock()
    {
        try
        {
            var session = await LocalStorage.GetAsync<UserSession>("userSession");
            if (selectedOBJPatternBlockFiles != null)
            {

                // web server  path (do not delete)
                if (!Directory.Exists("../SSY.Content/Uploads/ProductTypes/" + Id + "/OBJPatternBlock/"))
                {
                    Directory.CreateDirectory("../SSY.Content/Uploads/ProductTypes/" + Id + "/OBJPatternBlock/");
                }


                // local development path (do not delete)(for s3 bucket intergration)
                //if (!Directory.Exists("../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/" + Id + "/OBJPatternBlock/"))
                //{
                //    Directory.CreateDirectory("../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/" + Id + "/OBJPatternBlock/");
                //}

                foreach (var file in selectedOBJPatternBlockFiles)
                {
                    Stream stream = file.OpenReadStream(maxFileSize);

                    // web server  path (do not delete)
                    var path = $@"../SSY.Content/Uploads/ProductTypes/{Id}/OBJPatternBlock/{file.Name}";

                    // local development path (do not delete)(for s3 bucket intergration)
                    //var path = $@"../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/{Id}/OBJPatternBlock/{selectedOBJPatternBlockFile.Name}";

                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    fs.Close();
                    OBJPatternBlockListModel.MediaFile.FilePath = $@"SSY.Content/Uploads/ProductTypes/{Id}/OBJPatternBlock/{file.Name}";
                    OBJPatternBlockListModel.MediaFile.Name = file.Name;
                    OBJPatternBlockListModel.MediaFile.FileName = file.Name;
                    OBJPatternBlockListModel.MediaFile.StorageFileName = file.Name;
                    OBJPatternBlockListModel.MediaFile.ContentType = file.ContentType;
                    OBJPatternBlockListModel.MediaFile.ContentDisposition = "";
                    OBJPatternBlockListModel.TypeId = Id;
                    //BaseSizeSpecListModel.AddedBy = session.Value.FullName;
                }
                await _objPatternBlockService.CreateOBJPatternBlockList(OBJPatternBlockListModel);
                var response = await _objPatternBlockService.GetAllOBJPatternBlockLists(null, Id, null, null, 100);
                _oBJPatternBlockList = response.Result.Items;
                //await GetUploadedFiles();

            }
            else
            {
                labelText = "Please Insert your File";
                labelNewText = "Please use another file";
                classAlert = "Failed";
                StateHasChanged();
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
        }

    }

    public async Task AddWorkmanshipGuide()
    {
        try
        {
            var session = await LocalStorage.GetAsync<UserSession>("userSession");
            if (selectedWorkmanshipGuideFile != null)
            {

                // web server  path (do not delete)
                if (!Directory.Exists("../SSY.Content/Uploads/ProductTypes/" + Id + "/WorkmanshipGuide/"))
                {
                    Directory.CreateDirectory("../SSY.Content/Uploads/ProductTypes/" + Id + "/WorkmanshipGuide/");
                }


                // local development path (do not delete)(for s3 bucket intergration)
                //if (!Directory.Exists("../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/" + Id + "/WorkmanshipGuide/"))
                //{
                //    Directory.CreateDirectory("../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/" + Id + "/WorkmanshipGuide/");
                //}

                Stream stream = selectedWorkmanshipGuideFile.OpenReadStream(maxFileSize);

                // web server  path (do not delete)
                var path = $@"../SSY.Content/Uploads/ProductTypes/{Id}/WorkmanshipGuide/{selectedWorkmanshipGuideFile.Name}";

                // local development path (do not delete)(for s3 bucket intergration)
                //var path = $@"../../abpCore/aspnet-core/src/SSY.Content/Uploads/ProductTypes/{Id}/WorkmanshipGuide/{selectedWorkmanshipGuideFile.Name}";

                FileStream fs = File.Create(path);
                await stream.CopyToAsync(fs);
                fs.Close();
                WorkmanshipGuideListModel.MediaFile.FilePath = $@"SSY.Content/Uploads/ProductTypes/{Id}/WorkmanshipGuide/{selectedWorkmanshipGuideFile.Name}";
                WorkmanshipGuideListModel.MediaFile.Name = selectedWorkmanshipGuideFile.Name;
                WorkmanshipGuideListModel.MediaFile.FileName = selectedWorkmanshipGuideFile.Name;
                WorkmanshipGuideListModel.MediaFile.StorageFileName = selectedWorkmanshipGuideFile.Name;
                WorkmanshipGuideListModel.MediaFile.ContentType = selectedWorkmanshipGuideFile.ContentType;
                WorkmanshipGuideListModel.MediaFile.ContentDisposition = "";
                WorkmanshipGuideListModel.TypeId = Id;
                //WorkmanshipGuideListModel.AddedBy = session.Value.FullName;

                await _workmanshipGuideListService.CreateWorkmanshipGuideList(WorkmanshipGuideListModel);
                var response = await _workmanshipGuideListService.GetAllWorkmanshipGuideLists(null, Id, null, null, 100);
                _workmanshipGuideList = response.Result.Items;
                //await GetUploadedFiles();

            }
            else
            {
                labelText = "Please Insert your File";
                labelNewText = "Please use another file";
                classAlert = "Failed";
                StateHasChanged();
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            Console.WriteLine($"Error: {ex.Message}{innerException}");
        }

    }

    private async Task LoadBaseSizeSpecFiles(InputFileChangeEventArgs bss)
    {
        var dataBaseSizePecFiles = bss.GetMultipleFiles();
        selectedBaseSizeSpecFiles = dataBaseSizePecFiles;
        var format = "pdf";
        List<string> bssFiles = new();

        foreach (var file in dataBaseSizePecFiles)
        {
            var resizedImageFiles = await file.RequestImageFileAsync(format, 100, 100);
            var buffer = new byte[resizedImageFiles.Size];
            await resizedImageFiles.OpenReadStream().ReadAsync(buffer);
            var imageDataUrl = $"data: {format}; base64,{Convert.ToBase64String(buffer)}";
        }
        this.StateHasChanged();
    }

    private async Task LoadOBJPatternBlockFiles(InputFileChangeEventArgs obj)
    {
        var dataOBJPatternBlockFiles = obj.GetMultipleFiles();
        selectedOBJPatternBlockFiles = dataOBJPatternBlockFiles;
        var format = "pdf";
        List<string> objFiles = new();

        foreach (var file in dataOBJPatternBlockFiles)
        {
            var resizedImageFiles = await file.RequestImageFileAsync(format, 100, 100);
            var buffer = new byte[resizedImageFiles.Size];
            await resizedImageFiles.OpenReadStream().ReadAsync(buffer);
            var imageDataUrl = $"data: {format}; base64,{Convert.ToBase64String(buffer)}";
        }
        this.StateHasChanged();
    }

    private async Task LoadWorkmanshipGuideFiles(InputFileChangeEventArgs wg)
    {
        var dataWorkmanshipGuideFile = wg.File;
        selectedWorkmanshipGuideFile = dataWorkmanshipGuideFile;
        var format = "pdf";
        var resizedImageFiles = await dataWorkmanshipGuideFile.RequestImageFileAsync(format, 100, 100);
        var buffer = new byte[resizedImageFiles.Size];
        await resizedImageFiles.OpenReadStream().ReadAsync(buffer);
        var imageDataUrl = $"data: {format}; base64,{Convert.ToBase64String(buffer)}";
        this.StateHasChanged();
    }
}
