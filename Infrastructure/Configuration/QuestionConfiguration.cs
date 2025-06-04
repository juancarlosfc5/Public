using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("questions");

            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id)
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

            builder.Property(q => q.Question_number)
                .HasColumnName("question_number")
                .HasMaxLength(10);

            builder.Property(q => q.Response_type)
                .HasColumnName("response_type")
                .HasMaxLength(10);

            builder.Property(q => q.Comment_question)
                .HasColumnName("comment_question")
                .HasColumnType("text");

            builder.Property(q => q.Question_text)
                .HasColumnName("question_text")
                .HasColumnType("text")
                .IsRequired();

            builder.HasOne(q => q.Chapter)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.Chapter_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}