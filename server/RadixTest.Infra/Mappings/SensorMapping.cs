using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadixTest.Domain.Entities;

namespace RadixTest.Infra.Mappings
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(n => n.Name).IsRequired().HasMaxLength(60);
            builder.Property(n => n.Country).IsRequired().HasMaxLength(60);
            builder.Property(n => n.Region).IsRequired().HasMaxLength(60);

            builder.HasMany(x => x.Events).WithOne(y => y.Sensor).HasForeignKey(x => x.SensorId);
        }
    }
}
