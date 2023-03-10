using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto;

namespace SSY.Blazor.Pages.Products.Components.BOMSummaryReservation;

public partial class BOMSummaryReservation
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
    public bool IsEditable { get; set; }

    [Parameter]
    public ProductModel ProductModel { get; set; }

    [Parameter]
    public List<ProductModel> ChildProducts { get; set; } = new();

    [Parameter]
    public List<ProductBomSummaryDto> BomSummaries { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        
    }

    protected override async Task OnParametersSetAsync()
    {
        
    }

    public async Task OnEditConsumption(Guid Id, string value)
    {
        try
        {
            var selected = BomSummaries.Find(x => x.Id == Id);

            if (selected != null)
                selected.Consumption = double.Parse(value);
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

    public async Task OnClickEditConsumption(ProductBomSummaryDto bom)
    {
        try
        {
            var selected = BomSummaries.Find(x => x.Id == bom.Id);

            if (selected != null)
                selected.IsEdit = true;
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

}