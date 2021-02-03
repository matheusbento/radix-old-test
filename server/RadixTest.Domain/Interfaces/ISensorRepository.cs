using RadixTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadixTest.Domain.Interfaces
{
    public interface ISensorRepository : IRepository<Sensor>
    {
        Task<Sensor> GetSensorByNameAndRegionAndCountry(Sensor sensorMock);

        Task<List<Sensor>> GetWithEvents();
    }
}

