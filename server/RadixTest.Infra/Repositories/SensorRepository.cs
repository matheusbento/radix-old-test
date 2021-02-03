using Microsoft.EntityFrameworkCore;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Interfaces;
using RadixTest.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadixTest.Infra.Repositories
{
    public class SensorRepository : RepositoryBase<Sensor>, ISensorRepository
    {
        public SensorRepository(RadixContext context) : base(context)
        {
            
        }

        public async Task<Sensor> GetSensorByNameAndRegionAndCountry(Sensor sensorMock)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == sensorMock.Name && x.Region == sensorMock.Region && x.Country == sensorMock.Country);
        }

        public async Task<List<Sensor>> GetWithEvents()
        {
            return await _dbSet.Include(x => x.Events).ToListAsync();
        }
    }
}
