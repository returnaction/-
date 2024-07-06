using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.Entities;

namespace Сантехник.RepositoryLayer.Configuration.WebApplication
{
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Comment).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Testimonial
            {
                Id = 1,
                Comment = "Test comment for Testimonial",
                FullName = "Test FullName for Testimonial",
                Title = "Test title for Testimonial",

                FileName = "test",
                FileType = "test"
            }, new Testimonial
            {
                Id = 2,
                Comment = "Test comment for Testimonial",
                FullName = "Test FullName for Testimonial",
                Title = "Test title for Testimonial",

                FileName = "test2",
                FileType = "test2"
            },
            new Testimonial
            {
                Id = 3,
                Comment = "Test comment for Testimonial",
                FullName = "Test FullName for Testimonial",
                Title = "Test title for Testimonial",

                FileName = "test3",
                FileType = "test3"
            });
        }
    }
}
