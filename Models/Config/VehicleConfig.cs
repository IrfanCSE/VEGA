using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VEGA.Models.Config
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Model)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.ModelId);

            builder.OwnsOne(x => x.Contact, x =>
            {
                x.Property(x => x.Name)
                    .IsUnicode(false)
                    .HasMaxLength(250)
                    .IsRequired();

                x.Property(x => x.Phone)
                    .IsUnicode(false)
                    .HasMaxLength(25)
                    .IsRequired();
                
                x.Property(x => x.Email)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();

            });
        }
    }
}