using SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model;

namespace SSY.Blazor.Pages.Supplier.Components.ContactPerson
{
    public partial class ContactPerson
    {
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public CountryModel CountryModel { get; set; }

        [CascadingParameter(Name = "ModuleType")]
        private string ModuleType { get; set; }

        [Parameter]
        public EventCallback<ContactPersonsModel> OnAddContactPerson { get; set; }



        [Parameter]
        public List<ContactPersonsModel> ContactPersons { get; set; }
        private ContactPersonsModel ContactPersonModel { get; set; } = new();

        private bool isSortedAscending;
        private string activeSortColumn;
        bool isUpdatingModal = false;
        int contactID = new int();

        protected override async Task OnInitializedAsync()
        {
            ContactPersonModel = new();

        }

        public async Task ContactPersonHandler()
        {
            // showModal = false;
            // await OnAddContactPerson.InvokeAsync(ContactPersonModel);
            // // ContactPersonModel = new();
            if (isUpdatingModal)
            {
                await UpdateContactPerson();
            }
            else
            {
                ContactPersons.Add(new ContactPersonsModel()
                {
                    TenantId = 1,
                    IsActive = true,
                    Name = ContactPersonModel.Name,
                    Position = ContactPersonModel.Position,
                    Email = ContactPersonModel.Email,
                    Telephone = ContactPersonModel.Telephone,
                    MobileNumber = ContactPersonModel.MobileNumber,
                    Id = ContactPersonModel.Id
                });

                await ResetContactPerson();
            }

        }

        public async Task ResetContactPerson()
        {
            ContactPersonModel.Name = "";
            ContactPersonModel.Position = "";
            ContactPersonModel.Email = "";
            ContactPersonModel.Telephone = "";
            ContactPersonModel.MobileNumber = "";
            isUpdatingModal = false;
            contactID = new int();
        }
        public async Task RemoveContactPerson(ContactPersonsModel contactPersonModel)
        {
            if (ModuleType == "Add")
            {
                ContactPersons.Remove(contactPersonModel);
            }
            else
            {
                await SetContactPerson(contactPersonModel);

                var contact = ContactPersons.Find(x => x.ContactPersonId == contactID);

                contact.IsDeleted = true;

                if (contact != null)
                {
                    ContactPersons.Remove(contactPersonModel);
                }
            }
        }

        public async Task SetContactPerson(ContactPersonsModel contactPersonModel)
        {
            isUpdatingModal = true;
            ContactPersonModel.Name = contactPersonModel.Name;
            ContactPersonModel.Position = contactPersonModel.Position;
            ContactPersonModel.Email = contactPersonModel.Email;
            ContactPersonModel.Telephone = contactPersonModel.Telephone;
            ContactPersonModel.MobileNumber = contactPersonModel.MobileNumber;
            contactID = contactPersonModel.ContactPersonId;

        }

        public async Task UpdateContactPerson()
        {
            var contact = ContactPersons.Find(x => x.ContactPersonId == contactID);

            contact.Name = ContactPersonModel.Name;
            contact.Position = ContactPersonModel.Position;
            contact.Email = ContactPersonModel.Email;
            contact.Telephone = ContactPersonModel.Telephone;
            contact.MobileNumber = ContactPersonModel.MobileNumber;
        }

        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                ContactPersons = ContactPersons.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;

            }
            else
            {
                if (isSortedAscending)
                {
                    ContactPersons = ContactPersons.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    ContactPersons = ContactPersons.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
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
