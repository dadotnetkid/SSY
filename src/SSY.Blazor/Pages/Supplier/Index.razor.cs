using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Volo.Abp;

namespace SSY.Blazor.Pages.Supplier
{
    public partial class Index
    {
        public Index()
        {
        }

        [Inject]
        public ProtectedSessionStorage SessionStorage { get; set; }

        [Inject]
        public IJSRuntime js { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        private CompanyService _companyService { get; set; }

        public string Module = "Suppliers";
        public string ModuleMessage = "";

        public int TotalCount = 0;
        public int Count = 0;

        public int Id { get; set; }

        public List<CompanyModel> Companies { get; set; }
        public List<int> CompanyIds { get; set; } = new();
        private DeleteDataByIdService _deleteDataByIdService { get; set; }


        public CompanyModel CompanyModel { get; set; } = new();

        private IEnumerable<CompanyModel> _companies;
        private string customFilterValue;
        public string ContactPersons { get; set; } = string.Empty;

        //for sorting
        private bool isSortedAscending;
        private string activeSortColumn;
        private bool IsLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                Companies = new();
                _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
                _companyService = new(js, ClientFactory, NavigationManager, Configuration);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await GetCompanys();
                }
                IsLoading = false;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nAn error occured. Please contact your administrator. Inner Exception: {ex.InnerException.Message}.";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
            
        }

        public async Task GetCompanys()
        {
            var response = await _companyService.GetAllCompany(null, null, null, 1000000);
            _companies = response.Result.Items;
            Companies = response.Result.Items;
            Companies.ForEach(x => {
                x.ContactPersons.ForEach(cp => {
                    x.ContactPersonNames = cp.Name;
                    x.ContactPersonContactNumber = cp.MobileNumber;
                });
            });
        }

        public async Task SearchCompany(string value)
        {
            var result = await _companyService.GetAllCompany(value, null, null, null);
            Companies = result.Result.Items;
            Count = result.Result.TotalCount; // change to count

        }

        public async Task onChangeCheckBox(int id, bool checkedValue)
        {


            if (checkedValue)
            {
                if (!CompanyIds.Contains(id))
                {
                    CompanyIds.Add(id);
                }
            }
            else
            {
                if (CompanyIds.Contains(id))
                {
                    CompanyIds.Remove(id);
                }

            }
            Console.WriteLine(JsonSerializer.Serialize(id));

        }
        public async Task onChangeCheckBoxAll(bool checkedValue)
        {
            if (checkedValue)
            {
                CompanyIds.Clear();
                foreach (var item in Companies)
                {
                    CompanyIds.Add(item.Id);
                }
            }
            else
            {
                CompanyIds.Clear();
            }
            Console.WriteLine(JsonSerializer.Serialize(CompanyIds));
        }
        public async Task UnCheckAll()
        {
            CompanyIds.Clear();
        }

        public async Task DeleteSelectedIds()
        {

            // MaterialIds.Clear();

            foreach (var id in CompanyIds)
            {
                await _companyService.DeleteCompanyAsync(id);
            }
            await GetCompanys();
            await js.InvokeVoidAsync("defaultMessage", "success", "Successfully Deleted!", "");
            CompanyIds.Clear();
        }

        public async Task GenerateExcel()
        {
            var result = await _companyService.GetAllCompany(null, null, null, 1000000);

            IWorkbook workbook = new XSSFWorkbook();
            var dataFormat = workbook.CreateDataFormat();
            var dataStyle = workbook.CreateCellStyle();
            dataStyle.DataFormat = dataFormat.GetFormat("MM/dd/yyyy HH:mm:ss");
            ISheet worksheet = workbook.CreateSheet(Module);

            // style center of sheet;
            ICellStyle CellStyle = workbook.CreateCellStyle();
            CellStyle.Alignment = HorizontalAlignment.Center;
            CellStyle.WrapText = true; //wrap the text in the cell
            // CellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            // CellStyle.FillPattern = FillPattern.SolidForeground;

            // font style bold setup
            var font = workbook.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            // sheet name


            int rowNumber = 0;
            IRow row = worksheet.CreateRow(rowNumber++);

            // cell merge for main headers
            var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 9);
            var cra1 = new NPOI.SS.Util.CellRangeAddress(0, 0, 10, 14);
            var cra2 = new NPOI.SS.Util.CellRangeAddress(0, 0, 15, 19);
            worksheet.AddMergedRegion(cra);
            worksheet.AddMergedRegion(cra1);
            worksheet.AddMergedRegion(cra2);

            #region Header Main titles
            ICell cell = row.CreateCell(0);
            row.GetCell(0).CellStyle = CellStyle;
            cell.SetCellValue("COMPANY INFORMATION");
            cell.CellStyle.SetFont(font);

            cell = row.CreateCell(10);
            row.GetCell(10).CellStyle = CellStyle;
            cell.SetCellValue("CONTACT PERSON(S)");
            cell.CellStyle.SetFont(font);


            cell = row.CreateCell(15);
            row.GetCell(15).CellStyle = CellStyle;
            cell.SetCellValue("FINANCIAL INFORMATION");
            cell.CellStyle.SetFont(font);

            #endregion

            #region Header Subtitles

            row = worksheet.CreateRow(1); // setup for row 1 for sub titles
            for (int i = 0; i <= 38; i++)
            {
                cell = row.CreateCell(i);
                if (i == 0) cell.SetCellValue("Company Code*");
                if (i == 1) cell.SetCellValue("Company Name*");
                if (i == 2) cell.SetCellValue("Short Code*");
                if (i == 3) cell.SetCellValue("Website");
                if (i == 4) cell.SetCellValue("Address 1*");
                if (i == 5) cell.SetCellValue("Address 2");
                if (i == 6) cell.SetCellValue("Country*");
                if (i == 7) cell.SetCellValue("Province*");
                if (i == 8) cell.SetCellValue("City*");
                if (i == 9) cell.SetCellValue("Zip Code*");
                if (i == 10) cell.SetCellValue("Name*");
                if (i == 11) cell.SetCellValue("Position");
                if (i == 12) cell.SetCellValue("Email Address*");
                if (i == 13) cell.SetCellValue("Telephone Number");
                if (i == 14) cell.SetCellValue("Mobile Number");
                if (i == 15) cell.SetCellValue("Bank Name");
                if (i == 16) cell.SetCellValue("Account Number");
                if (i == 17) cell.SetCellValue("Account Name");
                if (i == 18) cell.SetCellValue("Swift");
                if (i == 19) cell.SetCellValue("Address");
                cell.CellStyle.SetFont(font);
            }
            #endregion

            rowNumber = 2; // start of material details
            foreach (var item in result.Result.Items)
            {
                // System.Console.WriteLine(JsonSerializer.Serialize(item));
                row = worksheet.CreateRow(rowNumber++);
                if (item.ContactPersons.Count == 1 || item.ContactPersons.Count == 0)
                {
                    for (int i = 0; i <= 19; i++)
                    {
                        cell = row.CreateCell(i);
                        // row.GetCell(i).CellStyle = CellStyle;
                        if (i == 0) cell.SetCellValue(item.Code);
                        if (i == 1) cell.SetCellValue(item.Name);
                        if (i == 2) cell.SetCellValue(item.ShortCode);
                        if (i == 3) cell.SetCellValue(item.Website);
                        if (i == 4) cell.SetCellValue(item.Address1);
                        if (i == 5) cell.SetCellValue(item.Address2);
                        if (i == 6) cell.SetCellValue(item.Country);
                        if (i == 7) cell.SetCellValue(item.Province);
                        if (i == 8) cell.SetCellValue(item.City);
                        if (i == 9) cell.SetCellValue(item.ZipCode);

                        if (item.ContactPersons.Count == 1)
                        {
                            if (i == 10) cell.SetCellValue(item.ContactPersons[0].Name);
                            if (i == 11) cell.SetCellValue(item.ContactPersons[0].Position);
                            if (i == 12) cell.SetCellValue(item.ContactPersons[0].Email);
                            if (i == 13) cell.SetCellValue(item.ContactPersons[0].Telephone);
                            if (i == 14) cell.SetCellValue(item.ContactPersons[0].MobileNumber);
                        }

                        if (i == 15) cell.SetCellValue(item.BankName);
                        if (i == 16) cell.SetCellValue(item.AccountNumber);
                        if (i == 17) cell.SetCellValue(item.AccountName);
                        if (i == 18) cell.SetCellValue(item.Swift);
                        if (i == 19) cell.SetCellValue(item.Address);
                    }
                }
                else
                {
                    rowNumber = rowNumber - 1;
                    for (int x = 0; x < item.ContactPersons.Count; x++)
                    {
                        row = worksheet.CreateRow(rowNumber++);
                        for (int i = 0; i <= 19; i++)
                        {
                            cell = row.CreateCell(i);
                            // row.GetCell(i).CellStyle = CellStyle;
                            if (i == 0) cell.SetCellValue(item.Code);
                            if (i == 1) cell.SetCellValue(item.Name);
                            if (i == 2) cell.SetCellValue(item.ShortCode);
                            if (i == 3) cell.SetCellValue(item.Website);
                            if (i == 4) cell.SetCellValue(item.Address1);
                            if (i == 5) cell.SetCellValue(item.Address2);
                            if (i == 6) cell.SetCellValue(item.Country);
                            if (i == 7) cell.SetCellValue(item.Province);
                            if (i == 8) cell.SetCellValue(item.City);
                            if (i == 9) cell.SetCellValue(item.ZipCode);
                            if (i == 10) cell.SetCellValue(item.ContactPersons[x].Name);
                            if (i == 11) cell.SetCellValue(item.ContactPersons[x].Position);
                            if (i == 12) cell.SetCellValue(item.ContactPersons[x].Email);
                            if (i == 13) cell.SetCellValue(item.ContactPersons[x].Telephone);
                            if (i == 14) cell.SetCellValue(item.ContactPersons[x].MobileNumber);
                            if (i == 15) cell.SetCellValue(item.BankName);
                            if (i == 16) cell.SetCellValue(item.AccountNumber);
                            if (i == 17) cell.SetCellValue(item.AccountName);
                            if (i == 18) cell.SetCellValue(item.Swift);
                            if (i == 19) cell.SetCellValue(item.Address);
                        }
                    }
                }
            }

            for (int i = 0; i <= 19; i++)
            {
                worksheet.AutoSizeColumn(i);
            }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            byte[] bytes = ms.ToArray();
            ms.Close();

            await _companyService.GenerateExcelExport("Company list", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private bool OnCustomFilter(CompanyModel model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;
            return model.Name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task OnClickRow(int id)
        {
            var url = $"/inventory/supplier/{id}";
            NavigationManager.NavigateTo(url);
        }


        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                Companies = Companies.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;

            }
            else
            {
                if (isSortedAscending)
                {
                    Companies = Companies.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    Companies = Companies.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }

                isSortedAscending = !isSortedAscending;
            }
        }

        private string SetSortIcon(string columnName)
        {
            if (activeSortColumn != columnName)
            {
                return "fa fa-sort";
            }
            if (isSortedAscending)
            {
                return "fa fa-sort-up";
            }
            else
            {
                return "fa fa-sort-down";
            }
        }

    }
}


