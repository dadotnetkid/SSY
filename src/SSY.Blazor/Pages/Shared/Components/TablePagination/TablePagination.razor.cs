namespace SSY.Blazor.Pages.Shared.Components.TablePagination
{

    public partial class TablePagination
    {

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }

        [Parameter]
        public string Module { get; set; }

        [Parameter]
        public int TotalCount { get; set; }

        [Parameter]
        public int Count { get; set; }

        [Parameter]
        public MaterialListModel MaterialTable { get; set; }

        [Parameter]
        public SubMaterialListModel SubMaterialTable { get; set; }

        [Parameter]
        public List<CompanyModel> Suppliers { get; set; }

        public MaterialService _materialService { get; set; }
        private int CurrentPage { get; set; } = 1;
        private int PaginationLimit { get; set; } = 5;
        private int PaginationStart { get; set; } = 1;

        public int TotalItems = 0;
        public int CurrentItems = 1;

        private int SkipCount { get; set; } = 10;

        private int ListPerPage { get; set; } = 10;

        private int TotalPage { get; set; } = 0;
        private int CurrentCount { get; set; } = 0;
        private int MaxPage { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (TotalCount != 0 && TotalPage == 0)
            {
                await SetUpMaxPage();
                await SetUpPageDetails();
            }
            if (TotalCount != CurrentCount)
            {
                await SetUpMaxPage();
                await SetUpPageDetails();
            }

            StateHasChanged();
        }

        public async Task SetUpMaxPage()
        {
            double a = Convert.ToDouble(TotalCount) / Convert.ToDouble(ListPerPage);
            MaxPage = Convert.ToInt32(Math.Ceiling(a));
            TotalPage = MaxPage;
            CurrentCount = TotalCount;
            if (PaginationLimit >= MaxPage)
            {
                PaginationLimit = MaxPage;
            }
        }

        public async Task SetUpPageDetails()
        {
            if (CurrentPage == 1)
            {
                CurrentItems = 1;
                TotalItems = ListPerPage;
            }
            else
            {
                TotalItems = CurrentPage * ListPerPage;
                CurrentItems = (TotalItems - ListPerPage) + 1;
            }

            if (TotalItems >= TotalCount)
            {
                TotalItems = TotalCount;
            }
        }


        public async Task onChangeListPerPage(string list)
        {
            ListPerPage = Convert.ToInt32(list);
            await SetUpMaxPage();
            await SetPage("1");
            await SetUpPageDetails();

        }

        public async Task SetPage(string page)
        {
            CurrentPage = Convert.ToInt32(page);
            SkipCount = ListPerPage;
            SkipCount = SkipCount * (CurrentPage - 1);

            if (PaginationStart <= MaxPage)
            {
                PaginationStart = CurrentPage - 4;
            }

            if (PaginationStart <= 1)
            {
                PaginationStart = 1;
            }
            if (PaginationLimit <= MaxPage)
            {
                PaginationLimit = CurrentPage + 4;
            }
            if (PaginationLimit >= MaxPage)
            {
                PaginationLimit = MaxPage;
            }
            await UpdateTable();
            await SetUpPageDetails();

        }

        public async Task UpdateTable()
        {
            if (Module == "All")
            {
                var result = await _materialService.GetAllMaterial(null, null, null, null, SkipCount, ListPerPage);
                MaterialTable.Materials = result.Result.Items;
                TotalCount = result.Result.TotalCount;
                Count = result.Result.Count;
            }

            if (Module == "Greige")
            {
                var result = await _materialService.GetAllMaterial(1, null, null, null, SkipCount, ListPerPage);
                MaterialTable.Materials = result.Result.Items;
                TotalCount = result.Result.TotalCount;
                Count = result.Result.Count;

            }
            if (Module == "Fabric")
            {
                var result = await _materialService.GetAllMaterial(2, null, null, null, SkipCount, ListPerPage);
                MaterialTable.Materials = result.Result.Items;
                TotalCount = result.Result.TotalCount;
                Count = result.Result.Count;

            }
            if (Module == "Trims and Accessories")
            {
                SubMaterialTable.SubMaterials = await GetSubMaterial("SubMaterial", 3);
            }
            if (Module == "Packaging")
            {
                SubMaterialTable.SubMaterials = await GetSubMaterial("SubMaterial", 4);
            }
            if (Module == "Others")
            {
                SubMaterialTable.SubMaterials = await GetSubMaterial("SubMaterial", 99);
            }
            if (Module == "Supplier")
            {
                await GetSupplier();
            }
        }

        public async Task<List<SubMaterialModel>> GetSubMaterial(string type, int categoryId)
        {
            List<SubMaterialModel> result = new();

            var url = $"{Configuration["App:ServerRootAddress"]}/{type}/GetAll?SkipCount={SkipCount}&CategoryId={categoryId}&MaxResultCount={ListPerPage}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = ClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAllSubMaterialOutputModel>(responseStream);


                result = data.Result.Items;
                TotalCount = data.Result.TotalCount;
            }

            return result;
        }

        public async Task GetSupplier()
        {
            var url = $"{Configuration["App:ServerRootAddress"]}/Company/GetAll?SkipCount={SkipCount}&MaxResultCount={ListPerPage}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var supplierData = await JsonSerializer.DeserializeAsync<GetAllCompanyOutputModel>(responseStream);
                Suppliers = supplierData.Result.Items;
                TotalCount = supplierData.Result.TotalCount;
                //Suppliers.ForEach(async x => x.ContactPersons = await GetContactPersons(x.Id));
                System.Console.WriteLine(JsonSerializer.Serialize(Suppliers));

            }
            else
            {
                // TODO: Error Handling use SWAL
                // await js.InvokeVoidAsync("defaultMessage", "error", "Update Error!", "Please Contact your");

            }
        }


        public async Task<List<ContactPersonModel>> GetContactPersons(int companyId)
        {
            var url = $"{Configuration["App:ServerRootAddress"]}/ContactPerson/GetAll?CompanyId=" + companyId;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var contactPersonData = await JsonSerializer.DeserializeAsync<GetAllContactPersonOutputModel>(responseStream);
                return contactPersonData.Result.Items;
            }
            else
            {
                return null;
                // TODO: Error Handling use SWAL
                // await js.InvokeVoidAsync("defaultMessage", "error", "Update Error!", "Please Contact your");

            }
        }


    }
}