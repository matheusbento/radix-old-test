using Microsoft.EntityFrameworkCore;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Requests;
using RadixTest.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixTest.Infra.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RadixContext context) : base(context)
        {
        }

        public async Task<List<Event>> GetAllWithFilters(EventRequest eventRequest)
        {
            return await _dbSet.Where(x => eventRequest.Region.Contains(x.Sensor.Region) || eventRequest.Name.Contains(x.Sensor.Name)).ToListAsync();
        }

        public async Task<List<Event>> GetBySensor()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedAt).Include(x => x.Sensor).ToListAsync();
        }
    }
}
