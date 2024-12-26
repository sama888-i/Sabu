using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sabu.Entities;

namespace Sabu.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Name)
                  .IsUnique();
            builder.Property(x => x.Code)
                  .IsFixedLength(true)
                  .HasMaxLength(2);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.Icon)
                .HasMaxLength(800);
            builder.HasData(new Language
            { 
                Code = "az",
                Name = "Azərbaycan",
                Icon = "https://banner2.cleanpng.com/20180614/ubx/kisspng-flag-of-azerbaijan-stock-photography-flag-of-azerbaijan-5b223219c10062.9993313215289677057906.jpg"


            });

        }
    }
}
