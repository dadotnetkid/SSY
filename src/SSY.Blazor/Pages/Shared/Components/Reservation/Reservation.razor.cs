namespace SSY.Blazor.Pages.Shared.Components.Reservation;
public partial class Reservation
{
    public Reservation()
    {
    }

    public string Module = "Inventory";
    public string ModuleMessage = "";
    [Inject]
    public IJSRuntime js { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }
    private ReservationService _reservationService { get; set; }
    private MaterialService _materialService { get; set; }
    private InfluencerService _influencerService { get; set; }
    private CollectionService _collectiionService { get; set; }
    private RollAndLocationService _rollAndLocationService { get; set; }
    public UserDetailService _userDetailService { get; set; }
    private DeleteDataByIdService _deleteDataByIdService { get; set; }

    private SubMaterialService _subMaterialService { get; set; }

    [Parameter]
    public Guid MaterialId { get; set; }

    [Parameter]
    public bool IsEditable { get; set; }

    public double TotalCount { get; set; } = new();

    public double ReservedCount { get; set; } = new();

    public double AvailableCount { get; set; } = new();

    [Parameter]
    public Guid SubMaterialId { get; set; }

    [Parameter]
    public MaterialModel MaterialModel { get; set; } = new();

    [Parameter]
    public SubMaterialModel SubMaterialModel { get; set; } = new();

    [Parameter]
    public string UoM { get; set; }

    [Parameter]
    public EventCallback<Guid> OnRollReservationSubmit { get; set; }

    [Parameter]
    public EventCallback<Guid> OnSubReservationSubmit { get; set; }

    [Parameter]
    public EventCallback<RollReservationModel> OnDeleteRollReservation { get; set; }

    [Parameter]
    public EventCallback<SubMaterialReservationModel> OnDeleteSubMaterialReservation { get; set; }

    public List<ReservationModel> ReservationListModel { get; set; } = new();
    public List<InfluencerModel> InfluencerListModel { get; set; } = new();
    public List<CollectionListDto> CollectionsListModel { get; set; } = new();
    public GetAllCollectionListDto CollectionList { get; set; } = new();
    public GetAllRollAndLocationOutputModel GetAllRollAndLocationOutputModel { get; set; } = new() { Result = new() { Items = new() } };
    public CreateReservationModel CreateReservationModel { get; set; } = new();
    public CreateRollReservationModel CreateRollReservationModel { get; set; }
    public CreateSubMaterialReservationModel CreateSubMaterialReservationModel { get; set; }
    public GetAllUserDetailCCOutputModel GetAllUserDetailModel { get; set; } = new() { Result = new() { Items = new() } };
    public List<Guid> InfluencersIds { get; set; } = new();
    public List<string> InfluencersNames { get; set; } = new();
    public string InfluencerNamesValue = "Select Influencers";
    public string[] InfluencerIds { get; set; } = new string[] { };
    private IEnumerable<RollReservationModel> _rollReservation { get; set; }
    private IEnumerable<SubMaterialReservationModel> _subMaterialReservation { get; set; }
    private List<RollReservationModel> reservationList { get; set; } = new();
    private List<SubMaterialReservationModel> SubMaterialreservationList { get; set; } = new();
    private Modal modalRef;

    private Task ShowModal()
    {
        return modalRef.Show();
    }

    protected override async Task OnInitializedAsync()
    {
        _reservationService = new(js, ClientFactory, NavigationManager, Configuration);
        _materialService = new(js, ClientFactory, NavigationManager, Configuration);
        _subMaterialService = new(js, ClientFactory, NavigationManager, Configuration);
        _influencerService = new(js, ClientFactory, NavigationManager, Configuration);
        _collectiionService = new(js, ClientFactory, NavigationManager, Configuration);
        _rollAndLocationService = new(js, ClientFactory, NavigationManager, Configuration);
        _userDetailService = new(js, ClientFactory, NavigationManager, Configuration);
        _deleteDataByIdService = new(js, ClientFactory, NavigationManager, Configuration);
        CreateRollReservationModel = new() { RollReservations = new() };
        CreateSubMaterialReservationModel = new ();

        try
        {

            // reservation for material
            if (MaterialId != Guid.Empty)
            {
                await GetRollAndLocation(MaterialId);
                CreateRollReservationModel.MaterialId = MaterialId;

                GetAllRollAndLocationOutputModel.Result.Items.ForEach(x => {
                    x.RollReservations.ForEach(r => {
                        r.RollNumber = x.RollNumber;
                        reservationList.Add(r);
                    });
                });

                _rollReservation = reservationList;
                TotalCount = MaterialModel.TotalCount;
                ReservedCount = (double)MaterialModel.ReservedCount;
                AvailableCount = (double)MaterialModel.AvailableCount;
            }
            else
            {
                CreateSubMaterialReservationModel.SubMaterialId = SubMaterialId;
                CreateSubMaterialReservationModel.ReservedCount = (double)SubMaterialModel.ReservedCount;

                foreach (var reservation in SubMaterialModel.SubMaterialReservations)
                {
                    var names = "";
                    foreach (var item in reservation.CollectionInfluencers)
                    {
                        names += item.InfluencerFullName + ", ";
                    }
                    names = names.Remove(names.Length - 2, 1);
                    reservation.InfluencersNames = names;
                    SubMaterialreservationList.Add(reservation);
                }
                _subMaterialReservation = SubMaterialreservationList;

                TotalCount = SubMaterialModel.TotalCount;
                ReservedCount = (double)SubMaterialModel.ReservedCount;
                AvailableCount = (double)SubMaterialModel.AvailableCount;
                Console.WriteLine(JsonSerializer.Serialize(_subMaterialReservation));
                Console.WriteLine("kelvin");
            }

            StateHasChanged();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // if (firstRender)
        // {
        //     StateHasChanged();
        // }
        await js.InvokeVoidAsync("loadMultiSelectSearch");

        CollectionList = await _collectiionService.GetAllCollectionList();
        GetAllUserDetailModel = await _userDetailService.GetAllUserCC(null, null, null, null, null, 999);
    }

    public async Task GetRollAndLocation(Guid id)
    {
        GetAllRollAndLocationOutputModel = await _rollAndLocationService.GetAllRollAndLocation(id, null, null, null, null, null);
    }
    // public async Task RefreshReservedCount()
    // {
    //     var material = await _materialService.GetMaterial(MaterialId);
    //     ReservedCount = material.Result.ReservedCount;
    // }

    public async Task onChangeInfluencer(Guid influencerId, string influencersName, bool isChecked)
    {
        CollectionsListModel = new();
        InfluencerNamesValue = string.Empty;
        if (isChecked)
        {
            if (!InfluencersIds.Contains(influencerId))
            {
                InfluencersIds.Add(influencerId);
            }

            if (!InfluencersNames.Contains(influencersName))
            {
                InfluencersNames.Add(influencersName);
            }
        }
        else
        {
            if (InfluencersIds.Contains(influencerId))
            {
                InfluencersIds.Remove(influencerId);
            }

            if (InfluencersNames.Contains(influencersName))
            {
                InfluencersNames.Remove(influencersName);
            }
        }

        if (InfluencersNames.Count == 0)
        {
            InfluencerNamesValue = "Select Influencers";
            CollectionsListModel = new();
            CreateReservationModel.InfluencerIds = JsonSerializer.Serialize(InfluencersIds);
            CreateReservationModel.InfluencersName = string.Empty;
        }
        else
        {
            InfluencerNamesValue = ReplaceString(JsonSerializer.Serialize(InfluencersNames));
            CreateReservationModel.InfluencerIds = JsonSerializer.Serialize(InfluencersIds);

            

            foreach (var collection in CollectionList.Items)
            {
                var isExisting = true;
                var collectionInfluencerids = collection.InfluencerNames.Contains(InfluencerNamesValue);
                if (collectionInfluencerids)
                {
                    CollectionsListModel.Add(collection);
                }
                else
                {
                    CollectionsListModel.Remove(collection);
                }
            }
        }
        Console.WriteLine(JsonSerializer.Serialize("InfluencerNamesValue"));
        Console.WriteLine(JsonSerializer.Serialize(InfluencerNamesValue));
    }

    public async Task GetReservations(Guid id)
    {
        var reservation = await _reservationService.GetAllReservation(null, id, null, null);
        ReservationListModel = reservation.Result.Items;
    }

    public async Task OnSubmit()
    {
        try
        {
            if (MaterialId != Guid.Empty)
            {
                await _reservationService.CreateMaterialReservation(CreateRollReservationModel);
                await OnRollReservationSubmit.InvokeAsync(MaterialId);
                // await RefreshReservedCount();
            }
            else
            {
                await _reservationService.CreateSubMaterialReservation(CreateSubMaterialReservationModel);
                await OnSubReservationSubmit.InvokeAsync(SubMaterialId);
                //Console.WriteLine(JsonSerializer.Serialize(CreateSubMaterialReservationModel));
                // await RefreshReservedCount();
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";
        }
    }

   
    public async Task CheckRoll(bool isChecked, RollAndLocationModel roll)
    {
        
        if (isChecked == true)
        {
            CreateRollReservationModel.RollReservations.Add(
                new RollReservation
                {
                    RollId = roll.Id,
                    ReservedCount = (double)roll.AvailableCount,
                    CurrentCount = (double)roll.AvailableCount,
                    RollNumber = roll.RollNumber
                }
            );
        }
        else
        {
            CreateRollReservationModel.RollReservations.Remove(CreateRollReservationModel.RollReservations.Find(r => r.RollId == roll.Id));
        }
    }

    public async Task Delete(Guid id)
    {
        
        await _deleteDataByIdService.DeleteDataById<DeleteModel>(id, "Reservation");

        if (MaterialId != Guid.Empty)
        {
            var reservation = reservationList.FirstOrDefault(e => e.ReservationId == id);
            reservationList.Remove(reservation);
            _rollReservation = reservationList;
            ReservedCount = ReservedCount - reservation.ReservationCount;
            AvailableCount = AvailableCount + reservation.ReservationCount;

            await OnDeleteRollReservation.InvokeAsync(reservation);
        }
        else {
            var subMaterialReservation = SubMaterialreservationList.FirstOrDefault(e => e.ReservationId == id);
            SubMaterialreservationList.Remove(subMaterialReservation);
            _subMaterialReservation = SubMaterialreservationList;
            ReservedCount = ReservedCount - subMaterialReservation.ReservationCount;
            AvailableCount = AvailableCount + subMaterialReservation.ReservationCount;

            await OnDeleteSubMaterialReservation.InvokeAsync(subMaterialReservation);
        }
    }

    public async Task OnSelectCollection(string input)
    {
        var collection = CollectionList.Items.FirstOrDefault(x => x.Id == Guid.Parse(input));

        if (collection != null)
        {
            CreateRollReservationModel.CollectionId = collection.Id.ToString();
            CreateRollReservationModel.CollectionName = collection.Name;
            CreateRollReservationModel.InfluencerNames = collection.InfluencerNames;
        }
    }

    private string ReplaceString(string input)
    {
        return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
    }

}


