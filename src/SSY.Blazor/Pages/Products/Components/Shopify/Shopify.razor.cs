

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;
using SSY.Blazor.HttpClients.Models.Shopify;
using SSY.Blazor.HttpClients.RefitServices.Products.Shopifies;

namespace SSY.Blazor.Pages.Products.Components.Shopify;

public partial class Shopify
{
    #region Injections
    [Inject] IMessageService messageService { get; set; }
    [Inject]
    public IWebHostEnvironment env { get; set; }
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
    public ShopifyService _shopifyService { get; set; }
    public MediaFileService _mediaFileService { get; set; }
    public ProductService _productService { get; set; }
    #endregion

    #region ImagesUploading
    IReadOnlyList<IBrowserFile> selectedFile;
    private long maxFileSize = long.MaxValue;
    private int maxAllowedFiles = 10;

    #endregion
    [Parameter]
    public MediaFileModel MediaFileModel { get; set; } = new();
    [Parameter]
    public EventCallback<List<ProductModel>> OnShopifyChanged { get; set; }
    [Parameter]
    public EventCallback<List<MediaFileModel>> OnMediaFileChanged { get; set; }

    [Parameter]
    public bool IsEditable { get; set; } = false;
    [Parameter]
    public List<ProductModel> ChildProducts { get; set; }
    [CascadingParameter(Name = "MainPage")] public Detail.Detail MainPage { get; set; }

    [Inject]
    public IShopifyApi shopifyApi { get; set; }

    bool rememberMe = false;
    string shopifyStatus = "Offline";

    List<string> multipleSelectionData = new();
    IDictionary<string, bool> States = new Dictionary<string, bool>()
    {
        {"IsSaving",false}
    };
    public IEnumerable<ShopifyModel> _tags { get; set; }


    // for ui used 

    private List<string> FilePaths = new();


    protected override async Task OnInitializedAsync()
    {

        MediaFileModel = MediaFileModel ?? new();
        ChildProducts = ChildProducts ?? new();

        _shopifyService = new(js, ClientFactory, NavigationManager, Configuration);
        _mediaFileService = new(js, ClientFactory, NavigationManager, Configuration);
        _productService = new(js, ClientFactory, NavigationManager, Configuration);

    }



    Task OnRememberMeChanged(ShopifyModel shopify, bool value)
    {
        rememberMe = value;
        if (rememberMe == true)
        {
            shopifyStatus = "Online";
            shopify.Published = true;
            OnShopifyChanged.InvokeAsync(ChildProducts);
        }
        else
        {
            shopifyStatus = "Offline";
            shopify.Published = false;
            OnShopifyChanged.InvokeAsync(ChildProducts);
        }
        return Task.CompletedTask;
    }

    protected override async Task OnParametersSetAsync()
    {
        // Console.WriteLine("Shopify");
        if (ChildProducts.Any())
        {
            ChildProducts.ForEach(x =>
            {
                x.Shopify = x.Shopify ?? new();
                if (!string.IsNullOrWhiteSpace(x.Shopify?.Tags))
                {
                    var tags = JsonSerializer.Deserialize<List<string>>(x.Shopify.Tags);
                    x.Shopify.ListTags = tags;
                }
            });
        }
    }

    public async Task PushToShopify(ShopifyModel shopify)
    {

    }

    public async Task ApplyToAll(ProductModel product)
    {
        var listTags = product.Shopify.ListTags;
        var description = product.Shopify.Description;
        Console.WriteLine(JsonSerializer.Serialize("product.Shopify.ListTags"));
        Console.WriteLine(JsonSerializer.Serialize(product.Shopify.ListTags));

        ChildProducts.ForEach(x =>
        {
            x.Shopify.ListTags = listTags;
            x.Shopify.Description = description;
            x.Shopify.Tags = JsonSerializer.Serialize(listTags);
        });

        Console.WriteLine(JsonSerializer.Serialize("product.Shopify.ListTags"));
        Console.WriteLine(JsonSerializer.Serialize(product.Shopify.ListTags));
    }

    private async Task UploadFile(InputFileChangeEventArgs e, Guid productId)
    {
        try
        {
            var product = ChildProducts.FirstOrDefault(x => x.Id == productId);
            List<CreateMediaFileModel> mediaFiles = new();

            //create file directory if the directory do not exist
            var directoryPath = $@"{env.WebRootPath}/Uploads/Products/{productId}/Shopify/";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var dataFiles = e.GetMultipleFiles();
            selectedFile = dataFiles;

            foreach (var file in selectedFile)
            {
                Stream stream = file.OpenReadStream(maxFileSize);
                var path = $@"/Uploads/Products/{productId}/Shopify/{file.Name}";
                var fullPath = $@"{env.WebRootPath}/Uploads/Products/{productId}/Shopify/{file.Name}";
                FileStream fs = File.Create(fullPath);
                await stream.CopyToAsync(fs);
                fs.Close();

                mediaFiles.Add(new CreateMediaFileModel()
                {
                    TenantId = null,
                    FilePath = path,
                    Name = file.Name,
                    FileName = file.Name,
                    StorageFileName = file.Name,
                    ContentType = file.ContentType,
                    ContentDisposition = "",
                    CategoryId = 0,
                    MediaFileType = 1
                });
            }

            var newMediaFiles = await _mediaFileService.CreateListMediaFileProduct(mediaFiles);

            int fileCount = 0;
            if (product.Shopify.MediaFiles.Any())
                fileCount = product.Shopify.MediaFiles.OrderByDescending(x => x.OrderNumber).FirstOrDefault().OrderNumber;

            foreach (var media in newMediaFiles)
            {
                fileCount++;
                product.Shopify.MediaFiles.Add(new ShopifyMediaFileModel()
                {
                    OrderNumber = fileCount,
                    MediaFile = media
                });
            }
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

    private async Task OnDelete(Guid productId, Guid mediaFileId)
    {
        try
        {
            var product = ChildProducts.FirstOrDefault(x => x.Id == productId);

            product.Shopify.MediaFiles.Remove(product.Shopify.MediaFiles.FirstOrDefault(x => x.MediaFile.Id == mediaFileId));

            Console.WriteLine(JsonSerializer.Serialize("product.Shopify"));
            Console.WriteLine(JsonSerializer.Serialize(product.Shopify));


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

    private async Task OnShopifyOnlinePublishChanged()
    {
        try
        {
            if (!IsEditable) return;
            if (ChildProducts.All(c => c.Shopify.Published)) return;
            var confirm = await messageService.Confirm("Are you sure you want to push to Shopify?", "Shopify", options: options =>
            {
                options.CancelButtonClass = "btn-lg";
                options.CancelButtonText = "No";
                options.ConfirmButtonColor = "default";
                options.ConfirmButtonClass = "btn-lg hexcolor-7B8E61 text-white";
            });
            if (!confirm) return;

            foreach (var product in ChildProducts.Where(c => !c.IsSaving && c is { IsIncluded: true, Shopify.Published: false }))
            {
                if (product.Shopify.Published) continue;

                if (product.IsSaving) continue;


                product.IsSaving = true;
                StateHasChanged();
                var res = await shopifyApi.CreateProductAsync(new ShopifyProductModel()
                {
                    Handle = product.Sku,
                    ProductType = product.TypeLabel,
                    Vendor = product.InfluencerNames,
                    Title = product.Name,
                    Status = "active",
                    Variants = new List<ProductVariant>()
                    {
                        new()
                        {
                            SKU=product.Sku,
                            Title=product.Name,
                        }
                    }
                }, product.Id);
                if (res.IsSuccessStatusCode)
                {
                    product.Shopify.Published = true;
                    product.Shopify.ShopifyId = res.Content.Id;
                    product.Shopify.PublishedAt = res.Content.PublishedAt?.DateTime;
                }
                product.IsSaving = false;
                StateHasChanged();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }

    private void ShowDropDown(ProductModel product)
    {
        if (!IsEditable) return;
        if (!product.CollectionAvailability) return;
        product.IsIncluded = !product.IsIncluded;
        product.IsDropdownShow = !product.IsDropdownShow;
        StateHasChanged();
    }
}