using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OptionQuestionConfiguration : IEntityTypeConfiguration<OptionQuestion>
    {
        public void Configure(EntityTypeBuilder<OptionQuestion> builder)
        {
            builder.ToTable("option_questions");

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

            builder.Property(e => e.Comment_optionres)
                .HasColumnName("comment_optionres")
                .HasColumnType("text");

            builder.Property(e => e.Number_option)
                .HasColumnName("number_option")
                .HasMaxLength(20);

            builder.HasOne(e => e.Question)
                .WithMany(q => q.OptionQuestions)
                .HasForeignKey(e => e.Question_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.SubQuestion)
                .WithMany(sq => sq.OptionQuestions)
                .HasForeignKey(e => e.SubQuestion_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CategoryCatalog)
                .WithMany(cc => cc.OptionQuestions)
                .HasForeignKey(e => e.CategoryCatalog_Id)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(e => e.OptionResponse)
                .WithMany(or => or.OptionQuestions)
                .HasForeignKey(e => e.OptionResponse_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}