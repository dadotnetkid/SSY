using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model;

namespace SSY.Blazor.Pages.Products.Components.ChildProduct;

public partial class ChildProduct
{

    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public Guid ThreeDVirtualId { get; set; }

    [Parameter]
    public string Module { get; set; } = "ChildProduct";

    [Parameter]
    public bool IsEditable { get; set; }

    [Parameter]
    public List<ProductModel> ChildProducts { get; set; }

    public ColorOptionService _colorOptionService { get; set; }

    public GetAllColorOptionOutputModel ColorOptionOutputModel { get; set; }

    [Parameter]
    public List<CollectionColorOptionsOutputModel> ColorOptions { get; set; }

    [Parameter]
    public ProductTypeModel ProductTypeModel{ get; set; }

    [Parameter]
    public List<PanelModel> Panels { get; set; }

    [Parameter]
    public Guid ProductParentId { get; set; }

    [Parameter]
    public UnitOfMeasurementListModel unitOfMeasurementListModel { get; set; } = new() { Result = new() { Items = new() } };

    [Parameter]
    public MaterialListModel MaterialListModel { get; set; } = new() { Materials = new() };

    [Parameter]
    public List<Guid> ProductOptionRollIds { get; set; } = new ();

    [Parameter]
    public List<Guid> ReservedRollIds { get; set; } = new ();

    [Parameter]
    public EventCallback<Guid> UpdateProductOptionRollIds { get; set; }

    [Parameter]
    public EventCallback<RejectionNoteModel> AddRejection { get; set; } = new();


    [Parameter]
    public double ForecastQuantity { get; set; } = new ();

    [Parameter]
    public EventCallback OnSaveProductOption { get; set; }

    [Parameter]
    public EventCallback<ProductModel> AddProductOptionNotes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _colorOptionService = new(js, ClientFactory, NavigationManager, Configuration);
        ChildProducts = ChildProducts ?? new();
        ColorOptions = ColorOptions = new();

    }

    protected override async Task OnParametersSetAsync()
    {
        // Console.WriteLine(JsonSerializer.Serialize("ChildProducts"));
        // Console.WriteLine(JsonSerializer.Serialize(ReservedRollIds));
        // Console.WriteLine(JsonSerializer.Serialize("ProductTypeId"));

        // foreach (var item in ColorOptions)
        // {
        //     //    item.ColorOptionTitle = ColorOptions?.FirstOrDefault(x => x.ColorOptionId == item.ColorOptionId)?.ColorOption?.Title;
        //     foreach (var producttype in item.ColorOption.ProductTypes)
        //     {
        //         if (producttype.ProductTypeId == ProductTypeId)
        //         {
        //             Console.WriteLine(JsonSerializer.Serialize(item));
        //             Console.WriteLine(JsonSerializer.Serialize("ColorOptions"));
        //         }

        //     }
        // }

    }
}