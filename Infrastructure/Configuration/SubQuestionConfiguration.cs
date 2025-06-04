using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SubQuestionConfiguration : IEntityTypeConfiguration<SubQuestion>
    {
        public void Configure(EntityTypeBuilder<SubQuestion> builder)
        {
            builder.ToTable("SubQuestions");

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

            builder.Property(sq => sq.Subquestion_number)
                .HasMaxLength(10);

            builder.Property(sq => sq.Comment_subquestion)
                .HasColumnType("text");

            builder.Property(sq => sq.Subquestion_text)
                .HasColumnType("text")
                .IsRequired();

            builder.HasOne(sq => sq.Question)
                .WithMany(q => q.SubQuestions)
                .HasForeignKey(sq => sq.Question_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}