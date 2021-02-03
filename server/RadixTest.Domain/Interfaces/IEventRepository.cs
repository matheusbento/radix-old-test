using RadixTest.Domain.Entities;
using RadixTest.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadixTest.Domain.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetAllWithFilters(EventRequest eventRequest);

        Task<List<Event>> GetBySensor();
    }
}

