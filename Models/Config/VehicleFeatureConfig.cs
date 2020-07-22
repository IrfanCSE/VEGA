using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VEGA.Models.Config
{
    public class VehicleFeatureConfig : IEntityTypeConfiguration<VehicleFeature>
    {
        public void Configure(EntityTypeBuilder<VehicleFeature> builder)
        {
            builder.HasKey(x=>new{x.VehicleId,x.FeatureId});

            builder.HasOne(x=>x.Vehicle)
                .WithMany(x=>x.Features)
                .HasForeignKey(x=>x.VehicleId);

            builder.HasOne(x=>x.Feature)
                .WithMany(x=>x.VehicalFeatures)
                .HasForeignKey(x=>x.FeatureId);
        }
    }
}