using System;

namespace RadixTest.Domain.Base
{
    public interface IEntity
    {
        Guid Id { get; }
        void SetId(Guid id);
    }
}
