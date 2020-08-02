using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataFinding.SurveyModel
{
    public partial class SurveyDataContext : DbContext
    {
        public SurveyDataContext()
        {
        }

        public SurveyDataContext(DbContextOptions<SurveyDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailData> EmailData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailData>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.SentDate).HasDefaultValueSql("('1900-01-01')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
