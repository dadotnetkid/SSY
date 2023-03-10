using System.Globalization;
using SSY.Blazor.HttpClients.Data.Administration.Roles;
using SSY.Blazor.HttpClients.Data.Administration.Roles.Model;

namespace SSY.Blazor.Pages.Settings.Components.User
{
    public partial class User
    {
        public User()
        {
        }

        public string Module = "SettingsUser";
        public string ModuleMessage = "";

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private RoleService _roleService { get; set; }
        private GetDropdownService _getDropdownService { get; set; }
        private UserDetailService _userDetailService { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        public UserDetailModel UserDetailModel { get; set; } = new();

        public GetAllUserDetailOutputModel GetAllUserDetailOutputModel { get; set; } = new() { Result = new() { Items = new() } };
        public GetAllCompanyOutputModel CompanyListModel { get; set; } = new() { Result = new() { Items = new() } };
        public RoleModel RoleModel { get; set; } = new();
        public List<RoleModel> RolesModel { get; set; } = new();

        public string TextType = "password";

        public string Icon = "fa fa-eye-slash";

        protected override async Task OnInitializedAsync()
        {
            _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);
            _getDropdownService = new(js, ClientFactory, NavigationManager, Configuration);
            _roleService = new(js, ClientFactory, NavigationManager, Configuration);
       
            CompanyListModel = await _getDropdownService.GetAllCompany(null, null, null, 100);
            GetAllUserDetailOutputModel = await _userDetailService.GetAllUser(null, null, null, null, 100);
            var role = await _roleService.GetAllRole(null, null, null);
            RolesModel = role.Result.Items;

            await GetAllUserDetails();
            await GetRoleNames();
        }
        public async Task GetRoleNames()
        {
            foreach (var item in GetAllUserDetailOutputModel.Result.Items.OrderByDescending(x => x.CreationTime))
            {
                if(item.RoleNames != null)
                {
                    var roleNames = JsonSerializer.Deserialize<List<string>>(item.RoleNames);
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    item.RoleNamesValue = textInfo.ToTitleCase(string.Join(", ", roleNames));
                }
            }
        }
        public async Task EditUserDetails(Guid id)
        {
            var result = await _userDetailService.GetUserDetail(id);
            UserDetailModel.Id = result.Result.Id;
            UserDetailModel.UserId = result.Result.UserId;
            UserDetailModel.Name = result.Result.Name;
            UserDetailModel.Surname = result.Result.Surname;
            UserDetailModel.EmailAddress = result.Result.EmailAddress;
            UserDetailModel.PhoneNumber = result.Result.PhoneNumber;
            UserDetailModel.Position = result.Result.Position;
            UserDetailModel.CompanyId = result.Result.CompanyId;
            UserDetailModel.Password = result.Result.Password;
            UserDetailModel.RoleNames = result.Result.RoleNames;
            UserDetailModel.Remarks = result.Result.Remarks;

            ModuleMessage = "Edit";
        }
        public async Task OnSubmit()
        {
            if (ModuleMessage != "Edit")
            {
                await _userDetailService.CreateUserDetail(UserDetailModel);
            }
            else
            {
                await _userDetailService.UpdateUserDetails(UserDetailModel);
            }
            await ClearAll();
        }
        public async Task AddButtonClear()
        {
            ModuleMessage = "Add";
            UserDetailModel.Name = string.Empty;
            UserDetailModel.Surname = string.Empty;
            UserDetailModel.EmailAddress = string.Empty;
            UserDetailModel.UserName = string.Empty;
            UserDetailModel.PhoneNumber = string.Empty;
            UserDetailModel.Password = string.Empty;
            UserDetailModel.Remarks = string.Empty;
            UserDetailModel.Position = string.Empty;
        }

        public async Task ClearAll()
        {
            UserDetailModel.Name = string.Empty;
            UserDetailModel.Surname = string.Empty;
            UserDetailModel.EmailAddress = string.Empty;
            UserDetailModel.PhoneNumber = string.Empty;
            UserDetailModel.Password = string.Empty;
            UserDetailModel.Remarks = string.Empty;
            UserDetailModel.Position = string.Empty;
            
            await GetAllUserDetails();
        }

        public async Task GetAllUserDetails()
        {
            GetAllUserDetailOutputModel = await _userDetailService.GetAllUser(null, null, null, null, 100);
            var role = await _roleService.GetAllRole(null, null, null);
            RolesModel = role.Result.Items;

            await GetRoleNames();

            GetAllUserDetailOutputModel.Result.Items.ForEach(x => {
                if(x.CompanyId != null)
                {
                    x.CompanyLabel = CompanyListModel.Result.Items.Find(y => y.Id == x.CompanyId).Name; 
                }
            });
        }

        public async Task DeleteUserDetail(Guid id)
        {
            await _userDetailService.DeleteUserDetail(id);

            GetAllUserDetailOutputModel = await _userDetailService.GetAllUser(null, null, null, null, 100);
            var role = await _roleService.GetAllRole(null, null, null);
            RolesModel = role.Result.Items;
            await GetRoleNames();
        }

        public async Task onChangeRole(string roleName)
        {
            List<string> roleNames = new List<string>();
            roleNames.Add(roleName);
            UserDetailModel.RoleNames = JsonSerializer.Serialize(roleNames.Select(x => x.ToString()).ToArray());
            Console.WriteLine(JsonSerializer.Serialize(UserDetailModel));
        }

        public void ShowPassword()
        {
            if (this.TextType == "password")
            {
                this.TextType = "text";
                this.Icon = "fa fa-eye";
            }
            else
            {
                this.TextType = "password";
                this.Icon = "fa fa-eye-slash";
            }
        }
    }
}