using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("surveys");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");
                // .ValueGeneratedOnAdd();

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
            // Trigger para actualizar el campo updated_at automáticamente
            // DELIMITER $$
            // CREATE TRIGGER trg_update_survey_timestamp
            // BEFORE UPDATE ON surveys
            // FOR EACH ROW
            // BEGIN
            //     SET NEW.updated_at = CURRENT_TIMESTAMP;
            // END $$
            // DELIMITER ;

            builder.Property(e => e.Componenthtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(20);

            builder.Property(e => e.Componentreact)
                .HasColumnName("componentreact")
                .HasMaxLength(20);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(e => e.Instruction)
                .HasColumnName("instruction")
                .HasColumnType("text");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();
        }
    }
}