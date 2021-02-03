using System;

namespace RadixTest.Domain.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public void SetId(Guid id) => Id = id;
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
