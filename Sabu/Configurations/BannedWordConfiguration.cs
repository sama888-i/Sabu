using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sabu.Entities;

namespace Sabu.Configurations
{
    public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
    {
        public void Configure(EntityTypeBuilder<BannedWord> builder)
        {
            builder.Property(x => x.Text)
                   .IsRequired()
                   .HasMaxLength(32);
        }
    }
}
