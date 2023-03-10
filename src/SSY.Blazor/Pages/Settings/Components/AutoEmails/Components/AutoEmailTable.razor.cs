namespace SSY.Blazor.Pages.Settings.Components.AutoEmails.Components
{
    public partial class AutoEmailTable
    {
        public AutoEmailTable()
        {
        }

        public string Module = "InventoryEmails";
        public string ModuleMessage = "";
        public string ModuleType = "Edit";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }

        public AutoEmailService _autoEmailService { get; set; }

        [Parameter]
        public int EmailCategoryId { get; set; }

        [Parameter]
        public bool IsEditable { get; set; }

        public AutoEmailDto AutoEmailModel { get; set; } = new();

        public GetAllAutoEmailOutputDto AutoEmailListModel { get; set; } = new() { Result = new() { Items = new() } };

        public bool IsAddAutoEmail { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            _autoEmailService = new(js, ClientFactory, NavigationManager, Configuration);

            await Refresh(EmailCategoryId);
        }

        public async Task CloseAutoEmail()
        {
            AutoEmailModel.Id = default;
            AutoEmailModel.Subject = default;
            AutoEmailModel.To = default;
            AutoEmailModel.Cc = default;
            AutoEmailModel.EmailBody = default;
        }

        public async Task Refresh(int emailCategoryId)
        {
            AutoEmailListModel = await _autoEmailService.GetAllAutoEmails(emailCategoryId, null, null, null, 9999);
        }

        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                CreateAutoEmailDto input = new()
                {
                    Subject = AutoEmailModel.Subject,
                    From = "info@sewsewyou.ltd",
                    EmailCategoryId = EmailCategoryId,
                    To = AutoEmailModel.To,
                    Cc = AutoEmailModel.Cc,
                    EmailBody = AutoEmailModel.EmailBody
                };
                await _autoEmailService.CreateAutoEmail(input);
            }
            else
            {
                UpdateAutoEmailDto input = new()
                {
                    Id = AutoEmailModel.Id,
                    Subject = AutoEmailModel.Subject,
                    From = "info@sewsewyou.ltd",
                    EmailCategoryId = EmailCategoryId,
                    To = AutoEmailModel.To,
                    Cc = AutoEmailModel.Cc,
                    EmailBody = AutoEmailModel.EmailBody
                };
                await _autoEmailService.UpdateAutoEmail(input);
            }
        }

        public async Task EditAutoEmail(AutoEmailDto autoEmail)
        {
            IsAddAutoEmail = false;

            var result = await _autoEmailService.GetAutoEmail(autoEmail.Id);

            AutoEmailModel.Id = result.Result.Id;
            AutoEmailModel.Subject = result.Result.Subject;
            AutoEmailModel.From = "info@sewsewyou.ltd";
            AutoEmailModel.EmailCategoryId = EmailCategoryId;
            AutoEmailModel.To = result.Result.To;
            AutoEmailModel.Cc = result.Result.Cc;
            AutoEmailModel.EmailBody = result.Result.EmailBody;

            ModuleMessage = "Edit";
        }

        public async Task RemoveAutoEmail(Guid id)
        {
            await _autoEmailService.DeleteAutoEmail(id);
            await Refresh(EmailCategoryId);
        }

        public async Task AddAutoEmailHandler()
        {
            IsAddAutoEmail = true;
            await CloseAutoEmail();
        }
    }
}

