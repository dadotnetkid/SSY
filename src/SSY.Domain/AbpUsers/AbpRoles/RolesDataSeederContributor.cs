using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace SSY.AbpUsers.AbpRoles
{
    public class RolesDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IdentityRoleManager _identityRoleManager;

        public RolesDataSeederContributor(IdentityRoleManager identityRoleManager)
        {
            _identityRoleManager = identityRoleManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (!(await _identityRoleManager.RoleExistsAsync("3DDESIGNER")))
                await _identityRoleManager.CreateAsync(new IdentityRole(Guid.Parse("2acc6bc7-dd61-4c83-b748-840895f6d07f"), "3DDESIGNER"));
            if (!(await _identityRoleManager.RoleExistsAsync("ADMIN")))
                await _identityRoleManager.CreateAsync(new IdentityRole(Guid.Parse("e9f7de46-9fcb-4714-a101-cd8b57ffcfeb"), "ADMIN"));
            if (!(await _identityRoleManager.RoleExistsAsync("SSYMERCHANDISER")))
                await _identityRoleManager.CreateAsync(new IdentityRole(Guid.Parse("31B2C973-4537-42F0-81ED-7151E70F159B"), "SSYMERCHANDISER"));
            if (!(await _identityRoleManager.RoleExistsAsync("AGENT")))
                await _identityRoleManager.CreateAsync(new IdentityRole(Guid.Parse("bfb6069e-ca54-4f8d-9456-aa9dba92ccdd"), "AGENT"));
            if (!(await _identityRoleManager.RoleExistsAsync("INFLUENCER")))
                await _identityRoleManager.CreateAsync(new IdentityRole(Guid.Parse("e430942c-7d92-4508-9b8e-29d4f379bfb2"), "INFLUENCER"));
            if (!(await _identityRoleManager.RoleExistsAsync("OEM")))
                await _identityRoleManager.CreateAsync(new IdentityRole(Guid.Parse("e44805e6-67e8-4940-a7bf-16d06a01b7a6"), "OEM"));
        }
    }
}
