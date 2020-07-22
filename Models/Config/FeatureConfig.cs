using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VEGA.Models.Config
{
    public class FeatureConfig : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Name)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}