using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.Entities;

namespace Сантехник.RepositoryLayer.Configuration.Identity
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(
            new AppUserRole
            {
                UserId = Guid.Parse("4802AED0-8173-4FC3-8BCD-376FB946C05B").ToString(),
                RoleId = Guid.Parse("799D7862-0ED0-4C31-BF73-D31162D7795A").ToString()
            },
            new AppUserRole
            {
                UserId = Guid.Parse("B2451B7D-F879-424A-9B48-816F44B7B5A9").ToString(),
                RoleId = Guid.Parse("082F1B6E-F029-48DD-96C6-65ED997C52ED").ToString()
            });
        }
    }
}
