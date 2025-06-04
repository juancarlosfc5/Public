using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoryOptionConfiguration : IEntityTypeConfiguration<CategoryOption>
    {
        public void Configure(EntityTypeBuilder<CategoryOption> builder)
        {
            builder.ToTable("category_options");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Created_at)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Updated_at)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            builder.HasOne(e => e.CategoryCatalog)
                .WithMany(c => c.CategoryOptions)
                .HasForeignKey(e => e.CategoryCatalog_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.OptionResponse)
                .WithMany(o => o.CategoryOptions)
                .HasForeignKey(e => e.OptionResponse_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}