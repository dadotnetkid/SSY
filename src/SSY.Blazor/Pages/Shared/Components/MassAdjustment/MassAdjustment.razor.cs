using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SSY.Blazor.Pages.Shared.Components.MassAdjustment;

public partial class MassAdjustment
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

    public MaterialAdjustmentModel MaterialAdjustmentModel { get; set; } = new();
    public MaterialAdjustmentListModel MaterialAdjustmentListModel { get; set; } = new();

    public SubMaterialAdjustmentModel SubMaterialAdjustmentModel { get; set; } = new();
    public SubMaterialAdjustmentListModel SubMaterialAdjustmentListModel { get; set; } = new();

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

    public MaterialListModel ExcelMaterialData { get; set; } = new();

    public SubMaterialListModel ExcelSubMaterialData { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {

        _materialService = new(js, ClientFactory, NavigationManager, Configuration);
        _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
        ExcelMaterialData = new() { Materials = new() };
        ExcelSubMaterialData = new() { SubMaterials = new() };
        MaterialAdjustmentModel = new();
        MaterialAdjustmentListModel = new() { Adjustment = new() };
        SubMaterialAdjustmentModel = new();
        SubMaterialAdjustmentListModel = new() { Adjustment = new() };
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
            MaterialAdjustmentModel = new();
            SubMaterialAdjustmentModel = new();
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
            MaterialAdjustmentListModel.Adjustment.Clear();
            SubMaterialAdjustmentListModel.Adjustment.Clear();
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
                    //System.Console.WriteLine(JsonSerializer.Serialize(r.Cells.ToList()));

                    // System.Console.WriteLine(r.FirstCellNum);
                    // return;

                    var index = j - 1;
                    //System.Console.WriteLine("row number/index  = " + (index));

                    if (sheetName.ToLower().Contains("fabric") || sheetName.ToLower().Contains("material") || sheetName.ToLower().Contains("greige") || sheetName.ToLower() == "fabric" || sheetName.ToLower() == "material" || sheetName.ToLower() == "greige")
                    {
                        MaterialAdjustmentListModel.Adjustment.Add(MaterialAdjustmentModel);
                        MaterialAdjustmentModel = new() {};
                    }

                    if (sheetName.ToLower().Contains("packaging") || sheetName.ToLower().Contains("trims") || sheetName.ToLower().Contains("trims and accessories") || sheetName.ToLower().Contains("other") || sheetName.ToLower().Contains("submaterial") || sheetName.ToLower() == "packaging" || sheetName.ToLower() == "trims and accessories" || sheetName.ToLower() == "other" || sheetName.ToLower() == "submaterial")
                    {
                        SubMaterialAdjustmentListModel.Adjustment.Add(SubMaterialAdjustmentModel);
                        SubMaterialAdjustmentModel = new();
                    }

                    if (r.FirstCellNum != 0 || r.FirstCellNum == -1 || string.IsNullOrEmpty(r.FirstCellNum.ToString())) continue;
                    for (var i = r.FirstCellNum; i < cc; i++)
                    {
                        // rl.Add(currentValue);
                        var rowError = index + 2;
                        var currentValue = r.GetCell(i) == null || r.GetCell(i).ToString() == ""? null : r.GetCell(i).ToString();

                        if (sheetName.ToLower().Contains("fabric") || sheetName.ToLower().Contains("material") || sheetName.ToLower().Contains("greige") || sheetName.ToLower() == "fabric" || sheetName.ToLower() == "material" || sheetName.ToLower() == "greige")
                        {
                            var data = MaterialAdjustmentListModel.Adjustment[index];

                            System.Console.WriteLine("index: " + keys[i] + " value: " + currentValue + " " + index);

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

                            if (keys[i] == "TotalCount")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.TotalCount = Convert.ToDouble(currentValue);
                                }
                            }

                            if (keys[i] == "BuildingWarehouse") data.BuildingWarehouse = currentValue;

                            if (keys[i] == "TRackNumber") data.TRackNumber = currentValue;
                            
                            if (keys[i] == "Rack") data.Rack = currentValue;

                            if (keys[i] == "PONumber") data.PONumber = currentValue;

                            if (keys[i] == "ShippedQuantity")
                            {
                                double number;
                                bool isSuccess = Double.TryParse(currentValue, out number);
                                data.ShippedCount = isSuccess ? number : 0;
                                data.ShippedCount = Convert.ToDouble(currentValue);
                            }

                            if (keys[i] == "ReceivedQuantity")
                            {
                                double number;
                                bool isSuccess = Double.TryParse(currentValue, out number);
                                data.ReceivedCount = isSuccess ? number : 0;
                                data.ReceivedCount = Convert.ToDouble(currentValue);
                            }


                            if (keys[i] == "Remarks") data.Remarks = currentValue;
                        }

                        if (sheetName.ToLower().Contains("packaging") || sheetName.ToLower().Contains("trims") || sheetName.ToLower().Contains("trims and accessories") || sheetName.ToLower().Contains("other") || sheetName.ToLower().Contains("submaterial") || sheetName.ToLower() == "packaging" || sheetName.ToLower() == "trims and accessories" || sheetName.ToLower() == "other" || sheetName.ToLower() == "submaterial")
                        {
                            var data = SubMaterialAdjustmentListModel.Adjustment[index];
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

                            if (keys[i] == "TotalCount")
                            {
                                if (string.IsNullOrEmpty(currentValue))
                                {
                                    UploadErrors.Add("Row Number " + rowError + ", " + keys[i] + " is invalid.");
                                }
                                else
                                {
                                    data.TotalCount = Convert.ToDouble(currentValue);
                                }
                            }

                            if (keys[i] == "BuildingWarehouse") data.BuildingWarehouse = currentValue;


                            if (keys[i] == "TRackNumber") data.TRackNumber = currentValue;


                            if (keys[i] == "Rack") data.Rack = currentValue;


                            if (keys[i] == "PONumber") data.PONumber = currentValue;


                            if (keys[i] == "ShippedCount")
                            {
                                double number;
                                bool isSuccess = Double.TryParse(currentValue, out number);
                                data.ShippedCount = isSuccess ? number : 0;
                            }

                            if (keys[i] == "ReceivedCount")
                            {
                                double number;
                                bool isSuccess = Double.TryParse(currentValue, out number);
                                data.ReceivedCount = isSuccess ? number : 0;
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

        if (MaterialAdjustmentListModel.Adjustment.Any())
        {
            await HandleMaterialUploadSubmit();
        }

        if (SubMaterialAdjustmentListModel.Adjustment.Any())
        {
            await HandleSubMaterialUploadSubmit();
        }

        // await OnMassUpload.InvokeAsync();
    }
    public async Task HandleMaterialUploadSubmit()
    {
        isUploading = true;
        isReady = false;
        var materials = MaterialAdjustmentListModel.Adjustment.Where(x => !string.IsNullOrWhiteSpace(x.ItemCode));
        Console.WriteLine(materials.Count());
        Console.WriteLine(JsonSerializer.Serialize(materials));
        await _materialService.MassAdjustmentAsync(materials);
        isUploading = false;
    }

    public async Task HandleSubMaterialUploadSubmit()
    {
        isUploading = true;
        isReady = false;
        var materials = SubMaterialAdjustmentListModel.Adjustment.Where(x => !string.IsNullOrWhiteSpace(x.MaterialName));
        // System.Console.WriteLine(materials.Count()); 
        //System.Console.WriteLine(JsonSerializer.Serialize(materials));
        Console.WriteLine(JsonSerializer.Serialize(materials));
        await _subMaterialService.MassAdjustmentAsync(materials);
        isUploading = false;
    }

    private async Task DownloadFileFromURL(string url, string name)
    {
        await js.InvokeVoidAsync("triggerFileDownload", name, url);
    }

    public async Task checkMaterial()
    {
        if (Module == "All")
        {
            var result = await _materialService.GetAllMaterial(null, null, null, null, null, 1000000); // udpate id and total count
            ExcelMaterialData.Materials = result.Result.Items;
        }
        if (Module == "Greige")
        {
            var result = await _materialService.GetAllMaterial(1, null, null, null, null, 1000000); // udpate id and total count
            ExcelMaterialData.Materials = result.Result.Items;
        }
        if (Module == "Fabric")
        {
            var result = await _materialService.GetAllMaterial(2, null, null, null, null, 1000000);
            ExcelMaterialData.Materials = result.Result.Items;
        }

        if (Module == "Trims and Accessories")
        {
            var result = await _subMaterialService.GetAllSubMaterial(3, null, null, null, 1000000);
            ExcelSubMaterialData.SubMaterials = result.Result.Items;
        }

        if (Module == "Packaging")
        {
            var result = await _subMaterialService.GetAllSubMaterial(4, null, null, null, 1000000);
            ExcelSubMaterialData.SubMaterials = result.Result.Items;
        }

        if (Module == "Others")
        {
            var result = await _subMaterialService.GetAllSubMaterial(99, null, null, null, 1000000);
            ExcelSubMaterialData.SubMaterials = result.Result.Items;
        }
    }

    public async Task GenerateMassAdjustmentExcel()
    {
        await checkMaterial();
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

        #region Header Main titles
        ICell cell = row.CreateCell(0);
        row.GetCell(0).CellStyle = CellStyle;
        cell.SetCellValue("Item Code*");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(1);
        row.GetCell(1).CellStyle = CellStyle;
        cell.SetCellValue("Color Code*");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(2);
        row.GetCell(2).CellStyle = CellStyle;
        cell.SetCellValue("Roll Number*");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(3);
        row.GetCell(3).CellStyle = CellStyle;
        cell.SetCellValue("Total Count*");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(4);
        row.GetCell(4).CellStyle = CellStyle;
        cell.SetCellValue("Building/Warehouse");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(5);
        row.GetCell(5).CellStyle = CellStyle;
        cell.SetCellValue("T-Rack Number");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(6);
        row.GetCell(6).CellStyle = CellStyle;
        cell.SetCellValue("Rack");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(7);
        row.GetCell(7).CellStyle = CellStyle;
        cell.SetCellValue("PO Number");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(8);
        row.GetCell(8).CellStyle = CellStyle;
        cell.SetCellValue("Shipped Count");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(9);
        row.GetCell(9).CellStyle = CellStyle;
        cell.SetCellValue("Received Count");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(10);
        row.GetCell(10).CellStyle = CellStyle;
        cell.SetCellValue("Remarks*");
        cell.CellStyle.SetFont(font);

        #endregion


        rowNumber = 1; // start of material details


        foreach (var item in ExcelMaterialData.Materials)
        {
            if (item.RollsAndLocations[0].IsDisposal == false)
            {
                // System.Console.WriteLine(JsonSerializer.Serialize(item));
                // System.Console.WriteLine(item.RollsAndLocations.Count);
                row = worksheet.CreateRow(rowNumber++);

                if (item.RollsAndLocations.Count == 1 || item.RollsAndLocations.Count == 0)
                {

                    for (int i = 0; i <= 10; i++)
                    {
                        cell = row.CreateCell(i);
                        // row.GetCell(i).CellStyle = CellStyle;
                        if (item.ItemCode == null)
                        {
                            if (i == 0) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 0) cell.SetCellValue(item.ItemCode);
                        }
                        if (item.ColorCode == null)
                        {
                            if (i == 1) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 1) cell.SetCellValue(item.ColorCode);
                        }
                        if (item.RollsAndLocations[0].RollNumber == null)
                        {
                            if (i == 2) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 2) cell.SetCellValue(item.RollsAndLocations[0].RollNumber);
                        }

                        if (item.RollsAndLocations[0].TotalCount == null)
                        {
                            if (i == 3) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 3) cell.SetCellValue((double)item.RollsAndLocations[0].TotalCount);
                        }
                        if (item.RollsAndLocations[0].BuildingOrWarehouse == null)
                        {
                            if (i == 4) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 4) cell.SetCellValue(item.RollsAndLocations[0].BuildingOrWarehouse);
                        }
                        if (item.RollsAndLocations[0].TRackNumber == null)
                        {
                            if (i == 5) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 5) cell.SetCellValue(item.RollsAndLocations[0].TRackNumber);
                        }
                        if (item.RollsAndLocations[0].Rack == null)
                        {
                            if (i == 6) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 6) cell.SetCellValue(item.RollsAndLocations[0].Rack);
                        }
                        if (item.RollsAndLocations[0].PONumber == null)
                        {
                            if (i == 7) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 7) cell.SetCellValue(item.RollsAndLocations[0].PONumber);
                        }
                        if (item.RollsAndLocations[0].ShippedCount == null)
                        {
                            if (i == 8) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 8) cell.SetCellValue((double)item.RollsAndLocations[0].ShippedCount);
                        }
                        if (item.RollsAndLocations[0].ReceivedCount == null)
                        {
                            if (i == 9) cell.SetCellValue("");
                        }
                        else
                        {
                            if (i == 9) cell.SetCellValue((double)item.RollsAndLocations[0].ReceivedCount);
                        }

                    }

                }
                else
                {
                    rowNumber = rowNumber - 1;

                    for (int x = 0; x < item.RollsAndLocations.Count; x++)
                    {
                        row = worksheet.CreateRow(rowNumber++);
                        for (int i = 0; i <= 10; i++)
                        {
                            cell = row.CreateCell(i);
                            // row.GetCell(i).CellStyle = CellStyle;
                            if (item.ItemCode == null)
                            {
                                if (i == 0) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 0) cell.SetCellValue(item.ItemCode);
                            }
                            if (item.ColorCode == null)
                            {
                                if (i == 1) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 1) cell.SetCellValue(item.ColorCode);
                            }
                            if (item.RollsAndLocations[x].RollNumber == null)
                            {
                                if (i == 2) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 2) cell.SetCellValue(item.RollsAndLocations[x].RollNumber);
                            }

                            if (item.RollsAndLocations[x].TotalCount == null)
                            {
                                if (i == 3) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 3) cell.SetCellValue((double)item.RollsAndLocations[x].TotalCount);
                            }
                            if (item.RollsAndLocations[x].BuildingOrWarehouse == null)
                            {
                                if (i == 4) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 4) cell.SetCellValue(item.RollsAndLocations[x].BuildingOrWarehouse);
                            }
                            if (item.RollsAndLocations[x].TRackNumber == null)
                            {
                                if (i == 5) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 5) cell.SetCellValue(item.RollsAndLocations[x].TRackNumber);
                            }
                            if (item.RollsAndLocations[x].Rack == null)
                            {
                                if (i == 6) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 6) cell.SetCellValue(item.RollsAndLocations[x].Rack);
                            }
                            if (item.RollsAndLocations[x].PONumber == null)
                            {
                                if (i == 7) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 7) cell.SetCellValue(item.RollsAndLocations[x].PONumber);
                            }
                            if (item.RollsAndLocations[x].ShippedCount == null)
                            {
                                if (i == 8) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 8) cell.SetCellValue((double)item.RollsAndLocations[x].ShippedCount);
                            }
                            if (item.RollsAndLocations[x].ReceivedCount == null)
                            {
                                if (i == 9) cell.SetCellValue("");
                            }
                            else
                            {
                                if (i == 9) cell.SetCellValue((double)item.RollsAndLocations[x].ReceivedCount);
                            }


                        }
                    }
                }
            }
        }
        for (int i = 0; i <= 10; i++)
        {
            worksheet.AutoSizeColumn(i);
        }

        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        byte[] bytes = ms.ToArray();
        ms.Close();

        await _materialService.GenerateExcelExport(Module + " - Mass Adjustment Form", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }

    public async Task GenerateMassAdjustmentSubMaterialExcel()
    {
        await checkMaterial();
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

        #region Header Main titles
        ICell cell = row.CreateCell(0);
        row.GetCell(0).CellStyle = CellStyle;
        cell.SetCellValue("Material Name*");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(1);
        row.GetCell(1).CellStyle = CellStyle;
        cell.SetCellValue("Total Count*");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(2);
        row.GetCell(2).CellStyle = CellStyle;
        cell.SetCellValue("Building / Warehouse");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(3);
        row.GetCell(3).CellStyle = CellStyle;
        cell.SetCellValue("T-Rack Number");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(4);
        row.GetCell(4).CellStyle = CellStyle;
        cell.SetCellValue("Rack");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(5);
        row.GetCell(5).CellStyle = CellStyle;
        cell.SetCellValue("PO Number");
        cell.CellStyle.SetFont(font);


        cell = row.CreateCell(6);
        row.GetCell(6).CellStyle = CellStyle;
        cell.SetCellValue("Shipped Count");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(7);
        row.GetCell(7).CellStyle = CellStyle;
        cell.SetCellValue("Received Count");
        cell.CellStyle.SetFont(font);

        cell = row.CreateCell(8);
        row.GetCell(8).CellStyle = CellStyle;
        cell.SetCellValue("Remarks*");
        cell.CellStyle.SetFont(font);

        #endregion


        rowNumber = 1; // start of material details


        foreach (var item in ExcelSubMaterialData.SubMaterials)
        {
            // System.Console.WriteLine(JsonSerializer.Serialize(item));
            row = worksheet.CreateRow(rowNumber++);
            for (int i = 0; i <= 9; i++)
            {
                cell = row.CreateCell(i);
                // row.GetCell(i).CellStyle = CellStyle;

                if (i == 0) cell.SetCellValue(item.Name);
                if (i == 1) cell.SetCellValue(item.TotalCount);
                if (i == 2) cell.SetCellValue(item.Location.BuildingWarehouse);
                if (i == 3) cell.SetCellValue(item.Location.Room);
                if (i == 4) cell.SetCellValue(item.Location.Rack);
                if (i == 5) cell.SetCellValue(item.PONumber);
                if (item.ShippedCount == null)
                {
                    if (i == 6) cell.SetCellValue("");
                }
                else
                {
                    if (i == 6) cell.SetCellValue((double)item.ShippedCount);
                }

                if (item.ReceivedCount == null)
                {
                    if (i == 7) cell.SetCellValue("");
                }
                else
                {
                    if (i == 7) cell.SetCellValue((double)item.ReceivedCount);
                }
            }

        }

        for (int i = 0; i <= 9; i++)
        {
            worksheet.AutoSizeColumn(i);
        }

        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        byte[] bytes = ms.ToArray();
        ms.Close();

        await _subMaterialService.GenerateExcelExport(Module + " - Mass Adjustment Form", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
}