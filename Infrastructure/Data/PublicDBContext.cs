using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PublicDBContext : DbContext
    {
        public PublicDBContext(DbContextOptions<PublicDBContext> options) : base(options)
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SubQuestion> SubQuestions { get; set; }
        public DbSet<SumaryOption> SumaryOptions { get; set; }
        public DbSet<OptionResponse> OptionResponses { get; set; }
        public DbSet<CategoryCatalog> CategoryCatalogs { get; set; }
        public DbSet<CategoryOption> CategoryOptions { get; set; }
        public DbSet<OptionQuestion> OptionQuestions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
