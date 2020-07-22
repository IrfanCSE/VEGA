using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VEGA.Models.Config
{
    public class ModelConfig : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}