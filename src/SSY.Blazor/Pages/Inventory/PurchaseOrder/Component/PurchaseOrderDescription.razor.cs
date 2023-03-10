using Microsoft.AspNetCore.Components.Forms;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrderTypes;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrderTypes.Model;

namespace SSY.Blazor.Pages.Inventory.PurchaseOrder.Component;


public partial class PurchaseOrderDescription
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

    public PurchaseOrderService _purchaseOrderService { get; set; }
    private CompanyService _companyService { get; set; }
    private PurchaseOrderTypeService _purchaseOrderTypeService { get; set; }

    public List<Guid> PurchaseOrderIds { get; set; } = new();

    #endregion

    #region Models

    private IEnumerable<PurchaseOrderModel> _purchaseOrder { get; set; }
    public GetAllPurchaseOrderOutputModel PurchaseOrderListModel { get; set; } = new() { Result = new() { Items = new() } };
    public List<CompanyModel> SuppliersModel { get; set; } = new();
    public List<PurchaseOrderTypeModel> PurchaseOrdersTypeModel { get; set; } = new();

    #endregion

    public string Module = "Detail";
    public string ModuleMessage = "";
    public string ModuleType = "View";
    public string Crud = "Detail";
    public string MaterialTypeText = "Detail";
    public string ModuleChange = "";

    private List<IBrowserFile> loadedFiles = new();
    private List<IBrowserFile> loadedShippingInvoice = new();
    private List<IBrowserFile> loadedPackingList = new();
    private List<IBrowserFile> loadedBlawb = new();
    private List<IBrowserFile> loadedFabricInspectionReport = new();
    private List<IBrowserFile> loadedFabricTestingReport = new();

    private long maxFileSize = 1024 * 5000;
    private int maxAllowedFiles = 3;
    private bool isLoading;

    private string customFilterValue;

    [Parameter]
    public bool IsEditable { get; set; }
    [Parameter]
    public PurchaseOrderModel PurchaseOrderModel { get; set; } = new();
    [Parameter]
    public CompanyModel SupplierModel { get; set; } = new();
    [Parameter]
    public EventCallback<CompanyModel> OnChangeSupplier { get; set; }
    [Parameter]
    public PurchaseOrderTypeModel PurchaseOrderTypeModel { get; set; } = new();

    public string _document = String.Empty;
    //public string _shippingInvoice;
    //public string _packingList;
    //public string _blawb;
    //public string _fabricInspectionReport;
    //public string _fabricTestingReport;

    public bool CanSubmit()
    {
        return editForm.EditContext.Validate();
    }

    protected override async Task OnInitializedAsync()
    {
        _purchaseOrderService = new(js, ClientFactory, NavigationManager, Configuration);
        _companyService = new(js, ClientFactory, NavigationManager, Configuration);
        _purchaseOrderTypeService = new(js, ClientFactory, NavigationManager, Configuration);

        var supplier = await _companyService.GetAllCompany(null, null, null, 100);
        var purchaseordertype = await _purchaseOrderTypeService.GetAllPurchaseOrderType(null, null, null, 100);

        SuppliersModel = supplier.Result.Items;
        PurchaseOrdersTypeModel = purchaseordertype.Result.Items;

        //if (IsEditable)
        //{
        //    string document = PurchaseOrderModel.Document;
        //    PurchaseOrderModel.Document = document;
        //    Console.WriteLine(JsonSerializer.Serialize(_document));
        //}
        //else {
        //    string document = PurchaseOrderModel.Document;
        //    PurchaseOrderModel.Document = document.Replace("/Uploads/PurchaseOrder/Documents/", "");
        //    Console.WriteLine(JsonSerializer.Serialize(_document));
        //}
        
        //string shippingInvoice = PurchaseOrderModel.ShippingInvoice.Replace("/Uploads/PurchaseOrder/ShippingInvoice/", "");
        //_shippingInvoice = shippingInvoice;

        //string packingList = PurchaseOrderModel.PackingList.Replace("/Uploads/PurchaseOrder/PackingList/", "");
        //_packingList = packingList;

        //string blawb = PurchaseOrderModel.Blawb.Replace("/Uploads/PurchaseOrder/Blawb/", "");
        //_blawb = blawb;

        //string fabricInspectionReport = PurchaseOrderModel.FabricInspectionReport.Replace("/Uploads/PurchaseOrder/FabricInspectionReport/", "");
        //_fabricInspectionReport = fabricInspectionReport;

        //string fabricTestingReport = PurchaseOrderModel.FabricTestingReport.Replace("/Uploads/PurchaseOrder/FabricTestingReport/", "");
        //_fabricTestingReport = fabricTestingReport;

        StateHasChanged();
    }

    private async Task DownloadFileFromURL(string url, string name)
    {
        await js.InvokeVoidAsync("triggerFileDownload", name, url);
    }

    private async Task DownloadFileFromURLShippingInvoice(string url, string name)
    {
        await js.InvokeVoidAsync("triggerFileDownload", name, url);
    }

    private async Task LoadFiles(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedFiles.Clear();
        var loadFile = e.File;

        try
        {

            loadedFiles.Add(loadFile);

            Stream stream = loadFile.OpenReadStream(maxFileSize);
            var path = $@"/Uploads/PurchaseOrder/Documents/{loadFile.Name}";
            var fullPath = $@"{env.WebRootPath}/Uploads/PurchaseOrder/Documents/{loadFile.Name}";
            FileStream fs = File.Create(fullPath);
            await stream.CopyToAsync(fs);
            fs.Close();
            PurchaseOrderModel.Document = path;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("File: {Filename} Error: {Error} " +
            loadFile.Name + ex.Message);
            await js.InvokeVoidAsync("defaultMessage", "error", "Upload Error!", ex.Message);

        }

        isLoading = false;
    }

    private async Task LoadShippingInvoice(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedShippingInvoice.Clear();
        var file = e.File;

        try
        {

            loadedShippingInvoice.Add(file);

            Stream stream = file.OpenReadStream(maxFileSize);
            var path = $@"/Uploads/PurchaseOrder/ShippingInvoice/{file.Name}";
            var fullPath = $@"{env.WebRootPath}/Uploads/PurchaseOrder/ShippingInvoice/{file.Name}";
            FileStream fs = File.Create(fullPath);
            await stream.CopyToAsync(fs);
            fs.Close();
            PurchaseOrderModel.ShippingInvoice = path;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("File: {Filename} Error: {Error} " +
            file.Name + ex.Message);
            await js.InvokeVoidAsync("defaultMessage", "error", "Upload Error!", ex.Message);

        }

        isLoading = false;
    }
    private async Task LoadPackingList(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedPackingList.Clear();
        var file = e.File;

        try
        {

            loadedPackingList.Add(file);

            Stream stream = file.OpenReadStream(maxFileSize);
            var path = $@"/Uploads/PurchaseOrder/PackingList/{file.Name}";
            var fullPath = $@"{env.WebRootPath}/Uploads/PurchaseOrder/PackingList/{file.Name}";
            FileStream fs = File.Create(fullPath);
            await stream.CopyToAsync(fs);
            fs.Close();
            PurchaseOrderModel.PackingList = path;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("File: {Filename} Error: {Error} " +
            file.Name + ex.Message);
            await js.InvokeVoidAsync("defaultMessage", "error", "Upload Error!", ex.Message);

        }

        isLoading = false;
    }
    private async Task LoadBlawb(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedBlawb.Clear();
        var file = e.File;

        try
        {

            loadedBlawb.Add(file);

            Stream stream = file.OpenReadStream(maxFileSize);
            var path = $@"/Uploads/PurchaseOrder/Blawb/{file.Name}";
            var fullPath = $@"{env.WebRootPath}/Uploads/PurchaseOrder/Blawb/{file.Name}";
            FileStream fs = File.Create(fullPath);
            await stream.CopyToAsync(fs);
            fs.Close();
            PurchaseOrderModel.Blawb = path;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("File: {Filename} Error: {Error} " +
            file.Name + ex.Message);
            await js.InvokeVoidAsync("defaultMessage", "error", "Upload Error!", ex.Message);

        }

        isLoading = false;
    }

    private async Task LoadFabricInspectionReport(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedFabricInspectionReport.Clear();
        var file = e.File;

        try
        {

            loadedFabricInspectionReport.Add(file);

            Stream stream = file.OpenReadStream(maxFileSize);
            var path = $@"/Uploads/PurchaseOrder/FabricInspectionReport/{file.Name}";
            var fullPath = $@"{env.WebRootPath}/Uploads/PurchaseOrder/FabricInspectionReport/{file.Name}";
            FileStream fs = File.Create(fullPath);
            await stream.CopyToAsync(fs);
            fs.Close();
            PurchaseOrderModel.FabricInspectionReport = path;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("File: {Filename} Error: {Error} " +
            file.Name + ex.Message);
            await js.InvokeVoidAsync("defaultMessage", "error", "Upload Error!", ex.Message);

        }

        isLoading = false;
    }
    private async Task LoadFabricTestingReport(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedFabricTestingReport.Clear();
        var file = e.File;

        try
        {

            loadedFabricTestingReport.Add(file);

            Stream stream = file.OpenReadStream(maxFileSize);
            var path = $@"/Uploads/PurchaseOrder/FabricTestingReport/{file.Name}";
            var fullPath = $@"{env.WebRootPath}/Uploads/PurchaseOrder/FabricTestingReport/{file.Name}";
            FileStream fs = File.Create(fullPath);
            await stream.CopyToAsync(fs);
            fs.Close();
            PurchaseOrderModel.FabricTestingReport = path;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("File: {Filename} Error: {Error} " +
            file.Name + ex.Message);
            await js.InvokeVoidAsync("defaultMessage", "error", "Upload Error!", ex.Message);

        }

        isLoading = false;
    }

}

