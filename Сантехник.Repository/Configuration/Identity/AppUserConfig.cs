using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.Entities;

namespace Сантехник.RepositoryLayer.Configuration.Identity
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var admin = new AppUser
            {
                Id = Guid.Parse("4802AED0-8173-4FC3-8BCD-376FB946C05B").ToString(),
                Email = "obergannikita@gmail.com",
                NormalizedEmail = "OBERGANNIKITA@GMAIL.COM",
                UserName = "TestAdmin",
                NormalizedUserName = "TESTADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var adminPasswordHash = PasswordHash(admin, "2752985BBnn!");
            admin.PasswordHash = adminPasswordHash;
            builder.HasData(admin);


            var member = new AppUser
            {
                Id = Guid.Parse("B2451B7D-F879-424A-9B48-816F44B7B5A9").ToString(),
                Email = "obergannikita2@gmail.com",
                NormalizedEmail = "OBERGANNIKITA2@GMAIL.COM",
                UserName = "TestMember",
                NormalizedUserName = "TESTMEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var memberPasswordHash = PasswordHash(member, "2752985BBnn!");
            member.PasswordHash = memberPasswordHash;
            builder.HasData(member);
        }

        private string PasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }


    }
}
