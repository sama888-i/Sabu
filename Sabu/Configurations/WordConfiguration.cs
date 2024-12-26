using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sabu.Entities;

namespace Sabu.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(w => w.Text)
                     .IsRequired()
                     .HasMaxLength(32);
            builder.HasOne(x => x.Language)
              .WithMany(x => x.Words)
              .HasForeignKey(x => x.LanguageCode);
            builder.HasMany(x => x.BannedWords)
              .WithOne(x => x.Word)
              .HasForeignKey(x => x.WordId);
        }
    }
}
