using Microsoft.EntityFrameworkCore;
using Sabu.Entities;

namespace Sabu.DAL
{
    public class SabuDbContext:DbContext
    {
        public SabuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord > BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SabuDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

