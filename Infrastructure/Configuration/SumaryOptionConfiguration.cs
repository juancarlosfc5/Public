using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SumaryOptionConfiguration : IEntityTypeConfiguration<SumaryOption>
    {
        public void Configure(EntityTypeBuilder<SumaryOption> builder)
        {
            builder.ToTable("SumaryOptions");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code_number)
                .HasColumnName("code_number")
                .HasMaxLength(20);

            builder.Property(e => e.Valuerta)
                .HasColumnName("valuerta")
                .HasColumnType("text");

            builder.HasOne(e => e.Survey)
                .WithMany(s => s.SumaryOptions)
                .HasForeignKey(e => e.Survey_Id)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(e => e.Question)
                .WithMany(s => s.SumaryOptions)
                .HasForeignKey(e => e.Question_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}