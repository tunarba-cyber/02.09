using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaModular.Modules.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Data.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(s => s.Name)
                .IsUnique();

            builder.Property(s => s.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(s => s.UpdatedAt)
                .IsRequired(false);

            builder.Property(s => s.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(0);

            // Configure many-to-many relationship with Product through ProductSize
            builder.HasMany(s => s.ProductSizes)
                .WithOne(ps => ps.Size)
                .HasForeignKey(ps => ps.SizeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
