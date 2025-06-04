using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoryCatalogConfiguration : IEntityTypeConfiguration<CategoryCatalog>
    {
        public void Configure(EntityTypeBuilder<CategoryCatalog> builder)
        {
            builder.ToTable("category_catalogs");

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

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(55);
        }
    }
}