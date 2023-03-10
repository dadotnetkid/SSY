using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SSY.AbpUsers.AbpRoles;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace SSY.UserDetails
{
    public class UserDetailDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<UserDetail, Guid> _repository;
        private readonly IdentityUserManager _userManager;
        private readonly IIdentityUserAppService _userAppService;
        private readonly RolesDataSeederContributor _roleDataSeeder;

        public UserDetailDataSeederContributor(IRepository<UserDetail, Guid> repository,
            IdentityRoleManager identityRoleManager,
            IdentityUserManager userManager, IIdentityUserRepository userRepository,
            IIdentityRoleRepository identityRoleRepository, IOptions<IdentityOptions> option, IServiceScopeFactory serviceScopeFactory)
        {
            _repository = repository;
            _userManager = userManager;
            _roleDataSeeder = new RolesDataSeederContributor(identityRoleManager);
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _roleDataSeeder.SeedAsync(context);
            #region 3DDESIGNER
            if ((await _userManager.FindByEmailAsync("j3dpm@yopmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("3DDESIGNER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "j3dpm@yopmail.com", "j3dpm@yopmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jovelyn", "3DPM", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sam@sam.sam")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("3DDESIGNER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sam@sam.sam", "sam@sam.sam");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sam", "3DPM", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("hello@soledadgallardo.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("3DDESIGNER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "hello@soledadgallardo.com", "hello@soledadgallardo.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Soledad", "Gallardo", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            #endregion
            #region ADMIN
            if ((await _userManager.FindByEmailAsync("afrel@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "afrel@sewsewyou.com", "afrel@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Afrel", "Vale Cruz", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("agatha@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "agatha@sewsewyou.com", "agatha@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Agatha", "Parocho", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("aicel@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "aicel@sewsewyou.com", "aicel@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Aicel", "Cruz", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("shine@sewsewu.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shine@sewsewu.co", "shine@sewsewu.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Alexis", "Allen", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ana.d@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ana.d@sewsewyou.com", "ana.d@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ana", "Dejanovic", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ana@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ana@sewsewyou.com", "ana@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ana Kristel", "Ching", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("arcelee@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "arcelee@sewsewyou.com", "arcelee@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Arcelee", "Ubas", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("arjie@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "arjie@sewsewyou.com", "arjie@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Arjie", "Jocson", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("bituin@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "bituin@sewsewyou.com", "bituin@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Bituin", "Mariquit", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("cherie@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "cherie@sewsewyou.com", "cherie@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Cherie", "Cudillo", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("christine@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "christine@sewsewyou.com", "christine@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Christine", "Delfin", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("cris@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "cris@sewsewyou.com", "cris@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Cris", "Baniqued", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("czarina@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "czarina@sewsewyou.com", "czarina@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Czarina", "Santos", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("daniel@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "daniel@sewsewyou.com", "daniel@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Daniel", "Dumrigue", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("dt.fashionstudio@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "dt.fashionstudio@gmail.com", "dt.fashionstudio@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Dragana", "Todorovic", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("eduardo@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "eduardo@sewsewyou.com", "eduardo@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Eduardo", "Lima", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("emma@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "emma@sewsewyou.com", "emma@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Emma", "Abraham", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("erin@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "erin@sewsewyou.com", "erin@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Erin", "Hardy", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("evelyn_mandani@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "evelyn_mandani@luenthai.com", "evelyn_mandani@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Evelyn", "Mandani", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("farah@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "farah@sewsewyou.com", "farah@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Farah", "Jocson", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("irene@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "irene@sewsewyou.com", "irene@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Irene", "Magalong", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ivanna@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ivanna@sewsewyou.com", "ivanna@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "ivanna", "Mallari", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("janelle.alorro@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "janelle.alorro@gmail.com", "janelle.alorro@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Janelle", "Alorro", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jed@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jed@sewsewyou.com", "jed@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jed", "Sena", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jerome@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jerome@sewsewyou.com", "jerome@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jerome", "Aquino", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jerson@sewsewyou.ltd")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jerson@sewsewyou.ltd", "jerson@sewsewyou.ltd");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jerson", "Billones", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jesi@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jesi@sewsewyou.com", "jesi@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jesi", "Alderite", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jhun@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jhun@sewsewyou.com", "jhun@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jhun", "Camit", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("john.michael@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "john.michael@sewsewyou.com", "john.michael@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "John Michael", "Mendoza", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jovy@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jovy@sewsewyou.com", "jovy@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jovelyn", "Ecija", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("laura@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "laura@sewsewyou.com", "laura@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Laura", "Sobh", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("lea@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "lea@sewsewyou.com", "lea@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Lea Ann", "Aniag", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("lyssa@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "lyssa@sewsewyou.com", "lyssa@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Lyssa", "Castillo", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mark@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mark@sewsewyou.com", "mark@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Mark", "Indionco", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mhian@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mhian@sewsewyou.com", "mhian@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Mhian", "Marasigan", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mhilka@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mhilka@sewsewyou.com", "mhilka@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Mhilka", "Angeles", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("michael_reyes@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "michael_reyes@luenthai.com", "michael_reyes@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Michael", "Reyes", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("342263100@qq.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "342263100@qq.com", "342263100@qq.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Midodo", "Liang", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mo@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mo@sewsewyou.com", "mo@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Mohammed", "Alkhodari", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("nadine@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "nadine@sewsewyou.com", "nadine@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Nadine", "Choufani", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("shine@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shine@sewsewyou.com", "shine@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Naomi", "Benitez", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("nate@sewsewyou.ltd")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "nate@sewsewyou.ltd", "nate@sewsewyou.ltd");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Nate", "Pañares", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("nikki@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "nikki@sewsewyou.com", "nikki@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Nikki", "Rivera", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("raenier@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "raenier@sewsewyou.com", "raenier@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Raenier", "Quiambao", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("randy@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "randy@sewsewyou.com", "randy@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Randy", "Acorda", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("raymond_tan@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "raymond_tan@luenthai.com", "raymond_tan@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Raymond", "Tan", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("rhoda@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rhoda@sewsewyou.com", "rhoda@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rhoda", "Agraviador", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sarah@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sarah@sewsewyou.com", "sarah@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sarah", "Chessis", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sarah.chessis@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sarah.chessis@sewsewyou.com", "sarah.chessis@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Shine", "Benitez", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sonja@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sonja@sewsewyou.com", "sonja@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sonja", "Brajovic", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("techteam@sewsewyou.ltd")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "techteam@sewsewyou.ltd", "techteam@sewsewyou.ltd");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Tech", "Team", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            #endregion
            #region SSYMERCHANDISER
            if ((await _userManager.FindByEmailAsync("cristina@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("ADMIN");
                roleName.Add("SSYMERCHANDISER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "cristina@sewsewyou.com", "cristina@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
                    new UserDetail(identity.Id, "Maria Cristina", "Basa", "", "OEM",
                        "", "", "", "", "", "", "", false, false, 0, 0));
            }

            #endregion
            #region AGENT
            if ((await _userManager.FindByEmailAsync("jim@ttpm.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("AGENT");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jim@ttpm.com", "jim@ttpm.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jim", "Silver", "", "jimsilverttpm",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("1jim@ttpm.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("AGENT");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "1jim@ttpm.com", "1jim@ttpm.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jim", "Silver", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("2jim@ttpm.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("AGENT");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "2jim@ttpm.com", "2jim@ttpm.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jim", "Silver", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("kelsey@ensembleds.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("AGENT");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kelsey@ensembleds.com", "kelsey@ensembleds.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kaycee", "Rice", "", "kayceericeofficial",
          "", "", "", "", "", "", "", false, false, 2713, 0));
            }

            if ((await _userManager.FindByEmailAsync("larry@ensembleds.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("AGENT");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "larry@ensembleds.com", "larry@ensembleds.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Larry", "Shapiro", "", "Agency",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            #endregion
            #region INFLUENCER
            if ((await _userManager.FindByEmailAsync("aaliyiabeauty4@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "aaliyiabeauty4@gmail.com", "aaliyiabeauty4@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Aaliyia", "Rogers", "", "_abeauty4",
          "", "", "", "_abeauty4", "", "", "", false, false, 193, 0));
            }

            if ((await _userManager.FindByEmailAsync("abigailbarlow.mgmt@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "abigailbarlow.mgmt@gmail.com", "abigailbarlow.mgmt@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Abigail", "Barlow", "", "abigailbarloww",
          "", "", "", "", "", "", "", false, false, 436, 0));
            }

            if ((await _userManager.FindByEmailAsync("shine@sewsewu.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shine@sewsewu.co", "shine@sewsewu.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Alexis", "Allen", "", "lexitelevision",
          "", "", "", "", "", "", "", false, false, 708, 0));
            }

            if ((await _userManager.FindByEmailAsync("hello@ambrosiamalbrough.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "hello@ambrosiamalbrough.com", "hello@ambrosiamalbrough.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ambrosia", "Malbrough", "", "brosiaaa",
          "", "", "", "", "", "", "", false, false, 240, 0));
            }

            if ((await _userManager.FindByEmailAsync("ana.d@yopmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ana.d@yopmail.com", "ana.d@yopmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ana", "Dejanovic", "", "ana.d",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("skukhtorova@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "skukhtorova@gmail.com", "skukhtorova@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Anastasia", "Skukhtorova", "", "anastasiaskukhtorovapoledance",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("nitraab@select.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "nitraab@select.co", "nitraab@select.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Anitra", "Pearson", "", "nitraab",
          "", "", "", "", "", "", "", false, false, 428, 0));
            }

            if ((await _userManager.FindByEmailAsync("collabwad@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "collabwad@gmail.com", "collabwad@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "April", "Daniels", "", "iamaprildaniels",
          "", "", "", "", "", "", "", false, false, 1281, 0));
            }

            if ((await _userManager.FindByEmailAsync("honestlyautumn@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "honestlyautumn@gmail.com", "honestlyautumn@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Autumn", "Barron", "", "honestlyautumnb",
          "", "", "", "", "", "", "", false, false, 596, 0));
            }

            if ((await _userManager.FindByEmailAsync("beverley@borntosweat.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "beverley@borntosweat.co", "beverley@borntosweat.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Beverley", "Cheng", "", "beverleycheng",
          "", "", "", "", "", "", "", false, false, 299, 0));
            }

            if ((await _userManager.FindByEmailAsync("billy@sewsewyou.ltd")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "billy@sewsewyou.ltd", "billy@sewsewyou.ltd");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Billy", "Sugian", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("noahrbin33@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noahrbin33@gmail.com", "noahrbin33@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Bryant", "Mckinnie", "", "bryantmckinnie",
          "", "", "", "", "", "", "", false, false, 108, 0));
            }

            if ((await _userManager.FindByEmailAsync("cherhubsh@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "cherhubsh@gmail.com", "cherhubsh@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Cher Hubsher", "For Tozi only", "", "cherhubsher",
          "", "", "", "", "", "", "", false, false, 300, 0));
            }

            if ((await _userManager.FindByEmailAsync("noahrubin3@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noahrubin3@gmail.com", "noahrubin3@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Chris", "Eubanks", "", "Chris_eubanks96",
          "", "", "", "", "", "", "", false, false, 444, 0));
            }

            if ((await _userManager.FindByEmailAsync("bookings@cnmofficial.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "bookings@cnmofficial.com", "bookings@cnmofficial.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Cost n'", "Mayor", "", "cost_n_mayor",
          "", "", "", "", "", "", "", false, false, 5532, 0));
            }

            if ((await _userManager.FindByEmailAsync("kwolekassist@artistandbrand.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kwolekassist@artistandbrand.co", "kwolekassist@artistandbrand.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Dana", "Hasson", "", "danahassonn",
          "", "", "", "", "", "", "", false, false, 114, 0));
            }

            if ((await _userManager.FindByEmailAsync("dwhitebusiness@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "dwhitebusiness@gmail.com", "dwhitebusiness@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Daquana", "White", "", "daquanawhite",
          "", "", "", "", "", "", "", false, false, 1184, 0));
            }

            if ((await _userManager.FindByEmailAsync("cherhubsher@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "cherhubsher@gmail.com", "cherhubsher@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Dawn and Cher", "Hubsher", "", "cherhubsher",
          "", "", "", "", "", "", "", false, false, 192, 0));
            }

            if ((await _userManager.FindByEmailAsync("cherhubshe@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "cherhubshe@gmail.com", "cherhubshe@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Dawn Hubsher", "For Tozi only", "", "dawn.hubsher",
          "", "", "", "", "", "", "", false, false, 88, 0));
            }

            if ((await _userManager.FindByEmailAsync("deanna@thesociablesociety.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "deanna@thesociablesociety.com", "deanna@thesociablesociety.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Deanna", "Giulietti", "", "deannagiulietti",
          "", "", "", "", "", "", "", false, false, 905, 0));
            }

            if ((await _userManager.FindByEmailAsync("thecordlefamily@currentsmgmt.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "thecordlefamily@currentsmgmt.com", "thecordlefamily@currentsmgmt.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Devin and Hunter", "Cordle", "", "devincordle",
          "", "", "", "", "", "", "", false, false, 501, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewsewyou.cm")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewsewyou.cm", "rc@sewsewyou.cm");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Diann", "Valentine", "", "diannvalentine",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("domoniqueutley@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "domoniqueutley@gmail.com", "domoniqueutley@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Domonique", "Robinson", "", "domoniqueutley_",
          "", "", "", "", "", "", "", false, false, 197, 0));
            }

            if ((await _userManager.FindByEmailAsync("dorothy@mannfolkpr.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "dorothy@mannfolkpr.com", "dorothy@mannfolkpr.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Dorothy", "Mannfolk", "", "dmannfolkpr",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("balde.elladj@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "balde.elladj@gmail.com", "balde.elladj@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "elladj", "Balde", "", "elladjbalde",
          "", "", "", "", "", "", "", false, false, 1090, 0));
            }

            if ((await _userManager.FindByEmailAsync("elle.leary@yahoo.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "elle.leary@yahoo.com", "elle.leary@yahoo.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Elle", "Leary", "", "ellelearyartistry",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mleparker111@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mleparker111@gmail.com", "mleparker111@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Emily", "Bear", "", "mlebear",
          "", "", "", "", "", "", "", false, false, 781, 0));
            }

            if ((await _userManager.FindByEmailAsync("emily@movethrugrief.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "emily@movethrugrief.com", "emily@movethrugrief.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Emily", "Bingham", "", "emilypbingham",
          "", "", "", "", "", "", "", false, false, 221, 0));
            }

            if ((await _userManager.FindByEmailAsync("erinhardy01@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "erinhardy01@gmail.com", "erinhardy01@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Erin", "Hardy", "", "erinhardy01",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("gsdaleman@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "gsdaleman@gmail.com", "gsdaleman@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Gabby", "Daleman", "", "gabby_daleman",
          "", "", "", "", "", "", "", false, false, 61, 0));
            }

            if ((await _userManager.FindByEmailAsync("gabebabetv@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "gabebabetv@gmail.com", "gabebabetv@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Gabe", "Flowers", "", "gabeflowers",
          "", "", "", "", "", "", "", false, false, 1881, 0));
            }

            if ((await _userManager.FindByEmailAsync("gabriella.papadakis@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "gabriella.papadakis@gmail.com", "gabriella.papadakis@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Gabriella", "Papadakis", "", "gabriellapapadakis",
          "", "", "", "", "", "", "", false, false, 730, 0));
            }

            if ((await _userManager.FindByEmailAsync("gemma@gemmacheung.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "gemma@gemmacheung.com", "gemma@gemmacheung.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Gemma", "Cheung", "", "gemma_cheung",
          "", "", "", "", "", "", "", false, false, 73, 0));
            }

            if ((await _userManager.FindByEmailAsync("jim@ttpm.c")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jim@ttpm.c", "jim@ttpm.c");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Hannah", "Cases", "", "hannahwiththelipstick",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("iknowlee@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "iknowlee@gmail.com", "iknowlee@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Helecia", "Williams", "", "iknowlee",
          "", "", "", "", "", "", "", false, false, 365, 0));
            }

            if ((await _userManager.FindByEmailAsync("collabwad@gmail.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "collabwad@gmail.co", "collabwad@gmail.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Holly", "Furtick", "", "hollyfurtick",
          "", "", "", "", "", "", "", false, false, 819, 0));
            }

            if ((await _userManager.FindByEmailAsync("stampedmanagement03@yahoo.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "stampedmanagement03@yahoo.com", "stampedmanagement03@yahoo.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Icess", "C", "", "slashedbyice",
          "", "", "", "", "", "", "", false, false, 472, 0));
            }

            if ((await _userManager.FindByEmailAsync("noahrubin@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noahrubin@gmail.com", "noahrubin@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jamie", "Loeb", "", "jloeb308",
          "", "", "", "", "", "", "", false, false, 32, 0));
            }

            if ((await _userManager.FindByEmailAsync("noah33@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noah33@gmail.com", "noah33@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jamie", "Weissler", "", "Jamieweissler_dvm",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("1larry@ensembleds.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "1larry@ensembleds.com", "1larry@ensembleds.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jenn", "Todryk", "", "theramblingredhead",
          "", "", "", "", "", "", "", false, false, 6464, 0));
            }

            if ((await _userManager.FindByEmailAsync("jennacompono@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jennacompono@gmail.com", "jennacompono@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jenna", "Compono", "", "jennacompono",
          "", "", "", "", "", "", "", false, false, 1348, 0));
            }

            if ((await _userManager.FindByEmailAsync("jolene@jolenegoring.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jolene@jolenegoring.com", "jolene@jolenegoring.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jolene", "Goring", "", "jolenegoring",
          "", "", "", "", "", "", "", false, false, 728, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewseyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewseyou.com", "rc@sewseyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Joyce", "Sheffield", "", "joycesheffield_",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mskaimichelle@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mskaimichelle@gmail.com", "mskaimichelle@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kai Michelle", "Scates", "", "mskaimichelle",
          "", "", "", "", "", "", "", false, false, 14, 0));
            }

            if ((await _userManager.FindByEmailAsync("kausha.campbell@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kausha.campbell@gmail.com", "kausha.campbell@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kausha", "Campbell", "", "kausha_campbell",
          "", "", "", "", "", "", "", false, false, 284, 0));
            }

            if ((await _userManager.FindByEmailAsync("kayceestroh@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kayceestroh@gmail.com", "kayceestroh@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "KayCee Stroh", "Higginson", "", "kaycstroh",
          "", "", "", "", "", "", "", false, false, 821, 0));
            }

            if ((await _userManager.FindByEmailAsync("hello@happykelli.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "hello@happykelli.com", "hello@happykelli.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kelli", "Butler", "", "kelladactyl",
          "", "", "", "", "", "", "", false, false, 4178, 0));
            }

            if ((await _userManager.FindByEmailAsync("kelsi@fullmhouse.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kelsi@fullmhouse.com", "kelsi@fullmhouse.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kelsi", "Fullmer", "", "fullmhouse",
          "", "", "", "", "", "", "", false, false, 1388, 0));
            }

            if ((await _userManager.FindByEmailAsync("kennasharp1@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kennasharp1@gmail.com", "kennasharp1@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kenna", "Sharp", "", "kennabbby",
          "", "", "", "", "", "", "", false, false, 448, 0));
            }

            if ((await _userManager.FindByEmailAsync("kim@kimperry.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kim@kimperry.com", "kim@kimperry.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kim", "Perry", "", "kimperryco",
          "", "", "", "", "", "", "", false, false, 790, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewsewyou.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewsewyou.co", "rc@sewsewyou.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kimberly", "Jones", "", "realtalkkim",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("kortnigilson@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kortnigilson@gmail.com", "kortnigilson@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kortni", "Gilson", "", "_k0nigi",
          "", "", "", "", "", "", "", false, false, 152, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewsewou.om")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewsewou.om", "rc@sewsewou.om");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kortni", "Morton", "", "kortnimorton",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("kristine@trendycurvy.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kristine@trendycurvy.com", "kristine@trendycurvy.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kristine", "Thompson", "", "mskristine",
          "", "", "", "", "", "", "", false, false, 1270, 0));
            }

            if ((await _userManager.FindByEmailAsync("kryshall100@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kryshall100@gmail.com", "kryshall100@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Krystal", "Hall", "", "thekrystalhall",
          "", "", "", "", "", "", "", false, false, 37, 0));
            }

            if ((await _userManager.FindByEmailAsync("s@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "s@sewsewyou.com", "s@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "LaRissa", "Johnson", "", "a",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("momlifewithlaura@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "momlifewithlaura@gmail.com", "momlifewithlaura@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Laura", "Claps", "", "momlifewithlaura",
          "", "", "", "", "", "", "", false, false, 46, 0));
            }

            if ((await _userManager.FindByEmailAsync("reallifemomandwife@outlook.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "reallifemomandwife@outlook.com", "reallifemomandwife@outlook.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Lindsey", "Jungwirth", "", "reallifemomandwife",
          "", "", "", "", "", "", "", false, false, 511, 0));
            }

            if ((await _userManager.FindByEmailAsync("lisettekrol@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "lisettekrol@gmail.com", "lisettekrol@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Lisette", "Krol", "", "lisettekrol",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("connect@makenziedustman.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "connect@makenziedustman.com", "connect@makenziedustman.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Makenzie", "Dustman", "", "makenzie_dustman",
          "", "", "", "", "", "", "", false, false, 475, 0));
            }

            if ((await _userManager.FindByEmailAsync("noahrubi33@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noahrubi33@gmail.com", "noahrubi33@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Makenzie", "Raine", "", "Makenzie_raine",
          "", "", "", "", "", "", "", false, false, 303, 0));
            }

            if ((await _userManager.FindByEmailAsync("matt@iconsource.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "matt@iconsource.com", "matt@iconsource.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Matt", "Ladley", "", "mattladley",
          "", "", "", "", "", "", "", false, false, 12, 0));
            }

            if ((await _userManager.FindByEmailAsync("maxphilisaire@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "maxphilisaire@gmail.com", "maxphilisaire@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Max", "Philisaire", "", "maxthebody",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("megan@meganewoldsen.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "megan@meganewoldsen.com", "megan@meganewoldsen.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Megan", "Ewoldsen", "", "meganewoldsen",
          "", "", "", "", "", "", "", false, false, 697, 0));
            }

            if ((await _userManager.FindByEmailAsync("miriamlurry@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "miriamlurry@gmail.com", "miriamlurry@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Miriam", "Lurry", "", "miriamlurry",
          "", "", "", "", "", "", "", false, false, 93, 0));
            }

            if ((await _userManager.FindByEmailAsync("shine@sewsewyou.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shine@sewsewyou.co", "shine@sewsewyou.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Miss", "Diddy", "", "missdiddy",
          "", "", "", "", "", "", "", false, false, 213, 0));
            }

            if ((await _userManager.FindByEmailAsync("missjemima56@createfluence.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "missjemima56@createfluence.com", "missjemima56@createfluence.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Miss", "Jemima", "", "missjemima",
          "", "", "", "", "", "", "", false, false, 213, 0));
            }

            if ((await _userManager.FindByEmailAsync("molleegray@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "molleegray@gmail.com", "molleegray@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Mollee", "Gray", "", "molleegray",
          "", "", "", "", "", "", "", false, false, 120, 0));
            }

            if ((await _userManager.FindByEmailAsync("nanawang@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "nanawang@gmail.com", "nanawang@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Natasha", "Wang", "", "polecricket",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("info@prettynici.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "info@prettynici.com", "info@prettynici.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Nici", "Ruffin", "", "prettynici",
          "", "", "", "", "", "", "", false, false, 28, 0));
            }

            if ((await _userManager.FindByEmailAsync("noahrubin33@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noahrubin33@gmail.com", "noahrubin33@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Noah", "Rubin", "", "noahrubin33",
          "", "", "", "", "", "", "", false, false, 92, 0));
            }

            if ((await _userManager.FindByEmailAsync("noorhamadani@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noorhamadani@gmail.com", "noorhamadani@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Noor", "Hussain", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("twinsauce@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "twinsauce@gmail.com", "twinsauce@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Paul and Luke", "Harwerth", "", "twinsauce",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("pearl.santillan22@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "pearl.santillan22@gmail.com", "pearl.santillan22@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Pearl Joy", "Santillan", "", "na",
          "", "", "", "", "", "", "", false, false, 190, 0));
            }

            if ((await _userManager.FindByEmailAsync("peggy@ontheqtrain.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "peggy@ontheqtrain.com", "peggy@ontheqtrain.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Peggy", "Jean", "", "ontheqtrain",
          "", "", "", "", "", "", "", false, false, 112, 0));
            }

            if ((await _userManager.FindByEmailAsync("sarah@fashforward.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sarah@fashforward.com", "sarah@fashforward.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Project", "FashForward", "", "-",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewseyou.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewseyou.co", "rc@sewseyou.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Quianna", "Lashea", "", "qui2health",
          "", "", "", "", "", "", "", false, false, 764, 0));
            }

            if ((await _userManager.FindByEmailAsync("noahrubn33@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "noahrubn33@gmail.com", "noahrubn33@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rachel", "Stuhlmann", "", "rstuhlmann",
          "", "", "", "", "", "", "", false, false, 681, 0));
            }

            if ((await _userManager.FindByEmailAsync("rahul@henrytalents.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rahul@henrytalents.com", "rahul@henrytalents.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rahul", "Rai", "", "therealrahulrai",
          "", "", "", "", "", "", "", false, false, 124, 0));
            }

            if ((await _userManager.FindByEmailAsync("rrogersworld@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rrogersworld@gmail.com", "rrogersworld@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rebecca", "Rogers", "", "rrogersworld",
          "", "", "", "", "", "", "", false, false, 401, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewswyou.om")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewswyou.om", "rc@sewswyou.om");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Robin", "Thomas", "", "mrrsrobinv",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sheenmgnt@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sheenmgnt@gmail.com", "sheenmgnt@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Russiena", "Brand", "", "trubeautyest85",
          "", "", "", "", "", "", "", false, false, 16, 0));
            }

            if ((await _userManager.FindByEmailAsync("sania@loserstolegends.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sania@loserstolegends.com", "sania@loserstolegends.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sania", "Khiljee", "", "saniakhiljee",
          "", "", "", "", "", "", "", false, false, 172, 0));
            }

            if ((await _userManager.FindByEmailAsync("saggysaraa@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "saggysaraa@gmail.com", "saggysaraa@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sara", "Puhto", "", "saggysara",
          "", "", "", "", "", "", "", false, false, 206, 0));
            }

            if ((await _userManager.FindByEmailAsync("schellea@ksinc.com.au")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "schellea@ksinc.com.au", "schellea@ksinc.com.au");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Schellea", "Fowler", "", "fabulous.50s",
          "", "", "", "", "", "", "", false, false, 6479, 0));
            }

            if ((await _userManager.FindByEmailAsync("athickgirlscloset@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "athickgirlscloset@gmail.com", "athickgirlscloset@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Shainna", "Tucker", "", "thickgrlscloset",
          "", "", "", "", "", "", "", false, false, 49, 0));
            }

            if ((await _userManager.FindByEmailAsync("shereadelsol@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shereadelsol@gmail.com", "shereadelsol@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "SheRea", "DelSol", "", "shereadelsol",
          "", "", "", "", "", "", "", false, false, 43, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewsewou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewsewou.com", "rc@sewsewou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sheree", "Zampino", "", "shereezampino",
          "", "", "", "", "", "", "", false, false, 347, 0));
            }

            if ((await _userManager.FindByEmailAsync("diaryofafitmommy@yahoo.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "diaryofafitmommy@yahoo.com", "diaryofafitmommy@yahoo.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sia", "Cooper", "", "diaryofafitmommyofficial",
          "", "", "", "", "", "", "", false, false, 93, 0));
            }

            if ((await _userManager.FindByEmailAsync("naomi.native@outlook.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "naomi.native@outlook.com", "naomi.native@outlook.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Simdi Naomi", "Obodosike", "", "naomi.native",
          "", "", "", "", "", "", "", false, false, 35, 0));
            }

            if ((await _userManager.FindByEmailAsync("millie.dwyer@thebrag.media")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "millie.dwyer@thebrag.media", "millie.dwyer@thebrag.media");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Simone", "Giertz", "", "simonegiertz",
          "", "", "", "", "", "", "", false, false, 990, 0));
            }

            if ((await _userManager.FindByEmailAsync("hello@simplysonja.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "hello@simplysonja.com", "hello@simplysonja.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Simply", "Sonja", "", "simplysonja_m",
          "", "", "", "", "", "", "", false, false, 42, 0));
            }

            if ((await _userManager.FindByEmailAsync("ssonia@ttpmtalent.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ssonia@ttpmtalent.com", "ssonia@ttpmtalent.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ssonia", "Ong", "", "ongsquadron",
          "", "", "", "", "", "", "", false, false, 384, 0));
            }

            if ((await _userManager.FindByEmailAsync("stella@createfluence.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "stella@createfluence.com", "stella@createfluence.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Stella", "Williams", "", "thestellawilliams",
          "", "", "", "", "", "", "", false, false, 167, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewsewou.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewsewou.co", "rc@sewsewou.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Stephanie", "Edwards", "", "isparklei",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("stephanie@imagemotion.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "stephanie@imagemotion.com", "stephanie@imagemotion.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Stephanie", "Werbin", "", "stefwerbie",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sruff@teamwass.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sruff@teamwass.com", "sruff@teamwass.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Steve", "Ruff", "", "steveruff",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("shine@sewsewou.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shine@sewsewou.co", "shine@sewsewou.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Tammy", "Franklin", "", "iamtammyfranklin",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("info@tangeiadsmith.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "info@tangeiadsmith.com", "info@tangeiadsmith.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Tan", "Smith", "", "chief_tan",
          "", "", "", "", "", "", "", false, false, 23, 0));
            }

            if ((await _userManager.FindByEmailAsync("tanyacheung@hotmail.co.uk")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "tanyacheung@hotmail.co.uk", "tanyacheung@hotmail.co.uk");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Tanya", "Cheung", "", "tanyaxcheung",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("lacenleopard@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "lacenleopard@gmail.com", "lacenleopard@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Tiffany", "Blackwood", "", "lacenleopard",
          "", "", "", "", "", "", "", false, false, 111, 0));
            }

            if ((await _userManager.FindByEmailAsync("shine@sewsewyo.co")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "shine@sewsewyo.co", "shine@sewsewyo.co");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Tiffney", "Cambridge", "", "lovetiffney",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("rc@sewsewyu.cm")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rc@sewsewyu.cm", "rc@sewsewyu.cm");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Treiva", "Williams", "", "msrocc68",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("viccaputo2012@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "viccaputo2012@gmail.com", "viccaputo2012@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Victoria", "Caputo", "", "viccaputo",
          "", "", "", "", "", "", "", false, false, 405, 0));
            }

            if ((await _userManager.FindByEmailAsync("passion4fashionplussize@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "passion4fashionplussize@gmail.com", "passion4fashionplussize@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Victoria", "Crawford", "", "victoria_lashay",
          "", "", "", "", "", "", "", false, false, 13, 0));
            }

            if ((await _userManager.FindByEmailAsync("victoriaxpark@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "victoriaxpark@gmail.com", "victoriaxpark@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Victoria", "Park", "", "heybvp",
          "", "", "", "", "", "", "", false, false, 422, 0));
            }

            if ((await _userManager.FindByEmailAsync("vladaaerialartist@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "vladaaerialartist@gmail.com", "vladaaerialartist@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Vladislava", "Zhizhchenko", "", "vlada_polefitdubai",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("mrsbritnicolem@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "mrsbritnicolem@gmail.com", "mrsbritnicolem@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Isabella", "Fonte", "", "mrsbritnicole_",
          "", "", "", "", "", "", "", false, false, 1066, 0));
            }

            if ((await _userManager.FindByEmailAsync("natasha@natashapehrson.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "natasha@natashapehrson.com", "natasha@natashapehrson.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Natasha", "Pehrson", "", "natashapehrson",
          "", "", "", "", "", "", "", false, false, 2360, 0));
            }

            if ((await _userManager.FindByEmailAsync("annadaly82@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "annadaly82@gmail.com", "annadaly82@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Anna", "Daly", "", "beautyofaboymom",
          "", "", "", "", "", "", "", false, false, 898, 0));
            }

            if ((await _userManager.FindByEmailAsync("ttest@yopmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ttest@yopmail.com", "ttest@yopmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jhun", "Camit", "", "deymjhun",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("brian@emmllc.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "brian@emmllc.com", "brian@emmllc.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Cara", "Newhart", "", "neverskipbrunch",
          "", "", "", "", "", "", "", false, false, 759, 0));
            }

            if ((await _userManager.FindByEmailAsync("ongsquadron@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ongsquadron@gmail.com", "ongsquadron@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ong", "Squad", "", "_ongsquad",
          "", "", "", "", "", "", "", false, false, 8064, 0));
            }

            if ((await _userManager.FindByEmailAsync("sarah.chessis@mac.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sarah.chessis@mac.com", "sarah.chessis@mac.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sarah", "Chessis", "", "sarah.c",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("kat@reelmanagement.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "kat@reelmanagement.com", "kat@reelmanagement.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Kath", "Dunn", "", "katdunn",
          "", "", "", "", "", "", "", false, false, 997, 0));
            }

            if ((await _userManager.FindByEmailAsync("losmoralesent@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "losmoralesent@gmail.com", "losmoralesent@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Briana", "Myles", "", "blmyles",
          "", "", "", "", "", "", "", false, false, 778, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("melissagbecraft@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "melissagbecraft@gmail.com", "melissagbecraft@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Melissa", "Becraft", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 1126, 0));
            }

            if ((await _userManager.FindByEmailAsync("nicole@odysseyentgroup.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "nicole@odysseyentgroup.com", "nicole@odysseyentgroup.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Keara", "Leech", "", "queen.kekeeee",
          "", "", "", "", "", "", "", false, false, 964, 0));
            }

            if ((await _userManager.FindByEmailAsync("jumpkck@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jumpkck@gmail.com", "jumpkck@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Joel", "Freeman", "", "joelfreemanfitness",
          "", "", "", "", "", "", "", false, false, 1482, 0));
            }

            if ((await _userManager.FindByEmailAsync("amanialiyya@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amanialiyya@gmail.com", "amanialiyya@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amani", "Aliyya", "", "_easyaa",
          "", "", "", "", "", "", "", false, false, 1482, 0));
            }

            if ((await _userManager.FindByEmailAsync("ali@alliancemanagementcompany.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ali@alliancemanagementcompany.com", "ali@alliancemanagementcompany.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Taylor", "Giavasis", "", "taylorgiavasis",
          "", "", "", "", "", "", "", false, false, 6148, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            if ((await _userManager.FindByEmailAsync("amybcotney@gmail.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("INFLUENCER");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "amybcotney@gmail.com", "amybcotney@gmail.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Amy", "Barton Cotney", "", "sweethomeauburnal",
          "", "", "", "", "", "", "", false, false, 419, 0));
            }

            #endregion
            #region OEM
            if ((await _userManager.FindByEmailAsync("ankh.yiu@tienhu.com2")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ankh.yiu@tienhu.com2", "ankh.yiu@tienhu.com2");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "A", "Yiu", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ailene_alcazar@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ailene_alcazar@luenthai.com", "ailene_alcazar@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ailene", "Alcazar", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("angelica_villanueva@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "angelica_villanueva@luenthai.com", "angelica_villanueva@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Angelica", "Villanueva", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ankh.yiu@tienhu.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ankh.yiu@tienhu.com", "ankh.yiu@tienhu.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ankh", "Yiu", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ariel_arca@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ariel_arca@yuenthai.com", "ariel_arca@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ariel", "Arca", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("carol.ge@tienhu.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "carol.ge@tienhu.com", "carol.ge@tienhu.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Carol", "Ge", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("christian_velez@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "christian_velez@yuenthai.com", "christian_velez@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Christian Niño", "Velez", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("daisy_ando@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "daisy_ando@yuenthai.com", "daisy_ando@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Daisy", "Ando", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("helen_wang@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "helen_wang@luenthai.com", "helen_wang@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "H", "Wang", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("hope_atillo@ytydigital.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "hope_atillo@ytydigital.com", "hope_atillo@ytydigital.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Hope Martinez", "Atillo", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("iris.wan@tienhu.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "iris.wan@tienhu.com", "iris.wan@tienhu.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Iris", "Wan", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("ismael_arong@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "ismael_arong@yuenthai.com", "ismael_arong@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Ismael", "Arong", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jeremy.wong@tienhu.com2")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jeremy.wong@tienhu.com2", "jeremy.wong@tienhu.com2");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "J", "Wong", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jeffrey_delrosario@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jeffrey_delrosario@yuenthai.com", "jeffrey_delrosario@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jeffrey", "Del Rosario", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jemmalyn_pulvera@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jemmalyn_pulvera@yuenthai.com", "jemmalyn_pulvera@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jemmalyn", "Pulvera", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("joe_wenceslao@ytydigital.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "joe_wenceslao@ytydigital.com", "joe_wenceslao@ytydigital.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Joe", "Wenceslao", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("jovenal_justiniani@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "jovenal_justiniani@yuenthai.com", "jovenal_justiniani@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Jovenal", "Justiani", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("junbert_enjambre@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "junbert_enjambre@yuenthai.com", "junbert_enjambre@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Junbert", "Enjambre", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("katherine_cheng@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "katherine_cheng@yuenthai.com", "katherine_cheng@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Katherine", "Cheng", "", "OEM, Supplier",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("leslie@sewsewyou.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "leslie@sewsewyou.com", "leslie@sewsewyou.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Leslie", "Parungo", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("li.michelle@tienhu.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "li.michelle@tienhu.com", "li.michelle@tienhu.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Li", "Michelle", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("marian_dalusung@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "marian_dalusung@yuenthai.com", "marian_dalusung@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Marian", "Dalusung", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("maryjoy_cabahug@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "maryjoy_cabahug@yuenthai.com", "maryjoy_cabahug@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Mary Joy", "Cabahug", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("monica_abrea@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "monica_abrea@yuenthai.com", "monica_abrea@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Monica", "Abrea", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("napoleon_villapez@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "napoleon_villapez@yuenthai.com", "napoleon_villapez@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Napoleon", "Villapez", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("peter_delapena@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "peter_delapena@yuenthai.com", "peter_delapena@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Peter", "Dela Peña", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("quennie_duerme@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "quennie_duerme@yuenthai.com", "quennie_duerme@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Quennie", "Duerme", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("regin.chung@tienhu.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "regin.chung@tienhu.com", "regin.chung@tienhu.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Regin", "Chung", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("rene_huyoa@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rene_huyoa@yuenthai.com", "rene_huyoa@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rene", "Huyo-a", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("rhea_mangubat@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rhea_mangubat@yuenthai.com", "rhea_mangubat@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rhea", "Rhea", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("rosemarie_gepitulan@ytydigital.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "rosemarie_gepitulan@ytydigital.com", "rosemarie_gepitulan@ytydigital.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Rosemarie", "Gepitulan", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sandy_chan@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sandy_chan@luenthai.com", "sandy_chan@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sandy", "Chan", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sheilamay_peroso@yuenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sheilamay_peroso@yuenthai.com", "sheilamay_peroso@yuenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sheila May", "Peroso", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("simon_wooi@luenthai.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "simon_wooi@luenthai.com", "simon_wooi@luenthai.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Simon", "Wooi", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            if ((await _userManager.FindByEmailAsync("sophia.lee@tienhu.com")) is null)
            {
                var roleName = new List<string>();
                roleName.Add("OEM");
                var id = Guid.NewGuid();
                var identity = new IdentityUser(id, "sophia.lee@tienhu.com", "sophia.lee@tienhu.com");
                await _userManager.CreateAsync(identity);
                await _userManager.AddToRolesAsync(identity, roleName.AsEnumerable());
                await _repository.InsertAsync(
             new UserDetail(identity.Id, "Sophia", "Lee", "", "",
          "", "", "", "", "", "", "", false, false, 0, 0));
            }

            #endregion

        }
    }
}

