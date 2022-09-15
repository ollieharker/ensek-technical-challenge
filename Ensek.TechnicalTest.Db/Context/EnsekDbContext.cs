using Ensek.TechnicalTest.Db.Models;
using Ensek.TechnicalTest.Db.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Ensek.TechnicalTest.Db.Context
{
    public class EnsekDbContext : DbContext
    {
        public EnsekDbContext()
                : base()
        {
        }

        public EnsekDbContext(DbContextOptions<EnsekDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(x => x.Id);

            AccountEntitySeeder.SeedData(modelBuilder);

            modelBuilder.Entity<MeterReading>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MeterReading>()
                .HasAlternateKey(x => new { x.AccountId, x.DateTime });

            modelBuilder.Entity<MeterReading>()
                .HasOne(x => x.Account);
        }

        public DbSet<MeterReading> MeterReadings { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
