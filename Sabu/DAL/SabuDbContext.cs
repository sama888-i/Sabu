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
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.HasIndex(x => x.Name)
                      .IsUnique();
                b.Property(x => x.Code)
                      .IsFixedLength(true)
                      .HasMaxLength(2);
                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(32);
                b.Property(x => x.Icon)
                    .HasMaxLength(800);
                b.HasData(new Language
                {
                    Code="az",
                    Name="Azərbaycan",
                    Icon= "https://banner2.cleanpng.com/20180614/ubx/kisspng-flag-of-azerbaijan-stock-photography-flag-of-azerbaijan-5b223219c10062.9993313215289677057906.jpg"


                });



            });
            modelBuilder.Entity<Word>(w =>
            {
                w.Property(w => w.Text)
                     .IsRequired()
                     .HasMaxLength(32);
                w.HasOne(x => x.Language)
                  .WithMany(x => x.Words)
                  .HasForeignKey(x => x.LanguageCode);
                w.HasMany(x => x.BannedWords)
                  .WithOne(x => x.Word)
                  .HasForeignKey(x => x.WordId);
               


            });
            modelBuilder.Entity<Game>(g =>
            {
                
                g.HasOne(x => x.Language)
                  .WithMany(x => x.Games)
                  .HasForeignKey(x => x.LanguageCode);
               

            });
            modelBuilder.Entity<BannedWord>(bw =>
            {

                bw.Property (x => x.Text)
                   .IsRequired()
                   .HasMaxLength(32);


            });


            base.OnModelCreating(modelBuilder);
        }
    }
}

