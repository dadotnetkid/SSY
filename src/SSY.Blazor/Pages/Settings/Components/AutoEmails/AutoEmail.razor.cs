namespace SSY.Blazor.Pages.Settings.Components.AutoEmails;

public partial class AutoEmail
{
    public string TabName = "Index";

    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }

    [Parameter]
    public int EmailCategoryId { get; set; }

    public AutoEmailService _autoEmailService { get; set; }

    private IEnumerable<AutoEmailDto> _autoEmail { get; set; }

    public AutoEmailDto AutoEmailModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {

    }

}

