using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sabu.Entities;

namespace Sabu.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
             builder.HasOne(x => x.Language)
                 .WithMany(x => x.Games)
                 .HasForeignKey(x => x.LanguageCode);

        }
    }
}
