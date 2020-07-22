using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VEGA.Models.Config
{
    public class MakeConfig : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.HasMany(x=>x.Model)
                .WithOne(x=>x.Make)
                .HasForeignKey(x=>x.MakeId);

        }
    }
}