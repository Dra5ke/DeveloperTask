using ChemicalsOverview.Models;
using Microsoft.EntityFrameworkCore;

namespace ChemicalsOverview.Controllers.Data
{
    public class ChemicalContext : DbContext
    {
        public ChemicalContext(DbContextOptions<ChemicalContext> options) : base(options)
        {

        }

        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<BackupSheet> BackupSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Chemical>().ToTable("Chemicals", "dbo");
            builder.Entity<BackupSheet>().ToTable("BackupSheets", "dbo");
        }
    }
}
