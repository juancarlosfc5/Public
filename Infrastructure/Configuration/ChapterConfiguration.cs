using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("chapters");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Created_at)
                .HasColumnName("created_at")
                .HasColumnType("datetime(6)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Updated_at)
                .HasColumnName("updated_at")
                .HasColumnType("datetime(6)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6)")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.Componenthtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(20);

            builder.Property(e => e.Componentreact)
                .HasColumnName("componentreact")
                .HasMaxLength(20);

            builder.Property(e => e.Chapter_number)
                .HasColumnName("chapter_number")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Chapter_title)
                .HasColumnName("chapter_title")
                .HasColumnType("text")
                .IsRequired();

            builder.HasOne(e => e.Survey)
                .WithMany(s => s.Chapters)
                .HasForeignKey(e => e.Survey_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}