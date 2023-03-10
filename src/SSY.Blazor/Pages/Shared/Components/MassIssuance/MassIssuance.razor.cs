using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SSY.Blazor.Pages.Shared.Components.MassIssuance
{

    public partial class MassIssuance
    {

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        private MaterialService _materialService { get; set; }

        private SubMaterialService _subMaterialService { get; set; }

        public MaterialIssuanceModel MaterialIssuanceModel { get; set; }
        public MaterialIssuanceListModel MaterialIssuanceListModel { get; set; }

        public SubMaterialIssuanceModel SubMaterialIssuanceModel { get; set; }
        public SubMaterialIssuanceListModel SubMaterialIssuanceListModel { get; set; }

        [Parameter]
        public string Module { get; set; }
        [Parameter]
        public IEnumerable<MaterialModel> MaterialTable { get; set; }
        [Parameter]
        public IEnumerable<SubMaterialModel> SubMaterialTable { get; set; }
        public string MassUploadSheetName = "";
        public bool isReady = false;
        public bool isInvalidFile = false;
        public bool isValidating = false;
        public bool isUploading = false;
        public List<string> UploadErrors { get; set; } = new();

        [Parameter]
        public EventCallback OnMassUpload { get; set; }

        protected override async Task OnInitializedAsync()
        {

            _materialService = new(js, ClientFactory, NavigationManager, Configuration);
            _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
            MaterialIssuanceModel = new();
            MaterialIssuanceListModel = new() { Issuance = new() };
            SubMaterialIssuanceModel = new();
            SubMaterialIssuanceListModel = new() { Issuance = new() };
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                StateHasChanged();
            }
        }

        public async Task ImportExcelFile(InputFileChangeEventArgs e)
        {
            try
            {
            UploadErrors.Clear();
            isValidating = true;
            isInvalidFile = false;
            MaterialIssuanceModel = new();
            isReady = false;
            var fileName = e.File.Name;
            var fileStream = e.File.OpenReadStream(maxAllowedSize: 100000000);
            var ms = new MemoryStream();
            await fileStream.CopyToAsync(ms);
            fileStream.Close();
            ms.Position = 0;

            ISheet sheet;
            var xsswb = new XSSFWorkbook(ms);
            var rl = new List<string>();
            var keys = new List<string>();

            MaterialIssuanceListModel.Issuance.Clear();
            SubMaterialIssuanceListModel.Issuance.Clear();
            for (int k = 0; k < xsswb.NumberOfSheets; k++)
            {
                // }
                rl.Clear();
                keys.Clear();
                sheet = xsswb.GetSheetAt(k);
                var sheetName = xsswb.GetSheetAt(k).SheetName;

                // System.Console.WriteLine(xsswb.GetSheetAt(k).SheetName);
                IRow hr = sheet.GetRow(0);
                System.Console.WriteLine(sheetName);
                // System.Console.WriteLine(xsswb.NumberOfSheets);
                MassUploadSheetName = sheetName;
                int cc = hr.LastCellNum;

                for (var j = 0; j < cc; j++)
                {
                    ICell cell = hr.GetCell(j);
                    keys.Add(ti.ToTitleCase(cell.ToString()).Replace("(filename)", "").Replace(" ", "").Replace("(OEM)", "").Replace("/", "").Replace("(Years)", "").Replace("-", "").Replace("#(TCXCode)", "Number").Replace("*", ""));

                }
                // Console.WriteLine(sheet.LastRowNum);
                for (var j = (sheet.FirstRowNum + 1); j <= sheet.LastRowNum; j++)
                {
                    var r = sheet.GetRow(j);
                    // System.Console.WriteLine(JsonSerializer.Serialize(r.Cells.ToList()));

                    // System.Console.WriteLine(r.FirstCellNum);
                    // return;

                    var index = j - 1;
                    // System.Console.WriteLine("row number/index  = " + (index));

                    if (sheetName.ToLower().Contains("fabric") || sheetName.ToLower().Contains("material") || sheetName.ToLower().Contains("greige") || sheetName.ToLower() == "fabric" || sheetName.ToLower() == "material" || sheetName.ToLower() == "greige")
                    {
                        MaterialIssuanceListModel.Issuance.Add(MaterialIssuanceModel);
                        MaterialIssuanceModel = new();
                    }

                    if (sheetName.ToLower().Contains("packaging") || sheetName.ToLower().Contains("trims") || sheetName.ToLower().Contains("trims and accessories") || sheetName.ToLower().Contains("other") || sheetName.ToLower().Contains("submaterial") || sheetName.ToLower() == "packaging" || sheetName.ToLower() == "trims and accessories" || sheetName.ToLower() == "other" || sheetName.ToLower() == "submaterial")
                    {
                        SubMaterialIssuanceListModel.Issuance.Add(SubMaterialIssuanceModel);
                        SubMaterialIssuanceModel = new();
                    }

                    if (r.FirstCellNum != 0) continue;
                    for (var i = r.FirstCellNum; i < cc; i++)
                    {
                        // rl.Add(currentValue);
                        var rowError = index + 2;
                        var currentValue = r.GetCell(i) == null? null : r.GetCell(i).ToString();

                        if (sheetName.ToLower().Contains("fabric") || sheetName.ToLower().Contains("material") || sheetName.ToLower().Contains("greige") || sheetName.ToLower() == "fabric" || sheetName.ToLower() == "material" || sheetName.ToLower() == "greige")
                        {
                            var data = MaterialIssuanceListModel.Issuance[index];
                            // System.Console.WriteLine("index: " + keys[i] + " value: " + currentValue + " " + index);

                            if (keys[i] == "ItemCode")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.ItemCode = currentValue;
                                }
                            }

                            if (keys[i] == "ColorCode")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.ColorCode = currentValue;
                                }
                            }

                            if (keys[i] == "RollNumber")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.RollNumber = currentValue;
                                }
                            }

                            if (keys[i] == "Usage")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.Usage = Convert.ToDouble(currentValue);
                                }
                            }

                            if (keys[i] == "Remarks") data.Remarks = currentValue;
                        }

                        if (sheetName.ToLower().Contains("packaging") || sheetName.ToLower().Contains("trims") || sheetName.ToLower().Contains("trims and accessories") || sheetName.ToLower().Contains("other") || sheetName.ToLower().Contains("submaterial") || sheetName.ToLower() == "packaging" || sheetName.ToLower() == "trims and accessories" || sheetName.ToLower() == "other" || sheetName.ToLower() == "submaterial")
                        {
                            var data = SubMaterialIssuanceListModel.Issuance[index];
                            System.Console.WriteLine("index: " + keys[i] + " value: " + currentValue + " " + index);
                            if (keys[i] == "MaterialName")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.MaterialName = currentValue;
                                }
                            }

                            if (keys[i] == "Usage")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.Usage = Convert.ToDouble(currentValue);
                                }
                            }

                            if (keys[i] == "Remarks") data.Remarks = currentValue;
                        }
                    }


                    // Console.WriteLine(JsonSerializer.Serialize(MaterialListModel.Materials));
                    // Console.WriteLine(JsonSerializer.Serialize(CreateSubMaterialListModel.CreateSubMaterialList));


                    rl.Clear();
                }
            }
            isReady = true;
            isValidating = false;
            Console.WriteLine("Ready for mass upload");
            }
            catch (Exception ex)
            {
                isInvalidFile = true;
                isValidating = false;
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }
        }
        public async Task HandleUploadSubmit()
        {

            if (MaterialIssuanceListModel.Issuance.Any())
            {
                await HandleMaterialUploadSubmit();
            }

            if (SubMaterialIssuanceListModel.Issuance.Any())
            {
                await HandleSubMaterialUploadSubmit();
            }

            // await OnMassUpload.InvokeAsync();
        }
        public async Task HandleMaterialUploadSubmit()
        {
            isUploading = true;
            isReady = false;
            var materials = MaterialIssuanceListModel.Issuance.Where(x => !string.IsNullOrWhiteSpace(x.ItemCode));
            System.Console.WriteLine(materials.Count());
            System.Console.WriteLine(JsonSerializer.Serialize(materials));
            await _materialService.MassIssuanceAsync(materials);
            isUploading = false;
        }

        public async Task HandleSubMaterialUploadSubmit()
        {
            isUploading = true;
            isReady = false;
            var materials = SubMaterialIssuanceListModel.Issuance.Where(x => !string.IsNullOrWhiteSpace(x.MaterialName));
            // System.Console.WriteLine(materials.Count()); 
            System.Console.WriteLine(JsonSerializer.Serialize(materials));

            await _subMaterialService.MassIssuanceAsync(materials);
            isUploading = false;
        }

        private async Task DownloadFileFromURL(string url, string name)
        {
            await js.InvokeVoidAsync("triggerFileDownload", name, url);
        }

    }
}