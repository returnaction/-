using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;

namespace Сантехник.RepositoryLayer.Configuration
{
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Portfolio
            {
                Id = 1,
                Title = "Test portfolio title",

                FileName = "test",
                FileType = "test",

                CategoryId = 1
            }, new Portfolio
            {
                Id = 2,
                Title = "Test2 portfolio title",

                FileName = "test2",
                FileType = "test2",

                CategoryId = 1
            }, new Portfolio
            {
                Id = 3,
                Title = "Test3 portfolio title",

                FileName = "test3",
                FileType = "test3",

                CategoryId = 2
            }, new Portfolio
            {
                Id = 4,
                Title = "Test4 portfolio title",

                FileName = "test4",
                FileType = "test4",

                CategoryId = 2
            });
            
        }
    }
}
