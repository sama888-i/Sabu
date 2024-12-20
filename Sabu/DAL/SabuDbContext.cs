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

                
            base.OnModelCreating(modelBuilder);
        }
    }
}

