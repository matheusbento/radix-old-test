using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadixTest.Domain.Entities;

namespace RadixTest.Infra.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(n => n.Value).IsRequired();
            builder.Property(n => n.Timestamp).IsRequired();
        }
    }
}
